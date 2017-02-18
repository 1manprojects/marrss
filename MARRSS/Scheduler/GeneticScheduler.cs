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

using MARRSS.Interface2;
using MARRSS.Definition;
using MARRSS.Global;

namespace MARRSS.Scheduler
{
    /**
    * \brief Genetic Scheduler
    *
    * This class defines the genetic algorithm to create a near optimal 
    * schedule. This is being done by creating a random starting population
    * made of 1 and 0 to show if a contact window at that position is being
    * included in the schedule. Every generation goes through the same steps
    * until a solution is found. First the worst solution is removed (survival
    * of the fittest) the remaining create through random combination children.
    * the unfittest parent will be replaced by the child. Through random the 
    * population is being mutated by a slight change (bit flipping). 
    * If no good enough solutin is found then the cycle begins annew. 
    * Survival of the fittest
    * Create Children
    * Mutate population
    * check for solution 
    * If there are no better results found after a certain amount of generations
    * the best result that has been found will be chosen as the solution.
    */
    class GeneticScheduler : SchedulerInterface , SchedulerSolutionInterface
    {
        private int popSize = 8; //!< int size of the population
        private int genCrea = 65; //!< int percentage to randomize population
        private int mutation = 1; //!< int percentage to mutate the children

        private ContactWindowsVector result; //!< ContactWindowsVector finall result
        private ContactWindowsVector set; //!< ContactWindowsVector current ContactWindows to calculate solution
        private List<int[]> population; //!< List<int[]> list containing the population
        private double[] fitness; //!< double[] fitness of the current generation
        private int nrOfStation; //!< int number of stations in the schedule
        private int nrOfContacts; //!< int number of contacts in the schedule
        private int nrOfSatellites; //!< int nor of satellite in the schedule

        private int nrOfGenerationsForCompletion = 300; //!< int nr of generations to look for a better solution
        private int countSolutionGeneration = 0; //!< int number of generations looging for a better solution
        private int[] bestSolution; //!< int[] array of the current best solution
        private double bestFitness = 0.0; //!< double the best fitness of the current generation
        private double lastBestFitness = 0.0; //!< double the best fitness of the current generation

        private int generation; //!< int number of generations

        private List<string> satelliteList; //!< list<string> satellite names
        private List<string> stationList; //!< list<string> station names

        private ObjectiveFunction objective;

        private bool cancel = false;

        //Logging
        private int generateLog = 0;
        private int generatePlotData = 0;
        private string plotPath = "";
        private System.IO.StreamWriter plotWr;

        private bool runUnitlTime = false;
        private double hours = 0;
        private DateTime startrunTime;

        private bool conflictValue = false;
        private bool solveConflict = false;

        private Main f = null;

        //! GeneticScheduler constructor.
        /*!
            Empty Constructor
        */
        public GeneticScheduler()
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
                if (generatePlotData == 1)
                    plotname = plotname + "-Genetic-Average";
                if (generatePlotData == 2)
                    plotname = plotname + "-Genetic-Maximum";
                if (generatePlotData == 3)
                    plotname = plotname + "-Genetic-All";
                if (generatePlotData == 4)
                    plotname = plotname + "-Genetic-NewMaxValue";
                plotWr = new System.IO.StreamWriter(plotPath + "\\" + plotname, true);
            }
        }

        public GeneticScheduler(int populationSize, int startingChance, int mutationsChance, int maxNumberOfGenerations,
            bool runForCertainTime = false, double runTime = 0.0, bool solveConflictsByPriority = false , bool solveConflictsAfterRun = false)
        {
            popSize = populationSize;
            genCrea = startingChance;
            mutation = mutationsChance;
            nrOfGenerationsForCompletion = maxNumberOfGenerations;
            runUnitlTime = runForCertainTime;
            hours = runTime;
            conflictValue = solveConflictsByPriority;
            solveConflict = solveConflictsAfterRun;
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

        //! set the main Form wich should be updated
        /*!
            \Main form
            sets the Form wich holds the elements that display progress bar etc.
        */
        public void setFormToUpdate(Main form)
        {
            f = form;
        }

        //! returns the found solution
        /*!
            \return ContactWindowsVector best solution found
        */
        public ContactWindowsVector getFinischedSchedule()
        {
            return result;
        }

        //! Starts the process of finding the best solution through genetor
        /*!
            \param ScheduleProblemInterface definition of the problem to solve
        */
        public void CalculateSchedule(ScheduleProblemInterface problem)
        {
            objective = problem.getObjectiveFunction();
            set = problem.getContactWindows();
            //Sort by time
            set.sort(Structs.sortByField.TIME);

            nrOfContacts = set.Count();
            nrOfStation = set.getNumberOfStation();
            nrOfSatellites = set.getNumberOfSatellites();
            satelliteList = new List<string>(set.getSatelliteNames());
            stationList = new List<string>(set.getStationNames());

            fitness = new double[popSize];
            bestSolution = new int[nrOfContacts];

            if(runUnitlTime)
            {
                startrunTime = DateTime.Now;
                double h = hours;
                startrunTime = startrunTime.AddHours(h);
            }
            generation = 0;

            //create 5-10 random schedules from the Data
            population = new List<int[]>();
            for (int i = 0; i < popSize; i++)
            {
                population.Add(new int[nrOfContacts]);
                fitness[i] = Constants.maxInt;
            }
            //Randomize the starting Population
            Random rnd = new Random();
            for (int k = 0; k < popSize; k++)
            {
                for (int i = 0; i < nrOfContacts; i++)
                {
                    int randStart = rnd.Next(0, 100);
                    if (randStart <= genCrea)
                    {
                        population[k][i] = 1;
                    }
                }
            }
            //--
            bool foundSolution = false;
            while (!foundSolution)
            {
                generation++;
                //Console.WriteLine("Generation: " + generation.ToString() );
                //elliminate all collsions either by using random chance or
                //by priority.
                //check fitness of each one (survival rate)
                for (int i = 0; i < popSize; i++)
                {
                    surviveConflicts(population[i], rnd, conflictValue);
                    fitness[i] = checkFitness(population[i]);
                }

                if (Properties.Settings.Default.global_MaxPerf == false)
                {
                    System.Windows.Forms.Application.DoEvents();
                }

                //take only the fittest
                survivalOfFittest(fitness, population);

                //Combine randomly and generate children
                createChildren(population, fitness, rnd);


                //Mutate (remove or add requests by slight change)
                for (int i = 0; i < popSize; i++)
                {
                    mutate(population[i], rnd);
                }

                //check if Solution has been found
                foundSolution = isComplete();

                if (generatePlotData > 0)
                {
                    WriteLog();
                }

                if (Properties.Settings.Default.global_MaxPerf == false)
                {
                    System.Windows.Forms.Application.DoEvents();
                }

                if (f != null)
                {
                    f.incrementProgressBar();
                }
            }
            if (solveConflict)
            {
                surviveConflicts(bestSolution, rnd, conflictValue);
            }
            //
            
            //surviveConflicts(bestSolution, rnd);
            setSchedule(bestSolution, set);
            Console.WriteLine("Found Solution after " + generation.ToString() + " Generations");
            result = set;
            result.randomize();
            fillGaps();
            if (generatePlotData > 0)
            {
                plotWr.Close();
            }
            if (f != null)
            {
                f.resetProgressBar();
            }
        }

        //! Checks if the algorithm has found a solution
        /*!
            \return bool true if a solution is found
        */
        public bool isComplete()
        {
            if (cancel)
                return true;
            if (!runUnitlTime)
            {
                bool result = false;
                double bestCurrent = fitness[0];
                int pos = 0;
                for (int i = 0; i < fitness.Count(); i++)
                {
                    if (fitness[i] >= bestCurrent)
                    {
                        bestCurrent = fitness[i];
                        pos = i;
                    }
                }
                if (bestCurrent > bestFitness)
                {
                    bestFitness = bestCurrent;
                    countSolutionGeneration = 0;
                    Array.Copy(population[pos], bestSolution, nrOfContacts);
                }
                else
                {
                    countSolutionGeneration++;
                    if (countSolutionGeneration >= nrOfGenerationsForCompletion)
                    {
                        result = true;
                    }
                }
                return result;
            }
            else
            {
                double bestCurrent = fitness[0];
                int pos = 0;
                for (int i = 0; i < fitness.Count(); i++)
                {
                    if (fitness[i] >= bestCurrent)
                    {
                        bestCurrent = fitness[i];
                        pos = i;
                    }
                }
                if (bestCurrent > bestFitness)
                {
                    bestFitness = bestCurrent;
                    countSolutionGeneration = 0;
                    Array.Copy(population[pos], bestSolution, nrOfContacts);
                }
                if(DateTime.Now >= startrunTime)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        //! Checks the fitness of the current population
        /*!
            \param ContactWindowsVector contactwindows to check against
            \param int[] current population to check fitness
            \return double fittness of the current populus
            The Fitness is defined by the objective Function
            from 1.0 to 0 with 1.0 being optimal
        */
        private double checkFitness(int[] pop)
        {
            objective.calculateValues(set, pop);
            return objective.getObjectiveResults();
        }

        //! Survival of the Fittest by elminating populus with poor fitness
        /*!
            \pram double[] fitness of the current generation
            \param List<int[]> current population
            this funktion removes the one witht the lowest fitness and replaces it with a copy of the fittest
        */
        private void survivalOfFittest(double[] fitnes, List<int[]> populus)
        {
            double maxfit = 0;
            double minfit = Constants.maxInt;
            int posmax = 0;
            int posmin = 0;
            for (int i = 0; i < popSize; i++)
            {
                if (fitnes[i] < minfit)
                {
                    minfit = fitnes[i];
                    posmin = i;
                }
                if (fitnes[i] > maxfit)
                {
                    maxfit = fitnes[i];
                    posmax = i;
                }
            }
            populus[posmin] = new int[nrOfContacts];
            Array.Copy(populus[posmax], populus[posmin], nrOfContacts);
            //Console.WriteLine( generation +" "+ fitnes[posmax]);
        }

        //! Create Children through schuffeling
        /*!
            \param List<int[]> current population
            \param double[] fitness of the current generation
            \param Random object 
            Two items of the current generation create a child element by 
            shuffeling their genetic information
            The parent with the lowest fitness will be replaced by the child
        */
        private void createChildren(List<int[]> populus, double[] fitness, Random ran)
        {
            for (int i = 0; i < popSize; i = i + 2 )
            {
                //generate child1
                int randStop = ran.Next(0, nrOfContacts - 1);
                int[] child1 = new int[nrOfContacts];
                Array.Copy(populus[i], 0, child1, 0, randStop);
                Array.Copy(populus[i + 1], randStop, child1, randStop, nrOfContacts - randStop);
                //generate child2
                randStop = ran.Next(0, nrOfContacts - 1);
                int[] child2 = new int[nrOfContacts];
                Array.Copy(populus[i], 0, child2, 0, randStop);
                Array.Copy(populus[i + 1], randStop, child2, randStop, nrOfContacts - randStop);
                //both children replace their parents
                Array.Copy(child1, populus[i + 1], nrOfContacts);
                Array.Copy(child2, populus[i], nrOfContacts);
            }
        }

        //! Mutate the current generation
        /*!
            \param int[] current populus
            \param Random object 
            The population undergoes random mutation determined by change certain genes will flip
        */
        private void mutate(int[] child, Random ran)
        {
            for (int k = 0; k < child.Count(); k++)
            {
                int randMutation = ran.Next(0, 100);
                if (randMutation <= mutation)
                {
                    if (child[k] == 1)
                    {
                        child[k] = 0;
                    }
                    else
                    {
                        child[k] = 1;
                    }
                }
            }
        }

        //! Set the finall schedule
        /*!
            \param int[] current populus
            \param ContactWindowsVector starting contactwindows
            Each contact windows will be scheduled or unscheduled defined by the found solution
        */
        private void setSchedule(int[] pop, ContactWindowsVector contacts)
        {
            for (int i = 0; i < nrOfContacts; i++)
            {
                if (pop[i] == 1)
                {
                    contacts.getAt(i).setSheduled();
                }
                else
                {
                    contacts.getAt(i).unShedule();
                }
            }
        }

        //! Solve Conflict and all collisions by random
        /*!
            this funcions checks all contacts that are included in the 
            current population and removes conflicting ones, either by
            priority or by random chance
        */
        private void surviveConflicts(int[] pop, Random ran, bool piroity = false)
        {
            for (int i = 0; i < nrOfContacts; i++)
            {
                if (pop[i] == 1)
                {
                    List<int> conflicting = new List<int>();
                    conflicting.Add(i);
                    int startItem = i - (nrOfSatellites * nrOfStation) / 2;
                    if (startItem < 0)
                    {
                        startItem = 0;
                    }
                    int stopItem = i + (nrOfSatellites * nrOfStation) / 2;
                    if (stopItem > nrOfContacts)
                    {
                        stopItem = nrOfContacts;
                    }
                    for (int k = startItem; k < stopItem; k++)
                    {
                        if (pop[k] == 1 && k != i
                            && set.getAt(i).checkConflikt(set.getAt(k)))
                        {
                            if (set.getAt(i).getSatName() == set.getAt(k).getSatName()
                               || set.getAt(i).getStationName() == set.getAt(k).getStationName())
                            {
                                conflicting.Add(k);
                            }
                        }
                    }
                    if (conflicting.Count > 1)
                    {
                        if (piroity)
                        {
                            int maxPrio = 4;
                            int posMax = 0;
                            for (int l = 0; l < conflicting.Count; l++)
                            {
                                if ((int)set.getAt(conflicting[l]).getPriority() <= maxPrio)
                                {
                                    maxPrio = (int)set.getAt(conflicting[l]).getPriority();
                                    posMax = conflicting[l];
                                    pop[conflicting[l]] = 0;
                                }
                            }
                            pop[posMax] = 1;
                        }
                        else
                        {
                            for (int l = 0; l < conflicting.Count; l++)
                            {
                                pop[conflicting[l]] = 0;
                            }
                            pop[conflicting[ran.Next(0,conflicting.Count -1)]] = 1;
                        }
                    }
                }
            }
        }

        //! Fill Gaps in finisched Schedule
        /*!
            this funcions will run through the final solution and
            adds contact windows to the schedule were there is still
            space and time. Thus filling in empty spaces were contacts
            can be made
        */
        private void fillGaps()
        {
            for (int i = 0; i < result.Count(); i++)
            {
                if (!result.getAt(i).getSheduledInfo())
                {
                    bool found = false;
                    for (int k = 0; k < result.Count(); k++)
                    {
                        if (set.getAt(i).checkConflikt(set.getAt(k))
                            && result.getAt(k).getSheduledInfo()
                            && i != k)
                        {
                            if (set.getAt(i).getSatName() == set.getAt(k).getSatName()
                            || set.getAt(i).getStationName() == set.getAt(k).getStationName())
                            {
                                found = true;
                                break;
                            }
                        }
                    }
                    if (!found)
                    {
                        result.getAt(i).setSheduled();
                    }
                }
            }
        }


        //! Write Log Data to File
        /*!
            writes the average, Max or all fitness values of every generation
            to the output folder
        */
        private void WriteLog()
        {
            switch (generatePlotData)
            {
                case 1:
                    double average = 0.0;
                    for (int i = 0; i < fitness.Count(); i++)
                    {
                        average += fitness[i];
                    }
                    average = average / fitness.Count();
                    plotWr.WriteLine(generation + " " + average);
                    break;
                case 2:
                    double max = 0.0;
                    for (int i = 0; i < fitness.Count(); i++)
                    {
                        if (fitness[i] > max)
                        {
                            max = fitness[i];
                        }
                    }
                    plotWr.WriteLine(generation + " " + max);
                    break;
                case 3:
                    for (int i = 0; i < fitness.Count(); i++)
                    {
                        plotWr.WriteLine(i + " " + generation + " " + fitness[i]);
                    }
                    break;
                case 4:
                    if (lastBestFitness < bestFitness)
                    {
                        //plotWr.WriteLine(generation + " " + lastBestFitness);
                        plotWr.WriteLine(generation + " " + bestFitness);
                        lastBestFitness = bestFitness;
                    }
                    break;
            }
            plotWr.Flush();
        }

        //! Set the size of the population
        /*!
            \param int size
            size has to be devidable by two and will set how big the population
            will be 2/4/6/8/10/12/... 
        */
        public void setPopulationSize(int size)
        {
            //check if size is dividable by two
            if (size % 2 == 0)
            {
                popSize = size;
            }
            else
            {
                popSize = size + 1;
            }
        }

        //! Set the percentage to randomise the starting population
        /*!
            \param int percentage
            this will define how high the change is to include a contact window
            in the starting population
        */
        public void setCreationPercentage(int percent)
        {
            genCrea = percent;
        }

        //! Set the percentage of the mutation
        /*!
            \param int percentag
            Each generation will be mutated by slight chance 
        */
        public void setMutationPercentage(int percent)
        {
            mutation = percent;
        }

        //! Set the max number of generation unitl scheduler is stoped
        /*!
            \param int max
            if no better solution is found during the next max number of generations
            the scheduler stops and takes the best solution found until then.
        */
        public void setMaxNumberOfGeneration(int max)
        {
            nrOfGenerationsForCompletion = max;
        }

        //! returns the Nr of Generations calculated until Solution has been found
        /*!
            \return int Nr of Generations
        */
        public int getNrOfGenerations()
        {
            return generation;
        }

        //! Set the Genetor to run for a certain time
        /*!
            \param bool status true turns it on
            \param int hours to run
        */
        public void RunForCertainTime(bool status, double Hours = 0)
        {
            runUnitlTime = status;
            hours = Hours;
        }


        //! Set the Conflict Handler false -> Random
        /*!
            \param bool conflictValue
            handles conflicts by Priority or Random value
        */
        public void setConflictHandeling(bool ConflictValue)
        {
            conflictValue = ConflictValue;
        }


        //! Solve Conflicts after Run
        /*!
            \param solveConflicts
            
        */
        public void setSolveConflictsAfterRun(bool solveConflicts)
        {
            solveConflict = solveConflicts;
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
            string name = "Genetic Scheduler" + "\n" + "PopulationSize: "
                + popSize + "\n" + "Starting Chance: " + genCrea + "\n" + "Mutation Chance: " + mutation + "\n";
            if (runUnitlTime)
            {
                name += "\n" + "Max Runtime (H): " + hours;
            }
            else
            {
                name += "\n" + "Max Generations: " + nrOfGenerationsForCompletion;
            }
            return name;
        }
    }
}
