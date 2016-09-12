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
using System.Diagnostics;

namespace MARRSS.Performance
{
    /**
* \brief Time Measurment Class
*
* This class handles the time measurments to compare diffrent algorithms and 
* options against each other. This is achived by getting the timestamps
* at start and finish. 
*/
    class TimeMeasurement
    {

        long start; //!< long start time
        long stop; //!< long stop time

        //! Time Meassurment constructor.
        /*!
            creates a basic time meassurment object
        */
        public TimeMeasurement()
        {
            start = 0;
        }

        //! Activates the meassurement
        /*!
            gets the current timestamp and sets the starttime
        */
        public void activate()
        {
            start = Stopwatch.GetTimestamp();
        }

        //! deactivates the meassurement
        /*!
            gets the current timestamp and sets the stoptime
        */
        private void deactivate()
        {
            stop = Stopwatch.GetTimestamp();
        }

        //! Deactivates the meassurement and gets the meassured time
        /*!
            gets the current timestamp
        */
        public string getValueAndDeactivate()
        {
            deactivate();
            long frequenzy = Stopwatch.Frequency;
            float time = (float)(stop - start) / (float)frequenzy;
            Console.WriteLine("Time = " + time.ToString());
            return time.ToString();
        }

    }
}
