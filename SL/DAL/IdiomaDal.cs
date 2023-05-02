using SL.Domain.BusinessExceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SL.DAL
{

    public sealed class IdiomaDal
    {
        #region singleton
        private readonly static IdiomaDal _instance = new IdiomaDal();

        public static IdiomaDal Current
        {
            get
            {
                return _instance;
            }
        }

        private IdiomaDal()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        private string folderLanguage = ConfigurationManager.AppSettings["FolderLanguage"];

        private string filePathLanguage = ConfigurationManager.AppSettings["FilePathLanguage"];
        public string Traducir(string key)
        {
            string filePath = $"{folderLanguage}/{filePathLanguage}{Thread.CurrentThread.CurrentUICulture.Name}";

            using (StreamReader sr = new StreamReader(filePath))
            {
                while(!sr.EndOfStream)
                {
                    string[] dataFile = sr.ReadLine().Split('=');

                    if(dataFile[0] == key)
                    {
                        return dataFile[1];
                    }
                }
            }

            throw new NoSeEncontroLaPalabraException();
        }

        public List<string> GetIdiomasDisplonibles()
        {
            //new DirectoryInfo(folderLanguage).GetFiles();
            return null;
        }
    }
}
