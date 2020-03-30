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
                default:
                    break;
            }
        }
    
    }
}
