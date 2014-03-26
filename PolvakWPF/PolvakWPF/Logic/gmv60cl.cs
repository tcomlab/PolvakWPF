using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using OwenProtokol;
using PolvakWPF.Logic.DataBasePrototype;

namespace PolvakWPF.Logic
{
    public class Gmv60Cl:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private Sensors _toGradirnya; // На градирню
        private Sensors _fromGradirnya; // ОТ градирни

        /// <summary>
        /// Температура воды на градирню
        /// </summary>
        public Sensors ToGradirnya
        {
            set
            {
                _toGradirnya = value;
                NotifyChange(new PropertyChangedEventArgs("ToGradirnya"));
            }
            get { return _toGradirnya; }
        }

        /// <summary>
        /// Температура воды от градирни
        /// </summary>
        public Sensors FromGradirnya
        {
            set
            {
                _fromGradirnya = value;
                NotifyChange(new PropertyChangedEventArgs("FromGradirnya"));
            }
            get { return _fromGradirnya; }
        }

        public DataBasePrototype.gmv_60 GetTableDb()
        {
            return new gmv_60()
            {
                DT = DateTime.Now,
                ot_gradirnya = _fromGradirnya.Result,
                to_gradirnya = _toGradirnya.Result
            };
        }
    }
}
