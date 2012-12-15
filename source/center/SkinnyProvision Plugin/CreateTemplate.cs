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
    public partial class CreateTemplate : Form
    {
        Session session;
        string hostUuid;
        XenRef<Host> hostRef;
        string version;

        public CreateTemplate(Session session, string hostUuid)
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
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("template_to_clone", templateList.SelectedItem.ToString());
            args.Add("new_template_name", templateName.Text);
            args.Add("overlay_size", "" + (1048576 * overlaySize.Value));
            string new_uuid = Host.call_plugin(session, this.hostRef, "skinnybox", "create_template", args);
            MessageBox.Show("Template created, the uuid="+new_uuid, "Operation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateTemplate_Load(object sender, EventArgs e)
        {
            Dictionary<XenRef<VM>, VM> allVMs = VM.get_all_records(session);
            List<string> list = new List<string>(50);

            foreach (KeyValuePair<XenRef<VM>, VM> pair in allVMs)
            {
                string skinnybox_config;
                if (pair.Value.name_label.StartsWith("Ubuntu"))
                {
                    if (!pair.Value.other_config.TryGetValue("skinnybox", out skinnybox_config))
                    {
                        list.Add(pair.Value.name_label);
                    }
                }
            }

            list.Sort();
            templateList.Items.AddRange(list.ToArray());

            if (list.Count > 0)
            {
                templateList.SelectedIndex = 0;
            }
        }


        private void validateData()
        {
            createBtn.Enabled = true;
            if (templateList.SelectedIndex < 0) { createBtn.Enabled = false; }
            if (templateName.TextLength == 0) { createBtn.Enabled = false; }
            if (overlaySize.Value <= 16) { createBtn.Enabled = false; }
        }

        private void templateName_TextChanged(object sender, EventArgs e)
        {
            validateData();
        }

        private void templateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateData();
        }
    }
}
