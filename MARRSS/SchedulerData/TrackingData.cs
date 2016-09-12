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

namespace MARRSS.Scheduler
{
    /**
    * \brief Tracking Data Class
    *
    * This class defines the Tracking data for each contact window.
    * Azimuth, Elevation, Range, RangeRate and time are stored for every point
    * that was calculated. 
    */
    class TrackingData
    {
        private double azimuth = 999.0; //!< Azimuth in degree*/
        private double elevation = 99.0; //!< Elevation in degree */
        private double range = 999.0; //!< Range in Km */
        private double rangeRate = -999.0; //!< RangeRate in meter/sec */
        private string time; //!< Time as a string */

        //! Tracking Data constructor
        /*!
        \param double Azimuth in radians
        \param double Elevation in radians
        \param double Range in Km
        \param string Time
        */
        public TrackingData(double azi, double ele, double ran, string tt)
        {
            time = tt;
            azimuth = azi * Constants.toDegrees;
            elevation = ele * Constants.toDegrees;
            range = ran;
        }

        //! returns Azimuth
        /*!
        \return double azimuth
        */
        public double getAzimuth()
        {
            return azimuth;
        }

        //! returns Elevation
        /*!
        \return double elevation
        */
        public double getElevation()
        {
            return elevation;
        }

        //! returns Range
        /*!
        \return double range
        */
        public double getRange()
        {
            return range;
        }

        //! returns RangeRate
        /*!
        \return double range rate
        */
        public double getRangeRate()
        {
            return rangeRate;
        }

        //! returns time
        /*!
        \return string time
        */
        public string getTimeStamp()
        {
            return time;
        }

        //! ToString
        /*!
        \return string Time, Elevation, Azimuth, Range
        */
        public override string ToString()
        {
            return String.Format("{0}, El: {1},  Az: {2}, Range: {3}", time, elevation, azimuth, range);
        }

    }
}
