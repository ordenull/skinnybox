using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XenAPI;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Windows.Forms;

namespace SkinnyProvision
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string serverURL = "";
            string sessionRef = "";
            string hostUUID = "";
            string function = "";

            if (args.Length == 0)
            {
                //Set these to debug outside of the XenServer process
                function = "create-batch";
                serverURL = "https://server-url:443/";
                sessionRef = "OpaqueRef:xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
                hostUUID = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
            }

            try
            {
                if (serverURL.Length == 0 || sessionRef.Length == 0 || hostUUID.Length == 0 || function.Length == 0)
                {
                    function = args[0];
                    List<ParameterSet> ParamSets;
                    SeparateParams(args, 1, out ParamSets);

                    switch (ParamSets.Count)
                    {
                        case 0:
                            throw new Exception("At least one host must be selected");
                        case 1:
                            break;
                        default:
                            throw new Exception("Only one host can be selected at a time");
                    }

                    if (ParamSets[0].SelectedObjectClass.ToLower() != "host")
                        throw new Exception("A XenServer host must be selected");

                    serverURL = ParamSets[0].ServerURL;
                    sessionRef = ParamSets[0].SessionRef;
                    hostUUID = ParamSets[0].SelectedObjectUuid;
                }

                Connecting connectingDlg = new Connecting(serverURL, sessionRef);
                Application.Run(connectingDlg);

                if (connectingDlg.XenSession != null)
                {
                    switch (function)
                    {
                        case "create-template":
                            Application.Run(new CreateTemplate(connectingDlg.XenSession, hostUUID));
                            break;
                        case "create-single":
                            Application.Run(new CreateSingleVM(connectingDlg.XenSession, hostUUID));
                            break;
                        case "create-batch":
                            Application.Run(new CreateMultipleVMs(connectingDlg.XenSession, hostUUID));
                            break;
                        default:
                            throw new Exception("That function is not supported by this plugin.");
                    }
                }
                else
                {
                    throw new Exception("Unable to connect to XenServer, please make sure that you are still logged in.");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void SeparateParams(string[] args, int start, out List<ParameterSet> ParamSets)
        {
            ParamSets = new List<ParameterSet>();
            for (int i = start; i < args.Length; i += 4)
            {
                ParamSets.Add(new ParameterSet(args[i], args[i + 1], args[i + 2], args[i + 3]));
            }
        }

        internal static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public class ParameterSet
        {
            public string ServerURL = "";
            public string SessionRef = "";
            public string SelectedObjectClass = "";
            public string SelectedObjectUuid = "";

            public ParameterSet(string ServerURL, string SessionRef, string SelectedObjectClass, string SelectedObjectUuid)
            {
                this.ServerURL = ServerURL;
                this.SessionRef = SessionRef;
                this.SelectedObjectClass = SelectedObjectClass;
                this.SelectedObjectUuid = SelectedObjectUuid;
            }
        }
    }
}



