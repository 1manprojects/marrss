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
using MARRSS.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

        private const long Kb = 1000;
        private const long Mb = Kb * 1000;
        private const long Gb = Mb * 1000;
        private const long Tb = Gb * 1000;

        public static int getDataSize(double nrOfByte)
        {
            var calc = nrOfByte;
            var count = 0;
            while(calc > 1000)
            {
                calc = calc / 1000;
                count++;
            }
            return count;
        }

        public static string getDataSizeToString(double nrOfByte)
        {
            var calc = nrOfByte;
            var count = 0;
            while (calc > 1000)
            {
                calc = calc / 1000;
                count++;
            }
            var ret = "Byte";
            switch(count)
            {
                case 0:
                    ret = "Byte";
                    break;
                case 1:
                    ret = "KByte";
                    break;
                case 2:
                    ret = "MByte";
                    break;
                case 3:
                    ret = "GByte";
                    break;
                case 4:
                    ret = "TByte";
                    break;
                case 5:
                    ret = "PByte";
                    break;
                default:
                    ret = "ERROR";
                    break;
            }
            return ret;
        }

        public static string GetHumanReadableSize(double nrOfByte)
        {
            var calc = nrOfByte;
            while (calc > 1000)
            {
                calc = calc / 1000;
            }
            calc = Math.Round(calc, 3);
            return calc.ToString();
        }

        public static string EpochToHumanReadable(double epoch)
        {
            var d = Math.Floor(epoch);
            var r = epoch - d;
            var h = Math.Floor(r * 24);
            var m = Math.Floor((r - h) * 60);
            return string.Format("{0} days {1} hours {2} min",d,h,m);
        }

        public static double GetDuration(One_Sgp4.EpochTime start, One_Sgp4.EpochTime end)
        {
            if (end.getYear() == start.getYear())
            {
                var d = start.getEpoch() - end.getEpoch();
                return d * 86400;
            }
            else
            {
                var d = start.getEpoch() - 365.0;
                d += end.getEpoch();
                return d * 86400;
            }
        }
    }

    public class ToStringJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //var test = (One_Sgp4.EpochTime)value;
            //writer.WriteValue(test.toDateTime().ToString());
            writer.WriteValue(value.ToString());
        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
