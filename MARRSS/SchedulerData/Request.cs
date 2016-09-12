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
using MARRSS.Definition;
using MARRSS.Global;

namespace MARRSS.Scheduler
{
    /**
    * \brief Request Class
    *
    * This class defines the Request that are made. Currently every Request 
    * has a priority and a unique id. 
    *  
    */
    class Request: RequestInterface
    {
        private Guid id; /*!< Guid Unique-ID */
        private Structs.priority priority; /*!< priority from 0 to 4 */

        //! Request Constructor
        /*!
        \param Guid
        creates a new Request with ID
        */
        public Request(Guid ID)
        {
            id = ID;
        }

        //! Set the ID
        /*!
        \param Guid ID
        */
        public void setID(Guid ID)
        {
            id = ID;
        }

        //! Set the priority
        /*!
        \param priority 
        */
        public void setPriority(Structs.priority prio)
        {
            priority = prio;
        }

        //! Get Id
        /*!
        /return string Id
        */
        public string getIdToString()
        {
            return id.ToString();
        }

        //! Get Id
        /*!
        /return Guid Id
        */
        public Guid getId()
        {
            return id;
        }

        //! Returns the Priority
        /*!
        \return priority
        */
        public Structs.priority getPriority()
        {
            return priority;
        }
    
    }
}
