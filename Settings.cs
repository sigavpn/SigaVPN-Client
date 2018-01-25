using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Net.Configuration;
using NetFwTypeLib;

namespace SigaVPN
{
    public partial class Settings : UserControl
    {
        RegistryKey registryKey;
        Ipv6Element DisableIPv6 = new Ipv6Element();

        public Settings()
        {


            InitializeComponent();
            checkBox1.Checked = Properties.Settings.Default.Blockleaks;
            checkBox2.Checked = Properties.Settings.Default.Killswitch;
            checkBox3.Checked = Properties.Settings.Default.Startup;
            textBox1.Text = Properties.Settings.Default.OpenVPNPath;
            registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Blockleaks = checkBox1.Checked;
            Properties.Settings.Default.Save();

            if (checkBox1.Checked)
            {
                DisableIPv6.Enabled = false;
            }
            else
            {
                registryKey.DeleteValue("SigaVPN", false);
                DisableIPv6.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Killswitch = checkBox2.Checked;
            Properties.Settings.Default.Save();

            if (checkBox2.Checked) { }
            else
            {
                INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                firewallPolicy.Rules.Remove("Block Internet");
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Startup = checkBox3.Checked;
            Properties.Settings.Default.Save();

            if (checkBox3.Checked)
            {

                registryKey.SetValue("SigaVPN", Application.ExecutablePath);
            }
            else
            {
                registryKey.DeleteValue("SigaVPN", false);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OpenVPNPath = textBox1.Text;
            Properties.Settings.Default.Save();
        }
    }
}