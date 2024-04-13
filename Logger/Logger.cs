using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public static class Logger
    {
        //private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static Logger()
        {
            //// Cấu hình Log4Net từ tệp cấu hình "log4net.config"
            //XmlConfigurator.Configure(LogManager.GetRepository(Assembly.GetEntryAssembly()), new FileInfo("log4net.config"));
            //string logDirectory = $"{Environment.GetEnvironmentVariable("LOG_DIRECTORY")}\\{DateTime.Now.ToString("yyyyMMdd")}\\{Environment.GetEnvironmentVariable("CONTEXT_NAME")}";
            //Directory.CreateDirectory(logDirectory);

            new DateChangeTask().Start();
        }

        public static void SetContext(string appName)
        {
            string logDirectory = @"C:\hontorsp_pos\log";
            string contextName = appName + "_context";

            Environment.SetEnvironmentVariable("APP_NAME", appName);
            Environment.SetEnvironmentVariable("CONTEXT_NAME", contextName);
            Environment.SetEnvironmentVariable("LOG_DIRECTORY", logDirectory);
            Environment.SetEnvironmentVariable("LOG_DATE", DateTime.Now.ToString("yyyyMMdd"));

            XmlConfigurator.Configure(LogManager.GetRepository(Assembly.GetEntryAssembly()), new FileInfo("log4net.config"));
            //logDirectory = $"{Environment.GetEnvironmentVariable("LOG_DIRECTORY")}\\{DateTime.Now.ToString("yyyyMMdd")}\\{Environment.GetEnvironmentVariable("CONTEXT_NAME")}";
            //Directory.CreateDirectory(logDirectory);
        }

        public static void LogInfo(string message, Type callingType)
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame frame = stackTrace.GetFrame(1); // Lấy frame của lớp gọi (không phải của Logger)

            ThreadContext.Properties["file"] = frame.GetFileName();
            ThreadContext.Properties["line"] = frame.GetFileLineNumber();
            log4net.LogManager.GetLogger(callingType).Info(message);
        }
        public static void LogError(string message, Type callingType)
        {
            log4net.LogManager.GetLogger(callingType).Error(message);
        }
    }

}
