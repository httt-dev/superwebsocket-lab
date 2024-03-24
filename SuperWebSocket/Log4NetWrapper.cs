using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWebSocket
{
    public class Log4NetWrapper : ILogger
    {
        private readonly log4net.ILog _logger;

        public Log4NetWrapper(Type type)
        {
            _logger = log4net.LogManager.GetLogger(type);
        }

        public void Debug(object message)
        {
            _logger.Debug(message);
        }

        public bool IsDebugEnabled
        {
            get { return _logger.IsDebugEnabled; }
        }

        // complete ILogger interface implementation
    }
}
