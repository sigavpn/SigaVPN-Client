using System;
using System.Windows.Forms;

namespace SigaVPN
{
    public partial class ServerSelect : UserControl
    {

        VPNScreen VPNscreen = new VPNScreen();
        public ServerSelect()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            VPNscreen.SetSelectedCountry("Canada");

            panel1.Controls.Clear();
            VPNscreen.LabelUpdate();
            panel1.Controls.Add(VPNscreen);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            VPNscreen.SetSelectedCountry("Latvia");

            panel1.Controls.Clear();
            VPNscreen.LabelUpdate();
            panel1.Controls.Add(VPNscreen);
        }
    }
}