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
    public class Gmv40Cl:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private Sensors _toGradirnya; // На градирню
        private Sensors _fromGradirnya; // ОТ градирни
        private Sensors _avtoklavCirculation; // вода циркуляционная
        private Sensors _tank6; // Емкость 6
        private Sensors _tank7; // Емкость 7
        private Sensors _tank8; // Емкость 8

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

        /// <summary>
        /// Температура воды оборотной от автоклава
        /// </summary>
        public Sensors AvtoklavCirculation
        {
            set
            {
                _avtoklavCirculation = value;
                NotifyChange(new PropertyChangedEventArgs("AvtoklavCirculation"));
            }
            get { return _avtoklavCirculation; }
        }

        /// <summary>
        /// Температура воды в эмкости 6
        /// </summary>
        public Sensors Tank6
        {
            set
            {
                _tank6 = value;
                NotifyChange(new PropertyChangedEventArgs("Tank6"));
            }
            get { return _tank6; }
        }

        /// <summary>
        /// Температура воды в эмкости 7
        /// </summary>
        public Sensors Tank7
        {
            set
            {
                _tank7 = value;
                NotifyChange(new PropertyChangedEventArgs("Tank7"));
            }
            get { return _tank7; }
        }

        /// <summary>
        /// Температура воды в эмкости 8
        /// </summary>
        public Sensors Tank8
        {
            set
            {
                _tank8 = value;
                NotifyChange(new PropertyChangedEventArgs("Tank8"));
            }
            get { return _tank8; }
        }

        public DataBasePrototype.gmv_40 GetTableDb()
        {
            return new gmv_40()
            {
                DT = DateTime.Now,
                ot_gradirnya = _fromGradirnya.Result,
                t_ot_avtoklava = _avtoklavCirculation.Result,
                to_gradirnya = _toGradirnya.Result,
                tank6 = _tank6.Result,
                tank7 = _tank7.Result,
                tank8 = _tank8.Result,
            };
        }
    }
}
