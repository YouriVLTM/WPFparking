using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    public class ParkingsView : BaseModel
    {
        public ParkingsView()
        {
            Parkings = new ObservableCollection<ParkingView>();
        }
        public ObservableCollection<ParkingView> Parkings { get; set; }
    }
}
