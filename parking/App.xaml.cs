using parking.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using parking.ViewModel;

namespace parking
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const int tim_min = 4000;

        protected override void OnStartup(StartupEventArgs e)
        {
            SplashScreen splash = new SplashScreen();
            splash.Show();
            Stopwatch timer = new Stopwatch();
            timer.Start();

            base.OnStartup(e);

            MainWindow main = new MainWindow();
            timer.Stop();
            int remaining = tim_min - (int)timer.ElapsedMilliseconds;
            if(remaining > 0)
                Thread.Sleep(remaining);

            splash.Close();
            
        }
        public void App_Navigated(object sender, NavigationEventArgs e)
        {
            Page page = e.Content as Page;
            if (page != null)
                ApplicationHelper.NavigationService = page.NavigationService;
        }

    }



}
