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
using MARRSS.Scheduler;
using MARRSS.Global;

namespace MARRSS.Ground
{
    /**
    * \brief InView Class definition.
    *
    * This class calculates the contact windows for each satellite to every
    * groundstation. For this the position vector of the satellite and the
    * coordinates of the groundstation need to be available. From the starting
    * time of the orbit calculation the azimuth, elevation and range to the
    * ground station are calculated and if the satellite is in view a new
    * ContactWindow will be created.  
    */
    class InView
    {
        private List<ContactWindow> results;

        private Station _station;
        private One_Sgp4.EpochTime _time;
        private List<One_Sgp4.Sgp4Data> _satPosData;
        private string _satName;
        private double _tick;

        //! InView constructor.
        /*!
            \param Station groundstation used to calculate visibilty
            \param One_Sgp4.EpochTime starttime
            \param List<One_Sgp4.Sgp4Data> satelliteposition list x,y,z coordinates
            \param string satellite name for to calculate visibilty
            \param double tick time dime difference between every coordinate set
        */
        public InView(Station groundstation, One_Sgp4.EpochTime time,
            List<One_Sgp4.Sgp4Data> satPosData, string satName, double tick)
        {
            results = new List<ContactWindow>();
            _station = groundstation;
            _time = time;
            _satPosData = satPosData;
            _satName = satName;
            _tick = tick;
        }

        //! Calculate ContactWindows for satellite and groundstations
        /*!
            \param Station to calcuate if satellite is in View
            \param TimeDate start time
            \param List<Sgp4Data> satellite position vector
            \param string name of the satellite
            \param double tick in witch time is increased by each step
            \return List<contactWindow> 
        */
        public void calcContactWindows()
        {
            One_Sgp4.EpochTime starttime = new One_Sgp4.EpochTime(_time);
            bool visible = false;
            ContactWindow window = null;
            double minElevation = _station.getMinElevation();

            for (int i =0; i < _satPosData.Count(); i++)
            {
                double lsr = starttime.getLocalSiderealTime(_station.getLongitude());
                Structs.point3D groundLocation = _station.getEci(lsr);

                Structs.point3D v = new Structs.point3D();
                v.x = _satPosData[i].getX() - groundLocation.x;
                v.y = _satPosData[i].getY() - groundLocation.y;
                v.z = _satPosData[i].getZ() - groundLocation.z;

                double r_lat = _station.getLatitude() * Constants.toRadians;

                double sin_lat = Math.Sin(r_lat);
                double cos_lat = Math.Cos(r_lat);
                double sin_srt = Math.Sin(lsr);
                double cos_srt = Math.Cos(lsr);

                
                double rs = sin_lat * cos_srt * v.x
                          + sin_lat * sin_srt * v.y
                          - cos_lat * v.z;
                double re = - sin_srt * v.x
                            + cos_srt * v.y;
                double rz = cos_lat * cos_srt * v.x
                            + cos_lat * sin_srt * v.y + sin_lat * v.z;

                double range = Math.Sqrt(rs * rs + re * re + rz * rz);
                double elevation = Math.Asin(rz / range);
                double azimuth = Math.Atan(-re / rs);

                if (rs > 0.0)
                {
                    azimuth += Constants.pi;
                }
                if (azimuth < 0.0)
                {
                    azimuth += Constants.twoPi;
                }

                if (elevation >= minElevation)
                {
                    if (visible == false)
                    {
                        window = new ContactWindow(_satName, _station.getName());
                        window.StartTime = new One_Sgp4.EpochTime(starttime);
                    }
                    visible = true;
                }
                else
                {
                    if (visible == true)
                    {
                        window.EndTime = new One_Sgp4.EpochTime(starttime);
                        results.Add(window);
                    }
                    visible = false;
                }
                azimuth = azimuth * Constants.toDegrees;
                starttime.addTick(_tick);
            }

        }

        //! returns result of calculations
        /*!
            \return List<contactWindow> 
        */
        public List<ContactWindow> getResults()
        {
            return results;
        }

    }
}
