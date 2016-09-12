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
using MARRSS.Definition;
using MARRSS.Global;

namespace MARRSS.Interface1
{
    //! Contact Interface
    /*!
        Needed and required function calls for the ContactWindow Class
    */
    interface ContactInterface
    {
        void setSheduled();
        void unShedule();
        void setStartTime(One_Sgp4.EpochTime time);
        void setStopTime(One_Sgp4.EpochTime time);
        void setExclusion(bool exclusion);
        void setRequestID(Guid id);

        One_Sgp4.EpochTime getStartTime();
        One_Sgp4.EpochTime getStopTime();
        bool getSheduledInfo();
        int getDuration();
        int getHash();
        Guid getRequestID();
        string getStationName();
        string getSatName();
    }
}
