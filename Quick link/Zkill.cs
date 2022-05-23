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
            string url = root_url + charId;
            zkilllink.Text = url;
            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("user-agent", "quick-link");
                string pageContent = client.DownloadString(url);
                HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
                htmldoc.LoadHtml(pageContent);
                HtmlNodeCollection dangerous = htmldoc.DocumentNode.SelectNodes("//table[@class='table table-condensed alltime-ranks']//div[@class='progress-bar progress-bar-danger']");
                dangerousBar.Value = int.Parse(dangerous[0].Attributes["aria-valuenow"].Value);
                gangComp.Value = int.Parse(dangerous[1].Attributes["aria-valuenow"].Value);
                getKillmailList(htmldoc);
            }
            catch (Exception ex)
            {

            }
        }

        private void getKillmailList(HtmlAgilityPack.HtmlDocument htmldoc)
        {
            HtmlNodeCollection killmailNode = htmldoc.DocumentNode.SelectNodes("//tbody[@id='killmailstobdy']/tr");
            int len = killmailNode.Count;
            for(int i = 0; i < len; i++)
            {
                HtmlNode currNode = killmailNode[i];
                if (currNode.Name != "tr") continue;
                if(currNode.Attributes["class"].Value.Contains("tr-date"))
                {
                    string date = currNode.Attributes["date"].Value;
                    killlist.Groups.Add(new ListViewGroup(date));
                } else if(currNode.Attributes["class"].Value.Contains("killListRow"))
                {

                    ListViewItem item = new ListViewItem();
                    HtmlNodeCollection row = currNode.SelectNodes("td");
                    HtmlNode priceAndTime = row[0];
                    string pat = priceAndTime.ChildNodes[0].InnerText.Trim();
                    pat += "\n" + priceAndTime.ChildNodes[2].InnerText;
                    item.SubItems.Add(pat);
                    HtmlNode place = row[2];
                    HtmlNode victim = row[4];
                    HtmlNode finalBlow = row[6];
                    killlist.Items.Add(item);
                    if(killlist.Groups.Count != 0)
                    {
                        item.Group = killlist.Groups[killlist.Groups.Count - 1];
                    }
                }
            }
        }

        private void Zkill_Shown(object sender, EventArgs e)
        {
            //ActiveForm.Text = charname + " - " + charId;
            
        }

        private void zkilllink_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start(zkilllink.Text);
        }
    }
}