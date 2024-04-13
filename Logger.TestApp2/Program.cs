using Abc.LogTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logger.TestApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.SetContext("stera_emoney");

            Logger.LogInfo("Start app", typeof(Program));

            //log.Info("Hello logging world!");

            try
            {
                for(int i =0 ; i < 10; i++)
                {
                    SomeTestClass someTestClass = new SomeTestClass();

                    someTestClass.Foo("stera_emoney" + i.ToString());

                    StaticTestClass.Bar("stera_emoney" + i.ToString());

                    Thread.Sleep(1000);
                }


                //throw new Exception("Tao exception");
            }
            catch (Exception ex)
            {
                //Logger.LogInfo(ex.StackTrace, typeof(Program));
            }
        }
    }
}
