/**
* ----------------------------------------------------------------
*
* Sgp4Thread.cs
*
* this is the Thread Class to run the sgp4 Calculations in diffrent threads
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
using System.Threading;

using MARRSS.Definition;
using MARRSS.TLE;

namespace MARRSS.SGP4
{
    class SGP4Thread
    {
        private List<Sgp4Data> results;
        private Tle satTleData;
        private TimeDate startTime;
        private TimeDate stopTime;
        private double tick;
        SatelliteDataVector dataVectorRes;

        public SGP4Thread(SatelliteDataVector dataVector, Tle tleData,
            TimeDate starttime, TimeDate stoptime, double step)
        {
            satTleData = tleData;
            startTime = starttime;
            stopTime = stoptime;
            tick = step;
            dataVectorRes = dataVector;
        }

        public SGP4Thread(Tle tleData,
            TimeDate starttime, TimeDate stoptime, double step)
        {
            satTleData = tleData;
            startTime = starttime;
            stopTime = stoptime;
            tick = step;
        }

        public void testFuckShit()
        {
            SGP4.Sgp4 sgp = new SGP4.Sgp4(satTleData, 0);
            sgp.runSgp4Cal(startTime, stopTime, tick / 60.0);
            dataVectorRes.addSatData(sgp.getRestults(), 11);
            sgp.clear();
            sgp = null;
        }

        public void testFuckShit2()
        {
            SGP4.Sgp4 sgp = new SGP4.Sgp4(satTleData, 0);
            sgp.runSgp4Cal(startTime, stopTime, tick / 60.0);
            results = new List<Sgp4Data>(sgp.getRestults());
            sgp.clear();
            sgp = null;
            satTleData = null;
            startTime = null;
            stopTime = null;
            dataVectorRes = null;
        }

        public List<Sgp4Data> getResults()
        {
            return results;
        }

        public void clear()
        {
            results.Clear();
            results = null;
            satTleData = null;
        }

        public string getName()
        {
            return "null";
        }

    }
}
