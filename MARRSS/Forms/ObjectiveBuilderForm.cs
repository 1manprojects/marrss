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
    public partial class ObjectiveBuilderForm : Form
    {

        /*
            0: Priority
            1: Satellite Fairness
            2: Station Fairness
            3: Scheduled Duration
            4: Scheduled Contacts
        */
        private int[] wheight = { 0,0,0,0,0 };
        private int lastSelected = 0;

        public ObjectiveBuilderForm()
        {
            InitializeComponent();
            wheight = new int[5] { 0, 0, 0, 0, 0, };
            lastSelected = 0;
            ObjectivesPresetSelection.SelectedItem = 0;
        }

        private void addObjectiveButton_Click(object sender, EventArgs e)
        {
            int selected = availableObjectivesListBox.SelectedIndex;
            wheight[selected]++;
            updateSelectedObjectListBox(wheight);
        }

        private void updateSelectedObjectListBox(int[] objWheight)
        {
            selectedObjectiveListBox.Items.Clear();
            for (int i = 0; i < objWheight.Count(); i++)
            {
                string listObject = objWheight[i].ToString() + "X -";
                if ( objWheight[i] >= 0)
                {
                    switch (i)
                    {
                        case 0:
                            listObject = listObject + " Priority";
                            break;
                        case 1:
                            listObject = listObject + " Satellite Fairness";
                            break;
                        case 2:
                            listObject = listObject + " Station Fairness";
                            break;
                        case 3:
                            listObject = listObject + " Scheduled Duration";
                            break;
                        case 4:
                            listObject = listObject + " Scheduled Contacts";
                            break;
                    }
                    selectedObjectiveListBox.Items.Add(listObject);
                }
            }
        }

        private void removeObjectiveButton_Click(object sender, EventArgs e)
        {
            int selected = selectedObjectiveListBox.SelectedIndex;
            if (selected < 0)
                selected = lastSelected;
            lastSelected = selected;
            if (wheight[selected] > 0)
                wheight[selected]--;
            updateSelectedObjectListBox(wheight);
        }

        private void ObjectivesPresetSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = ObjectivesPresetSelection.SelectedIndex;

        }
    }
}
