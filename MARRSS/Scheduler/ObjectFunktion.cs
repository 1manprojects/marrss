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
using System.Text;
using System.Threading.Tasks;

using MARRSS.Definition;
using MARRSS.Global;

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
    class ObjectFunktion
    {

        public enum Objective
        {
            PRIORITY = 0x0,
            FAIRNESS = 0x1,
        };

        //! calculat fitness value for the Greedy Algorithm
        /*!
            \param ContactWindowsVector current Schedule
            \param ContactWindow contact to add to schedule
            \return double fitness value of schedule if the contact is added
        */
        public static double ObjectiveFunction(ContactWindowsVector contactWindows,
            ContactWindow contactToCheck, int NrOfAllContacts)
        {
            contactWindows.add(contactToCheck);
            double result = 0.0;
            double fairSat = calcSatelliteFairnes(contactWindows);
            double fairSta = calcStationFairnes(contactWindows);
            double nrOfShe = calcScheduled(contactWindows, NrOfAllContacts);
            contactWindows.deleteAt(contactWindows.Count() - 1);

            result = (1.0 / 3.0) * (fairSat + fairSta + nrOfShe);
            return result;
        }

        //! calculat fitness value for the Genetic Algorithm
        /*!
            \param ContactWindowsVector current Schedule
            \param int[] population array of the genetic
            \return double fitness value of the schedule
        */
        public static double ObjectiveFunction(ContactWindowsVector contactWindows,
            int[] population)
        {
            ContactWindowsVector toCheck = new ContactWindowsVector();
            double result = 0.0;
            double fairSat = calcSatelliteFairnes(contactWindows, population);
            double fairSta = calcStationFairnes(contactWindows, population);
            double nrOfShe = calcScheduled(contactWindows, population);

            result = (1.0 / 3.0) * (fairSat + fairSta + nrOfShe);
            return result;
        }

        //! get value of scheduled contacts over all contacts (Greedy)
        /*!
            \param ContactWindowsVector current Schedule
            \param int number of all contacts
            \return double fitness
        */
        private static double calcScheduled(ContactWindowsVector contacts,
            int nrOfAllContacts, ContactWindow contact = null)
        {
            int scheduled = contacts.Count();
            if (contact != null)
                scheduled++;
            double result = (double)scheduled / (double)nrOfAllContacts;
            return result;
        }

        //! get value of scheduled contacts over all contacts (Genetic)
        /*!
            \param ContactWindowsVector current Schedule
            \param int gentic population
            \return double fitness
        */
        private static double calcScheduled(ContactWindowsVector contacts,
            int[] population)
        {
            int nrOfScheduled = 0;
            for (int i = 0; i < population.Count(); i++)
            {
                if (population[i] == 1)
                {
                    nrOfScheduled++;
                }
            }
            double result = (double)nrOfScheduled / (double)population.Count();
            return result;
        }

        //! get value of satellite fairness
        /*!
            \param ContactWindowsVector current Schedule
            \param genetic population = null
            \return double fitness
        */
        private static double calcSatelliteFairnes(ContactWindowsVector contacts,
            int[] population = null)
        {
            int nrOfSatellites = contacts.getNumberOfSatellites();
            List<string> satelliteList = contacts.getSatelliteNames();
            int[] nrOfContactsPerSa = new int[nrOfSatellites];
            for (int i = 0; i < contacts.Count(); i++)
            {
                if (population != null)
                {
                    if (population[i] == 1)
                    {
                        int satpo = satelliteList.IndexOf(contacts.getAt(i).getSatName());
                        if (satpo > -1)
                        {
                            nrOfContactsPerSa[satpo]++;
                        }
                    }
                }
                else
                {
                    int satpo = satelliteList.IndexOf(contacts.getAt(i).getSatName());
                    if (satpo > -1)
                    {
                        nrOfContactsPerSa[satpo]++;
                    }
                }
            }
            double a = 0.0;
            double b = 0.0;
            for (int i = 0; i < nrOfSatellites; i++)
            {
                a = a + nrOfContactsPerSa[i];
                b = b + Math.Pow(nrOfContactsPerSa[i], 2);
            }
            double fairness = Math.Pow(a, 2) / (nrOfSatellites * b);
            return fairness;
        }

        //! get value of station fairness
        /*!
            \param ContactWindowsVector current Schedule
            \param genetic population = null
            \return double fitness
        */
        private static double calcStationFairnes(ContactWindowsVector contacts,
            int[] population = null)
        {
            List<string> stationList = contacts.getStationNames();
            int nrOfStation = contacts.getNumberOfStation();
            int[] nrOfContactsPerSt = new int[nrOfStation];
            for (int i = 0; i < contacts.Count(); i++)
            {
                if (population != null)
                {
                    if (population[i] == 1)
                    {
                        int stapo = stationList.IndexOf(contacts.getAt(i).getStationName());
                        if (stapo > -1)
                        {
                            nrOfContactsPerSt[stapo]++;
                        }
                    }
                }
                else
                {
                    int stapo = stationList.IndexOf(contacts.getAt(i).getStationName());
                    if (stapo > -1)
                    {
                        nrOfContactsPerSt[stapo]++;
                    }
                }
            }
            double a = 0.0;
            double b = 0.0;
            for (int i = 0; i < nrOfStation; i++)
            {
                a = a + nrOfContactsPerSt[i];
                b = b + Math.Pow(nrOfContactsPerSt[i], 2);
            }
            double fairness = Math.Pow(a, 2) / (nrOfStation * b);
            return fairness;
        }

    }
}
