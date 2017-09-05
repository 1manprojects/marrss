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
        public ScenarioEditor()
        {
            InitializeComponent();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            scenarioTabControll.SelectedIndex = (scenarioTabControll.SelectedIndex + 1 < scenarioTabControll.TabCount) ?
                             scenarioTabControll.SelectedIndex + 1 : scenarioTabControll.SelectedIndex;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            scenarioTabControll.SelectedIndex = (scenarioTabControll.SelectedIndex -1 >= 0) ?
                             scenarioTabControll.SelectedIndex - 1 : scenarioTabControll.SelectedIndex;
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
    }
}
