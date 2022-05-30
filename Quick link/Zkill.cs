using HtmlAgilityPack;
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
        public List<ListItem> kills;
        public Zkill()
        {
            InitializeComponent();
            charId = "";
            kills = new List<ListItem>();
        }

        public void SetCharId(string charname, string id)
        {
            //killlist.Clear();
            //kills.Clear();
            charId = id;
            this.charname = charname;
            this.Text = charname;
            string url = root_url + charId;
            zkilllink.Text = url;
            try
            {
                webbrowse.Url = new Uri(url);
                
            }
            catch (Exception ex)
            {

            }
        }

        private void Zkill_Shown(object sender, EventArgs e)
        {
            //ActiveForm.Text = charname + " - " + charId;
            
        }

        private void zkilllink_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start(zkilllink.Text);
            this.Close();
        }

        private void webbrowse_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }
    }
}