using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWebSocket
{
    public interface ILogger
    {
        void Debug(object message);
        bool IsDebugEnabled { get; }

        // continue for all methods like Error, Fatal ...
    }
}
