using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using XenAPI;

namespace SkinnyProvision
{
    public partial class Connecting : Form
    {
        string hostURL;
        string sessionRef;
        Session session;
        Thread connectingThread;

        public Session XenSession
        {
            get { return session; }
        }

        public Connecting(string hostURL, string sessionRef)
        {
            this.hostURL = hostURL;
            this.sessionRef = sessionRef;
            InitializeComponent();
        }

        private void Connecting_Load(object sender, EventArgs e)
        {
            this.Text += hostURL;
            this.addressBox.Text += hostURL;
            this.addressBox.Text += sessionRef;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            session = null;
            connectingThread.Abort();
            this.Close();
        }

        private void Connecting_Shown(object sender, EventArgs e)
        {
            connectBackgroundWorker.RunWorkerAsync();
        }

        private void connectBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.session = new Session(hostURL, sessionRef);
            }
            catch
            {
                this.session = null;
            }
        }

        private void connectBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
