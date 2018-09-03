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
using MARRSS.Interface2;
using MARRSS.Definition;
using MARRSS.Global;

namespace MARRSS.Scheduler
{
    /**
    * \brief Example Scheduler
    *
    * This class is an Example of how to implement another Scheduler into
    * the software it has all the callbacks and funktions that need to be defined
    * To Add the Scheduler into the main Programm it has to be added into the
    * Main.cs Class under startScheduleButton_Click()
    * There it can replace either a existing schedule or complemente the others
    * To let the user be able to select whitch scheduler he wants to use a new 
    * Radio Button has to be added to the other ones in the Main form.
    * It has to be added into the same GroupBox as the others.
    * In the Main.cs file add 
    * if (nameOfTheRadioButtonForNewScheduler.Checked)
    */
    class ExampleScheduler : SchedulerInterface, SchedulerSolutionInterface
    {
        //!ExampleScheduler constructor.
        /*!
            Class constructor is neede to create the object
        */
        public ExampleScheduler()
        {

        }

        //! get The Objective Funktion to solve the scheduling problem
        /*!
            \param ObjectiveFunction problem set to solve
        */
        public void setObjectiveFunktion(ObjectiveFunction objectiveFunction)
        {
            //objective = objectiveFunction;
        }
        //! returns The Objective Funktion to solve the scheduling problem
        /*!
            \rreturn ObjectiveFunction problem set to solve
        */
        public ObjectiveFunction getObjectiveFunction()
        {
            return null;
        }

        //! Calculates a schedule from the defined problem
        /*!
            \pram ScheduleProblemInterface defined problem with contactwindows
            This Function will calculate the solution to the problem defined in
            Schedule Problem Interface
        */
        public void CalculateSchedule(ScheduleProblemInterface problem)
        {
            //retrive all the contactwindows that need to be scheduled
            //ContactWindowsVector set = problem.getContactWindows();
            //Scheduler Magic until is Complete returns true
            //No Element of the ContactWindowsVector set should be deleted
            //To Schedule a item call set.getAt(index).setSheduled()
            //To Unschedule a item call set.getAt(index).unShedule()
        }
        
        //! Checks if a solution has been found
        /*!
            \return bool true if complete
            This function will tell the scheduler if a solutin has been found
            evaluation function
        */
        public bool isComplete()
        {
            return true;
        }

        //! returns the finisched Schedule
        /*!
            \return ContactWindowsVector solution
            This Function returns the finisched schedule as a ContactWindowsVector
        */
        public ContactWindowsVector getFinischedSchedule()
        {
            return null;
        }

        //! cancel function
        /*!
            set internal value to halt/stop current calculation
        */
        public void cancelCalculation()
        {

        }

        //! ToString method
        /*!
           \return string 
            returns the Name of the Schedule and used Settings as String
        */
        override public string ToString()
        {
            return "Example Scheduler";
        }

        public string getName()
        {
            return "Example";
        }

    }
}
