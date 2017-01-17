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
* \brief ScheduleProblemInterface
*
* This Interface lists the requried callbacks neccesary for the Definition of the
* Schedule Problem Class. Each scheduling problem needs a list of ContactWindows
* and Requests. 
*/
    interface ScheduleProblemInterface
    {
        void setContactWindows(ContactWindowsVector contacts);
        void setRequests(List<RequestInterface> requestsList);
        void setObjectiveFunction(ObjectiveFunction objectiveFunction);
        void setRequestToContact();
        ContactWindowsVector getContactWindows();
        ObjectiveFunction getObjectiveFunction();
    }
}
