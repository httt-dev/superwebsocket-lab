using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperWebSocket
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            log4net.GlobalContext.Properties["testProperty"] = "This is my test property information";
            log4net.ThreadContext.Properties["customer"] = "My Customer Name";
            log4net.LogicalThreadContext.Properties["activityid"] = new ActivityIdHelper().ToString();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Server());
        }
    }
}
