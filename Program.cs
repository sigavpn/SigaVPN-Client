using System;
using System.Windows.Forms;
using NetFwTypeLib;


namespace SigaVPN
{
    static class Program
    {
        public static bool KeepRunning
        {
            get;
            set;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            KeepRunning = true;
            try
            {
                while (KeepRunning)
                {
                    KeepRunning = false;
                    Application.Run(new VPNSelect());

                }
            }
            catch
            {
                if (Properties.Settings.Default.Killswitch)
                {
                    INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                    firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                    firewallRule.Description = "Used to block all internet access.";
                    firewallRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                    firewallRule.Enabled = true;
                    firewallRule.InterfaceTypes = "All";
                    firewallRule.Name = "Block Internet";

                    INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                    firewallPolicy.Rules.Add(firewallRule);
                }
            }

        }
    }
}