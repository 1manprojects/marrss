﻿using System;
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
    public partial class Scenarios : Form
    {
        public Scenarios()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            Forms.ScenarioEditor scenarioEditor = new Forms.ScenarioEditor();
            scenarioEditor.ShowDialog();
        }

        private void editButton_Click(object sender, EventArgs e)
        {

        }

        private void saveScenarios()
        {

        }

        private void LoadScenarios()
        {

        }
    }
}
