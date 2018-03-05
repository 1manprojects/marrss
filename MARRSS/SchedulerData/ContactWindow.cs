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
using System.IO;

using MARRSS.Definition;
using MARRSS.Interface1;
using MARRSS.Global;

namespace MARRSS.Scheduler
{
    /**
    * \brief Contact Window Class
    *
    * This class defines the Contact Window for each satellite to groundstation
    * Every contact window is assigned a satellite and ground station with starting
    * and end time. Each contact also contains the Azimuth, Elevation, Range of
    * every time point during the contact. 
    */
    class ContactWindow : ContactInterface
    {
        private string satName; /*!< string Satellite Name */
        private string stationName; /*!< string GroundStation Name */

        private One_Sgp4.EpochTime startTime; /*!< TimeDate Starttime of Contact */
        private One_Sgp4.EpochTime stopTime; /*!< TimeDate Stoptime of contact */
        private double duration; /*!< double duration of contact */

        //List<TrackingData> trackingData = new List<TrackingData>(); /*!< trackingData */

        bool sheduled; /*!< boolean if contact has been scheduled */
        bool exluded; /*!< boolean if contact is to be excluded */

        private Guid id; /*!< Guid - ID of ContactWindow */
        private Guid requestID; /*!< Guid - ID of Request */

        private string SatStorageAtBegin;
        private string SatStorageAtEnd;

        private Global.Structs.priority priority = (Structs.priority)4; /*!< Global.Structs.priority - Priority of Request */

        //! ContactWindow constructor
        /*!
        \param TimeDate Starttime
        \param TimeDate Stoptime
        \param string SatelliteName
        \param string GroundStationName
        */
        public ContactWindow(One_Sgp4.EpochTime start, One_Sgp4.EpochTime stop,
            string satelliteName, string groundStationName)
        {
            satName = satelliteName;
            stationName = groundStationName;

            startTime = new One_Sgp4.EpochTime(start);
            stopTime = new One_Sgp4.EpochTime(stop);

            sheduled = false;
            exluded = false;
            calcDuration();

            SatStorageAtBegin = "";
            SatStorageAtEnd = "";

            id = System.Guid.NewGuid();
            List<TrackingData> trackingData = new List<TrackingData>();
        }

        //! ContactWindow constructor
        /*!
        \param string SatelliteName
        \param string GroundStationName
        */
        public ContactWindow( string satelliteName, string groundStationName)
        {
            satName = satelliteName;
            stationName = groundStationName;

            sheduled = false;
            exluded = false;

            id = System.Guid.NewGuid();
            List<TrackingData> trackingData = new List<TrackingData>();
        }

        //! calcDuration
        /*!
        calculates the Duration of Contact in seconds
        */
        private void calcDuration()
        {
            double start_t = startTime.getEpoch();
            double stop_t = stopTime.getEpoch();
            double dur = stop_t - start_t;
            if (dur < 0)
            {
                dur = dur + 366;
                if (dur < 0)
                {
                    dur++;
                }
            }
            duration = dur * 86400.0;
        }

        //! setSheduled
        /*!
        sets sheduled to true
        */
        public void setSheduled()
        {
            sheduled = true;
        }

        //! unSheduled
        /*!
        sets sheduled to false
        */
        public void unShedule()
        {
            sheduled = false;
        }

        //! getSheduledInfo
        /*!
        \return boolean scheduled
        returns the scheduled value
        */
        public bool getSheduledInfo()
        {
            return sheduled;
        }

        //! getStartTime
        /*!
        \return TimeDate
        returns the starttime of Contact
        */
        public One_Sgp4.EpochTime getStartTime()
        {
            return startTime;
        }

        //! getStopTime
        /*!
        \return TimeDate
        returns the stoptime of Contact
        */
        public One_Sgp4.EpochTime getStopTime()
        {
            return stopTime;
        }

        //! getDuration
        /*!
        \return double
        returns the duration in seconds of Contact
        */
        public double getDuration()
        {
            return duration;
        }


        //! addTrackingData
        /*!
        \param TrackingData
        adds Tracking Data to the contactWindow
        */
        //public void addTrackingData(TrackingData data)
        //{
        //    trackingData.Add(data);
        //}

        //! setStartTime
        /*!
        \param TimeDate
        sets the starttime of Contact
        */
        public void setStartTime(One_Sgp4.EpochTime time)
        {
            startTime = new One_Sgp4.EpochTime(time);
        }

        //! setStopTime
        /*!
        \param TimeDate
        sets the stoptime of Contact
        */
        public void setStopTime(One_Sgp4.EpochTime time)
        {
            stopTime = new One_Sgp4.EpochTime(time);
            calcDuration();
        }

        //! getSatName
        /*!
        \return string
        returns the Satellite Name for this Contact Window
        */
        public string getSatName()
        {
            return satName;
        }

        //! getStationName
        /*!
        \return string
        returns the Station name for this Contact
        */
        public string getStationName()
        {
            return stationName;
        }

        //! setExclusion
        /*!
        \param bool
        true if if this contact should be excluded
        */
        public void setExclusion(bool exclusion)
        {
            exluded = exclusion;
        }

        //! Set the Request ID
        /*!
        \param Guid ID
        */
        public void setRequestID(Guid id)
        {
            requestID = id;
        }

        //! Returns the Request ID
        /*!
        \return Guid requestID
        */
        public Guid getRequestID()
        {
            return requestID;
        }

        //! Set the Priority
        /*!
        \param Structs.priority p
        */
        public void setPriority(Structs.priority p)
        {
            priority = p;
        }

        //! Returns the priority 
        /*!
        \return Structs.priority priority
        */
        public Structs.priority getPriority()
        {
            return priority;
        }

        //! Set the Contact ID
        /*!
        \param Guid ID
        This should only be used wen reading saved data.
        If a completly new ContactWindow is created then it will be set automaticaly
        */
        public void setID(Guid ID)
        {
            id = ID;
        }

        //! Returns the ContactWindow ID
        /*!
        \return Guid ID
        */
        public Guid getID()
        {
            return id;
        }

        //! To String
        /*!
        \return string Name, Starttime, Stoptime, Duration
        */
        public override string ToString()
        {

            return String.Format("Name: {0}; startTime: {1}; stopTime: {2}; duration: {3}",
                satName, startTime.ToString(), stopTime.ToString(), duration);
        }

        //! Returns the Exclusion
        /*!
        \return bool true if this contact should not be considerd
        */
        public bool getExclusion()
        {
            return exluded;
        }

        //! Retruns the Hash for this Object
        /*!
        \return int hash
        */
        public int getHash()
        {
            return satName.GetHashCode();
        }

        public void setSatStorageAtstart(string value)
        {
            SatStorageAtBegin = value;
        }

        public string getSatStorageAtStart()
        {
            return SatStorageAtBegin;
        }

        public void setSatStorageAtEnd(string value)
        {
            SatStorageAtEnd = value;
        }

        public string getsetSatStorageAtEnd()
        {
            return SatStorageAtEnd;
        }

        public ContactWindow Clone()
        {
            return (ContactWindow)this.MemberwiseClone();
        }

        //! Retruns the tracking data for this Object
        /*!
        \return List<TrackingData> tracking data
        */
        //public List<TrackingData> getTrackingData()
        //{
        //    return trackingData;
        //}

        //! Check if this item Conflicts with another
        /*!
        \param ContactWindow
        \return bool true if the contacttime of both object collide
        */
        public bool checkConflikt(ContactWindow window)
        {
            bool startyear = startTime.getYear() == window.getStartTime().getYear();
            bool stopyear = stopTime.getYear() == window.getStopTime().getYear();
            if (startyear || stopyear)
            {
                if (startTime.getEpoch() >= window.getStartTime().getEpoch() &&
                    stopTime.getEpoch() <= window.getStopTime().getEpoch() )
                {
                    return true;
                }
                if ( stopTime.getEpoch() >= window.getStopTime().getEpoch() &&
                    startTime.getEpoch() <= window.getStartTime().getEpoch() )
                {
                    return true;
                }
                if ( startTime.getEpoch() >= window.getStartTime().getEpoch() &&
                    startTime.getEpoch() <= window.getStopTime().getEpoch() &&
                    stopTime.getEpoch() >= window.getStopTime().getEpoch())
                {
                    return true;
                }
                if (startTime.getEpoch() <= window.getStartTime().getEpoch() &&
                    stopTime.getEpoch() >= window.getStopTime().getEpoch())
                {
                    return true;
                }
                if ( stopTime.getEpoch() >= window.getStartTime().getEpoch() &&
                     stopTime.getEpoch() <= window.getStopTime().getEpoch() )
                {
                    return true;
                }
            }
            return false;
        }
    }
}
