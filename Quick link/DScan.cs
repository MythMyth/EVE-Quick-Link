using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick_link
{
    public partial class DScan : Form
    {
        public DScan()
        {
            InitializeComponent();
        }

        public void SetLink(string link)
        {
            linkLabel1.Text = link;
            webBrowser.Url = new Uri(link);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
            this.Close();
        }
    }
}
