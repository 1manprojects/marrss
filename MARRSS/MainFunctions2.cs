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
using System.Threading.Tasks;

using MARRSS.Definition;
using MARRSS.Ground;
using One_Sgp4;

namespace MARRSS
{
    class MainFunctions2
    {
        //! Calculate Contact windows
        /*! 
         /param List<TLE> list of Tle data
         /param List<Statons> list of Stations
         /param EpochTime starting time
         /param Epoch Time stoping time
         /param string Logfile = null 
         /param Main mainform to update = null
         * cacluated the orbits of selected satellites and then the contact windows
         * for each station in the given time frame
        */
        public static ContactWindowsVector calculateContactWindows(List<Tle> tleData,
            List<Station> stations, EpochTime start, EpochTime stop, string logfile = null,
            Main mainform = null)
        {
            ContactWindowsVector contacts = new ContactWindowsVector();
            double accuracy = Properties.Settings.Default.orbit_Calculation_Accuracy;
            
            //Calculate Orbits of the selected Satellites

            Sgp4[] tasks = new Sgp4[tleData.Count()];
            Task[] threads = new Task[tleData.Count()];
            for (int i = 0; i < tleData.Count(); i++)
            {
                tasks[i] = new One_Sgp4.Sgp4(tleData[i], Properties.Settings.Default.orbit_Wgs);
                tasks[i].setStart(start, stop, accuracy / 60.0);
                threads[i] = new Task(tasks[i].starThread);
            }
            for (int i = 0; i < threads.Count(); i++)
            {
                //start each Thread
                threads[i].Start();
            }
            try
            {
                //wait till all threads are finished
                Task.WaitAll(threads);
            }
            catch (AggregateException ae)
            {
                //Logg any exceptions thrown
                if (logfile != null)
                    MainFunctions.updateLog(logfile, "Orbit Predictions Exception: " + ae.InnerExceptions[0].Message, mainform);
            }

            //Calculate Contact Windows
            if (logfile != null)
                MainFunctions.updateLog(logfile, "Starting Contact Window Calculation:", mainform);
            for (int i = 0; i < tleData.Count(); i++)
            {
                Ground.InView[] inViews = new Ground.InView[stations.Count()];
                Task[] inThreads = new Task[stations.Count()];
                for (int k = 0; k < stations.Count(); k++)
                {
                    inViews[k] = new Ground.InView(stations[k], start, tasks[i].getRestults(), tleData[i].getName(), accuracy);
                    inThreads[k] = new Task(inViews[k].calcContactWindows);
                }
                for (int k = 0; k < stations.Count(); k++)
                {
                    //start every thread
                    inThreads[k].Start();
                }
                try
                {
                    //whait for all threads to finish
                    Task.WaitAll(inThreads);
                }
                catch (AggregateException ae)
                {
                    if (logfile != null)
                        MainFunctions.updateLog(logfile, "Contact Windows Calculation Exception: " + ae.InnerExceptions[0].Message, mainform);
                }
                for (int k = 0; k < stations.Count(); k++)
                {
                    contacts.add(inViews[k].getResults());
                }
            }
            contacts.StartTime = start;
            contacts.EndTime = stop;
            return contacts;
        }

    }
}
