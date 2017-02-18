using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MARRSS.DataBase;

namespace MARRSS.Forms
{
    public partial class AutomatedRunsForm : Form
    {
        private DataBase.DataBase database;
        private static string geneticDefault = "#Genetic Settings\n" +
                "Name=Genetic;\n" +
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
                "Name=HillClimber;\n" +
                "# Settings\n" +
                "# Start with a random schedule to optimize\n" +
                "hill_randomStart=false;\n" +
                "# Max number of oplimizsation iterations\n" +
                "hill_maxNumberIterations=1000;\n" +
                "# Set Max Number of Iterations adaptive\n" +
                "hill_adaptiveMaxIterations=false;\n" +
                "#END of SETTINGS";
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

        private void highlightLineContaining(RichTextBox rtb, int line, string search, Color color)
        {
            int c0 = rtb.GetFirstCharIndexFromLine(line);
            int c1 = rtb.GetFirstCharIndexFromLine(line + 1);
            if (c1 < 0) c1 = rtb.Text.Length;
            rtb.SelectionStart = c0;
            rtb.SelectionLength = c1 - c0;
            if (rtb.SelectedText.Contains(search))
                rtb.SelectionColor = color;
            rtb.SelectionLength = 0;
        }

        private void highlightLineNotContaining(RichTextBox rtb, int line, string search1, string search2, Color color)
        {
            int c0 = rtb.GetFirstCharIndexFromLine(line);
            int c1 = rtb.GetFirstCharIndexFromLine(line + 1);
            if (c1 < 0) c1 = rtb.Text.Length;
            rtb.SelectionStart = c0;
            rtb.SelectionLength = c1 - c0;
            if (!rtb.SelectedText.Contains(search1) && !rtb.SelectedText.Contains(search2) )
                rtb.SelectionColor = color;
            rtb.SelectionLength = 0;
        }

        private void highlightLineNotContaining(RichTextBox rtb, int line, string search1, Color color)
        {
            int c0 = rtb.GetFirstCharIndexFromLine(line);
            int c1 = rtb.GetFirstCharIndexFromLine(line + 1);
            if (c1 < 0) c1 = rtb.Text.Length;
            rtb.SelectionStart = c0;
            rtb.SelectionLength = c1 - c0;
            if (!rtb.SelectedText.Contains(search1))
                rtb.SelectionColor = color;
            rtb.SelectionLength = 0;
        }

        private void highlightLineContaining(RichTextBox rtb, int line, string search1, string search2, Color color)
        {
            int c0 = rtb.GetFirstCharIndexFromLine(line);
            int c1 = rtb.GetFirstCharIndexFromLine(line + 1);
            if (c1 < 0) c1 = rtb.Text.Length;
            rtb.SelectionStart = c0;
            rtb.SelectionLength = c1 - c0;
            if (rtb.SelectedText.Contains(search1) && !rtb.SelectedText.Contains(search2))
                rtb.SelectionColor = color;
            rtb.SelectionLength = 0;
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
            bool result = false;
            for (int i = 0; i < SettingsRichTextBox.Lines.Count(); i++)
            {
                highlightLineContaining(SettingsRichTextBox, i, "#", Color.Green);
                highlightLineNotContaining(SettingsRichTextBox, i, ";", "#", Color.Red);
                highlightLineContaining(SettingsRichTextBox, i, " ", "#", Color.Red);
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

        }
    }
}
