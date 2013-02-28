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
    public partial class CreateSingleVM : Form
    {
        Session session;
        string hostUuid;
        XenRef<Host> hostRef;
        string version;

        string valSelectedMaster = "";
        string valSelectedTemplate = "";
        string valNewName = "";
        bool valAutoStart = false;

        public CreateSingleVM(Session session, string hostUuid)
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
            this.createVM();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateSingleVM_Load(object sender, EventArgs e)
        {
            Dictionary<XenRef<VM>, VM> allVMs = VM.get_all_records(session);

            List<string> templates = new List<string>(50);
            List<string> masters = new List<string>(50);

            foreach (KeyValuePair<XenRef<VM>, VM> pair in allVMs)
            {
                string skinnybox_config;
                if (pair.Value.other_config.TryGetValue("skinnybox", out skinnybox_config)) {

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

            if (masters.Count == 0)
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
                    this.createVM();
                }
            }

        }

        private bool validateData()
        {
            createBtn.Enabled = true;
            if (vmCreateWorker.IsBusy) { createBtn.Enabled = false; }
            if (templateList.SelectedIndex < 0) { createBtn.Enabled = false; }
            if (vmName.TextLength == 0) { createBtn.Enabled = false; }
            return createBtn.Enabled;
        }

        private void createVM()
        {
            if (!vmCreateWorker.IsBusy) {
                this.UseWaitCursor = true;
                this.createBtn.Enabled = false;
                this.cancelBtn.Enabled = false;

                valSelectedMaster = masterList.SelectedItem.ToString();
                valSelectedTemplate = templateList.SelectedItem.ToString();
                valNewName = vmName.Text;
                valAutoStart = autoStart.Checked;

                vmCreateWorker.RunWorkerAsync();
            }
        }

        private void vmCreateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("template", valSelectedTemplate);
            args.Add("name", valNewName);
            args.Add("master", valSelectedMaster);
            string new_uuid = Host.call_plugin(session, this.hostRef, "skinnybox", "provision", args);

            if (valAutoStart)
            {
                string new_ref = VM.get_by_uuid(session, new_uuid);
                VM.async_start(session, new_ref, false, false);
            }

            MessageBox.Show("VM created, the uuid=" + new_uuid, "Operation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void vmCreateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.UseWaitCursor = false;
            this.createBtn.Enabled = true;
            this.cancelBtn.Enabled = true;
        }
    }
}
