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
    public partial class ScenarioEditor : Form
    {
        private int step = 0;

        public ScenarioEditor()
        {
            InitializeComponent();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            scenarioTabControll.SelectedIndex = (scenarioTabControll.SelectedIndex + 1 < scenarioTabControll.TabCount) ?
                             scenarioTabControll.SelectedIndex + 1 : scenarioTabControll.SelectedIndex;
            step = scenarioTabControll.SelectedIndex;
            updateButtons();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            scenarioTabControll.SelectedIndex = (scenarioTabControll.SelectedIndex -1 >= 0) ?
                             scenarioTabControll.SelectedIndex - 1 : scenarioTabControll.SelectedIndex;
            step = scenarioTabControll.SelectedIndex;
            updateButtons();
        }

        private void selectAllSatsButton_Click(object sender, EventArgs e)
        {

        }

        private void onBoardStoargeSizeText_ValueChanged(object sender, EventArgs e)
        {
            usedStorageValueNum.Maximum = onBoardStoargeSizeText.Value;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void updateButtons()
        {
            scenNameButton.BackColor = Color.WhiteSmoke;
            scenSatellites.BackColor = Color.WhiteSmoke;
            scenStations.BackColor = Color.WhiteSmoke;
            scenNameButton.BackColor = Color.WhiteSmoke;
            scenContacts.BackColor = Color.WhiteSmoke;
            scenDescription.BackColor = Color.WhiteSmoke;
            scenDone.BackColor = Color.WhiteSmoke;
            switch (step)
            {
                case 0:
                    scenNameButton.BackColor = Color.LightSteelBlue;
                    break;
                case 1:
                    scenSatellites.BackColor = Color.LightSteelBlue;
                    break;
                case 2:
                    scenStations.BackColor = Color.LightSteelBlue;
                    break;
                case 3:
                    scenContacts.BackColor = Color.LightSteelBlue;
                    break;
                case 4:
                    scenDescription.BackColor = Color.LightSteelBlue;
                    break;
                case 5:
                    scenDone.BackColor = Color.LightSteelBlue;
                    break;
            }
        }
    }
}
