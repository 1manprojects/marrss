/**
* ----------------------------------------------------------------
* Nikolai Jonathan Reed 
*
* 
* Copyright (c) 2018, Nikolai Reed, 1manprojects.de
* All rights reserved.
*
* Licensed under
* Creative Commons Attribution NonCommercial (CC-BY-NC)
*/

using System;
using System.Collections.Generic;

namespace MARRSS.Scenarios
{
    /**
    * \brief JPlan Class
    *
    * This class defines the elements that are read from a json file to generate
    * a custom data storage scenario for satellites.
    */
    public class JPlan
    {
        public int count { get; set; }
        public int supid { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public JPlanTemp temporalModule { get; set; }
        public List<JPlanTimeLine> timelines { get; set; }

    }

    public class JPlanTemp
    {
        public string type { get; set; }
        public string timeScale { get; set; }
        public string timeStamp { get; set; }
        public string timeInterval { get; set; }
        public string timeDistance { get; set; }
        public string timeZone { get; set; }
        public DateTime origin { get; set; }
        public DateTime horizon { get; set; }
    }

    public class JPlanTimeLine
    {
        public int index { get; set; }
        public int supid { get; set; }
        public JPlanTimeName name { get; set; }
        public string type { get; set; }
        public string source { get; set; }
        public List<JPlanValues> values { get; set; }
        public string value { get; set; }

    }

    public class JPlanValues
    {
        public int index { get; set; }
        public int supid { get; set; }
        public string value { get; set; }
        public JPlanverfifiers verifier { get; set; }
        public JPlanTimes time { get; set; }
        public JPlanDuration duration { get; set; }
    }

    public class JPlanDuration
    {
        public string lb { get; set; }
        public string ub { get; set; }

        public TimeSpan LowerBoundToTimeSpan()
        {
            string[] ydhms = lb.Split(':');
            string[] ssff = ydhms[4].Split('.');
            return new TimeSpan(Int32.Parse(ydhms[1]), Int32.Parse(ydhms[2]), Int32.Parse(ydhms[3]),
                Int32.Parse(ssff[0]), Int32.Parse(ssff[1]));
        }

        public TimeSpan UperBoundToTimeSpan()
        {
            string[] ydhms = ub.Split(':');
            string[] ssff = ydhms[4].Split('.');
            return new TimeSpan(Int32.Parse(ydhms[1]), Int32.Parse(ydhms[2]), Int32.Parse(ydhms[3]),
                Int32.Parse(ssff[0]), Int32.Parse(ssff[1]));
        }
    }

    public class JPlanverfifiers
    {
        public string source { get; set; }
        public string target { get; set; }
    }

    public class JPlanTimes
    {
        public DateTime lb { get; set; }
        public DateTime ub { get; set; }
    }

    public class JPlanTimeName
    {
        public string component { get; set; }
        public string label { get; set; }
        public string id { get; set; }
    }
}
