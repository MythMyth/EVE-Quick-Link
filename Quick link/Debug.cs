using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick_link
{
    internal class Debug
    {
        static Debug instance;
        static System.Threading.Mutex mutex = new System.Threading.Mutex();

        bool printLog;
        StreamWriter writer;

        public static Debug GetInstance()
        {
            mutex.WaitOne();
            if(instance == null)
            {
                instance = new Debug();
            }
            mutex.ReleaseMutex();
            return instance;
        }

        public static void Log(string log)
        {
            GetInstance()._Log(log);
        }

        public Debug()
        {
            string exe_dir = Application.ExecutablePath;
            exe_dir = exe_dir.Substring(0, exe_dir.LastIndexOf("\\"));
            printLog = Directory.Exists(exe_dir + "\\log");
            if(printLog)
            {
                writer = new StreamWriter(File.Open(exe_dir + "\\log\\log.txt", FileMode.OpenOrCreate | FileMode.Append));
            }
        }

        ~Debug()
        {
            if(writer != null)
            {
                writer.Close();
            }
        }

        public void _Log(string log)
        {
            if (!printLog) return;
            try
            {
                string time = DateTime.Now.ToString();
                writer.WriteLine(time + ": " + log);
            }
            catch(Exception e) { }
        }
    }
}
