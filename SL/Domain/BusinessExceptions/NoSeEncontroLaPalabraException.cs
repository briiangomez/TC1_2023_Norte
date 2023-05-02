using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Domain.BusinessExceptions
{
    public class NoSeEncontroLaPalabraException : Exception
    {
        public NoSeEncontroLaPalabraException() : base("No se ha encontrado la clave")
        {

        }
    }
}
