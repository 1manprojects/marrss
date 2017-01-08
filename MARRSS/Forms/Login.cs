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
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

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
                Properties.Settings.Default.secure_SavedLogin = true;

                byte[] plaintext = Encoding.ASCII.GetBytes(textBox2.Text);

                byte[] entropy = new byte[20];
                using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(entropy);
                    Properties.Settings.Default.entropy = Encoding.ASCII.GetString(entropy);
                }
                byte[] ciphertext = ProtectedData.Protect(plaintext, entropy,
                    DataProtectionScope.LocalMachine);

                Properties.Settings.Default.email = textBox1.Text;
                string test = Encoding.ASCII.GetString(ciphertext);
                Properties.Settings.Default.passwd = Encoding.ASCII.GetString(ciphertext);
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.secure_SavedLogin = false;
                Properties.Settings.Default.entropy = "0";
                Properties.Settings.Default.email = "";
                Properties.Settings.Default.Save();
            }

            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Properties.Settings.Default.secure_SavedLogin;
            if (checkBox1.Checked)
            {
                try
                {
                    string test = Properties.Settings.Default.passwd;
                    byte[] entropy = Encoding.ASCII.GetBytes(Properties.Settings.Default.entropy);
                    byte[] ciphertext = Encoding.ASCII.GetBytes(Properties.Settings.Default.passwd);
                    byte[] plaintext = ProtectedData.Unprotect(ciphertext, entropy,
                        DataProtectionScope.LocalMachine);
                    textBox2.Text = Encoding.ASCII.GetString(plaintext);
                }
                catch (CryptographicException)
                {
                    MessageBox.Show("Error 1820 decoding login credentials", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
                textBox1.Text = Properties.Settings.Default.email;
            }
        }

    }
}
