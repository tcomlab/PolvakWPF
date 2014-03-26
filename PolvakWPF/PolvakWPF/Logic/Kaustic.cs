using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwenProtokol;
using PolvakWPF.Logic.DataBasePrototype;

namespace PolvakWPF.Logic
{
    public class KausticCl:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private Sensors _tank1;
        private Sensors _tank2;

        public Sensors Tank1
        {
            set
            {
                _tank1 = value;
                NotifyChange(new PropertyChangedEventArgs("Tank1"));
            }
            get { return _tank1; }
        }

        public Sensors Tank2
        {
            set
            {
                _tank2 = value;
                NotifyChange(new PropertyChangedEventArgs("Tank2"));
            }
            get { return _tank2; }
        }

        public DataBasePrototype.kaustik GetDbKaustik()
        {
            return new kaustik()
            {
                DT = DateTime.Now,
                emkost1 = _tank1.Result,
                emkost2 = _tank2.Result
            };
        }
    }
}
