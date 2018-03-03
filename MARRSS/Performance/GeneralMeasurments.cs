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

        public static double getDurationOfScheduledContacts(ContactWindowsVector contacts)
        {
            double duration = 0.0;
            for (int i = 0; i < contacts.Count(); i++)
            {
                if (contacts.getAt(i).getSheduledInfo())
                {
                    duration += contacts.getAt(i).getDuration();
                }
            }
            return duration;
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

        public static List<string> calculateDataStoragePerformance(List<Satellite.Satellite> sats)
        {
            List<string> results = new List<string>();
            foreach (var sat in sats)
            {
                string satResult = string.Format("{0}: Created / Downloaded Data {1}/{2}", sat.getName(), sat.getDataStorage().getMaxGeneratedData(),sat.getDataStorage().getMaxDownladedData());
                results.Add(satResult);
            }
            return results;
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

        public string AnalizeStorageOfSat(Satellite.Satellite sat)
        {
            return "";
        }

    }
}
