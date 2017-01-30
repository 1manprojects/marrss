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
using System.IO;


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
                Properties.Settings.Default.email = textBox1.Text;
                using (AesManaged aesEncrypt = new AesManaged())
                {
                    byte[] encryptedPwd = EncryptStringToByte(textBox2.Text, aesEncrypt.Key, aesEncrypt.IV);
                    string enc = Convert.ToBase64String(encryptedPwd);
                    Properties.Settings.Default.passwd = enc;
                    Properties.Settings.Default.ent = Convert.ToBase64String(aesEncrypt.IV);
                    Properties.Settings.Default.ent2 = Convert.ToBase64String(aesEncrypt.Key);
                }

            }
            else
            {
                Properties.Settings.Default.secure_SavedLogin = false;
                Properties.Settings.Default.ent = "0";
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
                
                textBox1.Text = Properties.Settings.Default.email;
                textBox2.Text = getPassword();

            }
        }

        private static byte[] EncryptStringToByte(string plain, byte[] key, byte[] ent)
        {
            if (plain == null || plain.Length <= 0)
                throw new ArgumentNullException("Plain Text");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (ent == null || ent.Length <= 0)
                throw new ArgumentNullException("ent");
            byte[] encrypted;
            using (AesManaged aes = new AesManaged())
            {
                aes.Key = key;
                aes.IV = ent;
                ICryptoTransform aesEncrypt = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, aesEncrypt,CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plain);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }

        private static string DecryptStringFromBytes(byte[] cipher, byte[] key, byte[] ent)
        {
            // Check arguments.
            if (cipher == null || cipher.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (ent == null || ent.Length <= 0)
                throw new ArgumentNullException("IV");

            string plain = null;
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = key;
                aesAlg.IV = ent;
                ICryptoTransform aesDecryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipher))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, aesDecryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plain = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }
            return plain;
        }

        public static string getPassword()
        {
            byte[] enc = Convert.FromBase64String(Properties.Settings.Default.passwd);
            byte[] key = Convert.FromBase64String(Properties.Settings.Default.ent2);
            byte[] ent = Convert.FromBase64String(Properties.Settings.Default.ent);
            string plain = DecryptStringFromBytes(enc, key, ent);
            return plain;
        }

    }
}
