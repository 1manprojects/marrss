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
using MARRSS.Scheduler;
using MARRSS.Definition;
using MARRSS.Performance;


namespace MARRSS
{
    class RunScheduler
    {
        //! Start Scheduler
        /*! 
            /param SchedulerInterface scheduler to run
            /param SchedulingProblems problem to solve
        */
        public static void startScheduler(SchedulerInterface scheduler, SchedulingProblem problem)
        {
            scheduler.setObjectiveFunktion(problem.getObjectiveFunction());
            scheduler.CalculateSchedule(problem);
        }

        //! Start Pseudo BruteForce method
        /*! 
            /param SChedulerInterface scheduler to run
            /param SchedulingProblem to solve
            /param Main mainform to update Information
            Currently can only be called with the greedy scheduler
        */
        public static void startBruteForce(SchedulerInterface scheduler, SchedulingProblem problem, Main mainform)
        {
            if (scheduler.GetType() == typeof(GreedyScheduler))
            {
                TimeMeasurement tm = new TimeMeasurement();
                GreedyScheduler greedy = (GreedyScheduler)scheduler;
                double bestFitness = 0.0;
                for (int iteration = 0; iteration < problem.getContactWindows().Count(); iteration++)
                {
                    tm.activate();
                    greedy.BruteForceSchedule(problem, iteration);
                    mainform.updateCalculationTime(tm.getValueAndDeactivate());
                    ObjectiveFunction obj = problem.getObjectiveFunction();
                    obj.calculateValues(greedy.getFinischedSchedule());
                    mainform.updateCalculationTime(tm.getValueAndDeactivate());
                    mainform.setNumberOfGeneration(iteration);
                    if (bestFitness <= obj.getObjectiveResults())
                    {
                        bestFitness = obj.getObjectiveResults();
                        displayResults(mainform, scheduler, iteration);
                    }
                }
            }
            //else do nothing
        }

        //! set Scheduler 
        /*! 
            /param SChedulerInterface scheduler to set up
            /param Main mainform to update = null
            reads the settings set and sets up the scheduler bases on its type
        */
        public static SchedulerInterface setScheduler(SchedulerInterface scheduler, Main UpdateForm = null)
        {
            if (scheduler.GetType() == typeof(GeneticScheduler))
            {
                GeneticScheduler genetic = (GeneticScheduler)scheduler;
                if (Properties.Settings.Default.genetic_Run_For_MaxTime == true)
                {
                    genetic.RunForCertainTime(true, Properties.Settings.Default.genetic_RunTime);
                }
                genetic.setCreationPercentage(Properties.Settings.Default.genetic_Start_Percentage);
                genetic.setMaxNumberOfGeneration(Properties.Settings.Default.genetic_Max_Nr_of_Generations);
                genetic.setMutationPercentage(Properties.Settings.Default.genetic_Mutation_Chance);
                genetic.setPopulationSize(Properties.Settings.Default.genetic_Population_Size);
                genetic.setSolveConflictsAfterRun(Properties.Settings.Default.genetic_SolveContflicts);
                genetic.setConflictHandeling(Properties.Settings.Default.genetic_ConflictSolver);
                genetic.setFormToUpdate(UpdateForm);
                scheduler = genetic;
            }
            if (scheduler.GetType() == typeof(HillClimberScheduler))
            {
                HillClimberScheduler hillclimber = (HillClimberScheduler)scheduler;
                hillclimber.setFormToUpdate(UpdateForm);
                hillclimber.setAdaptiveMaxIterationbs(Properties.Settings.Default.hill_adaptiveMaxIterations);
                hillclimber.setMaxNumberOfIterations(Properties.Settings.Default.hill_maxNumberIterations);
                hillclimber.setRandomStart(Properties.Settings.Default.hill_randomStart);
                scheduler = hillclimber;
            }
            if (scheduler.GetType() == typeof(EftGreedyScheduler))
            {
                EftGreedyScheduler eftGreedy = (EftGreedyScheduler)scheduler;
                eftGreedy.setFormToUpdate(UpdateForm);
                scheduler = eftGreedy;
            }
            if (scheduler.GetType() == typeof(GreedyScheduler))
            {
                GreedyScheduler greedy = (GreedyScheduler)scheduler;
                greedy.setFormToUpdate(UpdateForm);
                scheduler = greedy;
            }
            /*
             * if (schduler.GetType() == typeof(ExampleScheduler))
             * {
             *      set scheduler settings
             *      
             * }
             */
            return scheduler;
        }

        //! get Scheduling Results
        /*! 
            /param SchedulerInterface scheduler
            /return ContactWindowsVector finisched schedule
        */
        public static ContactWindowsVector getResults(SchedulerInterface scheduler)
        {
            return scheduler.getFinischedSchedule();
        }

        //! get max Number of Generations
        /*! 
            /param schedulerInterface scheduler to read nr. Of Generations
            /return int number of generations or zero if scheduler unsuported
            only for genetic scheduler will
        */
        public static int getNumberOfGeneration(SchedulerInterface scheduler)
        {
            if (scheduler.GetType() == typeof(GeneticScheduler))
            {
                GeneticScheduler genetic = (GeneticScheduler)scheduler;
                return genetic.getNrOfGenerations();
            }
            return 0;
        }

        //! set the Scheduling Problem
        /*! 
            /param ContactWindowsVector contacts to schedule
            /param ObjectiveFunction obective to solve problems
        */
        public static SchedulingProblem setSchedulingProblem(ContactWindowsVector contacts, ObjectiveFunction objective)
        {
            SchedulingProblem problem = new SchedulingProblem();
            problem.setContactWindows(contacts);
            problem.removeUnwantedContacts(Properties.Settings.Default.orbit_Minimum_Contact_Duration_sec);
            problem.setObjectiveFunction(objective);
            /*
                * The contact windows that have been calculate are randomized
                * to imporve the result of the greedy algorithms. If the
                * turning the randomiziation off will lead to the greedy
                * algorithms to only schedule contacts for the first few 
                * groundstation ignoring others.
            */
            problem.getContactWindows().randomize(Properties.Settings.Default.global_Random_Seed);
            return problem;
        }

        //! get and Display the results on Main Page
        /*! 
            /param Main main form to update
            /param SchedulerInterface scheduler to get results
            /param int count = -1 the current run number
        */
        public static void displayResults(Main main, SchedulerInterface scheduler, int count = -1)
        {
            if (scheduler != null)
            {
                ObjectiveFunction objfunc = scheduler.getObjectiveFunction();
                if (objfunc == null)
                    objfunc = new ObjectiveFunction();
                objfunc.calculateValues(scheduler.getFinischedSchedule());

                int _H = scheduler.getFinischedSchedule().getNrOfScheduled();
                double _H1 = objfunc.getScheduledContactsValue();
                int _H2 = GeneralMeasurments.getNrOfConflicts(scheduler.getFinischedSchedule());
                double _H3 = objfunc.getStationFairnessValue();
                double _H4 = objfunc.getSatelliteFairnessValue();
                double _H5 = GeneralMeasurments.getDurationOfScheduledContacts(scheduler.getFinischedSchedule());

                main.setFitnessValue(objfunc.getObjectiveResults());
                if (count > -1)
                    main.setNumberOfGeneration(count);
                else
                    main.setNumberOfGeneration(getNumberOfGeneration(scheduler));
                main.setContactsNumber(_H);
                main.setCollisons(_H2);
                main.setFairnessStation(_H3);
                main.setFairnessSatellite(_H4);
                main.setDuration(_H5);
                main.setPriority(GeneralMeasurments.getNrOfPrioritysScheduled(scheduler.getFinischedSchedule()));
                main.setNumberOfUweContact(GeneralMeasurments.getNrOfUweContacts(scheduler.getFinischedSchedule()));
            }
        }
    }
}
