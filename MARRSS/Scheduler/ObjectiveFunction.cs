/**
* ----------------------------------------------------------------
* Nikolai Jonathan Reed 
*
* 
* Copyright (c) 2015, Nikolai Reed, 1manprojects.de
* All rights reserved.
*
* Licensed under
* Creative Commons Attribution NonCommercial (CC-BY-NC)
*/
using System;
using System.Collections.Generic;
using System.Linq;

using MARRSS.Definition;
using MARRSS.Scheduler;

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

        public enum ObjectiveEnum:int
        {
            PRIORITY = 0,
            //FAIRNES = 1,
            FAIRNESSATELITE = 2,
            FAIRNESSTATION = 3,
            DURATION = 4,
            SCHEDULEDCONTACTS = 5
        };

        private ObjectiveEnum[] objectives;
        private double val_Priority;
        private double val_FairStations;
        private double val_FairSatellites;
        private double val_Scheduled;
        private double val_Duration;

        public ObjectiveFunction(params ObjectiveEnum[] objectivesToSchedule)
        {
            objectives = objectivesToSchedule;
            val_Priority = 0;
            val_FairSatellites = 0;
            val_FairStations = 0;
            val_Scheduled = 0;
            val_Duration = 0;
        }

        public void setObjectives(params ObjectiveEnum[] objectivesToSchedule)
        {
            objectives = objectivesToSchedule;
            val_Priority = 0;
            val_FairSatellites = 0;
            val_FairStations = 0;
            val_Scheduled = 0;
            val_Duration = 0;
        }

        // Call to calculate Objective Values for Fitness
        public void calculateValues(ContactWindowsVector contactWindows, int numberOfAllContacts,
            ContactWindow contactToAdd)
        {
            contactWindows.add(contactToAdd);
            calculate(contactWindows, numberOfAllContacts);
            contactWindows.deleteAt(contactWindows.Count() - 1);
        }

        public void calculateValues(ContactWindowsVector contactWindows)
        {
            calculate(contactWindows);
        }

        public void calculateValues(ContactWindowsVector contactWindows, int[] population)
        {
            calculate(contactWindows, contactWindows.Count(), population);
        }

        //! calculate the fitness value of ALL defined objetive values
        /*!
           \param ContactWindowsVector contact windows to check
           \param int max number of Contacts of the Scheduling problem
           \param int[] population representation of the Genetic scheduler default NULL
        */
        private void calculate(ContactWindowsVector contactWindows, int nrOfAllContacts = 0, int[] population = null)
        {
            //list of stations and Satellites
            List<string> stationList = contactWindows.getStationNames();
            List<string> satelliteList = contactWindows.getSatelliteNames();

            //number of times sation and satellite is scheduled
            int nrOfStation = contactWindows.getNumberOfStation();
            int nrOfSatellites = contactWindows.getNumberOfSatellites();

            //
            int[] nrOfContactsPerSatellite = new int[nrOfSatellites];
            int[] nrOfContactsPerStation = new int[nrOfStation];

            //number of Contacts Scheduled
            int nrOfScheduledContacts = 0;

            //Overall Scheduled Time
            double scheduledDuration = 0.0;
            //Complete Time of ALL contacts
            double allDuaration = 0.0;

            for (int i = 0; i < contactWindows.Count(); i++)
            {
                int stapo = -1;
                int satpo = -1;
                if (population != null)
                {
                    if (population[i] == 1)
                    {
                        stapo = stationList.IndexOf(contactWindows.getAt(i).getStationName());
                        satpo = satelliteList.IndexOf(contactWindows.getAt(i).getSatName());
                        nrOfScheduledContacts++;
                        scheduledDuration += contactWindows.getAt(i).getDuration();
                    }
                }
                else
                {
                    if (nrOfAllContacts == 0)
                    {
                        if (contactWindows.getAt(i).getSheduledInfo())
                        {
                            stapo = stationList.IndexOf(contactWindows.getAt(i).getStationName());
                            satpo = satelliteList.IndexOf(contactWindows.getAt(i).getSatName());
                            scheduledDuration += contactWindows.getAt(i).getDuration();
                            nrOfScheduledContacts++;
                        }
                    }
                    else
                    {
                        stapo = stationList.IndexOf(contactWindows.getAt(i).getStationName());
                        satpo = satelliteList.IndexOf(contactWindows.getAt(i).getSatName());
                        scheduledDuration += contactWindows.getAt(i).getDuration();
                        nrOfScheduledContacts++;
                    }
                }
                allDuaration += contactWindows.getAt(i).getDuration();

                if (stapo > -1)
                {
                    nrOfContactsPerStation[stapo]++;
                }
                if (satpo > -1)
                {
                    nrOfContactsPerSatellite[satpo]++;
                }
            }

            //calculate Fairness for Stations
            double a_station = 0.0;
            double b_station = 0.0;
            for (int i = 0; i < nrOfStation; i++)
            {
                a_station = a_station + nrOfContactsPerStation[i];
                b_station = b_station + Math.Pow(nrOfContactsPerStation[i], 2);
            }
            val_FairStations = Math.Pow(a_station, 2) / (nrOfStation * b_station);

            //calculate Fairnes for Satellites
            double a_satellites = 0.0;
            double b_satellites = 0.0;
            for (int i = 0; i < nrOfSatellites; i++)
            {
                a_satellites = a_satellites + nrOfContactsPerSatellite[i];
                b_satellites = b_satellites + Math.Pow(nrOfContactsPerSatellite[i], 2);
            }
            val_FairSatellites = Math.Pow(a_satellites, 2) / (nrOfSatellites * b_satellites);

            if (nrOfAllContacts == 0)
                nrOfAllContacts = contactWindows.Count();

            val_Scheduled = nrOfScheduledContacts / (double)nrOfAllContacts;

            val_Duration = scheduledDuration / allDuaration;

        }

        //! get Objective results
        /*!
           \return double 
            returns the fitness value of all objectives that were chosen
            
        */
        public double getObjectiveResults()
        {
            double fitness = 0.0;

            foreach (ObjectiveEnum obj in objectives)
            {
                switch (Convert.ToInt32(obj))
                {
                    case 0:
                        break;
                    case 1:
                        //not implemented
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
                    default:
                        //Do Nothing
                        break;
                }
            }

            fitness = fitness / Convert.ToDouble(objectives.Count());
            return fitness;
        }

        //! ToString method
        /*!
           \return string 
            returns the Objectives that were scheduled to
        */
        public override string ToString()
        {
            string res = "Objectives Scheduled To:";
            foreach (ObjectiveEnum obj in objectives)
            {
                res = res + " - " + obj.ToString();
            }
            return res;
        }

        public double getDurationValue()
        {
            return val_Duration;
        }

        public double getSatelliteFairnessValue()
        {
            return val_FairSatellites;
        }

        public double getStationFairnessValue()
        {
            return val_FairStations;
        }

        public double getScheduledContactsValue()
        {
            return val_Scheduled;
        }

        public double getPriorityValue()
        {
            return val_Priority;
        }

    }
}
