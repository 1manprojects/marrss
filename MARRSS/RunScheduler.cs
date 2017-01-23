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
        public static void startScheduler(SchedulerInterface scheduler, SchedulingProblem problem)
        {
            scheduler.setObjectiveFunktion(problem.getObjectiveFunction());
            scheduler.CalculateSchedule(problem);
        }

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

        public static SchedulerInterface setScheduler(SchedulerInterface scheduler, Main UpdateForm = null)
        {
            if (scheduler.GetType() == typeof(GeneticScheduler))
            {
                GeneticScheduler genetic = (GeneticScheduler)scheduler;
                if (Properties.Settings.Default.genetic_RunVariable == 1)
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

        public static ContactWindowsVector getResults(SchedulerInterface scheduler)
        {
            return scheduler.getFinischedSchedule();
        }

        public static int getNumberOfGeneration(SchedulerInterface scheduler)
        {
            if (scheduler.GetType() == typeof(GeneticScheduler))
            {
                GeneticScheduler genetic = (GeneticScheduler)scheduler;
                return genetic.getNrOfGenerations();
            }
            return 0;
        }

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
