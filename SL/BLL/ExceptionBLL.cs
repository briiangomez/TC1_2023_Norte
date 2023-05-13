using SL.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.BLL
{
    internal static class ExceptionBLL
    {
        private static string dalAssembly = ConfigurationManager.AppSettings["DALAssembly"];
        private static string bllAssembly = ConfigurationManager.AppSettings["BLLAssembly"];

        public static void Handle(Exception ex, object sender)
        {
            //Aplicar nuestras políticas de Exceptions
            //Console.WriteLine(ex.Message);

            string assemblyName = sender.GetType().Module.Name;

            if (assemblyName == dalAssembly)
            {
                //Aplicamos la política de exception de la DAL
                DALPolicy(ex);
            }
            else if (assemblyName == bllAssembly)
            {
                BLLPolicy(ex);
            }
        }

        private static void DALPolicy(Exception ex)
        {
            //1) Registrar en bitacora
            LoggerService.WriteLog($"MSJ: {ex.Message} - ST: {ex.StackTrace} ", EventLevel.Error, "Brian G");
            //2) Propagar
            throw new Exception(String.Empty, ex);
        }

        private static void BLLPolicy(Exception ex)
        {
            //Tengo que saber si la exception viene de BLL puramente o de DAL
            if (ex.InnerException != null)
            {
                //Estoy ante una exception en BLL pero que fue originada en DAL
                throw new Exception("Error accediendo a los datos...", ex);
            }
            else
            {
                //Es una exception propia de BLL, registro en bitacora
                LoggerService.WriteLog($"MSJ: {ex.Message} - ST: {ex.StackTrace} ", EventLevel.Error, "Brian G");
                //2) Propagar
                throw ex;
            }
        }
    }

}