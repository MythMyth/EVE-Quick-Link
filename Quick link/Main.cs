using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private readonly string AppName = "EVE-Quick-Link";
        string exe_dir;
        public Main()
        {
            InitializeComponent();
            exe_dir = Application.ExecutablePath;
            exe_dir = exe_dir.Substring(0, exe_dir.LastIndexOf("\\"));
            mutex = new Mutex();
            RegisterHotKey(this.Handle, GET_DSCAN, 6, (int)Keys.D);
            RegisterHotKey(this.Handle, GET_ZKILL, 6, (int)Keys.Z);
            MakeContextMenu();
            LoadConfig();
            if (autoMinimizeCheckbox.Checked)
            {
                WindowState = FormWindowState.Minimized;
                Hide();
            }
        }

        void MakeContextMenu()
        {
            MenuItem exit = new MenuItem();
            exit.Text = "Exit";
            exit.Index = 1;
            exit.Click += new EventHandler(this.exit_click);

            MenuItem setting = new MenuItem();
            setting.Text = "Setting";
            setting.Index = 0;
            setting.Click += new EventHandler(this.show_form);

            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add(setting);
            menu.MenuItems.Add(exit);
            notifyIcon1.ContextMenu = menu;
        }

        void LoadConfig()
        {
            try
            {
                FileStream fs = File.Open(exe_dir + "\\config", FileMode.OpenOrCreate);
                StreamReader reader = new StreamReader(fs);
                string line = reader.ReadLine();
                reader.Close();
                fs.Close();
                if (line == null)
                {
                    autoMinimizeCheckbox.Checked = false;
                    fs = File.OpenWrite(exe_dir + "\\config");
                    StreamWriter writer = new StreamWriter(fs);
                    writer.WriteLine("false");
                    writer.Close();
                    fs.Close();
                }
                else if (line == "false")
                {
                    autoMinimizeCheckbox.Checked = false;
                }
                else
                {
                    autoMinimizeCheckbox.Checked = true;
                }

                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (rk.GetValueNames().Contains(AppName))
                {
                    startUpCheckbox.Checked = true;
                }
                else
                {
                    startUpCheckbox.Checked = false;
                }
                rk.Close();
            } 
            catch(Exception e)
            {
                Debug.Log("Load config: " + e.Message);
                label1.Text = e.Message;
            }
            
        }

        void show_form(object sender, EventArgs arg)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        void exit_click(object sender, EventArgs arg)
        {
            this.Close();
        }

        private async Task GetLink(string content)
        {
            mutex.WaitOne();
            try
            {
                WebClient client = new WebClient();
                string pageContent = client.DownloadString(root_url);
                int size = pageContent.Length;
                int startOfForm = -1, endOfForm = -1;
                for (int i = 0; i < size; i++)
                {
                    if ("<form" == pageContent.Substring(i, 5))
                    {
                        startOfForm = i;
                        break;
                    }
                }
                if (startOfForm == -1)
                {
                    mutex.ReleaseMutex();
                    return;
                }
                for (int i = startOfForm; i < size; i++)
                {
                    if (pageContent[i] == '>')
                    {
                        endOfForm = i;
                    }
                }
                if (endOfForm == -1)
                {
                    mutex.ReleaseMutex();
                    return;
                }
                int action_start = -1, action_end = -1;
                for (int i = startOfForm; i < endOfForm; i++)
                {
                    if ("action=" == pageContent.Substring(i, 7))
                    {
                        for (; i < endOfForm; i++)
                        {
                            if (pageContent[i] == '"')
                            {
                                i++;
                                action_start = i;
                                break;
                            }
                        }
                        for (; i < endOfForm; i++)
                        {
                            if (pageContent[i] == '"')
                            {
                                action_end = i;
                                break;
                            }
                        }
                        break;
                    }
                }
                if (action_end == -1 || action_start == -1)
                {
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
                if (res_arr[0] == "OK")
                {
                    Clipboard.SetText(root_url + "/v/" + res_arr[1]);
                    DScan ds = new DScan();
                    ds.SetLink(root_url + "/v/" + res_arr[1]);
                    ds.Show();
                }
                mutex.ReleaseMutex();
            }
            catch(Exception e)
            {
                mutex.ReleaseMutex();
                Debug.Log("Get link: " + e.Message);
            }
            
        }

        private async Task GetZkill(string charname)
        {
            try
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
                    if (result.Split('[').Length < 2)
                    {
                        //Not found
                    }
                    else
                    {
                        result = result.Split('[')[1].Trim();
                        //System.Diagnostics.Process.Start("https://zkillboard.com/character/" + result);


                        Zkill zkill = new Zkill();
                        zkill.SetCharId(charname, result);
                        zkill.Show();
                    }

                }
                else
                {
                    //Request failed
                }
            } catch (Exception e)
            {
                Debug.Log("Get zkill: " + e.Message);
            }
            
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

        private void startUpCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (startUpCheckbox.Checked)
                    rk.SetValue(AppName, exe_dir);
                else
                    rk.DeleteValue(AppName, false);

                rk.Close();
            }
            catch(Exception ex)
            {
                Debug.Log("Start check change: " + ex.Message);
            }
        }

        private void autoMinimizeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = File.Open(exe_dir + "\\config", FileMode.Truncate);
                StreamWriter sw = new StreamWriter(fs);
                if (autoMinimizeCheckbox.Checked)
                {
                    sw.WriteLine("true");
                }
                else
                {
                    sw.WriteLine("false");
                }
                sw.Close();
                fs.Close();
            }
            catch(Exception ex)
            {
                Debug.Log("Auto minimize check change: " + ex.Message);
            }
            
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            show_form(sender, e);
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

