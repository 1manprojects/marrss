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
using MARRSS.Global;

namespace MARRSS.Interface1
{
    //! Request Interface
    /*!
        Definition of functions needed for the Requests class
    */
    interface RequestInterface
    {
        void setID(Guid ID);
        void setPriority(Structs.priority prio);

        Structs.priority getPriority();
        Guid getId();
    }
}
