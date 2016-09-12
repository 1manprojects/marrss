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

using MARRSS.Scheduler;

namespace MARRSS.Interface1
{
    //! Request to Contact Interface
    /*!
        Definition of functions needed for Request to Contact class
    */
    interface Reqest2ContactInterface
    {
        void assignRequestToContact(ContactWindow contact, Guid RequestID);
    }
}
