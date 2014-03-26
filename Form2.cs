using InMaFSS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InMaFSS
{
    public partial class Form2 : Form
    {
        BackgroundWorker worker;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.RunWorkerAsync();
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString(), "Serverantwort", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Upload upload = new Upload(this.OnWarning);

            e.Result = upload.Do();
        }

        private void OnWarning(string msg)
        {
            MessageBox.Show(msg, "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
