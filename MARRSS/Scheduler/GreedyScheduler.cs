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

using MARRSS.Interface2;
using MARRSS.Definition;

namespace MARRSS.Scheduler
{
    /**
    * \brief Greedy Scheduler
    *
    * This class defines the greedy scheduler to find a solution to the problem.
    * This is done by selecting the job that is finisched earliest for each
    * groundstation until all contacts have been scheduled.
    */
    class GreedyScheduler : SchedulerInterface, SchedulerSolutionInterface
    {
        private ContactWindowsVector schedule; //!< ContactWindowsVector to add scheduled items
        private ContactWindowsVector set; //!< ContactWindowsVector to start with
        private Main f = null;

        private bool cancel = false;

        private ObjectiveFunction objective = null;

        //logging
        private int generateLog = 0;
        private int generatePlotData = 0;
        private string plotPath = "";
        private System.IO.StreamWriter plotWr;

        //!GreedyScheduler constructor.
        /*!
            constructs a basic greedy scheduler
        */
        public GreedyScheduler()
        {
            generateLog = Properties.Settings.Default.global_SaveLogs_Path;
            generatePlotData = Properties.Settings.Default.PlotData;
            plotPath = Properties.Settings.Default.global_Save_Path;
            if (generatePlotData > 0)
            {
                //create File to write in to
                string plotname = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString()
                    + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Hour.ToString()
                    + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                plotname = plotname + "-FairGreedy";
                plotWr = new System.IO.StreamWriter(plotPath + "\\" + plotname, true);
            }
            schedule = new ContactWindowsVector();
        }
        //! get The Objective Funktion to solve the scheduling problem
        /*!
            \param ObjectiveFunction problem set to solve
        */
        public void setObjectiveFunktion(ObjectiveFunction objectiveFunction)
        {
            objective = objectiveFunction;
        }
        //! returns The Objective Funktion to solve the scheduling problem
        /*!
            \rreturn ObjectiveFunction problem set to solve
        */
        public ObjectiveFunction getObjectiveFunction()
        {
            return objective;
        }

        //! returns the finisched Schedule
        /*!
            \return ContactWindowsVector solution
        */
        public ContactWindowsVector getFinischedSchedule()
        {
            return schedule;
        }

        //! Checks if a solution has been found
        /*!
            \return bool true if complete
        */
        public bool isComplete()
        {
            if (cancel)
                return true;
            if (set.isEmpty())
                return true;
            else
                return false;
        }

        //! set the main Form wich should be updated
        /*!
            \Main form
            sets the Form wich holds the elements that display progress bar etc.
        */
        public void setFormToUpdate(Main form)
        {
            f = form;
        }

        //! Calculates a schedule from the defined problem
        /*!
            \pram ScheduleProblemInterface defined problem with contactwindows
            Greedy approach based on Objective Fairness function
        */
        public void CalculateSchedule(ScheduleProblemInterface problem)
        {
            objective = problem.getObjectiveFunction();
            objective.Initialize(problem.getContactWindows(), problem.getSatellites(), problem.getGroundStations());
            set = problem.getContactWindows();
            int nrOfAllContacts = set.Count();

            ContactWindowsVector set1 = new ContactWindowsVector();
            ContactWindowsVector set2 = new ContactWindowsVector();

            if (f != null)
            {
                f.setProgressBar(set.Count());
            }

            set1.add(set.getAt(0));
            set.deleteAt(0);

            while (!isComplete())
            {
                int pos = -1;
                double maxFitness = 0.0;
                ContactWindow toAdd = null; ;
                bool betterfound = false;
                for (int i = 0; i < set.Count(); i++)
                {
                    for (int j = 0; j < set1.Count(); j++)
                    {
                        bool collision = false;
                        if (set.getAt(i).checkConflikt(set1.getAt(j)))
                        {
                            if (set.getAt(i).SatelliteName == set1.getAt(j).SatelliteName
                                || set.getAt(i).StationName == set1.getAt(j).StationName)
                            {
                                collision = true;
                                set2.add(set.getAt(i));
                                set.deleteAt(i);
                                i--;
                                break;
                            }
                        }
                        if (!collision)
                        {
                            set1.add(set.getAt(i));
                            objective.CalculateObjectiveFitness(set1);
                            double fitness = objective.getObjectiveResults();
                            if (fitness > maxFitness)
                            {
                                maxFitness = fitness;
                                pos = i;
                                set1.deleteAt(set1.Count() - 1);
                                betterfound = true;
                                break;
                            }
                            set1.deleteAt(set1.Count() - 1);
                        }
                    }
                    if (betterfound)
                        break;
                }
                if (pos >= 0)
                {
                    set1.add(set.getAt(pos));
                    set1.getLast().setSheduled();
                    set.deleteAt(pos);
                }

                if (f != null)
                    f.updateProgressBar(set1.Count() + set2.Count());
                if (Properties.Settings.Default.global_MaxPerf == false)
                    System.Windows.Forms.Application.DoEvents();
            }
            set.add(set1);
            set.add(set2);
            if (f != null)
                f.updateProgressBar(set1.Count() + set2.Count());
            if (Properties.Settings.Default.global_MaxPerf == false)
                System.Windows.Forms.Application.DoEvents();
            schedule = set;

        }


        //! Calculate scheduling solution from certain startpoint
        /*!
            calculate a schedule from a certain starting point
            if iterating trhough every contact window can be used to brute force
            the scheduling solution
            \param ScheduleProblemInterface to solve scheduling problem
            \param int point from which to start from
        */
        public void BruteForceSchedule(ScheduleProblemInterface problem, int step)
        {
            throw new NotImplementedException();
        }

        public void cancelCalculation()
        {
            cancel = true;
        }

        //! ToString method
        /*!
           \return string 
            returns the Name of the Schedule and used Settings as String
        */
        override public string ToString()
        {
            return "Fair-Greedy Scheduler";
        }
    }
}
