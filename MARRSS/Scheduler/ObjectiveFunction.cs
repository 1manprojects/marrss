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

        private List<Satellite.Satellite> of_satellites;
        private List<Ground.Station> of_stations;

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

        public void CalculateObjectiveFitness(ContactWindowsVector currentSolution, int[] currentPopulation = null)
        {
            priorityCounter = new int[5] { 0, 0, 0, 0, 0, };
            overallContactDuration = 0.0;
            numberOfContacts = 0;
            numberOfContactsPerSatellite = new int[numberofSatellites];
            numberOfContactsPerStation = new int[numberOfGroundStations];
            ResteDownlinkCapacity();
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
                downloadedData += sat.getDataStorage().getMaxDownladedData();
            }
            //Set Values
            val_MaxData = (double)downloadedData / (double)createdData;
            val_Scheduled = numberOfContacts / (double)MAX_NumberOfContacts;
            val_Duration = overallContactDuration / MAX_Duration;
            val_Priority = CalculatePriorityValue() / MAX_Priority;
        }

        private void CalculateMaxDuration(ContactWindowsVector cons)
        {
            MAX_Duration = 0.0;
            foreach(var con in cons.getAllContacts())
            {
                MAX_Duration += con.getDuration();
            }
        }

        private void CalculateMAxPriority(ContactWindowsVector cons)
        {
            int[] priorityCounts = new int[5] { 0, 0, 0, 0, 0, };
            int res = 0;
            for (int i = 0; i < cons.Count(); i++)
            {
                int p = (int)cons.getAt(i).getPriority();
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

        private void ResteDownlinkCapacity()
        {
            foreach(var sat in satelliteList)
            {
                sat.ResetDataStorage();
            }
        }

        private void CountNumberOfContactsPerStation(ContactWindowsVector solution, int index)
        {
            var p = solution.getStationNames().IndexOf(solution.getAt(index).getStationName());
            if (p > -1)
            {
                numberOfContactsPerStation[p]++;
            }
        }

        private void CountNumberOfContactsPerSatelltie(ContactWindowsVector solution, int index)
        {
            var p = solution.getSatelliteNames().IndexOf(solution.getAt(index).getSatName());
            if (p > -1)
            {
                numberOfContactsPerSatellite[p]++;
            }
        }

        private void CountContactDuration(ContactWindowsVector solution, int index)
        {
            overallContactDuration += solution.getAt(index).getDuration();
        }

        private void CountNumberOfContacts()
        {
            numberOfContacts++;
        }

        private void CalculateDownlink(ContactWindowsVector solution, int index)
        {
            long packetSize = Convert.ToInt32(solution.getAt(index).getDuration()) * 5;
            if (GetSatelliteByName(solution.getAt(index).getSatName()) != null)
            {
                var sat = GetSatelliteByName(solution.getAt(index).getSatName());
                sat.RemoveDataPacket(new Satellite.DataPacket(packetSize, 4,
                    solution.getAt(index).getStartTime(), Convert.ToInt32(solution.getAt(index).getDuration()), Structs.DataSize.MBYTE));
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
            var p = (int)solution.getAt(index).getPriority();
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

        ///*
        // *########################################################################################
        // * ######################################################################################
        // * 
        // */
        ////! calculate the fitness value of the given contactvectors if a contact is added
        ///*!
        //   \param ContactWindowsVector contact windows to check
        //   \param CotnactWindowsVector contacts of the complete problem
        //   \param int max number of Contacts of the Scheduling problem
        //   \param ContactWindow to add
        //*/
        //// Call to calculate Objective Values for Fitness
        //public void calculateValues(ContactWindowsVector currentSolution, ContactWindowsVector completeContacts, int numberOfAllContacts,
        //    ContactWindow contactToAdd, List<Satellite.Satellite> satellites, List<Ground.Station> stations)
        //{
        //    of_satellites = satellites;
        //    of_stations = stations;
        //    currentSolution.add(contactToAdd);
        //    calculate(currentSolution, calcualteMaxPrioValue(completeContacts), numberOfAllContacts, null, completeContacts);
            
        //    currentSolution.deleteAt(currentSolution.Count() - 1);
        //}

        ////! calculate the fitness value of the given contact windows
        ///*!
        //   \param ContactWindowsVector
        //*/
        //public void calculateValues(ContactWindowsVector contactWindows, List<Satellite.Satellite> satellites, List<Ground.Station> stations)
        //{
        //    of_satellites = satellites;
        //    of_stations = stations;
        //    calculate(contactWindows, calcualteMaxPrioValue(contactWindows));
        //}

        ////! calculate the fitness value of the contact windows with population of the genetic scheduler
        ///*!
        //   \param ContactWindowsVector contact windows to check
        //   \param int[] population representation of the Genetic scheduler default NULL
        //*/
        //public void calculateValues(ContactWindowsVector contactWindows, int[] population, List<Satellite.Satellite> satellites, List<Ground.Station> stations)
        //{
        //    of_satellites = satellites;
        //    of_stations = stations;
        //    calculate(contactWindows, calcualteMaxPrioValue(contactWindows, population), contactWindows.Count(), population);
        //}

        ////! calculate the fitness value of ALL defined objetive values
        ///*!
        //   \param ContactWindowsVector contact windows to check
        //   \param int max number of Contacts of the Scheduling problem
        //   \param int[] population representation of the Genetic scheduler default NULL
        //*/
        //private void calculate(ContactWindowsVector contactWindows, int priorityValue,
        //                       int nrOfAllContacts = 0, int[] population = null, ContactWindowsVector allcontactWindows = null)
        //{
        //    //list of stations and Satellites
        //    List<string> stationList = contactWindows.getStationNames();
        //    List<string> satelliteList = contactWindows.getSatelliteNames();

        //    //number of times sation and satellite is scheduled
        //    int nrOfStation = contactWindows.getNumberOfStation();
        //    int nrOfSatellites = contactWindows.getNumberOfSatellites();

        //    //
        //    int[] nrOfContactsPerSatellite = new int[nrOfSatellites];
        //    int[] nrOfContactsPerStation = new int[nrOfStation];

        //    //number of Contacts Scheduled
        //    int nrOfScheduledContacts = 0;

        //    //Overall Scheduled Time
        //    double scheduledDuration = 0.0;
        //    //Complete Time of ALL contacts
        //    double allDuaration = 0.0;
        //    //Priority counts
        //    int priorityMax = priorityValue;
        //    int prio = calcualteMaxPrioValue(contactWindows);

        //    for (int i = 0; i < contactWindows.Count(); i++)
        //    {
        //        int stapo = -1;
        //        int satpo = -1;
        //        if (population != null)
        //        {
        //            if (population[i] == 1)
        //            {
        //                stapo = stationList.IndexOf(contactWindows.getAt(i).getStationName());
        //                satpo = satelliteList.IndexOf(contactWindows.getAt(i).getSatName());
        //                nrOfScheduledContacts++;
        //                scheduledDuration += contactWindows.getAt(i).getDuration();

        //                //download at 0.5MBps => 30MBpmin
        //                long test = Convert.ToInt32(contactWindows.getAt(i).getDuration()) * 5;
        //                if (getScheduledSatellite(contactWindows.getAt(i).getSatName()) != null)
        //                    getScheduledSatellite(contactWindows.getAt(i).getSatName()).RemoveDataPacket(
        //                        new Satellite.DataPacket(test, 4, contactWindows.getAt(i).getStartTime(), Convert.ToInt32(contactWindows.getAt(i).getDuration()), Structs.DataSize.MBYTE));

        //            }
        //        }
        //        else
        //        {
        //            if (nrOfAllContacts == 0)
        //            {
        //                if (contactWindows.getAt(i).getSheduledInfo())
        //                {
        //                    stapo = stationList.IndexOf(contactWindows.getAt(i).getStationName());
        //                    satpo = satelliteList.IndexOf(contactWindows.getAt(i).getSatName());
        //                    scheduledDuration += contactWindows.getAt(i).getDuration();
        //                    nrOfScheduledContacts++;

        //                    //download at 0.5MBps => 30MBpmin
        //                    long test = Convert.ToInt32(contactWindows.getAt(i).getDuration()) * 5;
        //                    if (getScheduledSatellite(contactWindows.getAt(i).getSatName()) != null)
        //                        getScheduledSatellite(contactWindows.getAt(i).getSatName()).RemoveDataPacket(
        //                            new Satellite.DataPacket(test, 4, contactWindows.getAt(i).getStartTime(), Convert.ToInt32(contactWindows.getAt(i).getDuration()), Structs.DataSize.MBYTE));

        //                }
        //            }
        //            else
        //            {
        //                stapo = stationList.IndexOf(contactWindows.getAt(i).getStationName());
        //                satpo = satelliteList.IndexOf(contactWindows.getAt(i).getSatName());
        //                scheduledDuration += contactWindows.getAt(i).getDuration();
        //                nrOfScheduledContacts++;

        //                //download at 0.5MBps => 30MBpmin
        //                long test = Convert.ToInt32(contactWindows.getAt(i).getDuration()) * 5;
        //                if (getScheduledSatellite(contactWindows.getAt(i).getSatName()) != null)
        //                    getScheduledSatellite(contactWindows.getAt(i).getSatName()).RemoveDataPacket(
        //                        new Satellite.DataPacket(test, 4, contactWindows.getAt(i).getStartTime(), Convert.ToInt32(contactWindows.getAt(i).getDuration()), Structs.DataSize.MBYTE));

        //            }
        //        }
        //        if (allcontactWindows == null)
        //            allDuaration += contactWindows.getAt(i).getDuration();

        //        if (stapo > -1)
        //        {
        //            nrOfContactsPerStation[stapo]++;
        //        }
        //        if (satpo > -1)
        //        {
        //            nrOfContactsPerSatellite[satpo]++;
        //        }
        //    }

        //    //calculate Fairness for Stations
        //    double a_station = 0.0;
        //    double b_station = 0.0;
        //    for (int i = 0; i < nrOfStation; i++)
        //    {
        //        a_station = a_station + nrOfContactsPerStation[i];
        //        b_station = b_station + Math.Pow(nrOfContactsPerStation[i], 2);
        //    }
        //    val_FairStations = Math.Pow(a_station, 2) / (nrOfStation * b_station);

        //    //calculate Fairnes for Satellites
        //    double a_satellites = 0.0;
        //    double b_satellites = 0.0;
        //    for (int i = 0; i < nrOfSatellites; i++)
        //    {
        //        a_satellites = a_satellites + nrOfContactsPerSatellite[i];
        //        b_satellites = b_satellites + Math.Pow(nrOfContactsPerSatellite[i], 2);
        //    }
        //    val_FairSatellites = Math.Pow(a_satellites, 2) / (nrOfSatellites * b_satellites);

        //    if (nrOfAllContacts == 0)
        //        nrOfAllContacts = contactWindows.Count();

        //    long createdData = 0;
        //    long downloadedData = 0;
        //    foreach(Satellite.Satellite sat in of_satellites)
        //    {
        //        createdData += sat.getDataStorage().getMaxGeneratedData();
        //        downloadedData += sat.getDataStorage().getMaxDownladedData();
        //    }
        //    val_MaxData = (double)downloadedData / (double)createdData;

        //    val_Scheduled = nrOfScheduledContacts / (double)nrOfAllContacts;

        //    val_Duration = scheduledDuration / allDuaration;

        //    val_Priority = (double)prio / (double)priorityMax;

        //}

        //private Satellite.Satellite GetSaelliteByName(string name)
        //{
        //    foreach(var sat in of_satellites)
        //    {
        //        if (sat.getName().Equals(name))
        //            return sat;
        //    }
        //    return null;
        //}

        //private int calcualteMaxPrioValue(ContactWindowsVector contacts, int[] population = null)
        //{
        //    int[] priorityCounts = new int[5] { 0, 0, 0, 0, 0, };
        //    int res = 0;
        //    for (int i = 0; i < contacts.Count(); i++)
        //    {
        //        int p = 0;
        //        if (population!= null)
        //        {
        //            if (population[i] == 1)
        //                p = (int)contacts.getAt(i).getPriority();
        //        }
        //        else
        //        { 
        //            p = (int)contacts.getAt(i).getPriority();
        //        }
        //        priorityCounts[p]++;
        //    }
        //    for (int i = 0; i < priorityCounts.Count(); i++)
        //    {
        //        res += priorityCounts[i] * (5 - i);
        //    }
        //    return res;
        //}

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

        //private Satellite.Satellite getScheduledSatellite(string name)
        //{
        //    for (int i = 0; i < of_satellites.Count(); i++)
        //    {
        //        if (of_satellites[i].getName() == name)
        //            return of_satellites[i];
        //    }
        //    return null;
        //}

        //! ToString method
        /*!
           \return string 
            returns the Objectives that were scheduled to
        */
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
