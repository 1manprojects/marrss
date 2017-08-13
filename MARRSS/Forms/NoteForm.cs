using System;
using System.Windows.Forms;

namespace MARRSS.Forms
{
    public partial class NoteForm : Form
    {
        private string headerText = "HeaderText";
        private string infoText = "info Test here";
        public NoteForm(String title, String info)
        {
            headerText = title;
            infoText = info;
            InitializeComponent();
        }

        private void header_Click(object sender, EventArgs e)
        {

        }

        private void NoteForm_Load(object sender, EventArgs e)
        {
            headerLabel.Text = headerText;
            infoLabelText.Text = infoText;
        }
    }
}
