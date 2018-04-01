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
    public class ContactWindow
    {
        public string SatelliteName { get; set; }
        public string StationName { get; set; }
        public One_Sgp4.EpochTime StartTime { get; set; }
        public One_Sgp4.EpochTime EndTime { get; set; }        
        public bool IsScheduled { get; set; }
        public bool Excluded { get; set; }
        public string Id { get; set; }
        public string RequestId { get; set; }
        public Structs.priority Priority { get; set; }

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
            SatelliteName = satelliteName;
            StationName = groundStationName;
            StartTime = new One_Sgp4.EpochTime(start);
            EndTime = new One_Sgp4.EpochTime(stop);
            IsScheduled = false;
            Excluded = false;
            calculateContactDuration();
            Id = Guid.NewGuid().ToString();
        }

        //! ContactWindow constructor
        /*!
        \param string SatelliteName
        \param string GroundStationName
        */
        public ContactWindow( string satelliteName, string groundStationName)
        {
            SatelliteName = satelliteName;
            StationName = groundStationName;
            IsScheduled = false;
            Excluded = false;
            Id = Guid.NewGuid().ToString();
            List<TrackingData> trackingData = new List<TrackingData>();
        }

        //! calcDuration
        /*!
        calculates the Duration of Contact in seconds
        */
        private double calculateContactDuration()
        {
            double start_t = StartTime.getEpoch();
            double stop_t = EndTime.getEpoch();
            double dur = stop_t - start_t;
            if (dur < 0)
            {
                dur = dur + 366;
                if (dur < 0)
                {
                    dur++;
                }
            }
            return dur * 86400.0;
        }

        public double ContactDuration()
        {
            return calculateContactDuration();
        }

        //! setSheduled
        /*!
        sets IsScheduled to true
        */
        public void setSheduled()
        {
            IsScheduled = true;
        }

        //! unSheduled
        /*!
        sets IsScheduled to false
        */
        public void unShedule()
        {
            IsScheduled = false;
        }

        //! getSheduledInfo
        /*!
        \return boolean scheduled
        returns the scheduled value
        */
        public bool getSheduledInfo()
        {
            return IsScheduled;
        }

        //! Set the Request ID
        /*!
        \param Guid ID
        */
        public void setRequestID(string id)
        {
            RequestId = id;
        }

        //! To String
        /*!
        \return string Name, Starttime, Stoptime, Duration
        */
        public override string ToString()
        {
            return String.Format("Name: {0}; StartTime: {1}; EndTime: {2}; duration: {3}",
                SatelliteName, StartTime.ToString(), EndTime.ToString(), ContactDuration());
        }

        //! Retruns the Hash for this Object
        /*!
        \return int hash
        */
        public int getHash()
        {
            return SatelliteName.GetHashCode();
        }

        public ContactWindow Clone()
        {
            return (ContactWindow)this.MemberwiseClone();
        }

        //! Check if this item Conflicts with another
        /*!
        \param ContactWindow
        \return bool true if the contacttime of both object collide
        */
        public bool checkConflikt(ContactWindow window)
        {
            bool startyear = StartTime.getYear() == window.StartTime.getYear();
            bool stopyear = EndTime.getYear() == window.EndTime.getYear();
            if (startyear || stopyear)
            {
                if (StartTime.getEpoch() >= window.StartTime.getEpoch() &&
                    EndTime.getEpoch() <= window.EndTime.getEpoch() )
                {
                    return true;
                }
                if ( EndTime.getEpoch() >= window.EndTime.getEpoch() &&
                    StartTime.getEpoch() <= window.StartTime.getEpoch() )
                {
                    return true;
                }
                if ( StartTime.getEpoch() >= window.StartTime.getEpoch() &&
                    StartTime.getEpoch() <= window.EndTime.getEpoch() &&
                    EndTime.getEpoch() >= window.EndTime.getEpoch())
                {
                    return true;
                }
                if (StartTime.getEpoch() <= window.StartTime.getEpoch() &&
                    EndTime.getEpoch() >= window.EndTime.getEpoch())
                {
                    return true;
                }
                if ( EndTime.getEpoch() >= window.StartTime.getEpoch() &&
                     EndTime.getEpoch() <= window.EndTime.getEpoch() )
                {
                    return true;
                }
            }
            return false;
        }
    }
}
