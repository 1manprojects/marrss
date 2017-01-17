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
using System.Collections.Generic;
using System.Linq;

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
    class EftGreedyScheduler : SchedulerInterface, SchedulerSolutionInterface
    {
        private ContactWindowsVector schedule; //!< ContactWindowsVector to add scheduled items
        private ContactWindowsVector set; //!< ContactWindowsVector to start with
        private Main f = null;

        //!GreedyScheduler constructor.
        /*!
            constructs a basic greedy scheduler
        */
        public EftGreedyScheduler()
        {
            schedule = new ContactWindowsVector();
        }

        //! get The Objective Funktion to solve the scheduling problem
        /*!
            \param SchedulingProblemInterface problem set to solve
            Not implementet since EFTGReedy does not use Objective Funktion
        */
        public void getObjectiveFunction(ScheduleProblemInterface problem)
        {
            //Do Nothing
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
            Greedy approach earliest job first.
        */
        public void CalculateSchedule(ScheduleProblemInterface problem)
        {
            set = problem.getContactWindows();
            ContactWindowsVector set1 = new ContactWindowsVector();
            ContactWindowsVector set2 = new ContactWindowsVector();

            List<string> staName = set.getStationNames();
            //while set is not empty do
            while (!isComplete())
            {
                //loop through all Stations
                for (int i = 0; i < staName.Count(); i++)
                {
                    int pos = -1;
                    double earliest = 9999.99;
                    int priority = 4;
                    //loop through all Contacts and find the item that finisches
                    //first and has the highest priority.
                    for(int k = 0; k < set.Count(); k++)
                    {
                        if( set.getAt(k).getStationName() == staName[i])
                        {
                            if (set.getAt(k).getStopTime().getEpoch() < earliest 
                                &&
                                (int)set.getAt(k).getPriority() <= priority)
                            {
                                pos = k;
                                earliest = set.getAt(k).getStopTime().getEpoch();
                                priority = (int)set.getAt(k).getPriority();
                            }
                        }
                    }
                    //update Progress Bar on Main Form
                    if (Properties.Settings.Default.global_MaxPerf == false)
                    {
                        System.Windows.Forms.Application.DoEvents();
                    }
                    if (f != null)
                    {
                        f.incrementProgressBar();
                    }
                    //the found earliest job is added to set1 if its empty
                    //or no other contact in set1 is conflicting with it
                    //if there is a conflict add this element to set2
                    //Then the element is deleted from set1 
                    if (pos > -1)
                    {
                        if (set1.isEmpty())
                        {
                            set1.add(set.getAt(pos));
                            set.deleteAt(pos);
                        }
                        else
                        {
                            bool found = false;
                            for (int k = 0; k < set1.Count(); k++)
                            {
                                if (set.getAt(pos).checkConflikt(set1.getAt(k)))
                                {
                                    if (set.getAt(pos).getSatName() == set1.getAt(k).getSatName() )
                                    {
                                        set2.add(set.getAt(pos));
                                        set.deleteAt(pos);
                                        found = true;
                                        break;
                                    }
                                }
                            }
                            if (!found)
                            {
                                set1.add(set.getAt(pos));
                                set.deleteAt(pos);
                            }
                        }
                    }
                }
            }

            for(int i = 0; i < set1.Count(); i++)
            {
                set1.getAt(i).setSheduled();
            }
            for (int i = 0; i < set2.Count(); i++ )
            {
                set2.getAt(i).unShedule();
            }
            set.add(set1);
            set.add(set2);
            schedule = set;
            solveConflictsByPriority();
            if (f != null)
            {
                f.resetProgressBar();
            }
        }

        //! Solve Conflicts by Priority
        /*!
            this function will go throuh all conflicting elements that have
            ben scheduled by the scheduler and will remove conflicting elements
            with lower priority (None - Critical -> 4 - 0)
        */
        public void solveConflictsByPriority()
        {
            if (schedule != null)
            {
                for (int i = 0; i < schedule.Count(); i++)
                {
                    for (int k = 0; k < schedule.Count(); k++)
                    {
                        int maxPriority = (int)schedule.getAt(i).getPriority();

                        if (schedule.getAt(i).getSheduledInfo() && k != i &&
                            schedule.getAt(k).getSheduledInfo() &&
                            schedule.getAt(k).getStationName() == schedule.getAt(i).getStationName() &&
                            schedule.getAt(i).checkConflikt(schedule.getAt(k)))
                        {
                            if ((int)schedule.getAt(k).getPriority() < maxPriority)
                            {
                                schedule.getAt(i).unShedule();
                                break;
                            }
                            else
                            {
                                schedule.getAt(k).unShedule();
                                break;
                            }
                        }
                    }
                }
            }
        }

        //! ToString method
        /*!
           \return string 
            returns the Name of the Schedule and used Settings as String
        */
        override public string ToString()
        {
            return "EFT-Greedy Scheduler";
        }
    }
}
