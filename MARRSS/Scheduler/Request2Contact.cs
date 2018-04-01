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

using MARRSS.Interface1;
using MARRSS.Interface2;
using MARRSS.Definition;

namespace MARRSS.Scheduler
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
            contact.RequestId = requestID.ToString();
            contact.Excluded = false;
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
