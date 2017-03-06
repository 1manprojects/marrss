using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MARRSS.Automated;
using MARRSS.Performance;
using One_Sgp4;
using MARRSS.DataBase;

namespace MARRSS.Forms
{
    public partial class AutomatedRunsForm : Form
    {
        private DataBase.DataBase database;
        private static string geneticDefault = "#Genetic Settings\n" +
                "# Settings\n" +
                "genetic_Population_Size=8;\n" +
                "genetic_Start_Percentage=65;\n" +
                "genetic_Mutation_Chance=1;\n" +
                "# Run for certain Generations\n" +
                "genetic_Run_For_MaxGen=true;\n" +
                "genetic_Max_Nr_of_Generations=10000;\n" +
                "# Run for certian Time in hours\n" +
                "genetic_Run_For_MaxTime=false;\n" +
                "genetic_RunTime=1.0;\n" +
                "# Handle Conflicts by priority\n" +
                "genetic_ConflictSolver=false;\n" +
                "# wenn done solve conflicts\n" +
                "genetic_SolveConflicts=false;\n" +
                "#END of SETTINGS";
        private static string hillclimberDefault = "#HillClimber Settings\n" +
                "# Settings\n" +
                "# Start with a random schedule to optimize\n" +
                "hill_randomStart=false;\n" +
                "# Max number of oplimizsation iterations\n" +
                "hill_maxNumberIterations=1000;\n" +
                "# Set Max Number of Iterations adaptive\n" +
                "hill_adaptiveMaxIterations=false;\n" +
                "#END of SETTINGS";


        private List<AutomatedRun> runList;
        private bool cancel = false;
        List<string> results;

        public AutomatedRunsForm()
        {
            InitializeComponent();
            OnLoad();
        }

        private void OnLoad()
        {
            database = new DataBase.DataBase();

            //database.connectDB();

            DateTime now = DateTime.Now;
            startDatePicker.Value = now.Date;
            startTimePicker.Value = now.ToUniversalTime();
            now = now.AddDays(1.0);
            stopDatePicker.Value = now.Date;
            stopTimePicker.Value = now.ToUniversalTime();

            schedulerComboBox.SelectedIndex = 0;
            List<string> objectiveFunctionnames = Forms.ObjectiveBuilderForm.getSavedObjectiveNames();
            for (int i = 0; i < objectiveFunctionnames.Count; i++)
                objectiveComboBox.Items.Add(objectiveFunctionnames[i]);
            if (objectiveComboBox.Items.Count > 0)
                objectiveComboBox.SelectedIndex = 0;
            comboScenarioBox.SelectedIndex = 0;

            database.displayAllSatellites(checkedSatellites);
            database.displayAllStations(checkedStations);

            validateRichTextBox();

            runList = new List<AutomatedRun>();
        }

        private void startTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void createNewRunToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addRunButton_Click(object sender, EventArgs e)
        {
            if (validateRichTextBox())
            {
                EpochTime startTime = new EpochTime(startTimePicker.Value.Hour, startTimePicker.Value.Minute,
                    startTimePicker.Value.Second, startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day);
                EpochTime stopTime = new EpochTime(stopTimePicker.Value.Hour, stopTimePicker.Value.Minute,
                  stopTimePicker.Value.Second, stopDatePicker.Value.Year, stopDatePicker.Value.Month, stopDatePicker.Value.Day);
                List<string> sats = new List<string>();
                for (int i = 0; i < checkedSatellites.Items.Count; i++)
                {
                    if (checkedSatellites.GetItemChecked(i))
                    {
                        sats.Add(checkedSatellites.Items[i].ToString());
                    }
                }
                List<string> sta = new List<string>();
                for (int i = 0; i < checkedStations.Items.Count; i++)
                {
                    if (checkedStations.GetItemChecked(i))
                    {
                        sta.Add(checkedStations.Items[i].ToString());
                    }
                }

                string sett = "";

                for (int i =0; i < SettingsRichTextBox.Lines.Count(); i++)
                {
                    string ln = SettingsRichTextBox.Lines[i];
                    if (ln[0] != '#')
                    {
                        int pos = ln.IndexOf('=');
                        sett += ln.Substring(pos+1);
                    }
                }

                AutomatedRun run = new AutomatedRun(schedulerComboBox.Items[schedulerComboBox.SelectedIndex].ToString(), startTime,
                    stopTime, sats, sta, comboScenarioBox.SelectedIndex, objectiveComboBox.Items[objectiveComboBox.SelectedIndex].ToString(),sett);
                runList.Add(run);
                runsListBox.Items.Add(run.ToString());
            }
        }

        private void AutomatedRunsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (database.connected())
                database.closeDB();
        }

        private void schedulerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = schedulerComboBox.SelectedIndex;
            // selected = 0: EFT:
            // selected = 1: Greedy;
            // selected = 2: Genetic;
            // selected = 3: HillClimber
            switch(selected)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
            restorDefaultsInSettingsBox();
        }

        private bool highlightLineContaining(RichTextBox rtb, int line, string search, Color color)
        {
            bool res = false;
            int c0 = rtb.GetFirstCharIndexFromLine(line);
            int c1 = rtb.GetFirstCharIndexFromLine(line + 1);
            if (c1 < 0) c1 = rtb.Text.Length;
            rtb.SelectionStart = c0;
            rtb.SelectionLength = c1 - c0;
            if (rtb.SelectedText.Contains(search))
            {
                rtb.SelectionColor = color;
                res = true;
            }
            rtb.SelectionLength = 0;
            return res;
        }

        private bool highlightLineNotContaining(RichTextBox rtb, int line, string search1, string search2, Color color)
        {
            bool res = false;
            int c0 = rtb.GetFirstCharIndexFromLine(line);
            int c1 = rtb.GetFirstCharIndexFromLine(line + 1);
            if (c1 < 0) c1 = rtb.Text.Length;
            rtb.SelectionStart = c0;
            rtb.SelectionLength = c1 - c0;
            if (!rtb.SelectedText.Contains(search1) && !rtb.SelectedText.Contains(search2) )
            {
                rtb.SelectionColor = color;
                res = true;
            }
            rtb.SelectionLength = 0;
            return res;
        }

        private bool highlightLineNotContaining(RichTextBox rtb, int line, string search1, Color color)
        {
            bool res = false;
            int c0 = rtb.GetFirstCharIndexFromLine(line);
            int c1 = rtb.GetFirstCharIndexFromLine(line + 1);
            if (c1 < 0) c1 = rtb.Text.Length;
            rtb.SelectionStart = c0;
            rtb.SelectionLength = c1 - c0;
            if (!rtb.SelectedText.Contains(search1))
            {
                rtb.SelectionColor = color;
                res = true;
            }
            rtb.SelectionLength = 0;
            return res;
        }

        private bool highlightLineContaining(RichTextBox rtb, int line, string search1, string search2, Color color)
        {
            bool res = false;
            int c0 = rtb.GetFirstCharIndexFromLine(line);
            int c1 = rtb.GetFirstCharIndexFromLine(line + 1);
            if (c1 < 0) c1 = rtb.Text.Length;
            rtb.SelectionStart = c0;
            rtb.SelectionLength = c1 - c0;
            if (rtb.SelectedText.Contains(search1) && !rtb.SelectedText.Contains(search2))
            {
                rtb.SelectionColor = color;
                res = true;
            }
            rtb.SelectionLength = 0;
            return res;
        }

        private void deleteCharsAfterSemiColon(RichTextBox rtb)
        {
            for (int i = 0; i < rtb.Lines.Count(); i++)
            {
                if (!rtb.Lines[i].Contains("#"))
                    if (!rtb.Lines[i].EndsWith(";"))
                    {
                        //Delete everyging after ;
                    }
            }
        }

        private bool validateRichTextBox()
        {
            bool result = true;
            for (int i = 0; i < SettingsRichTextBox.Lines.Count(); i++)
            {
                highlightLineContaining(SettingsRichTextBox, i, "#", Color.Green);
                bool result2 = highlightLineNotContaining(SettingsRichTextBox, i, ";", "#", Color.Red);
                bool result3 = highlightLineContaining(SettingsRichTextBox, i, " ", "#", Color.Red);
                if (!result2 == false || !result3 == false)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        private void restorDefaultsInSettingsBox()
        {
            SettingsRichTextBox.Clear();
            int selected = schedulerComboBox.SelectedIndex;
            // selected = 0: EFT:
            // selected = 1: Greedy;
            // selected = 2: Genetic;
            // selected = 3: HillClimber
            switch (selected)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    SettingsRichTextBox.Text = geneticDefault;
                    break;
                case 3:
                    SettingsRichTextBox.Text = hillclimberDefault;
                    break;
            }
            validateRichTextBox();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            restorDefaultsInSettingsBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (startButton.Text != "Cancel")
            {
                cancel = false;
                startButton.Text = "Cancel";
                startButton.BackColor = Color.Coral;
                startAutomatedRun();
            }
            else
            {
                cancel = true;
            }
            //Display Results
        }

        private void startAutomatedRun()
        {
            results = new List<string>();
            progressBar1.Value = 0;
            progressBar1.Maximum = runList.Count();
            results.Add("Results From Automated Run");
            results.Add(DateTime.Now.ToString());
            for (int i = 0; i < runList.Count; i++)
            {
                results.Add("###############");
                if (cancel == true)
                {
                    break;
                }
                string name = runsListBox.Items[i].ToString();
                results.Add(runList[i].getNameOfScheduler());
                results.Add("#Settings Used");
                results.Add(runList[i].getSettings());
                results.Add("Scenario:");
                results.Add(comboScenarioBox.Items[runList[i].getScenario()].ToString());
                results.Add("StartTime: " + runList[i].getStartTime().ToString() + " StopTime: "+runList[i].getStopTime().ToString());
                results.Add("Stations Used");
                results.AddRange(runList[i].getStation());
                results.Add("Satellites Used");
                results.AddRange(runList[i].getSatellites());
                runsListBox.Items[i] = "Running: " + runsListBox.Items[i].ToString();
                AutomatedRun currentRun = runList[i];
                bool res = runList[i].runThisRun();

                Application.DoEvents();
                if (res)
                {
                    runsListBox.Items[i] = "Done: " + name;
                    progressBar1.Value = i + 1;
                    results.AddRange(runList[i].getResults());
                }
                else
                {
                    runsListBox.Items[i] = "FAILED: " + name;
                    progressBar1.Value = i + 1;
                }
                results.Add("###############");
                Application.DoEvents();
            }
            startButton.Text = "Start Run";
            startButton.BackColor = Color.LightSkyBlue;
            cancel = false;

            Log.writeResults("AutomatedRun-"+ DateTime.Now.ToString("yyyyMMddHHmmss"), "Automated Run Results", results);

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Forms.ResultsForm resForm = new Forms.ResultsForm(results);
            resForm.ShowDialog();
        }
    }
}
