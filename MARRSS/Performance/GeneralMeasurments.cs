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

using MARRSS.Scheduler;
using MARRSS.Definition;
using MARRSS.Interface1;
using MARRSS.Global;

namespace MARRSS.Performance
{
    /**
* \brief General Measurement Class
*
* This class calculates values to compare diffrent results to each other
*/
    class GeneralMeasurments
    {

        //! Calculate Fairness of used ground stations of schedule
        /*!
            \param ContactWindowVector schedule to calculate fairness
            \return double fairness of used stations value of 1.0 means every
            station is used as often as every other one
        */
        public static double getFairnesStations(ContactWindowsVector contacts)
        {
            double fairness = 0.0;
            List<string> stationList = contacts.getStationNames();

            int[] nrOfContactsPerSa = new int[contacts.getNumberOfStation()];
            for (int i = 0; i < contacts.Count(); i++)
            {
                if (contacts.getAt(i).getSheduledInfo())
                {
                    int satpo = stationList.IndexOf(contacts.getAt(i).getStationName());
                    if (satpo > -1)
                    {
                        nrOfContactsPerSa[satpo]++;
                    }
                }
            }
            double a = 0.0;
            double b = 0.0;
            for (int i = 0; i < contacts.getNumberOfStation(); i++)
            {
                a = a + nrOfContactsPerSa[i];
                b = b + Math.Pow(nrOfContactsPerSa[i], 2);
            }
            fairness = Math.Pow(a, 2) / (contacts.getNumberOfStation() * b);
            return fairness;
        }

        //! Calculate Fairness of scheduled satellites
        /*!
            \param ContactWindowVector schedule to calculate fairness
            \return double fairness of used satellites value of 1.0 means every
            satellite is used as often as every other one
        */
        public static double getFairnesSatellites(ContactWindowsVector contacts)
        {
            double fairness = 0.0;
            List<string> satelliteList = contacts.getSatelliteNames();

            int[] nrOfContactsPerSa = new int[contacts.getNumberOfSatellites()];
            for (int i = 0; i < contacts.Count(); i++)
            {
                if (contacts.getAt(i).getSheduledInfo())
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
            for (int i = 0; i < contacts.getNumberOfSatellites(); i++)
            {
                a = a + nrOfContactsPerSa[i];
                b = b + Math.Pow(nrOfContactsPerSa[i], 2);
            }
            fairness = Math.Pow(a, 2) / (contacts.getNumberOfSatellites() * b);
            return fairness;
        }

        //! returns the number of scheduled contacts
        /*!
            \param ContactWindowVector schedule to calculate fairness
            \return int number of scheduled contacts
        */
        public static int getNrOfScheduled(ContactWindowsVector contacts)
        {
            int nrOfScheduled = 0;
            for (int i = 0; i < contacts.Count(); i++ )
            {
                if (contacts.getAt(i).getSheduledInfo())
                {
                    nrOfScheduled++;
                }
            }
                return nrOfScheduled;
        }

        //! Calculate number of Conflicts in the schedule
        /*!
            \param ContactWindowVector schedule to calculate fairness
            \return int number of overall conflicting contact windows
        */
        public static int getNrOfConflicts(ContactWindowsVector contacts)
        {
            int nrOfConflicts = 0;
            HashSet<Guid> hashConflict = new HashSet<Guid>();

            for (int i = 0; i < contacts.Count(); i++)
                {
                    for (int k = 0; k < contacts.Count(); k++)
                    {
                        if (i != k && contacts.getAt(i).getSheduledInfo() &&
                            contacts.getAt(k).getSheduledInfo() &&
                            contacts.getAt(i).checkConflikt(contacts.getAt(k)))
                        {
                            if (contacts.getAt(k).getSatName() == contacts.getAt(i).getSatName()
                                || contacts.getAt(k).getStationName() == contacts.getAt(i).getStationName())
                            {
                                if (!hashConflict.Contains(contacts.getAt(k).getID()))
                                {
                                    nrOfConflicts++;
                                    hashConflict.Add(contacts.getAt(i).getID());
                                }
                            }
                        }
                    }
                }
            hashConflict.Clear();
            return nrOfConflicts;
        }

        //Test Function
        public static string getNrOfUweContacts(ContactWindowsVector contacts)
        {
            int count = 0;
            for (int i = 0; i < contacts.Count(); i++)
            {
                if (contacts.getAt(i).getSheduledInfo()
                    && contacts.getAt(i).getSatName() == "UWE-3")
                {
                    count++;
                }
            }
            return "UWE-3: " + count;
        }

        //! returns the number of contacts for each priority
        /*!
            \param ContactWindowVector schedule to calculate fairness
            \return string containing number of contacts schedule for each priorty
        */
        public static string getNrOfPrioritysScheduled(ContactWindowsVector contacts)
        {
            int p0 = 0;
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int sp0 = 0;
            int sp1 = 0;
            int sp2 = 0;
            int sp3 = 0;
            int sp4 = 0;
            for (int i = 0; i < contacts.Count(); i++)
            {
                int p = (int)contacts.getAt(i).getPriority();
                switch (p)
                {
                    case 0:
                        p0++;
                        break;
                    case 1:
                        p1++;
                        break;
                    case 2:
                        p2++;
                        break;
                    case 3:
                        p3++;
                        break;
                    case 4:
                        p4++;
                        break;
                }
                if (contacts.getAt(i).getSheduledInfo())
                {
                    switch (p)
                    {
                        case 0:
                            sp0++;
                            break;
                        case 1:
                            sp1++;
                            break;
                        case 2:
                            sp2++;
                            break;
                        case 3:
                            sp3++;
                            break;
                        case 4:
                            sp4++;
                            break;
                    }
                }
                
            }
            return sp0 + "/" + p0 + " - " + sp1 + "/" + p1 + " - " + sp2 + "/" + p2 + " - " + sp3 + "/" + p3 + " - " + sp4 + "/" + p4;
        }
    }
}
