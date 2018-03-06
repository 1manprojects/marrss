/**
* ----------------------------------------------------------------
* Nikolai Jonathan Reed 
*
* 
* Copyright (c) 2017, Nikolai Reed, 1manprojects.de
* All rights reserved.
*
* Licensed under
* Creative Commons Attribution NonCommercial (CC-BY-NC)
*/
using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;

using MARRSS.Global;
using MARRSS.Satellite;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace MARRSS.Scenarios
{
    class ScenarioClass
    {
        private string scenarioName;
        private List<Satellite.Satellite> satellitesToInclude;
        private List<String> stationsToInclude;
        private int contactsPercentage;
        private int minimumContactWindow;
        private string descriptionText;
        private string fileName;

        public ScenarioClass(string nameOfScenario)
        {
            scenarioName = nameOfScenario;
            minimumContactWindow = 0;

        }

        public void setName(string name)
        {
            scenarioName = name;
        }

        public void addSatelliteToScenario(Satellite.Satellite sat, Structs.priority priority,
            long maxDataStorage, long usedDataStorage, Structs.DataSize dataSize, string homeStation)
        {
            sat.setHomeStation(homeStation);
            sat.SetMaxDataStorage(maxDataStorage, dataSize);

            sat.setGlobalPriority(priority);

            satellitesToInclude.Add(sat);
        }

        public void addGroundStationToScenario(string stationName)
        {
            stationsToInclude.Add(stationName);
        }

        public void setContactPercentage(int percentage)
        {
            contactsPercentage = percentage;
        }

        public void setMinimumContactWindowLength(int lenghtMin)
        {
            minimumContactWindow = lenghtMin;
        }

        public void setDescription(string text)
        {
            descriptionText = text;
        }

        public void saveScenario()
        {
            //if (!File.Exists("scenarios.set"))
            //{

            //    using (XmlWriter writer = XmlWriter.Create("scenarios.set"))
            //    {
            //        writer.WriteStartDocument();
            //        writer.WriteStartElement("Scenarios");
            //        writer.WriteEndElement();
            //        writer.WriteEndDocument();
            //        writer.Dispose();
            //    }

            //}
            //else
            //{
            XmlWriter.Create("scenarios.set");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("scenarios.set");
                XmlNode root = xmlDoc.DocumentElement;
                //TODO: Check if name exists already and overwrite
                XmlNodeList children = root.ChildNodes;
                bool nodeExists = false;
                XmlNode oldNode = null;
                foreach (XmlNode node in children)
                {
                    if (node.Name == scenarioName)
                    {
                        nodeExists = true;
                        oldNode = node;
                        break;
                    }
                }

                //root.ReplaceChild

                XmlElement elem = xmlDoc.CreateElement(scenarioName);
                XmlElement sats = xmlDoc.CreateElement("Satellites");
                for (int i = 0; i < satellitesToInclude.Count; i++)
                {
                    sats.InnerText = satellitesToInclude[i].getName();
                    XmlElement sat = xmlDoc.CreateElement("Homestation");
                    sat.InnerText = satellitesToInclude[i].getHomeStation();
                }
                //sats.InnerText = w[0].ToString();
                elem.AppendChild(sats);
                //Xmll


                if (nodeExists && oldNode != null)
                {
                    root.ReplaceChild(elem, oldNode);
                }
                root.AppendChild(elem);
                xmlDoc.Save("scenarios.set");
            //}
        }

        public string getScenarioName()
        {
            return scenarioName;
        }

        public string getDescription()
        {
            return descriptionText;
        }

        public List<Satellite.Satellite> getSatelites()
        {
            return satellitesToInclude;
        }

        public List<string> getStations()
        {
            return stationsToInclude;
        }

        public void LoadScenario()
        {

        }

        public static JPlan LoadDataScenarioFromCustomJson(string filePath)
        {
            //@"D:\Programmieren\git\marrss\TIM___Nominal.json"
            JObject CustomJObject = JObject.Parse(File.ReadAllText(filePath));
            var res = CustomJObject.SelectToken("solution.plans.list");
            var ret = res.ToObject<List<JPlan>>();
            return ret.FirstOrDefault();            
        }

    }
}
