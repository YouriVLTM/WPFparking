using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    public class Graph<X,Y> : BaseModel
    {
        public Graph()
        {

        }

        private Y yValue;
        public Y YValue
        {
            get
            {
                return yValue;
            }
            set
            {
                yValue = value;
                NotifyPropertyChanged();
            }
        }


        private X xValue;
        public X XValue
        {
            get
            {
                return xValue;
            }
            set
            {
                xValue = value;
                NotifyPropertyChanged();
            }
        }

    }
}
