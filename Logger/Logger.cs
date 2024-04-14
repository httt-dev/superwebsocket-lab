using log4net;
using log4net.Config;
using log4net.Layout.Pattern;
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

        private static Type GetCallingType()
        {
            var stackTrace = new StackTrace();
            // Frame index 0 là Logger.LogInfo hoặc Logger.LogError, index 1 là phương thức gọi LogInfo hoặc LogError, index 2 là lớp gọi
            var callingFrame = stackTrace.GetFrame(2);
            return callingFrame?.GetMethod()?.DeclaringType;
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

        public static void LogDebug(string message)
        {
            LogDebug(message, GetCallingType());
        }

        //public static void LogInfo(string message)
        //{
        //    //LogInfo(message, GetCallingType());
        //    var stackTrace = new StackTrace();
        //    var frame = stackTrace.GetFrame(1);
        //    var method = frame.GetMethod();
        //    var callingType = method.DeclaringType;
        //    var methodName = method.Name;

        //    var logger = LogManager.GetLogger(callingType);
        //    //logger.Info($"[{callingType.Name}.{methodName}] {message}");

        //    logger.Info(message);
        //}
        private static string GetClassName(string sourceFilePath)
        {
            string className = Path.GetFileNameWithoutExtension(sourceFilePath);
            return className;
        }

        public static void LogInfo(string message,
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            string callingClassName = GetClassName(sourceFilePath);
            log4net.LogManager.GetLogger(callingClassName).Info(message);
        }

        public static void LogWarn(string message)
        {
            LogWarn(message, GetCallingType());
        }

        public static void LogError(string message)
        {
            LogError(message, GetCallingType());
        }
        public static void LogFatal(string message)
        {
            LogFatal(message, GetCallingType());
        }

        //-------------------
        private static void LogDebug(string message, Type callingType)
        {
            log4net.LogManager.GetLogger(callingType).Debug(message);
        }

        public static void LogInfo(string message, Type callingType)
        {
            log4net.LogManager.GetLogger(callingType).Info(message);
        }
        private static void LogWarn(string message, Type callingType)
        {
            log4net.LogManager.GetLogger(callingType).Warn(message);
        }
        private static void LogError(string message, Type callingType)
        {
            log4net.LogManager.GetLogger(callingType).Error(message);
        }
        private static void LogFatal(string message, Type callingType)
        {
            log4net.LogManager.GetLogger(callingType).Fatal(message);
        }

    }

    public class CallerMethodNamePatternConverter : PatternLayoutConverter
    {
        protected override void Convert(System.IO.TextWriter writer, log4net.Core.LoggingEvent loggingEvent)
        {
            var locationInfo = loggingEvent.LocationInformation;
            var className = locationInfo?.ClassName;

            if (!string.IsNullOrEmpty(className))
            {
                var methodName = LogHelper.GetCurrentMethodName();
                writer.Write(methodName);
                return;
            }

            // Nếu không thể xác định được tên phương thức gọi, ghi là "UnknownMethod"
            writer.Write("UnknownMethod");
        }




    }

    public static class LogHelper
    {
        public static string GetCurrentMethodName()
        {
            return System.Reflection.MethodBase.GetCurrentMethod().Name;
        }
    }
}
