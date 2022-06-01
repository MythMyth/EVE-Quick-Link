using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick_link
{
    public partial class Main : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        const string root_url = "https://dscan.info";
        const string get_char_id_url = "https://esi.evetech.net/latest/search/";
        private Mutex mutex;
        const int GET_DSCAN = 1, GET_ZKILL = 2;
        public Main()
        {
            InitializeComponent();
            mutex = new Mutex();
            RegisterHotKey(this.Handle, GET_DSCAN, 6, (int)Keys.D);
            RegisterHotKey(this.Handle, GET_ZKILL, 6, (int)Keys.Z);
            MakeContextMenu();
             WindowState = FormWindowState.Minimized;
            Hide();
        }

        void MakeContextMenu()
        {
            MenuItem exit = new MenuItem();
            exit.Text = "Exit";
            exit.Index = 0;
            exit.Click += new EventHandler(this.exit_click);

            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add(exit);
            notifyIcon1.ContextMenu = menu;
        }

        void exit_click(object sender, EventArgs arg)
        {
            this.Close();
        }

        private async Task GetLink(string content)
        {
            Log.GetInstance().DebugLog("Get link hit");
            mutex.WaitOne();
            WebClient client = new WebClient();
            string pageContent = client.DownloadString(root_url);
            int size = pageContent.Length;
            Log.GetInstance().DebugLog("Get content " + size + " bytes");
            int startOfForm = -1, endOfForm = -1;
            for(int i = 0; i < size; i++)
            {
                if("<form" == pageContent.Substring(i, 5))
                {
                    startOfForm = i;
                    break;
                }
            }
            if(startOfForm == -1)
            {
                //Error
                Log.GetInstance().DebugLog("Not found <form");
                mutex.ReleaseMutex();
                return;
            }
            for(int i = startOfForm; i < size; i++)
            {
                if(pageContent[i] == '>')
                {
                    endOfForm = i;
                }
            }
            if(endOfForm == -1)
            {
                //Error
                Log.GetInstance().DebugLog("Not found end form");
                mutex.ReleaseMutex();
                return;
            }
            int action_start = -1, action_end = -1;
            for(int i = startOfForm; i < endOfForm; i++)
            {
                if ("action=" == pageContent.Substring(i, 7))
                {
                    for(;i < endOfForm; i++)
                    {
                        if (pageContent[i] == '"')
                        {
                            i++;
                            action_start = i;
                            break;
                        }
                    }
                    for(;i < endOfForm; i++)
                    {
                        if(pageContent[i] == '"')
                        {
                            action_end = i;
                            break;
                        }
                    }
                    break;
                }
            }
            if(action_end == -1 || action_start == -1)
            {
                //Error
                Log.GetInstance().DebugLog("Action not found");
                mutex.ReleaseMutex();
                return;
            }

            HttpClient http_client = new HttpClient();
            string query_link = root_url + pageContent.Substring(action_start, action_end - action_start);
            var data = new Dictionary<string, string> {
                { "paste", content}
            };

            var request_content = new System.Net.Http.FormUrlEncodedContent(data);
            var response = await http_client.PostAsync(query_link, request_content);
            string res = await response.Content.ReadAsStringAsync();
            string[] res_arr = res.Split(';');
            if(res_arr[0] == "OK") {
                Clipboard.SetText(root_url + "/v/" + res_arr[1]);
                ShowSuccees(root_url + "/v/" + res_arr[1]);
            } else
            {
                Log.GetInstance().DebugLog("Get link failed");
            }
            mutex.ReleaseMutex();
        }

        private async Task GetZkill(string charname)
        {
            HttpClient http_client = new HttpClient();
            string request_url = get_char_id_url + "?";
            request_url += "categories=character&";
            request_url += "datasource=tranquility&";
            request_url += "language=en&";
            request_url += "search=" + charname.Trim().Replace(" ", "%20") + "&";
            request_url += "strict=true";

            HttpResponseMessage response = await http_client.GetAsync(request_url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = await response.Content.ReadAsStringAsync();
                result = result.Replace("{", "").Replace("}", "").Replace("]", "");
                if(result.Split('[').Length < 2)
                {
                    //Not found
                } else
                {
                    result = result.Split('[')[1].Trim();
                    //System.Diagnostics.Process.Start("https://zkillboard.com/character/" + result);

                    
                    Zkill zkill = new Zkill();
                    zkill.SetCharId(charname, result);
                    zkill.Show();
                }

            } else
            {
                //Request failed
            }

            

        }
        void ShowSuccees(string link)
        {
            Log.GetInstance().DebugLog("ShowSuccess: " + link);
            DScan ds = new DScan();
            ds.SetLink(link);
            ds.Show();
            ToastContentBuilder builder = new ToastContentBuilder();
            builder.AddArgument("link", link);
            builder.AddText("Link accquired!");
            builder.AddText(link);
            builder.Show();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                if (m.WParam.ToInt32() == GET_DSCAN) GetLink(Clipboard.GetText());
                else if(m.WParam.ToInt32() == GET_ZKILL) GetZkill(Clipboard.GetText());
            }
            base.WndProc(ref m);
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if(FormWindowState.Minimized == WindowState)
            {
                Hide();
            }
        }
    }
}

