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

using MARRSS.Definition;
using MARRSS.Scheduler;

namespace MARRSS.Interface2
{
    /**
* \brief Scheduler Interface
*
* This interface defines the neccesary callbacks required for the Scheduler
* Class. Every Scheduler musst be able to Calculate / Generate a solution
* based on the defined problem and a return function to get the result. 
*/
    interface SchedulerInterface
    {
        void CalculateSchedule(ScheduleProblemInterface problem);
        void setObjectiveFunktion(ObjectiveFunction objective);
        ObjectiveFunction getObjectiveFunction();
        ContactWindowsVector getFinischedSchedule();
        string ToString();
        void cancelCalculation();
        string getName();
    }
}
