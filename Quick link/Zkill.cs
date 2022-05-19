using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick_link
{
    public partial class Zkill : Form
    {
        private string charId;
        private string charname;
        private string root_url = "https://zkillboard.com/character/";
        public Zkill()
        {
            InitializeComponent();
            charId = "";
        }

        public void SetCharId(string charname, string id)
        {
            charId = id;
            this.charname = charname;
            string url = root_url + charId;
            zkilllink.Text = url;
        }

        private void Zkill_Shown(object sender, EventArgs e)
        {
            //ActiveForm.Text = charname + " - " + charId;
            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("user-agent", "quick-link");
                string url = root_url + charId;
                string pageContent = client.DownloadString(url);
            }
            catch(WebException ex)
            {

            }
        }

        private void zkilllink_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start(zkilllink.Text);
        }
    }
}