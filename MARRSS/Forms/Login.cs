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
    public partial class Login : Form
    {
        private SatelliteForm parent;

        public Login(SatelliteForm Parent)
        {
            InitializeComponent();
            parent = Parent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parent.setPassword(textBox2.Text);
            parent.setLogin(textBox1.Text);
            
            if (checkBox1.Checked)
            {
                //Store Password securly
                //TODO
            }

            this.Close();
        }
    }
}
