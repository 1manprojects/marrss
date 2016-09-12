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
using System.Globalization;
using System.Windows.Forms;
using System.IO;

namespace MARRSS.Forms
{
    public partial class StationForm : Form
    {
        private DialogResult userSelect;
        private string stationFilePath;

        public StationForm()
        {
            InitializeComponent();
        }

        private void canelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                //Manual Input
                DataBase.DataBase db = new DataBase.DataBase();
                double lat = double.Parse(textLat.Text, CultureInfo.GetCultureInfo("en-US"));
                double lon = double.Parse(textLon.Text, CultureInfo.GetCultureInfo("en-US"));
                double height = double.Parse(textHeight.Text, CultureInfo.GetCultureInfo("en-US"));
                Ground.Station station = new Ground.Station(textStationName.Text, lat, lon, height);

                db.writeStation(station);
                this.Close();
            }
            if (radioButton1.Checked)
            {
                using (var reader = new StreamReader(stationFilePath))
                {
                    DataBase.DataBase db = new DataBase.DataBase();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string _name;
                        double _latitude;
                        double _longitude;
                        double _height;
                        string[] res = line.Split(' ');
                        if (res.Count() >= 3)
                        {
                            _name = res[0];
                            _latitude = Convert.ToDouble(res[1]);
                            _longitude = Convert.ToDouble(res[2]);
                            if (res.Count() == 4)
                            {
                                _height = Convert.ToDouble(res[3]);
                            }
                            else
                            {
                                _height = 0.0;
                            }
                            Ground.Station station = new Ground.Station(_name, _latitude, _longitude, _height);
                            db.writeStation(station);
                        }
                    }
                }

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                tabControl1.SelectedIndex = 0;
            }
            if (radioButton3.Checked)
            {
                tabControl1.SelectedIndex = 1;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                tabControl1.SelectedIndex = 0;
            }
            if (radioButton3.Checked)
            {
                tabControl1.SelectedIndex = 1;
            }
        }

        private void StationForm_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            userSelect = openFileDialog1.ShowDialog();
            if (userSelect == DialogResult.OK)
            {
                stationFilePath = openFileDialog1.FileName;
                textFilePath.Text = stationFilePath;
            }
        }
    }
}
