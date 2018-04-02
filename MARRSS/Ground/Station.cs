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

using MARRSS.Definition;
using MARRSS.Global;

namespace MARRSS.Ground
{
    /**
    * \brief Station Class definition.
    *
    * This class defines the object ground station. Each station as a coordinate
    * and a name. Currently each ground station will be seen has having only one
    * antenna with now furtur information.
    * Can be expanded with the Antenna Class in the future. 
    */
    public class Station
    {
        private string name; //!< string name of the Station
        private GeoCoordinate geoCoordinate; //!< GeoCoordinate position of the stations
        private double minElevation = 0.000000; //!< double min elevation of groundstation
        private double maxUpLink; //!< double max Uplink of groundstation in Kbps
        private double maxDownLink; //!< double max Downlink of groundstation in Kbps

        //! Stations constructor.
        /*!
            \param string name of station
            \param GeoCoordinate position of the Station
            constructs a basic Groundstation with a single basic antenna at the given coordinates
        */
        public Station(string _name, GeoCoordinate _geoCord)
        {
            geoCoordinate = _geoCord;
            name = _name;
            maxUpLink = 0;
            maxDownLink = 0;
        }
                        
        //! Stations constructor.
        /*!
            \param string name of station
            \param double latetude of the station
            \param double longitude of the station
            \param double height of the stations
            constructs a Groundstationat with one antenna the given coordinates
        */
        public Station(string _name, double latetude, double longetude,
                        double height = 0.0)
        {
            geoCoordinate = new Definition.GeoCoordinate(latetude, longetude, height);
            name = _name;
            maxUpLink = 0;
            maxDownLink = 0;
        }

        //! Stations constructor.
        /*!
            \param string name of station
            \param double latetude of the station
            \param double longitude of the station
            \param double height of the stations
            constructs a Groundstationat with one antenna the given coordinates
        */
        public Station(string _name, double latetude, double longetude,
                        double height = 0.0, double maxUp = 0.0, double maxDown= 0.0)
        {
            geoCoordinate = new Definition.GeoCoordinate(latetude, longetude, height);
            name = _name;
            maxUpLink = maxUp;
            maxDownLink = maxDown;
        }

        //! Set the Coordinates of the Stations
        /*!
            \param GeoCoordinate
        */
        public void setGeoCoordinate(GeoCoordinate _geoCoord)
        {
            geoCoordinate = _geoCoord;
        }

        //! returns the Coordinates of the stations
        /*!
            \return GeoCoordinate
        */
        public GeoCoordinate getGeoCoordinate()
        {
            return geoCoordinate;
        }

        //! returns the Name of the stations
        /*!
            \return string
        */
        public string getName()
        {
            return name;
        }

        //! returns local sidreal time at any given time
        /*!
            \pram TimeDate current time
            \return double LocalSidrealTime
        */
        public double getLocalSidrealTime(One_Sgp4.EpochTime time)
        {
            return time.getLocalSiderealTime(geoCoordinate.getLongitude());
        }

        //! returns the longitude
        /*!
            \return double longitude
        */
        public double getLongitude()
        {
            return geoCoordinate.getLongitude();
        }

        //! returns the latitude
        /*!
            \return double latitude
        */
        public double getLatitude()
        {
            return geoCoordinate.getLatetude();
        }

        //! returns the min elevation
        /*!
            \return double minElevation
        */
        public double getMinElevation()
        {
            return minElevation;
        }

        //! returns the Position of the Station in ECI-vector
        /*!
            \param double localSidrealTime at station
            \return point3D ECI coordinates as x,y,z-vector
        */
        public Structs.point3D getEci(double localSidrealTime)
        {
            return geoCoordinate.toECI(localSidrealTime);
        }

        //! returns the hight of the station
        /*!
            \return double height
        */
        public double getHeight()
        {
            return geoCoordinate.getHeight();
        }

        public double getMaxUpLink()
        {
            return maxUpLink;
        }

        public double getMaxDownLink()
        {
            return maxDownLink;
        }

    }
}
