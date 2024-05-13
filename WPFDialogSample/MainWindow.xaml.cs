using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPFDialogSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Window> overlapWindows = new List<Window>();

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            foreach (Window window in Application.Current.Windows)
            {
                if (window != this)
                {
                    window.Close();
                }
            }

            CloseChildWindows();

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //OverlapWindow overlapWindow = new OverlapWindow();
            //lets launch a modal window

            //overlapWindow.ShowDialog();
            OverlapWindowFactory();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OverlapWindow overlapWindow = new OverlapWindow();

            overlapWindows.Add(overlapWindow);
            //lets launch a modaless window

            overlapWindow.Show();
        }

        private void OverlapWindowFactory()
        {
            Thread overlapThread = new Thread( new ThreadStart(StartThread));
            overlapThread.SetApartmentState(ApartmentState.STA);
            overlapThread.IsBackground = true;  // Thiet lap background thi moi co the ket thuc thread nay khi main thread ket thuc
            overlapThread.Start();
            //overlapThread.Join();
        }

        private void StartThread()
        {
            OverlapWindow tempWindow = new OverlapWindow();
            overlapWindows.Add(tempWindow);

            tempWindow.ShowDialog();
            // The thread will die if we don't start the window message dispactcher
            System.Windows.Threading.Dispatcher.Run();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CloseChildWindows();
        }

        private void CloseChildWindows()
        {
            for (int i = 0; i < overlapWindows.Count; i++)
            {
                Window window = overlapWindows[i];
                if (window.Dispatcher.CheckAccess())
                {
                    window.Close();
                }
                else
                {
                    window.Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(window.Close));
                }
            }
        }
        private bool IsModal(Window w)
        {
            return (bool)typeof(Window).GetField("_showingAsDialog" ,  System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(w);
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < overlapWindows.Count; i++)
            {
                var isModal = IsModal(overlapWindows[i]);
                if (isModal)
                {
                    MessageBox.Show("The thread is running a modal window");
                }
            }
        }
    }
}
