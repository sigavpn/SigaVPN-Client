using System;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;


namespace SigaVPN
{
    public partial class VPNScreen : UserControl
    {
        private string selectedCountry;
        string IPadress;
        int Port;
        string OVPNFile;
        public string GetSelectedCountry()
        {
            return selectedCountry;
        }

        public void SetSelectedCountry(string value)
        {
            selectedCountry = value;
        }

        string URL;

        public VPNScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.KeepRunning = true;
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "Menu")
                    Application.OpenForms[i].Close();
            }
        }

        public void LabelUpdate()
        {

            switch (GetSelectedCountry())
            {
                case "Canada":
                    URL = "https://sigavpn.com/canadavpn.php";
                    break;
                case "Latvia":
                    URL = "https://sigavpn.com/latviavpn.php";
                    break;
                default:
                    break;
            }



            using (WebClient client = new WebClient())
            {
                string htmlCode = client.DownloadString(URL);
                string[] splitHTML = new string[3];
                splitHTML = Regex.Split(htmlCode, "\r\n|\r|\n");
                IPadress = splitHTML[0];
                Port = Convert.ToInt32(splitHTML[1]);
                OVPNFile = splitHTML[2];
                client.DownloadFile(OVPNFile, Path.Combine(Path.GetTempPath(), "country.ovpn"));
                OVPNFile = Path.Combine(Path.GetTempPath(), "country.ovpn");
                Console.WriteLine("IP=" + IPadress + " Port=" + Port + " OVPNFile=" + OVPNFile);
            }


            try
            {
                //Insert VPN Connecting code here
            }
            catch
            {
                label1.Text = "Unsuccesfully connected to VPN... :(";
                label2.Text = "Connection failed";
            }

        }
    }
}