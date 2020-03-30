using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace parking.Extensions
{
    public static class ApplicationHelper { 
        private static NavigationService navigator; 
        public static NavigationService NavigationService {
            get { return navigator; }
            set { navigator = value; }           
        }
    }
}
