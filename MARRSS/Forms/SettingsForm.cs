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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MARRSS.Forms
{
    public partial class SettingsForm : Form
    {

        Properties.Settings settings = Properties.Settings.Default;
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void settingsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selection = settingsTreeView.SelectedNode.Text;
            settingsLocationText.Text = selection;

            switch (selection)
            {
                case "Orbit":
                    {
                        OrbitPanel.BringToFront();
                        break;
                    }
                case "Scheduler":
                    {
                        GeneticPanel.BringToFront();
                        break;
                    }
                case "Genetic":
                    {
                        GeneticPanel.BringToFront();
                        break;
                    }
                case "EFT(Earliest Finsish Time)":
                    {
                        EFTPanel.BringToFront();
                        break;
                    }
                case "Fair Greedy":
                    {
                        FairPanel.BringToFront();
                        break;
                    }
                case "Logging":
                    {
                        LoggingPanel.BringToFront();
                        break;
                    }
                case "TLE-Data":
                    {
                        Tlepanel.BringToFront();
                        break;
                    }
                default:
                    {
                        GlobalPanel.BringToFront();
                        break;
                    }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            settings.global_AutoSave = AutoSaveCheckBox.Checked;
            settings.global_SaveSchedule = AutoScheduleCheckBox.Checked;
            settings.global_SaveContacts = AutoContactsCheckBox.Checked;
            if (AutoSaveCheckBox.Checked)
            {
                AutoScheduleCheckBox.Enabled = true;
                AutoContactsCheckBox.Enabled = true;
            }
            else
            {
                AutoScheduleCheckBox.Enabled = false;
                AutoContactsCheckBox.Enabled = false;
            }
            settings.global_MaxPerf = MaxPerformanceCheckBox.Checked;
            settings.global_Save_Path = SavePathTextBox.Text;
            settings.global_Random_Seed = Convert.ToInt32( RandSeedTextBox.Text );
            settings.global_ShowLog = showLogCheckBox.Checked;

            settings.genetic_Population_Size = Convert.ToInt32( genPopsize.Value );
            settings.genetic_Start_Percentage = Convert.ToInt32(genStartChance.Value);
            settings.genetic_Mutation_Chance = Convert.ToInt32(genMutation.Value);
            settings.genetic_Max_Nr_of_Generations = Convert.ToInt32(genMaxGen.Value);
            settings.genetic_RunTime = Convert.ToDouble(genMaxTime.Value);
            settings.genetic_ConflictSolver = checkConflictHandling.Checked;
            settings.genetic_SolveContflicts = checkSolveConflicts.Checked;

            settings.orbit_Calculation_Accuracy_select = accuracySelect.SelectedIndex;
            settings.orbit_Minimum_Contact_Duration_sec = Convert.ToInt32(minDurationTextBox.Text);
            settings.orbit_Minimum_Elevation_deg = Convert.ToInt32(minElevationTextBox.Text);
            if ( wgs84RadioButton.Checked)
            {
                settings.orbit_Wgs = 1;
            }
            if (wgs72RadioButton.Checked)
            {
                settings.orbit_Wgs = 0;
            }

            settings.log_AutoSave_Results = autoSaveResultsCheckBox.Checked;
            settings.log_AutoSave_RunLog = saveLogFileCheckBox.Checked;
            settings.global_LogSavePath= saveLogPathTextBox.Text;
            settings.global_ResultSavePath = saveResultsPathTextBox.Text;

            settings.gloabal_LogFitness = logFitnessCheckBox.Checked;
            settings.log_ShowLog = showLogCheckBox.Checked;

            settings.Save();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void genMaxGen_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            settingsTreeView.ExpandAll();

            AutoSaveCheckBox.Checked = settings.global_AutoSave;
            AutoScheduleCheckBox.Checked = settings.global_SaveSchedule;
            AutoContactsCheckBox.Checked = settings.global_SaveContacts;
            if (AutoSaveCheckBox.Checked)
            {
                AutoScheduleCheckBox.Enabled = true;
                AutoContactsCheckBox.Enabled = true;
            }
            else
            {
                AutoScheduleCheckBox.Enabled = false;
                AutoContactsCheckBox.Enabled = false;
            }
            MaxPerformanceCheckBox.Checked = settings.global_MaxPerf;
            SavePathTextBox.Text = settings.global_Save_Path;
            RandSeedTextBox.Text = settings.global_Random_Seed.ToString();
            showLogCheckBox.Checked = settings.global_ShowLog;

            genPopsize.Value = settings.genetic_Population_Size;
            genStartChance.Value = settings.genetic_Start_Percentage;
            genMutation.Value = settings.genetic_Mutation_Chance;
            genMaxGen.Value = settings.genetic_Max_Nr_of_Generations;
            genMaxTime.Value = Convert.ToDecimal(settings.genetic_RunTime);
            checkConflictHandling.Checked = settings.genetic_ConflictSolver;
            checkSolveConflicts.Checked = settings.genetic_SolveContflicts;

            accuracySelect.SelectedIndex = settings.orbit_Calculation_Accuracy_select;
            minDurationTextBox.Text = settings.orbit_Minimum_Contact_Duration_sec.ToString();
            minElevationTextBox.Text = settings.orbit_Minimum_Elevation_deg.ToString();
            if (settings.orbit_Wgs == 1)
            {
                wgs84RadioButton.Checked = true;
                wgs72RadioButton.Checked = false;
            }
            else
            {
                wgs84RadioButton.Checked = false;
                wgs72RadioButton.Checked = true;
            }

            autoSaveResultsCheckBox.Checked = settings.log_AutoSave_Results;
            saveLogFileCheckBox.Checked = settings.log_AutoSave_RunLog;

            tleAutoUpdateCheckBox.Checked = settings.tle_AutoUpdate;
            if (tleAutoUpdateCheckBox.Checked)
            {
                tlegroupBox.Enabled = true;
            }
            else
            {
                tlegroupBox.Enabled = false;
            }
            if (settings.tle_UpdateTime == 0)
            {
                tleStartUpRadioButton.Checked = true;
                tlehourlyradioButton.Checked = false;
            }

            saveLogPathTextBox.Text = settings.global_LogSavePath;
            saveResultsPathTextBox.Text = settings.global_ResultSavePath;
            showLogCheckBox.Checked = settings.log_ShowLog;
            logFitnessCheckBox.Checked = settings.gloabal_LogFitness;

        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {

        }

        private void deleteCredentialsButton_Click(object sender, EventArgs e)
        {
            settings.tle_AutoUpdate = false;
            settings.passwd = "";
            settings.email = "";
            settings.Save();
            tleAutoUpdateCheckBox.Checked = settings.tle_AutoUpdate;
            if (tleAutoUpdateCheckBox.Checked)
            {
                tlegroupBox.Enabled = true;
            }
            else
            {
                tlegroupBox.Enabled = false;
            }
            if (settings.tle_UpdateTime == 0)
            {
                tleStartUpRadioButton.Checked = true;
                tlehourlyradioButton.Checked = false;
            }
        }

        private void saveLogFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AutoSaveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoSaveCheckBox.Checked)
            {
                AutoContactsCheckBox.Enabled = true;
                AutoScheduleCheckBox.Enabled = true;
            }
            else
            {
                AutoContactsCheckBox.Enabled = false;
                AutoScheduleCheckBox.Enabled = false;
            }
        }

        private void savePathButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SavePathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                saveResultsPathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                saveLogPathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
