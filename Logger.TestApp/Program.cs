using Abc.LogTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logger.TestApp
{
    internal class Program
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            Logger.SetContext("stera_credit");

            Logger.LogInfo("Start app" );

            //log.Info("Hello logging world!");

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    SomeTestClass someTestClass = new SomeTestClass();

                    someTestClass.Foo("stera_credit" + i.ToString());

                    StaticTestClass.Bar("stera_credit" + i.ToString());

                    Thread.Sleep(1000);
                }

                //throw new Exception("Tao exception");
            }catch (Exception ex)
            {
                //Logger.LogInfo(ex.StackTrace, typeof(Program));
            }
        }
    }
}
