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
using MARRSS.Interface2;
using MARRSS.Definition;

namespace MARRSS.Scheduler
{
    class HillClimberScheduler : SchedulerInterface, SchedulerSolutionInterface
    {

        private ObjectiveFunction objective;
        private ContactWindowsVector result;
        private bool cancel = false;
        private double currentFitness = 0.0;
        private double oldFitness = 0.0;

        private Main mainform = null;

        private int iterations = 0;
        private int maxNumberOfIteration = 1000;
        bool adaptiveMaxIterations = false;

        bool randomStart = false;


        public HillClimberScheduler()
        {

        }

        public HillClimberScheduler(bool randomizeOnStart, bool useAdaptiveMaxIterations = false, int setMaxIterations = 1000)
        {
            randomStart = randomizeOnStart;
            adaptiveMaxIterations = useAdaptiveMaxIterations;
            maxNumberOfIteration = setMaxIterations;
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

        //! Calculates a schedule from the defined problem
        /*!
            \pram ScheduleProblemInterface defined problem with contactwindows
            This Function will calculate the solution to the problem defined in
            Schedule Problem Interface
        */
        public void CalculateSchedule(ScheduleProblemInterface problem)
        {
            objective = problem.getObjectiveFunction();
            result = problem.getContactWindows();

            if (adaptiveMaxIterations)
            {
                maxNumberOfIteration = result.Count() * 4;
            }

            if (randomStart)
            {
                result.randomize();
                fillContacts(result);
            }

            if (mainform != null)
                mainform.setProgressBar(maxNumberOfIteration);

            currentFitness = 0.0;
            result.getAt(0).setSheduled();
            while (!isComplete())
            {
                for (int i = 0; i < result.Count(); i++)
                {
                    iterations++;
                    for (int j = 0; j < result.Count(); j++)
                    {
                        if (i != j && result.getAt(i).checkConflikt(result.getAt(j)))
                        {
                            if (result.getAt(i).getStationName() == result.getAt(j).getStationName() ||
                                result.getAt(i).getSatName() == result.getAt(j).getSatName())
                            {
                                //collision detected
                                result.getAt(i).unShedule();
                                result.getAt(j).setSheduled();
                                double newFitness = getFitness(result, problem);
                                if (newFitness < currentFitness)
                                {
                                    result.getAt(j).unShedule();
                                    result.getAt(i).setSheduled();
                                }
                                else
                                {
                                    currentFitness = newFitness;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (Properties.Settings.Default.global_MaxPerf == false)
                    System.Windows.Forms.Application.DoEvents();
                if (mainform != null)
                    mainform.updateProgressBar(iterations);

                currentFitness = getFitness(result, problem);
                fillContacts(result);
            }

        }

        //! Checks if a solution has been found
        /*!
            \return bool true if complete
            This function will tell the scheduler if a solutin has been found
            evaluation function
        */
        public bool isComplete()
        {
            if (cancel)
                return true;
            if (currentFitness > oldFitness)
            {
                oldFitness = currentFitness;
                iterations = 0;
            }
            else
            {
                //iterations++;
                //Console.WriteLine("iterations: " + iterations);
            }
            if (iterations > maxNumberOfIteration)
                return true;
            return false;
        }

        //! returns the finisched Schedule
        /*!
            \return ContactWindowsVector solution
            This Function returns the finisched schedule as a ContactWindowsVector
        */
        public ContactWindowsVector getFinischedSchedule()
        {
            return result;
        }

        //! cancel function
        /*!
            set internal value to halt/stop current calculation
        */
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
            return "Hill Climber Scheduler";
        }

        private void fillContacts(ContactWindowsVector contacts)
        {
            for (int i=0; i < contacts.Count();i++)
            {
                bool confilcts = false;
                if (!contacts.getAt(i).getSheduledInfo())
                {
                    for (int j=0;j<contacts.Count();j++)
                    {
                        if (contacts.getAt(j).getSheduledInfo() && i != j && contacts.getAt(i).checkConflikt(contacts.getAt(j)))
                        {
                            if (contacts.getAt(i).getStationName() == contacts.getAt(j).getStationName() ||
                                contacts.getAt(i).getSatName() == contacts.getAt(j).getSatName())
                            {
                                confilcts = true;
                                break;
                            }
                        }
                    }
                }
                if (!confilcts)
                {
                    contacts.getAt(i).setSheduled();
                }
            }
        }

        //! returns the fitness value of current set
        /*!
            /param Contact Windows Vector
            /return double fitnessValue
        */
        private double getFitness(ContactWindowsVector contacts, ScheduleProblemInterface prob)
        {
            objective.calculateValues(contacts, prob.getSatellites(), prob.getGroundStations());
            return objective.getObjectiveResults();
        }

        //! set the main Form wich should be updated
        /*!
            \Main form
            sets the Form wich holds the elements that display progress bar etc.
        */
        public void setFormToUpdate(Main form)
        {
            mainform = form;
        }

        public void setMaxNumberOfIterations(int val)
        {
            maxNumberOfIteration = val;
        }

        public void setRandomStart(bool val)
        {
            randomStart = val;
        }

        public void setAdaptiveMaxIterationbs(bool val)
        {
            adaptiveMaxIterations = val;
        }

    }
}
