using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.BLL
{
    internal static class LoggerBLL
    {
        public static void WriteLog(string message, EventLevel level, string user)
        {
            DAL.Implementations.LoggerRepository.Current.WriteLog(message, level, user);

           /* switch (level)
            {
                case EventLevel.LogAlways:

                    break;
                case EventLevel.Critical:

                    break;
                case EventLevel.Error:

                    break;
                case EventLevel.Warning:

                    break;
                case EventLevel.Informational:

                    break;
                case EventLevel.Verbose:

                    break;
                default:
                    break;
            }*/
        }
    }
}
