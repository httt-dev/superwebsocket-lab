using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WPFDialogSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
            this.Exit += new ExitEventHandler(App_Exit);
        }

        void App_Exit(object sender, ExitEventArgs e)
        {
            //Check stack trace.
            Application.Current.Shutdown();
        }

        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            //Check if this event handler get executed and from where control is coming to this method.
            Application.Current.Shutdown();
        }


        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);

            //Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            //if (Application.Current.MainWindow == null)
            //{
            //    //Nếu chưa, tạo mới main window và hiển thị
            //    MainWindow mainWindow = new MainWindow();
            //    mainWindow.Show();
            //}

            mainWindow.Closed += MainWindow_Closed;

        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            // Khi main window đã đóng, kết thúc ứng dụng
            Application.Current.Shutdown();
        }


    }
}
