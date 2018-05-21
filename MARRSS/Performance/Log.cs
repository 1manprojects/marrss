/**
* ----------------------------------------------------------------
* Nikolai Jonathan Reed 
*
* 
* Copyright (c) 2016, Nikolai Reed, 1manprojects.de
* All rights reserved.
*
* Licensed under
* Creative Commons Attribution NonCommercial (CC-BY-NC)
*/
using System;
using System.Collections.Generic;

namespace MARRSS.Performance
{
    class Log
    {
        private static string format = "dd-MM-yyyy_HHmmss";

        public static void writeLog(string name, string logLine)
        {
            //create save name String for all files that are saved automatacly
            DateTime time = DateTime.Now;
            Properties.Settings settings = Properties.Settings.Default;
            string file = settings.global_LogSavePath + "\\" + name + "-log.txt";

            using (System.IO.StreamWriter logwriter = new System.IO.StreamWriter(file, true))
            {
                logwriter.WriteLine(time.ToString(format) + ": " + logLine);
            }
        }

        public static void writeResults(string name, string schedulerName, List<string> results)
        {
            Properties.Settings settings = Properties.Settings.Default;
            string file = settings.global_ResultSavePath + "\\" + name + "-results.txt";
            using (System.IO.StreamWriter logwriter = new System.IO.StreamWriter(file, true))
            {
                logwriter.WriteLine("Results From Run " + schedulerName);
                foreach (string line in results)
                {
                    logwriter.WriteLine(line);
                }
            }
        }

    }
}
