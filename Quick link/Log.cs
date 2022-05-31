using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quick_link
{
    class Log
    {
        static Log instance;
        static Mutex m_mutex;
        StreamWriter file;

        public static Log GetInstance()
        {
            m_mutex.WaitOne();
            if(instance == null)
            {
                instance = new Log();
            }
            m_mutex.ReleaseMutex();
            return instance;
        }
        public Log()
        {
            file = new StreamWriter("log.txt", true);
        }

        public void DebugLog(string log)
        {
            file.WriteLine(DateTime.Now.ToString() + ": " + log);
        }
    }
}
