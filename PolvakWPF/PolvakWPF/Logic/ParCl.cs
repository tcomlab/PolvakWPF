using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwenProtokol;

namespace PolvakWPF.Logic
{
    public class ParCl : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private Sensors _pPara; // ДАвление пара

        public Sensors PPara
        {
            set
            {
                _pPara = value;
                NotifyChange(new PropertyChangedEventArgs("PPara"));
            }
            get { return _pPara; }
        }

    }
}
