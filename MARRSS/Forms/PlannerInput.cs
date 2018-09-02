using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MARRSS.Global;
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
            JPlan.dataRateType dataRate = JPlan.dataRateType.KByte_p_Second;
            switch(dataRateComboBox.SelectedIndex)
            {
                case 0:
                    dataRate = JPlan.dataRateType.Byte_p_Millisecond;
                    break;
                case 1:
                    dataRate = JPlan.dataRateType.Byte_p_Second;
                    break;
                case 2:
                    dataRate = JPlan.dataRateType.KByte_p_Millisecond;
                    break;
                case 3:
                    dataRate = JPlan.dataRateType.KByte_p_Second;
                    break;
                case 4:
                    dataRate = JPlan.dataRateType.MByte_p_Millisecond;
                    break;
                case 5:
                    dataRate = JPlan.dataRateType.MByte_p_Second;
                    break;
                default:
                    dataRate = JPlan.dataRateType.KByte_p_Second;
                    break;
            }

            Structs.DataSize satStorageType = Structs.DataSize.MBYTE;
            switch(satStorageComboBox.SelectedIndex)
            {
                case 0:
                    satStorageType = Structs.DataSize.BYTE;
                    break;
                case 1:
                    satStorageType = Structs.DataSize.KBYTE;
                    break;
                case 2:
                    satStorageType = Structs.DataSize.MBYTE;
                    break;
                case 3:
                    satStorageType = Structs.DataSize.GBYTE;
                    break;
                default:
                    satStorageType = Structs.DataSize.MBYTE;
                    break;
            }

            try
            {
                var CustomDataScenario = ScenarioClass.LoadDataScenarioFromCustomJson(textBox1.Text, dataRate, satStorageType);
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

        private void PlannerInput_Load(object sender, EventArgs e)
        {
            dataRateComboBox.SelectedIndex = 5;
            satStorageComboBox.SelectedIndex = 2;
        }
    }
}
