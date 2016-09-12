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

namespace MARRSS.Global
{
/**
* \brief Functions definition.
*
* This class contains global functions that are needed.
*/
    class Funktions
    {
        //! Create new Unique ID
        /*!
            \return GUID
            creates a new unique ID to identify objects
        */
        public static Guid CreateNewID()
        {
            return System.Guid.NewGuid();
        }

        //! Parse Enum from String
        /*!
            \param string
            Parses the String to the defined Enum T
        */
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        //! calculat ArcTan
        /*!
            \param double sinx
            \param double cosx
            \return double ArcTan(sinx,cosx)
        */
        public static double AcTan(double sinx, double cosx)
        {
            double ret;

            if (cosx == 0.0)
            {
                if (sinx > 0.0)
                {
                    ret = Math.PI / 2.0;
                }
                else
                {
                    ret = 3.0 * Math.PI / 2.0;
                }
            }
            else
            {
                if (cosx > 0.0)
                {
                    ret = Math.Atan(sinx / cosx);
                }
                else
                {
                    ret = Math.PI + Math.Atan(sinx / cosx);
                }
            }
            return ret;
        }
    }
}
