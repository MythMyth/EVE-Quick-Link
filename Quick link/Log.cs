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
        static Mutex m_mutex = new Mutex();

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
            
        }

        public void DebugLog(string log)
        {
            File.AppendAllText("log.txt", DateTime.Now.ToString() + ": " + log + "\n");
        }
    }
}
