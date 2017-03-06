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
    public partial class ResultsForm : Form
    {
        List<string> resultsToDisplay;

        public ResultsForm(List<string> results)
        {
            InitializeComponent();
            resultsToDisplay = results;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void displayResults(List<string> results)
        {
            for (int i = 0; i < results.Count; i++)
            {
                richTextBox1.AppendText(results[i] + "\n");
            }
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < resultsToDisplay.Count; i++)
            {
                richTextBox1.AppendText(resultsToDisplay[i] + "\n");
            }
        }
    }
}
