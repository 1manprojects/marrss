/**
* ----------------------------------------------------------------
* Nikolai Jonathan Reed 
*
* 
* Copyright (c) 2017, Nikolai Reed, 1manprojects.de
* All rights reserved.
*
* Licensed under
* Creative Commons Attribution NonCommercial (CC-BY-NC)
*/
using System;
using System.Collections.Generic;
using System.Linq;
using MARRSS.Global;

using MARRSS.Definition;
using MARRSS.Results;

namespace MARRSS.Scheduler
{
    /**
    * \brief Objective Function Class
    *
    * This class contains all the calculations of the objective function
    * to asssess the overall fitness of each solution. Changing requirements
    * for the scheduling algorithms can be defined here globaly for every 
    * algroithm using the objective function for calculations.
    */
    class ObjectiveFunction
    {
        private Structs.ObjectiveEnum[] objectives;
        private double val_Priority;
        private double val_FairStations;
        private double val_FairSatellites;
        private double val_Scheduled;
        private double val_Duration;
        private double val_MaxData;

        public ObjectiveFunction(params Structs.ObjectiveEnum[] objectivesToSchedule)
        {
            objectives = objectivesToSchedule;
            val_Priority = 0;
            val_FairSatellites = 0;
            val_FairStations = 0;
            val_Scheduled = 0;
            val_Duration = 0;
            val_MaxData = 0;
        }

        public ObjectiveFunction()
        {
            objectives = new Structs.ObjectiveEnum[]
                {Structs.ObjectiveEnum.PRIORITY,
                Structs.ObjectiveEnum.SCHEDULEDCONTACTS, Structs.ObjectiveEnum.DURATION,
                Structs.ObjectiveEnum.FAIRNESSATELITE, Structs.ObjectiveEnum.FAIRNESSTATION };
            val_Priority = 0;
            val_FairSatellites = 0;
            val_FairStations = 0;
            val_Scheduled = 0;
            val_Duration = 0;
            val_MaxData = 0;
        }

        public void setObjectives(params Structs.ObjectiveEnum[] objectivesToSchedule)
        {
            objectives = objectivesToSchedule;
            val_Priority = 0;
            val_FairSatellites = 0;
            val_FairStations = 0;
            val_Scheduled = 0;
            val_Duration = 0;
            val_MaxData = 0;
        }

        //private ContactWindowsVector problemContacts;
        private int[] numberOfContactsPerSatellite;
        private int[] numberOfContactsPerStation;
        private int[] priorityCounter;
        private int numberOfContacts;
        private double overallContactDuration;
        private List<Satellite.Satellite> satelliteList;
        private List<Ground.Station> stationList;
        private double MAX_Duration;
        private double MAX_Priority;
        private int MAX_NumberOfContacts;
        private int numberofSatellites;
        private int numberOfGroundStations;

        public void Initialize(ContactWindowsVector completeContactWindows,
            List<Satellite.Satellite> satellites, List<Ground.Station> stations)
        {
            MAX_NumberOfContacts = completeContactWindows.Count();
            CalculateMaxDuration(completeContactWindows);
            CalculateMAxPriority(completeContactWindows);
            numberofSatellites = completeContactWindows.getNumberOfSatellites();
            numberOfGroundStations = completeContactWindows.getNumberOfStation();
            stationList = stations;
            satelliteList = satellites;
        }

        public void CalculateObjectiveFitness(ContactWindowsVector currentSolution, bool reset = true, int[] currentPopulation = null)
        {
            priorityCounter = new int[5] { 0, 0, 0, 0, 0, };
            overallContactDuration = 0.0;
            numberOfContacts = 0;
            numberOfContactsPerSatellite = new int[numberofSatellites];
            numberOfContactsPerStation = new int[numberOfGroundStations];
            if (reset)
                ResetDownloadLinkCapacities();
            for (int i = 0; i < currentSolution.Count(); i++)
            {
                bool toScheduled = false;
                if (currentPopulation != null)
                {
                    if (currentPopulation[i] == 1)
                    {
                        toScheduled = true;
                    }
                }
                else
                {
                    //if (currentSolution.getAt(i).IsScheduled)
                        toScheduled = true;
                }

                if (toScheduled)
                {
                    CountContactDuration(currentSolution, i);
                    CountNumberOfContacts();
                    CountNumberOfContactsPerSatelltie(currentSolution, i);
                    CountNumberOfContactsPerStation(currentSolution, i);
                    CountPriorityContact(currentSolution, i);
                    CalculateDownlink(currentSolution, i);
                }
            }
            CalculateFitnessValues();
        }

        private void CalculateFitnessValues()
        {
            //calculate Fairness for Stations
            double a_station = 0.0;
            double b_station = 0.0;
            double contactDuration = 0.0;
            for (int i = 0; i < stationList.Count; i++)
            {
                a_station = a_station + numberOfContactsPerStation[i];
                b_station = b_station + Math.Pow(numberOfContactsPerStation[i], 2);
            }
            val_FairStations = Math.Pow(a_station, 2) / (stationList.Count * b_station);

            //calculate Fairnes for Satellites
            double a_satellites = 0.0;
            double b_satellites = 0.0;
            for (int i = 0; i < satelliteList.Count; i++)
            {               
                a_satellites = a_satellites + numberOfContactsPerSatellite[i];
                b_satellites = b_satellites + Math.Pow(numberOfContactsPerSatellite[i], 2);
            }
            val_FairSatellites = Math.Pow(a_satellites, 2) / (satelliteList.Count * b_satellites);

            //Calculate Downlink Values
            long createdData = 0;
            long downloadedData = 0;
            foreach (Satellite.Satellite sat in satelliteList)
            {
                createdData += sat.getDataStorage().getMaxGeneratedData();
                if (createdData >= 0)
                    downloadedData += sat.getDataStorage().getMaxDownladedData();
            }
            //Set Values
            val_MaxData = (double)downloadedData / (double)createdData;
            if (val_MaxData > 1.0)
                val_MaxData = 1.0;
            val_Scheduled = numberOfContacts / (double)MAX_NumberOfContacts;
            val_Duration = overallContactDuration / MAX_Duration;
            val_Priority = CalculatePriorityValue() / MAX_Priority;
        }

        private void CalculateMaxDuration(ContactWindowsVector cons)
        {
            MAX_Duration = 0.0;
            foreach(var con in cons.getAllContacts())
            {
                MAX_Duration += con.ContactDuration();
            }
        }

        private void CalculateMAxPriority(ContactWindowsVector cons)
        {
            int[] priorityCounts = new int[5] { 0, 0, 0, 0, 0, };
            int res = 0;
            for (int i = 0; i < cons.Count(); i++)
            {
                int p = (int)cons.getAt(i).Priority;
                priorityCounts[p]++;
            }
            for (int i = 0; i < priorityCounts.Count(); i++)
            {
                res += priorityCounts[i] * (5 - i);
            }
            MAX_Priority = (double)res;
        }

        private double CalculatePriorityValue()
        {
            var res = 0.0;
            for (int i = 0; i < priorityCounter.Count(); i++)
            {
                res += priorityCounter[i] * (5 - i);
            }
            return res;
        }

        private void ResetDownloadLinkCapacities()
        {
            foreach(var sat in satelliteList)
            {
                sat.ResetDataStorage();
            }
        }

        private void CountNumberOfContactsPerStation(ContactWindowsVector solution, int index)
        {
            var p = solution.StationsNames.IndexOf(solution.getAt(index).StationName);
            if (p > -1)
            {
                numberOfContactsPerStation[p]++;
            }
        }

        private void CountNumberOfContactsPerSatelltie(ContactWindowsVector solution, int index)
        {
            var p = solution.SatelliteNames.IndexOf(solution.getAt(index).SatelliteName);
            if (p > -1)
            {
                numberOfContactsPerSatellite[p]++;
            }
        }

        private void CountContactDuration(ContactWindowsVector solution, int index)
        {
            overallContactDuration += solution.getAt(index).ContactDuration();
        }

        private void CountNumberOfContacts()
        {
            numberOfContacts++;
        }

        private void CalculateDownlink(ContactWindowsVector solution, int index)
        {
            var station = GetStationByName(solution.getAt(index).StationName);
            long packetSize = Convert.ToInt32(solution.getAt(index).ContactDuration()) * (long)Math.Ceiling(station.getMaxDownLink());
            if (packetSize > 0)
            {
                if (GetSatelliteByName(solution.getAt(index).SatelliteName) != null)
                {
                    var sat = GetSatelliteByName(solution.getAt(index).SatelliteName);
                    sat.getDataStorage().DownloadDataFromStorage(new Satellite.DataPacket(packetSize, 4,
                        solution.getAt(index).StartTime, Convert.ToInt32(solution.getAt(index).ContactDuration())));
                }
            }
        }

        private double GetDownlinkCapacityForStation(string name)
        {
            for (int i = 0; i < stationList.Count(); i++)
            {
                if (stationList[i].getName() == name)
                    return stationList[i].getMaxDownLink();
            }
            return 0.0;
        }

        private void CountPriorityContact(ContactWindowsVector solution, int index)
        {
            var p = (int)solution.getAt(index).Priority;
            priorityCounter[p]++;
        }

        private Satellite.Satellite GetSatelliteByName(string name)
        {
            for (int i = 0; i < satelliteList.Count(); i++)
            {
                if (satelliteList[i].getName() == name)
                    return satelliteList[i];
            }
            return null;
        }

        private Ground.Station GetStationByName(string name)
        {
            for (int i = 0; i < stationList.Count(); i++)
            {
                if (stationList[i].getName() == name)
                    return stationList[i];
            }
            return null;
        }

        ////! get Objective results
        ///*!
        //   \return double 
        //    returns the fitness value of all objectives that were chosen
            
        //*/
        public double getObjectiveResults()
        {
            double fitness = 0.0;

            foreach (Structs.ObjectiveEnum obj in objectives)
            {
                switch (Convert.ToInt32(obj))
                {
                    case 1:
                        fitness += val_Priority;
                        break;
                    case 2:
                        fitness += val_FairSatellites;
                        break;
                    case 3:
                        fitness += val_FairStations;
                        break;
                    case 4:
                        fitness += val_Duration;
                        break;
                    case 5:
                        fitness += val_Scheduled;
                        break;
                    case 6:
                        fitness += val_MaxData;
                        break;
                    default:
                        //Do Nothing
                        //
                        break;
                }
            }

            fitness = fitness / Convert.ToDouble(objectives.Count());
            return fitness;
        }

        public override string ToString()
        {
            string res = "Objectives Scheduled To:";
            foreach (Structs.ObjectiveEnum obj in objectives)
            {
                res = res + " - " + obj.ToString();
            }
            return res;
        }

        //! get DataDownload Value value
        /*!
           \return double scheduled downloaded data divided by all generatad data
        */
        public double getDataDownValue()
        {
            return val_MaxData;
        }

        //! get Duration Value value
        /*!
           \return double scheduled duration divided by all contact windows duration
        */
        public double getDurationValue()
        {
            return val_Duration;
        }
        //! get Satellite Fairness value
        /*!
-            \return double fairness of used satellites value of 1.0 means every
-            satellite is used as often as every other one
        */
        public double getSatelliteFairnessValue()
        {
            return val_FairSatellites;
        }
        //! get Station Fairness value
        /*!
           \return double fairness of used station value of 1.0 means every
-            station is used as often as every other one
        */
        public double getStationFairnessValue()
        {
            return val_FairStations;
        }
        //! get Scheduled Contacts value
        /*!
           \return double number of scheduled contacts divided by all contacts
        */
        public double getScheduledContactsValue()
        {
            return val_Scheduled;
        }
        //! get Priority Value NOT IMPLEMENTED CURRENTLY
        /*!
           \return double value to indicate the used priority of scheduled contacts
        */
        public double getPriorityValue()
        {
            return val_Priority;
        }

    }
}
