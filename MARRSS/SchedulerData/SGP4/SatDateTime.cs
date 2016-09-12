/**
* ----------------------------------------------------------------
*
* SatDateTime.cs
*
* this file contains the Date Time for TLE elements and conversions
* for epoch to a Date Time format 
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
using System.Globalization;

namespace MARRSS.SGP4
{
    class SatDateTime
    {
        private int year; /*!<int Year */
        private int month; /*!< int Month*/
        private int day; /*!< int Day */
        private int hour; /*!< int Hour*/
        private int min; /*!< int Minutes*/
        private double sec; /*!< double Seconds*/

        private int dayOfYear;
        private double epoch;

        //! SatDateTime constructor.
        /*!
        */
        public SatDateTime()
        {

        }

        //! DateTime constructor.
	    /*!
	    \param int EpochYear
	    \param double EpochDay
	    Converts Epoch to DateTime Format
	    */
        public SatDateTime(int epochYear, double epochDay)
        {
            // ---------------- temp fix for years from 1957-2056 -------------------
            // --------- correct fix will occur when year is 4-digit in tle ---------
            if (epochYear < 50)
                year = epochYear + 2000;
            else
                year = epochYear + 1900;

            epoch = epochDay;
            dayOfYear = Convert.ToInt32(Math.Floor(epochDay));
            daysToMDhms();
        }

        //! DateTime constructor.
        /*!
        Converts Epoch to DateTime Format
        */
        public SatDateTime(int YY, int MM, int DD, int HH, int m, double s)
        {
            year = YY;
            month = MM;
            day = DD;
            hour = HH;
            min = m;
            sec = s;
        }

        //! Returns the Date and Time as a readable format
        /*!
        \return string DateTime
        */
        public string toString()
        {
            return day + "-" + month + "-" + year + "_" + hour + ":" + min + ":"
                + sec;
        }


        //! Returns the Date and Time in JulianDate
        /*!
        \return double JulianDate
        */
        public double toJulianDate()
        {
            double a = Math.Floor((14.0 - month) / 12.0);
            double y = year + 4800 - a;
            double m = month + 12 * a - 3;
            double jd = day + Math.Floor((153 * m + 2) / 5) + 365 * y + Math.Floor(y / 4) - Math.Floor(y / 100)
                   + Math.Floor(y / 400) - 32045;
            jd = jd - 0.5;
            double t = (hour + ((min + (sec / 60.0)) / 60.0)) / 24.0;
            jd = jd + t;
            return jd;
        }


        void daysToMDhms()
        {
            int[] months = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if( year % 4 == 0)
            {
                months[1] = 29; 
            }
            int i = 1;
            int temp = 0;
            int dY = dayOfYear;

            while( dY > temp + months[i - 1] && i < 12 )
            {
                temp = temp + months[i - 1];
                i++;
            }
            month = i;
            day = dayOfYear - temp;

            double time = (epoch - dayOfYear) * 24.0;
            hour = Convert.ToInt32(Math.Floor(time));
            time = (time - hour) * 60.0;
            min = Convert.ToInt32(Math.Floor(time));
            sec = (time - min) * 60.0;
        }

        }
}
