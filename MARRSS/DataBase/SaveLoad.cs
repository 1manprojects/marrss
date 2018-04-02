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
using System.Threading;
using MARRSS.Definition;
using System.IO;
using Newtonsoft.Json;
using System.Xml;
using MARRSS.Scheduler;
using System.Collections.Generic;
using System;

namespace MARRSS.DataBase
{
    class SaveLoad
    {

        //! Create and save all scheduling data
        /*! 
           \param string path and name of file to save
           \param ContactWindowsVector contacts to save
        */
        public static void saveToFile(string filePathName, ContactWindowsVector contacts, Main f, bool saveAll = true)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            XmlWriter writer = XmlWriter.Create(filePathName, settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("Contacts");
            writer.WriteElementString("StartYear", contacts.StartTime.getYear().ToString());
            writer.WriteElementString("StartEpoch", contacts.StartTime.getEpoch().ToString());
            writer.WriteElementString("StopYear", contacts.EndTime.getYear().ToString());
            writer.WriteElementString("StopEpoch", contacts.EndTime.getEpoch().ToString());
            List<ContactWindow> cwList = contacts.getAllContacts();
            f.setProgressBar(cwList.Count);
            int count = 0;
            foreach (ContactWindow cw in cwList)
            {
                if (saveAll || cw.getSheduledInfo())
                {
                    writer.WriteStartElement("ContactWindow");
                    writer.WriteElementString("SatName", cw.SatelliteName);
                    writer.WriteElementString("StaName", cw.StationName);
                    writer.WriteElementString("StartTime", cw.StartTime.getEpoch().ToString());
                    writer.WriteElementString("StartYear", cw.StartTime.getYear().ToString());
                    writer.WriteElementString("StopTime", cw.EndTime.getEpoch().ToString());
                    writer.WriteElementString("StopYear", cw.EndTime.getYear().ToString());
                    writer.WriteElementString("Scheduled", cw.getSheduledInfo().ToString());
                    writer.WriteElementString("Excluded", cw.Excluded.ToString());
                    writer.WriteElementString("ID", cw.Id);
                    writer.WriteElementString("RequID", cw.RequestId);
                    writer.WriteElementString("Priority", cw.Priority.ToString());

                    writer.WriteEndElement();
                }
                f.updateProgressBar(count++);
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
            writer.Dispose();
            f.resetProgressBar();
        }

            //! Open and Load saved scheduling data
            /*! 
               \param string path to Load file
               \param Main Form to update loading bar
            */
        public static ContactWindowsVector loadFile(string filepath, Main f)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);
            XmlNodeList dataNodes = xmlDoc.SelectNodes("//Contacts/ContactWindow");

            f.setProgressBar(dataNodes.Count);

            int startYear = Int32.Parse(xmlDoc.SelectSingleNode("//Contacts/StartYear").InnerText);
            double startEpoch = double.Parse(xmlDoc.SelectSingleNode("//Contacts/StartEpoch").InnerText);
            int stopYear = Int32.Parse(xmlDoc.SelectSingleNode("//Contacts/StopYear").InnerText);
            double stopEpoch = double.Parse(xmlDoc.SelectSingleNode("//Contacts/StopEpoch").InnerText);
            One_Sgp4.EpochTime start = new One_Sgp4.EpochTime(startYear, startEpoch);
            One_Sgp4.EpochTime stop = new One_Sgp4.EpochTime(stopYear, stopEpoch);

            ContactWindowsVector saved = new ContactWindowsVector();
            saved.StartTime = start;
            saved.EndTime = stop;
            int count = 0;
            foreach (XmlNode node in dataNodes)
            {
                string sa = node.SelectSingleNode("SatName").InnerText;
                string st = node.SelectSingleNode("StaName").InnerText;
                int year = Int32.Parse(node.SelectSingleNode("StartYear").InnerText);
                double epoch = double.Parse(node.SelectSingleNode("StartTime").InnerText);
                ContactWindow cw = new ContactWindow(sa, st);
                One_Sgp4.EpochTime starttime = new One_Sgp4.EpochTime(year, epoch);
                cw.StartTime = starttime;
                year = Int32.Parse(node.SelectSingleNode("StopYear").InnerText);
                epoch = double.Parse(node.SelectSingleNode("StopTime").InnerText);
                One_Sgp4.EpochTime stoptime = new One_Sgp4.EpochTime(year, epoch);
                cw.EndTime = stoptime;
                if (node.SelectSingleNode("Scheduled").InnerText != "False")
                    cw.setSheduled();
                cw.Excluded = (bool.Parse(node.SelectSingleNode("Scheduled").InnerText));
                cw.Id = (Guid.Parse(node.SelectSingleNode("ID").InnerText)).ToString();
                cw.RequestId = (Guid.Parse(node.SelectSingleNode("RequID").InnerText)).ToString();
                cw.Priority = (Global.Funktions.ParseEnum<Global.Structs.priority>(node.SelectSingleNode("Priority").InnerText));

                f.updateProgressBar(count++);
                System.Windows.Forms.Application.DoEvents();
                saved.add(cw);
            }
            f.resetProgressBar();
            return saved;
        }
    }
}
