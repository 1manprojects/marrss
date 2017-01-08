/**
* ----------------------------------------------------------------
* Nikolai Jonathan Reed 
*
* 
* Copyright (c) 2015, Nikolai Reed, 1manprojects.de
* All rights reserved.
*
* Licensed under
* Creative Commons Attribution NonCommercial (CC-BY-NC)
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MARRSS
{
/**
* \brief MainFunctions class
*
* This class contains functions and callbacks for interactions with the main form. This was done to shorten the Main.cs class to keep it shorter and
  easier to read.
*/
    class MainFunctions
    {
        private const int panelheight = 70;

        //! Animate panel buttons
        /*! 
           \param Panel parent panel to update
           \param Panel panelButton to animate opening and closing
        */
        public static void sidePanelAction(Panel parent, Panel panelButton)
        {
            if (panelButton.Visible)
            {
                for (int i = panelButton.Height; i >= 0; i--)
                {
                    panelButton.Height = i;
                    parent.Refresh();
                }
                panelButton.Visible = false;
            }
            else
            {
                panelButton.Visible = true;
                for (int i = 0; i <= panelheight; i++)
                {
                    panelButton.Height = i;
                    parent.Refresh();
                }
            }
        }

        //! set Progressbar to defined max Value and reset
        /*! 
           \param ToolStripProgressBar progress bar
           \param int max Value
        */
        public static void setProgressBar(ToolStripProgressBar bar, int max)
        {
            bar.Maximum = max;
            bar.Minimum = 0;
        }

        //! update ProgressBar 
        /*! 
           \param ToolStripProgressBar progress bar
           \param int Value
        */
        public static void updateProgressBar(ToolStripProgressBar bar, int value)
        {
            int percent = 100 * value / bar.Maximum;
            //toolStripStatusLabel3.Text = "Status: " + percent.ToString() +"%";
            bar.Value = value;
            bar.ProgressBar.Refresh();
        }

        //! incremenat progressbar by one
        /*! 
           \param ToolStripProgressBar progress bar
        */
        public static void incrementProgressBar(ToolStripProgressBar bar)
        {
            bar.Increment(1);
            bar.ProgressBar.Refresh();
            if (bar.Value >= bar.Maximum)
            {
                bar.Value = 0;
            }
        }

        //! reset ProgressBar
        /*! 
           \param ToolStripProgressBar progress bar
        */
        public static void resetProgressBar(ToolStripProgressBar bar)
        {
            bar.Value = 0;
            bar.ProgressBar.Refresh();
        }

        //! set Status Text in the ToolStrip
        /*! 
           \param ToolStripStatusLabel label
           \param string text
        */
        public static void setStatusText(ToolStripStatusLabel label ,string text)
        {
            label.Text = "Status: " + text;
        }

        //! returns the selected accuracy
        /*! 
           \param int selectedIndex of selectTextBox
           \return double accuracy of calculation
        */
        public static double selectAccuracy(int index)
        {
            double accuracy = 0.5;
            switch (index)
            {
                case 0:
                    accuracy = 0.5;
                    break;
                case 1:
                    accuracy = 1.0;
                    break;
                case 2:
                    accuracy = 5.0;
                    break;
                case 3:
                    accuracy = 10.0;
                    break;
                case 4:
                    accuracy = 30.0;
                    break;
                case 5:
                    accuracy = 60.0;
                    break;
            }
            return accuracy;
        }



    }
}
