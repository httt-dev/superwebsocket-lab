using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.LogTest
{
    public class SomeTestClass
    {
        public void Foo(string callForm) {
            Logger.Logger.LogInfo("Foo >> " + callForm, typeof(SomeTestClass));
        }
    }

    public static class StaticTestClass
    {
        public static void Bar(string callForm)
        {
            Logger.Logger.LogInfo("Bar >> " + callForm, typeof(StaticTestClass));
        }
    }

}
