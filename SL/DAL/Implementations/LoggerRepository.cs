using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.DAL.Implementations
{

    public sealed class LoggerRepository
    {
        private readonly static LoggerRepository _instance = new LoggerRepository();


        public static LoggerRepository Current
        {
            get
            {
                return _instance;
            }
        }

        private LoggerRepository()
        {
            //Implent here the initialization of your singleton
        }

        private string logFile = ConfigurationManager.AppSettings["LogFile"];
        private string logFileName = ConfigurationManager.AppSettings["LogFileName"];

        public void WriteLog(string message, EventLevel level, string user)
        {
            string fileName = logFile + DateTime.Now.ToString("yyyyMMdd") + logFileName;


            using(StreamWriter sw = new StreamWriter(fileName,true))
            {
                string formattedMessage = $"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - LEVEL {level.ToString()} - USER :{user} - MENSAJE: {message}";
                sw.WriteLine(formattedMessage);
            }
        }
    }

}
