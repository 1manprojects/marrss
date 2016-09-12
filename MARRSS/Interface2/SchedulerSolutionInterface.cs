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
using MARRSS.Interface1;

namespace MARRSS.Interface2
{
    /**
* \brief Scheduler Solution Interface
* Every scheduler class can implement this interface witch defines that
* there needs to be a funktion to check if a solution has been found
*/
    interface SchedulerSolutionInterface
    {
        bool isComplete();
    }
}
