using parking.Extensions;
using parking.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.Extensions
{
    class PageNavigationService
    {
        public PageNavigationService()
        {

        }

        public void Navigate(string page)
        {
            switch (page)
            {
                case "Parking":
                    var parking = new Parking();
                    ApplicationHelper.NavigationService.Navigate(parking);
                    break;

                case "Home":
                    var home = new Home();
                    ApplicationHelper.NavigationService.Navigate(home);
                    break;

                case "Reserveren":
                    var reserveren = new Reserveren();
                    ApplicationHelper.NavigationService.Navigate(reserveren);
                    break;

                case "Statistiek":
                    var statistiek = new Statistiek();
                    ApplicationHelper.NavigationService.Navigate(statistiek);
                    break;

                default:
                    break;
            }
        }
    
    }
}
