using SL.DAL;
using SL.Domain.BusinessExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.BLL
{

    public sealed class IdiomaBll
    {
        #region singleton
        private readonly static IdiomaBll _instance = new IdiomaBll();

        public static IdiomaBll Current
        {
            get
            {
                return _instance;
            }
        }

        private IdiomaBll()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public string Traducir(string key) 
        {
            try
            {
                return IdiomaDal.Current.Traducir(key);
            }
            catch (NoSeEncontroLaPalabraException ex)
            {
                //Determinar qué hago???
                throw;
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }
    }

}
