using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XenAPI;

namespace SkinnyProvision
{
    public partial class CreateMultipleVMs : Form
    {
        Session session;
        string hostUuid;
        XenRef<Host> hostRef;
        string version;

        string valSelectedMaster = "";
        string valSelectedTemplate = "";
        string valNewNamePrefix = "";
        int valStartIndex = 0;
        int valEndIndex = 0;
        int valPadding = 0;
        bool valAutoStart = false;

        public CreateMultipleVMs(Session session, string hostUuid)
        {
            this.session = session;
            this.hostUuid = hostUuid;

            this.hostRef = Host.get_by_uuid(session, hostUuid);

            try
            {
                this.version = Host.call_plugin(session, this.hostRef, "skinnybox", "version", null);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to contact the skinnybox plugin. Please make sure that skinnybox exists in /etc/xapi.d/plugins/ and has execute permissions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            InitializeComponent();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            createVM();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (createVMsWorker.IsBusy)
            {
                createVMsWorker.CancelAsync();
                cancelBtn.Text = "Close";
            }
            else
            {
                this.Close();
            }


        }

        private void vmName_TextChanged(object sender, EventArgs e)
        {
            validateData();
        }

        private void vmName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (validateData())
                {
                    createVM();
                }
            }
        }

        private void createVMsWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void CreateMultipleVMs_Load(object sender, EventArgs e)
        {
            Dictionary<XenRef<VM>, VM> allVMs = VM.get_all_records(session);

            List<string> templates = new List<string>(50);
            List<string> masters = new List<string>(50);

            foreach (KeyValuePair<XenRef<VM>, VM> pair in allVMs)
            {
                string skinnybox_config;
                if (pair.Value.other_config.TryGetValue("skinnybox", out skinnybox_config))
                {

                    if (skinnybox_config == "template" && pair.Value.is_a_template)
                    {
                        templates.Add(pair.Value.name_label);
                    }

                    if (skinnybox_config == "master" && !pair.Value.is_a_template)
                    {
                        masters.Add(pair.Value.name_label);
                    }
                }
            }

            if (templates.Count == 0)
            {
                MessageBox.Show("There are no SkinnyBox templates installed. Please create one first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            if (templates.Count == 0)
            {
                MessageBox.Show("There are no SkinnyBox masters available. Please dedicate a master by setting the other_config field to \"master\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            templates.Sort();
            templateList.Items.AddRange(templates.ToArray());
            templateList.SelectedIndex = 0;

            masters.Sort();
            masterList.Items.AddRange(masters.ToArray());
            masterList.SelectedIndex = 0;

            validateData();
        }

        private bool validateData()
        {
            createBtn.Enabled = true;
            if (createVMsWorker.IsBusy) { createBtn.Enabled = false; }
            if (templateList.SelectedIndex < 0) { createBtn.Enabled = false; }
            if (vmName.TextLength == 0) { createBtn.Enabled = false; }
            return createBtn.Enabled;
        }

        private void createVM()
        {
            if (!createVMsWorker.IsBusy)
            {
                this.UseWaitCursor = true;
                this.createBtn.Enabled = false;
                cancelBtn.Text = "Cancel";

                valSelectedMaster = masterList.SelectedItem.ToString();
                valSelectedTemplate = templateList.SelectedItem.ToString();
                valNewNamePrefix = vmName.Text;
                valStartIndex = Convert.ToInt32(firstCountBox.Value);
                valEndIndex = Convert.ToInt32(lastCountBox.Value);
                valPadding = Convert.ToInt32(paddingBox.Value);
                valAutoStart = autoStart.Checked;

                createVMsWorker.RunWorkerAsync();
            }
        }

        private void createVMsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = valStartIndex; i <= valEndIndex; i++)
            {
                if (createVMsWorker.CancellationPending) {
                    createVMsWorker.ReportProgress(100);
                    break;
                }

                Dictionary<string, string> args = new Dictionary<string, string>();
                args.Add("template", valSelectedTemplate);
                args.Add("master", valSelectedMaster);
                
                if (valPadding != 0)
                    args.Add("name", valNewNamePrefix + i.ToString().PadLeft(valPadding, '0'));
                else
                    args.Add("name", valNewNamePrefix + i.ToString());

                string new_uuid = Host.call_plugin(session, this.hostRef, "skinnybox", "provision", args);

                if (valAutoStart)
                {
                    string new_ref = VM.get_by_uuid(session, new_uuid);
                    VM.async_start(session, new_ref, false, false);
                }
                int completeness = ((i-valStartIndex) * 200 + (valEndIndex - valStartIndex + 1)) / ((valEndIndex - valStartIndex + 1) * 2);
                createVMsWorker.ReportProgress(completeness);
            }
        }


        private void createVMsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.UseWaitCursor = false;
            this.createBtn.Enabled = true;
            progressBar.Value = 0;
            cancelBtn.Text = "Close";
        }
    }
}
