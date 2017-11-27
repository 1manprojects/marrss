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
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Linq;

using System.Diagnostics;

using MARRSS.Scheduler;
using MARRSS.Definition;
using MARRSS.Global;

namespace MARRSS.DataBase
{
    class SaveLoad
    {

        //! Create and save all scheduling data
        /*! 
           \param string path and name of file to save
           \param ContactWindowsVector contacts to save
        */
        public static void saveToFile(string filePathName, ContactWindowsVector contacts, Main f)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            
            XmlWriter writer = XmlWriter.Create(filePathName, settings);
                writer.WriteStartDocument();
                writer.WriteStartElement("Contacts");
                writer.WriteElementString("StartYear", contacts.getStartTime().getYear().ToString());
                writer.WriteElementString("StartEpoch", contacts.getStartTime().getEpoch().ToString());
                writer.WriteElementString("StopYear", contacts.getStopTime().getYear().ToString());
                writer.WriteElementString("StopEpoch", contacts.getStopTime().getEpoch().ToString());
                List<ContactWindow> cwList = contacts.getAllContacts();
                f.setProgressBar(cwList.Count());
                int count = 0;
                foreach (ContactWindow cw in cwList)
	            {
                    writer.WriteStartElement("ContactWindow");
		                writer.WriteElementString("SatName", cw.getSatName());
                        writer.WriteElementString("StaName", cw.getStationName());
                        writer.WriteElementString("StartTime", cw.getStartTime().getEpoch().ToString());
                        writer.WriteElementString("StartYear", cw.getStartTime().getYear().ToString());
                        writer.WriteElementString("StopTime", cw.getStopTime().getEpoch().ToString());
                        writer.WriteElementString("StopYear", cw.getStopTime().getYear().ToString());
                        writer.WriteElementString("Scheduled", cw.getSheduledInfo().ToString());
                        writer.WriteElementString("Excluded", cw.getExclusion().ToString());
                        writer.WriteElementString("ID", cw.getID().ToString());
                        writer.WriteElementString("RequID", cw.getRequestID().ToString());
                        writer.WriteElementString("Priority", cw.getPriority().ToString());

                        //writer.WriteStartElement("TrackingData");
                        //    List<TrackingData> tdList = cw.getTrackingData();
                        //    foreach (TrackingData td in tdList)
                        //    {
                        //        writer.WriteStartElement("Data");
                        //        writer.WriteElementString("Azimuth", td.getAzimuth().ToString());
                        //        writer.WriteElementString("Elevation", td.getElevation().ToString());
                        //        writer.WriteElementString("Range", td.getRange().ToString());
                        //        writer.WriteElementString("RangeRate", td.getRangeRate().ToString());
                        //        writer.WriteElementString("TimeStamp", td.getTimeStamp());
                        //        writer.WriteEndElement();
                        //    }
                        writer.WriteEndElement();
		            writer.WriteEndElement();
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

            int startYear =  Int32.Parse( xmlDoc.SelectSingleNode("//Contacts/StartYear").InnerText);
            double startEpoch = double.Parse(xmlDoc.SelectSingleNode("//Contacts/StartEpoch").InnerText);
            int stopYear = Int32.Parse(xmlDoc.SelectSingleNode("//Contacts/StopYear").InnerText);
            double stopEpoch = double.Parse(xmlDoc.SelectSingleNode("//Contacts/StopEpoch").InnerText);
            One_Sgp4.EpochTime start = new One_Sgp4.EpochTime(startYear, startEpoch);
            One_Sgp4.EpochTime stop = new One_Sgp4.EpochTime(stopYear, stopEpoch);

            ContactWindowsVector saved = new ContactWindowsVector();
            saved.setStartTime(start);
            saved.setStopTime(stop);
            int count = 0;
            foreach (XmlNode node in dataNodes)
            {
                string sa = node.SelectSingleNode("SatName").InnerText;
                string st = node.SelectSingleNode("StaName").InnerText;
                int year = Int32.Parse(node.SelectSingleNode("StartYear").InnerText );
                double epoch = double.Parse(node.SelectSingleNode("StartTime").InnerText);
                ContactWindow cw = new ContactWindow(sa, st);
                One_Sgp4.EpochTime starttime = new One_Sgp4.EpochTime(year, epoch);
                cw.setStartTime(starttime);
                year = Int32.Parse(node.SelectSingleNode("StopYear").InnerText);
                epoch = double.Parse(node.SelectSingleNode("StopTime").InnerText);
                One_Sgp4.EpochTime stoptime = new One_Sgp4.EpochTime(year, epoch);
                cw.setStopTime(stoptime);
                if (node.SelectSingleNode("Scheduled").InnerText != "False")
                    cw.setSheduled();
                cw.setExclusion(bool.Parse(node.SelectSingleNode("Scheduled").InnerText));
                cw.setID( Guid.Parse(node.SelectSingleNode("ID").InnerText) );
                cw.setRequestID(Guid.Parse(node.SelectSingleNode("RequID").InnerText));
                cw.setPriority(Global.Funktions.ParseEnum<Global.Structs.priority>(node.SelectSingleNode("Priority").InnerText));

                //XmlNodeList children = node.SelectNodes("TrackingData/Data");
                //foreach (XmlNode childNode in children)
                //{
                //    double azi = double.Parse(childNode.SelectSingleNode("Azimuth").InnerText);
                //    double ele = double.Parse(childNode.SelectSingleNode("Elevation").InnerText);
                //    double ran = double.Parse(childNode.SelectSingleNode("Range").InnerText);
                //    double ranR = double.Parse(childNode.SelectSingleNode("RangeRate").InnerText);
                //    string time = childNode.SelectSingleNode("TimeStamp").InnerText;
                //    TrackingData td = new TrackingData(azi, ele, ran, time);
                //    cw.addTrackingData(td);
                //}
                f.updateProgressBar(count++);
                System.Windows.Forms.Application.DoEvents();
                saved.add(cw);
            }
            f.resetProgressBar();
            return saved;
        }
    }
}
