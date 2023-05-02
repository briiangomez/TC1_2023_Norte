using SL.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Services.Extension
{
    public static class StringExtension
    {
        public static string Traducir(this string palabra)
        {
            return IdiomaBll.Current.Traducir(palabra);
        }
    }
}
