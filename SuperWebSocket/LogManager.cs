using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWebSocket
{
    public static class LogManager
    {
        public static ILogger GetLogger(Type type)
        {
            // if configuration file says log4net...
            return new Log4NetWrapper(type);
            // if it says Joe's Logger...
            // return new JoesLoggerWrapper(type); 
        }
    }
}
