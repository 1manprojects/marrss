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
using System.Drawing;
using System.Threading.Tasks;

using MARRSS.Global;

namespace MARRSS.Definition
{
    /**
   * \brief GeoCoordinate class
   *
   * This class defnies the GeoCoordinates of Latetude, Longitude, hight and the
   * conversions to Earth Centerd Inertial.
   */
    class GeoCoordinate
    {
        private double latetude; //!< double Latetude in degree
        private double longitude; //!< double longitude in degree
        private double height; //!< double height in meters

        private const double a_Wgs72 = 6378.135; //!< double WGS72 const in Km
        private const double a_Wgs84 = 6378.137; //!< double WGS84 const in Km
        private const double f = 1.0 / 298.26;

        //! GeoCoordinate constructor.
        /*!
        \param double latetude
        \param double longitude
        \param double hight default 0.0
        */
        public GeoCoordinate(double _latetude, double _longitude,
                             double _height = 0.0)
        {
            latetude = _latetude;
            longitude = _longitude;
            height = _height;
        }

        //! Returns the GeoCoordinates as a string
        /*!
        \return string GeoCoordinate
        */
        public string toString()
        {
            string ret = "Lat: " + latetude +
                        " Long: " + longitude +
                        " Hight: " + height;
            return ret;
        }

        //! Returns the Latetude
        /*!
        \return double Latetude
        */
        public double getLatetude()
        {
            return latetude;
        }

        //! Returns the Longitude
        /*!
        \return double longitude
        */
        public double getLongitude()
        {
            return longitude;
        }

        //! Returns the height
        /*!
        \return double height
        */
        public double getHeight()
        {
            return height;
        }

        //! Convert to ECI
        /*!
        \param double SidrealTime
        \return point3D ECI-Position vector of the Coordinate
        */
        public Structs.point3D toECI(double siderealTime)
        {
            double srt = siderealTime;
            double lat_rad = Constants.toRadians * latetude;
            Structs.point3D eciPos = new Structs.point3D();

            double c = 1.0 / Math.Sqrt(1.0 + f * (f - 2.0) *
                       (Math.Sin(lat_rad) * Math.Sin(lat_rad) ));
            double s = (1.0 - f) * (1.0 - f) * c;
            eciPos.x = a_Wgs72 * c * Math.Cos(lat_rad) * Math.Cos(srt);
            eciPos.y = a_Wgs72 * c * Math.Cos(lat_rad) * Math.Sin(srt);
            eciPos.z = a_Wgs72 * s * Math.Sin(lat_rad);
            
            return eciPos;
        }

        public Point toPoint(int imageWidth, int imageHeight)
        {
            int x = (int)((imageWidth / 360.0) * (180 + longitude));
            int y = (int)((imageHeight / 180.0) * (90 - latetude));
            //double x = (longitude + 180.0) * (imageWidth / 360.0);
            //double latRad = latetude * Math.PI / 180.0;
            //double mercN = Math.Log(Math.Tan((Math.PI / 4.0) + (latRad / 2.0)));
            //double y = (imageHeight / 2.0) - (imageWidth * mercN / (2.0 * Math.PI));
            Point ret = new Point(x,y);
            //ret.X = Convert.ToInt32(x);
            //ret.Y = Convert.ToInt32(y);
            return ret;
        }

        
    }
}
