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
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace MARRSS.Forms
{
    public partial class ObjectiveBuilderForm : Form
    {

        /*
            0: Priority
            1: Satellite Fairness
            2: Station Fairness
            3: Scheduled Duration
            4: Scheduled Contacts
        */
        private int[] wheight = { 0, 0, 0, 0, 0 };
        private int lastSelected = 0;

        public ObjectiveBuilderForm()
        {
            InitializeComponent();
            wheight = new int[5] { 0, 0, 0, 0, 0, };
            lastSelected = 0;
            ObjectivesPresetSelection.SelectedItem = 0;
        }

        private void addObjectiveButton_Click(object sender, EventArgs e)
        {
            int selected = availableObjectivesListBox.SelectedIndex;
            wheight[selected]++;
            updateSelectedObjectListBox(wheight);
        }

        private void updateSelectedObjectListBox(int[] objWheight)
        {
            selectedObjectiveListBox.Items.Clear();
            for (int i = 0; i < objWheight.Count(); i++)
            {
                string listObject = objWheight[i].ToString() + "X -";
                if (objWheight[i] >= 0)
                {
                    switch (i)
                    {
                        case 0:
                            listObject = listObject + " Priority";
                            break;
                        case 1:
                            listObject = listObject + " Satellite Fairness";
                            break;
                        case 2:
                            listObject = listObject + " Station Fairness";
                            break;
                        case 3:
                            listObject = listObject + " Scheduled Duration";
                            break;
                        case 4:
                            listObject = listObject + " Scheduled Contacts";
                            break;
                    }
                    selectedObjectiveListBox.Items.Add(listObject);
                }
            }
        }

        private void removeObjectiveButton_Click(object sender, EventArgs e)
        {
            int selected = selectedObjectiveListBox.SelectedIndex;
            if (selected < 0)
                selected = lastSelected;
            lastSelected = selected;
            if (wheight[selected] > 0)
                wheight[selected]--;
            updateSelectedObjectListBox(wheight);
        }

        private void ObjectivesPresetSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = ObjectivesPresetSelection.SelectedIndex;
            loadSavedObjective(ObjectivesPresetSelection.Items[selected].ToString());

        }

        private void ObjectiveBuilderForm_Load(object sender, EventArgs e)
        {
            loadSettings();
        }

        private void loadSettings()
        {
            List<string> names = getSavedObjectiveNames();
            //StringCollection savedObjectives = new StringCollection();
            //savedObjectives = Properties.Objective.Default.object_List;
            for (int i = 0; i < names.Count; i++)
                ObjectivesPresetSelection.Items.Add(names[i]);
            if (names.Count > 0)
                loadSavedObjective(names[0]);
            ObjectivesPresetSelection.SelectedIndex = 0;
        }

        private void loadSavedObjective(string name)
        {
            wheight = new int[5] { 0, 0, 0, 0, 0, };
            //StringCollection objective = (StringCollection)Properties.Objective.Default[name];
            int[] wh = getObjectiveValuesByName(name);
            for (int w = 0; w < wh.Count(); w++)
            {
                 wheight[w] = Convert.ToInt32(wh[w]);
            }
            updateSelectedObjectListBox(wheight);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = ObjectivesPresetSelection.Text;

            if (Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                writeObjectiveToXML(wheight, name);
            }
            else
            {
                MessageBox.Show("Name can only contain Letters and Numbers", "Illegal Arguments",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static Global.Structs.ObjectiveEnum[] getObjectiveEnumsByName(string name)
        {
            int[] w = getObjectiveValuesByName(name);
            List<int> items = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < w[i]; j++)
                    items.Add((i+1));
            }
            Global.Structs.ObjectiveEnum[] objectives = new Global.Structs.ObjectiveEnum[items.Count()];
            int count = 0;
            foreach (int item in items)
            {
                objectives[count] = (Global.Structs.ObjectiveEnum)item;
                count++;
            }
            return objectives;
        }

        public static void writeObjectiveToXML(int[] w, string name)
        {
            if (!File.Exists("objectives.set"))
            {

                using (XmlWriter writer = XmlWriter.Create("objectives.set"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Objectives");
                    writer.WriteStartElement(name);
                    writer.WriteElementString("Priority", w[0].ToString());
                    writer.WriteElementString("Satellite", w[1].ToString());
                    writer.WriteElementString("Station", w[2].ToString());
                    writer.WriteElementString("Duration", w[3].ToString());
                    writer.WriteElementString("Scheduled", w[4].ToString());
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Dispose();
                }

            }
            else
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("objectives.set");
                XmlNode root = xmlDoc.DocumentElement;
                //TODO: Check if name exists already and overwrite
                XmlNodeList children = root.ChildNodes;
                bool nodeExists = false;
                XmlNode oldNode = null;
                foreach (XmlNode node in children)
                {
                    if (node.Name == name)
                    {
                        nodeExists = true;
                        oldNode = node;
                        break;
                    }
                }

                    //root.ReplaceChild

                XmlElement elem = xmlDoc.CreateElement(name);
                XmlElement prio = xmlDoc.CreateElement("Priority");
                prio.InnerText = w[0].ToString();
                elem.AppendChild(prio);

                XmlElement sat = xmlDoc.CreateElement("Satellite");
                sat.InnerText = w[1].ToString();
                elem.AppendChild(sat);

                XmlElement sta = xmlDoc.CreateElement("Station");
                sta.InnerText = w[2].ToString();
                elem.AppendChild(sta);

                XmlElement dur = xmlDoc.CreateElement("Duration");
                dur.InnerText = w[3].ToString();
                elem.AppendChild(dur);

                XmlElement sch = xmlDoc.CreateElement("Scheduled");
                sch.InnerText = w[4].ToString();
                elem.AppendChild(sch);

                if (nodeExists && oldNode != null)
                {
                    root.ReplaceChild(elem, oldNode);
                }
                root.AppendChild(elem);
                xmlDoc.Save("objectives.set");
            }
        }

        public static List<string> getSavedObjectiveNames()
        {
            List<string> names = new List<string>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("objectives.set");
            XmlNode root = xmlDoc.DocumentElement;
            XmlNodeList children = root.ChildNodes;
            foreach (XmlNode node in children)
            {
                names.Add(node.Name);
            }
            return names;
        }


        private static int[] getObjectiveValuesByName(string name)
        {
            int[] res = new int[5] { 0, 0, 0, 0, 0, };
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("objectives.set");
            XmlNode root = xmlDoc.DocumentElement;
            XmlNodeList children = root.ChildNodes;
            foreach (XmlNode node in children)
            {
                if (node.Name == name)
                {
                    XmlNodeList childrenchildren = node.ChildNodes;
                    foreach (XmlNode child in childrenchildren)
                    {
                        string itemName = child.Name;
                        switch (itemName)
                        {
                            case "Priority":
                                res[0] = Convert.ToInt32(child.InnerText);
                                break;
                            case "Satellite":
                                res[1] = Convert.ToInt32(child.InnerText);
                                break;
                            case "Station":
                                res[2] = Convert.ToInt32(child.InnerText);
                                break;
                            case "Duration":
                                res[3] = Convert.ToInt32(child.InnerText);
                                break;
                            case "Scheduled":
                                res[4] = Convert.ToInt32(child.InnerText);
                                break;
                        }
                    }
                }
            }
            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
