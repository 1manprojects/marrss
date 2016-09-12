/**
* Sgp4Data.cs 
* 
* Class to store data associated with the calculation of satellite positions
*
*
* Code for Orbit-calculation is based on the SPACETRACK REPORT NO. 3
* Revisiting Spacetrack Report #3: Rev 2
* David A. Vallado, Paul Cawford, Richard Hujsak, T.S. Kelso
* http://www.celestrak.com/publications/AIAA/2006-6753/
*
* code for Bachelor Thesis
*
* Copyright (c) 2015, Nikolai Reed, 1manprojects.de
* All rights reserved.
*
* Licensed under
* Creative Commons Attribution-NoDerivatives 4.0 International Public
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MARRSS.Definition;

namespace MARRSS.SGP4
{
    class Sgp4Data
    {

        private int satNumber = -1; /*!< Satellite Number of Data */
        
        //end not Needed here

        private Structs.point3D pos; /*!< 3D-pointData for position Data */
        private Structs.point3D vel; /*!< 3D-pointData for velocity Data */

        //! SGP4-Data constructor.
        /*!
        \param integer SateliteNumber.
        */
        public Sgp4Data( int satNr = -1)
        {
            satNumber = satNr;
        }

        //! set the Satellite Number.
        /*!
        \param int Nr.
        */
        public void setSatNumber(int Nr)
        {
            satNumber = Nr;
        }

        //! set the X-Coordinate for Position.
        /*!
        \param double X
        */
        public void setX(double x)
        {
            pos.x = x;
        }

        //! set the Y-Coordinate for Position.
        /*!
        \param double Y
        */
        public void setY(double y)
        {
            pos.y = y;
        }

        //! set the Z-Coordinate for Position.
        /*!
        \param double Z
        */
        public void setZ(double z)
        {
            pos.z = z;
        }

        //! set the x-Velocity.
        /*!
        \param double xdot
        */
        public void setXDot(double xdot)
        {
            vel.x = xdot;
        }

        //! set the y-Velocity.
        /*!
        \param double ydot
        */
        public void setYDot(double ydot)
        {
            vel.y = ydot;
        }

        //! set the z-Velocity.
        /*!
        \param double zdot
        */
        public void setZDot(double zdot)
        {
            vel.z = zdot;
        }


        //! Returns the Satellite Number.
        /*!
        \return double SateliteNr
        */
        public int getSatNumber()
        {
            return satNumber;
        }

        //! Returns the Position Data as a 3d-Point.
        /*!
        \return double x, y, z;
        */
        public Structs.point3D getPositonData()
        {
            return pos;
        }

        //! Returns the velocity Data as a 3d-Point.
        /*!
        \return double x, y, z;
        */
        public Structs.point3D getVelocityData()
        {
            return vel;
        }

        //! Returns the X Position.
        /*!
        \return double x
        */
        public double getX()
        {
            return pos.x;
        }

        //! Returns the Y Position.
        /*!
        \return double y
        */
        public double getY()
        {
            return pos.y;
        }

        //! Returns the Z Position.
        /*!
        \return double z
        */
        public double getZ()
        {
            return pos.z;
        }

        //! Returns the X Velocity.
        /*!
        \return double xDot
        */
        public double getXDot()
        {
            return vel.x;
        }

        //! Returns the Y Velocity.
        /*!
        \return double yDot
        */
        public double getYDot()
        {
            return vel.y;
        }

        //! Returns the Z Velocity.
        /*!
        \return double zDot
        */
        public double getZDot()
        {
            return vel.z;
        }

        //! Returns position as String.
        /*!
        \string double X Y Z
        */
        public string getPosDataString()
        {
            string result;
            result = pos.x.ToString() + " :: " + pos.y.ToString() + " :: " +
                pos.z.ToString();
            return result;
        }

        //! Returns velocity as String.
        /*!
        \string double XDot YDot ZDot
        */
        public string getVelDataString()
        {
            string result;
            result = vel.x.ToString() + " :: " + vel.y.ToString() + " :: " +
                vel.z.ToString();
            return result;
        }

        public void clear()
        {
            
        }
    }
}
