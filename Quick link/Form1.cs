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
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        const string root_url = "https://dscan.info";
        private Mutex mutex;
        int MYACTION_HOTKEY_ID = 1;
        bool running;
        public Form1()
        {
            InitializeComponent();
            mutex = new Mutex();
            running = false;
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 6, (int)(Keys.D));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async Task GetLink(string content)
        {
            if (running) return;
            mutex.WaitOne();
            running = true;
            WebClient client = new WebClient();
            string pageContent = client.DownloadString(root_url);
            int size = pageContent.Length;
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
                running = false;
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
                running = false;
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
                running = false;
                mutex.ReleaseMutex();
                return;
            }

            HttpClient http_client = new HttpClient();
            string query_link = root_url + pageContent.Substring(action_start, action_end - action_start);
            label1.Text = query_link;
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
            }
            running = false;
            mutex.ReleaseMutex();
        }

        void ShowSuccees(string link)
        {
            ToastContentBuilder builder = new ToastContentBuilder();
            builder.AddArgument("link", link);
            builder.AddText("Link accquired!");
            builder.AddText(link);
            builder.Show();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID)
            {
                // My hotkey has been typed

                // Do what you want here
                // ...
                GetLink(Clipboard.GetText());
            }
            base.WndProc(ref m);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(FormWindowState.Minimized == WindowState)
            {
                Hide();
            }
        }
    }
}

