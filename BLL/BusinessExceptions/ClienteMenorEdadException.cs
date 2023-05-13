using SL.Services.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessExceptions
{
    public class ClienteMenorEdadException : Exception
    {
        public ClienteMenorEdadException() : base("El cliente es menor de edad")
        {
            base.HelpLink = "https://www.wiki.com";
        }
    }
}
