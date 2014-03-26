using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwenProtokol;

namespace PolvakWPF.Logic
{
    public class PRG : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private Sensors _QAluminat; // Расход алюмината
        private Sensors _TAluminat; // Температура алюмината
        private Sensors _QHlorid;   // Расход хлорида
        private Sensors _THlorid;   // Температура хлорида
        private Sensors _TPRG;      // Температура после ПРГ

        /// <summary>
        /// Расход алюмината
        /// </summary>
        public Sensors QAluminat
        {
            set
            {
                _QAluminat = value;
                NotifyChange(new PropertyChangedEventArgs("QAluminat"));
            }
            get { return _QAluminat; }
        }

        /// <summary>
        /// Температура алюмината
        /// </summary>
        public Sensors TAluminat
        {
            set
            {
                _TAluminat = value;
                NotifyChange(new PropertyChangedEventArgs("TAluminat"));
            }
            get { return _TAluminat; }
        }

        /// <summary>
        /// Расход хлорида
        /// </summary>
        public Sensors QHlorid
        {
            set
            {
                _QHlorid = value;
                NotifyChange(new PropertyChangedEventArgs("QHlorid"));
            }
            get { return _QHlorid; }
        }

        /// <summary>
        /// Температура хлорида
        /// </summary>
        public Sensors THlorid
        {
            set
            {
                _THlorid = value;
                NotifyChange(new PropertyChangedEventArgs("THlorid"));
            }
            get { return _THlorid; }
        }

        /// <summary>
        /// Температура после ПРГ
        /// </summary>
        public Sensors TPRG
        {
            set
            {
                _TPRG = value;
                NotifyChange(new PropertyChangedEventArgs("TPRG"));
            }
            get { return _TPRG; }
        }

        public DataBasePrototype.PRGNew DataBaseNew()
        {
            if (_QAluminat == null) return null;
            if (_TAluminat == null) return null;
            if (_QHlorid == null) return null;
            if (_THlorid == null) return null;
            if (_TPRG == null) return null;

            return new DataBasePrototype.PRGNew()
            {
                DT = DateTime.Now,
                QAluminat = _QAluminat.Result,
                TAluminat = _TAluminat.Result,
                QHlorid = _QHlorid.Result,
                THlorid = _THlorid.Result,
                TPRG = _TPRG.Result
            };
        }

        public DataBasePrototype.PRGOld DataBaseOld()
        {
            if (_QAluminat == null) return null;
            if (_TAluminat == null) return null;
            if (_QHlorid == null) return null;
            if (_THlorid == null) return null;
            if (_TPRG == null) return null;

            return new DataBasePrototype.PRGOld()
            {
                DT = DateTime.Now,
                QAluminat = _QAluminat.Result,
                TAluminat = _TAluminat.Result,
                QHlorid = _QHlorid.Result,
                THlorid = _THlorid.Result,
                TPRG = _TPRG.Result
            };
        }
    }
}
