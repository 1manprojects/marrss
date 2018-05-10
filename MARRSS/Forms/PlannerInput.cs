using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MARRSS.Scenarios;

namespace MARRSS.Forms
{
    public partial class PlannerInput : Form
    {
        private Main mainForm;
        public PlannerInput(Main form)
        {
            mainForm = form;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var CustomDataScenario = ScenarioClass.LoadDataScenarioFromCustomJson(textBox1.Text);
                if (radioButton1.Checked)
                    CustomDataScenario.setTimeSpansToUse(0);
                if (radioButton2.Checked)
                    CustomDataScenario.setTimeSpansToUse(1);
                if (radioButton3.Checked)
                    CustomDataScenario.setTimeSpansToUse(2);
                mainForm.LoadCustomScenario(CustomDataScenario);
                Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error could not Load JsonFile", ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult userSelect = openFileDialog1.ShowDialog();
            if (userSelect == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }
    }
}
