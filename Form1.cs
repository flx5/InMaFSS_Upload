using InMaFSS.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InMaFSS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Settings Settings = Settings.Default;
            txt_url.Text = Settings.URL;
            txt_consumer_key.Text = Settings.ConsumerKey;
            txt_consumer_secret.Text = Settings.ConsumerSecret;

            lst_files.Items.Clear();

            if (Settings.Files != null)
            {
                foreach (String item in Settings.Files)
                {
                    lst_files.Items.Add(item);
                }
            }

            btn_upload.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.AddExtension = true;
            fileDialog.CheckPathExists = true;
            fileDialog.DefaultExt = "html";
            fileDialog.Filter = "HTML/Word/Kalender Dateien (*.html; *.docx; *.ics) | *.html; *.docx; *.ics";
            fileDialog.Multiselect = true;
            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                foreach (String file in fileDialog.FileNames)
                {
                    if(!lst_files.Items.Contains(file))
                        lst_files.Items.Add(file);
                }
                btn_upload.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (int itemId in lst_files.SelectedIndices)
            {
                lst_files.Items.RemoveAt(itemId);
            }
            btn_upload.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings Settings = Settings.Default;

            if (!txt_url.Text.EndsWith("/"))
            {
                txt_url.Text += "/";
            }

            Settings.URL = txt_url.Text;
            Settings.ConsumerKey = txt_consumer_key.Text;
            Settings.ConsumerSecret = txt_consumer_secret.Text;

            StringCollection files = new StringCollection();

            foreach (String item in lst_files.Items)
            {
                files.Add(item);
            }

            Settings.Files = files;
            Settings.Save();

            btn_upload.Enabled = true;

            MessageBox.Show("Speichern erfolgreich", "Speichern", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 upload = new Form2();
            upload.ShowDialog();
        }

        private void txt_url_TextChanged(object sender, EventArgs e)
        {
            btn_upload.Enabled = false;
        }

        private void txt_apikey_TextChanged(object sender, EventArgs e)
        {
            btn_upload.Enabled = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lbl_link.Text);
        }
    }
}
