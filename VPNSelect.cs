using System;
using System.Windows.Forms;

namespace SigaVPN
{
    public partial class VPNSelect : Form
    {
        ServerSelect serverSelect = new ServerSelect();
        Settings settings = new Settings();

        public string CurrentScreen
        {
            get;
            set;
        }

        public VPNSelect()
        {
            InitializeComponent();
            panel2.Controls.Clear();
            panel2.Controls.Add(serverSelect);
            CurrentScreen = "serverSelect";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (CurrentScreen != "serverSelect")
            {
                CurrentScreen = "serverSelect";
                panel2.Controls.Clear();
                panel2.Controls.Add(serverSelect);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (CurrentScreen != "settings")
            {
                CurrentScreen = "settings";
                panel2.Controls.Clear();
                panel2.Controls.Add(settings);
            }
        }
    }
}