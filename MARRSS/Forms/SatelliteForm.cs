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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MARRSS.Forms
{
    public partial class SatelliteForm : Form
    {
        public SatelliteForm()
        {
            InitializeComponent();
        }

        private DialogResult userSelect;
        private string tleFilePath;

        private string userName = null;
        private string password = null;

        private int errorCode = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            userSelect = openFileDialog1.ShowDialog();
            if (userSelect == DialogResult.OK)
            {
                tleFilePath = openFileDialog1.FileName;
                textFilePath.Text = tleFilePath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DataBase.DataBase db = new DataBase.DataBase();
            //if selected to import a txt- file containg TLE data
            if (radioButton1.Checked)
            {
                this.Cursor = Cursors.WaitCursor;
                List<One_Sgp4.Tle> satTleData = new List<One_Sgp4.Tle>();
                satTleData = One_Sgp4.ParserTLE.ParseFile(tleFilePath);
                for( int i = 0; i < satTleData.Count(); i++)
                {
                    db.writeTleData(satTleData[i]);
                }
            }
            //if selected to add TLE - Data Manuely 
            if (radioButton3.Checked)
            {
                this.Cursor = Cursors.WaitCursor;
                One_Sgp4.Tle satTleData = new One_Sgp4.Tle();
                satTleData = One_Sgp4.ParserTLE.parseTle(textTleLine1.Text, textTleLine2.Text, textNameID.Text);
                db.writeTleData(satTleData);
            }
            //if selected to load TLE - Data from Internet
            if (radioButton2.Checked)
            {
                string[] searchIDs = textBox1.Text.Split(',');
                Forms.Login loginForm = new Forms.Login(this);
                loginForm.ShowDialog();
                if (userName != null && password != null)
                {
                    this.Cursor = Cursors.WaitCursor;
                    string res = One_Sgp4.SpaceTrack.GetSpaceTrack(searchIDs, userName, password);
                    if (res.Count() > 0)
                    {
                        string[] tleLines = res.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                        if (tleLines.Count() >= 3)
                        {
                            for (int i = 0; i < tleLines.Count() - 1; i += 3)
                            {
                                One_Sgp4.Tle satTleData = new One_Sgp4.Tle();
                                satTleData = One_Sgp4.ParserTLE.parseTle(tleLines[i + 1], tleLines[i + 2], tleLines[i]);
                                db.writeTleData(satTleData);
                            }
                        }
                        else
                        {
                            errorCode = 1;
                            //error parsing information
                        }
                    }
                }
                else
                {
                    errorCode = 2;
                    //No UserName or Password were given
                }
            }
            if (radioButton4.Checked)
            {
                List<string> tleList = db.getAllNoradID();
                string[] searchIDs = new string[tleList.Count];

                for (int i = 0; i < tleList.Count; i++)
                {
                    searchIDs[i] = tleList[i];
                }

                Forms.Login loginForm = new Forms.Login(this);
                loginForm.ShowDialog();
                if (userName != null && password != null)
                {
                    this.Cursor = Cursors.WaitCursor;
                    string res = One_Sgp4.SpaceTrack.GetSpaceTrack(searchIDs, userName, password);
                    if (res.Count() > 0)
                    {
                        string[] tleLines = res.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                        if (tleLines.Count() >= 3)
                        {
                            for (int i = 0; i < tleLines.Count() - 1; i += 3)
                            {
                                One_Sgp4.Tle satTleData = new One_Sgp4.Tle();
                                satTleData = One_Sgp4.ParserTLE.parseTle(tleLines[i + 1], tleLines[i + 2], tleLines[i]);
                                db.writeTleData(satTleData);
                            }
                        }
                        else
                        {
                            errorCode = 1;
                            //error parsing information
                        }
                    }
                }
                else
                {
                    errorCode = 2;
                    //No UserName or Password were given
                }
            }
            db.closeDB();
            db = null;
            if (errorCode == 0)
            {
                this.Close();
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Unable to Update from Server.\n Login information could be wrong or server is not reachable", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SelectInputForm();
        }

        private void SatelliteForm_Load(object sender, EventArgs e)
        {

        }

        private void SelectInputForm()
        {
            if (radioButton1.Checked)
            {
                tabControl1.SelectedIndex = 0;
            }

            if (radioButton2.Checked)
            {
                tabControl1.SelectedIndex = 1;
            }

            if (radioButton3.Checked)
            {
                tabControl1.SelectedIndex = 2;
            }
            if (radioButton4.Checked)
            {
                tabControl1.Visible = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SelectInputForm();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SelectInputForm();
        }

        public void setPassword(string psw)
        {
            password = psw;
        }

        public void setLogin(string login)
        {
            userName = login;
        }

        public void setSelection(int i)
        {
            if (i == 0)
                radioButton1.Checked = true;
            if (i == 1)
                radioButton2.Checked = true;
            if (i == 2)
                radioButton3.Checked = true;
            if (i == 3)
                radioButton4.Checked = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                addButton.Text = "Update";
            }
            {
                addButton.Text = "ADD";
            }
        }
    }
}
