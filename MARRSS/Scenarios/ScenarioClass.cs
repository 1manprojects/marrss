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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MARRSS.Global;
using MARRSS.Satellite;

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
            sat.SetMaxDataStorage(maxDataStorage);
            sat.setCurrentlyUsedStorage(usedDataStorage);
            sat.setDataSize(dataSize);
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

        }

    }
}
