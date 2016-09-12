/**
* ----------------------------------------------------------------
*
* Request2Contact.cs
*
* Part of the Bachelor thesis in Aerospace Computer Science
* 
* Design & Implementation of an Adaptive Multi-Ressource Range
* Scheduling-Software for Multi-Satellite Systems in Academical Networks
*
* By Nikolai Jonathan Reed 
*
* Universtiy Würzburg Germany 
* 
* Copyright (c) 2015, Nikolai Reed, 1manprojects.de
* All rights reserved.
*
* Licensed under
* Creative Commons Attribution-NoDerivatives 4.0 International Public
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MARRSS.Interface1;
using MARRSS.Interface2;
using MARRSS.Definition;

namespace MARRSS.SchedulerData
{
    /**
    * \brief Request To Contact Class
    *
    * This class defines how requests are assigned to a contact window.
    * Currently these are not used since there are no Requests created by
    * diffrent users in the current state of the software. 
    */
    class Request2Contact : Reqest2ContactInterface
    {
        //! Assign a Request to a Contact
        /*!
            \param ContactWindow contact
            \param Guid Request-ID
        */
        public void assignRequestToContact(ContactWindow contact, Guid requestID)
        {
            contact.setRequestID(requestID);
            contact.setExclusion(false);
        }

        //! Assigns a list of Request to the ContactWindows
        /*!
            \param ContactWindowsVector contact
            \param List<Request> request
        */
        public void calcRequToContacts(ContactWindowsVector contacts, List<Request> requests)
        {
            //assign Contacts to Requests
            //setExclusion for unasigned ContactWindows
        }

    }
}
