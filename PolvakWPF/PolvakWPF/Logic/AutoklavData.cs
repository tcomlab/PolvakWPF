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
    public class AutoklavData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        //NotifyChange(new PropertyChangedEventArgs("Text"));
        private Sensors _apparat = new Sensors();
        private Sensors _rubNiz = new Sensors();
        private Sensors _rubVerh = new Sensors();
        private Sensors _podPara = new Sensors();
        private Sensors _pApparat = new Sensors();
        private Sensors _uroven = new Sensors();

        public Sensors Apparat
        {
            set
            {
                _apparat = value;
                if (_apparat != null) _apparat.ScaleControlVal = Sensors.ScaleControl.Celsium;
                NotifyChange(new PropertyChangedEventArgs("Apparat"));
            }
            get { return _apparat; }
        }

        public Sensors RubNiz
        {
            set
            {
                _rubNiz = value;
                if (_rubNiz != null) _rubNiz.ScaleControlVal = Sensors.ScaleControl.Celsium;
                NotifyChange(new PropertyChangedEventArgs("RubNiz"));
            }
            get { return _rubNiz; }
        }

        public Sensors RubVerh
        {
            set
            {
                _rubVerh = value;
                if (_rubVerh != null) _rubVerh.ScaleControlVal = Sensors.ScaleControl.Celsium;
                NotifyChange(new PropertyChangedEventArgs("RubVerh"));
            }
            get { return _rubVerh; }
        }

        public Sensors PodPara
        {
            set
            {
                _podPara = value;
                if (_podPara != null) _podPara.ScaleControlVal = Sensors.ScaleControl.Celsium;
                NotifyChange(new PropertyChangedEventArgs("PodPara"));
            }
            get { return _podPara; }
        }

        public Sensors PApparat
        {
            set
            {
                _pApparat = value;
                if (_pApparat != null) _pApparat.ScaleControlVal = Sensors.ScaleControl.Bar;
                NotifyChange(new PropertyChangedEventArgs("PApparat"));
            }
            get { return _pApparat; }
        }

        public Sensors Uroven
        {
            set
            {
                _uroven = value;
                if (_uroven != null) _uroven.ScaleControlVal = Sensors.ScaleControl.Meters;
                NotifyChange(new PropertyChangedEventArgs("Uroven"));
            }
            get { return _uroven; }
        }

        public AutoklavData()
        {
           
        }

        public be16000 GetTablebe16000()
        {
            if (_apparat == null) return null;
            var tb = new be16000();
            tb.DT = DateTime.Now;
            tb.t_aparat = _apparat.SensorState == Sensors.SensorS.SensorOk ? _apparat.Result : 0;
            tb.t_rub_niz = _rubNiz.SensorState == Sensors.SensorS.SensorOk ? _rubNiz.Result : 0;
            tb.t_rub_verh = _rubVerh.SensorState == Sensors.SensorS.SensorOk ? _rubVerh.Result: 0;
            tb.t_pod_para = _podPara.SensorState == Sensors.SensorS.SensorOk ? _podPara.Result: 0;
            tb.dav_aparat = _pApparat.SensorState == Sensors.SensorS.SensorOk ? _pApparat.Result: 0;
            tb.uroven = _uroven.SensorState == Sensors.SensorS.SensorOk ? _uroven.Result : 0;
            tb.korrozion = 0;
            return tb;
        }

        public be16001 GetTablebe16001()
        {
            if (_apparat == null) return null;
            var tb = new be16001();
            tb.DT = DateTime.Now;
            tb.t_aparat = _apparat.SensorState == Sensors.SensorS.SensorOk ? _apparat.Result : 0;
            tb.t_rub_niz = _rubNiz.SensorState == Sensors.SensorS.SensorOk ? _rubNiz.Result : 0;
            tb.t_rub_verh = _rubVerh.SensorState == Sensors.SensorS.SensorOk ? _rubVerh.Result : 0;
            tb.t_pod_para = _podPara.SensorState == Sensors.SensorS.SensorOk ? _podPara.Result : 0;
            tb.dav_aparat = _pApparat.SensorState == Sensors.SensorS.SensorOk ? _pApparat.Result : 0;
            tb.uroven = _uroven.SensorState == Sensors.SensorS.SensorOk ? _uroven.Result : 0;
            tb.korrozion = 0;
            return tb;
        }

        public ce25 GetTablece25()
        {
            if (_apparat == null) return null;
            var tb = new ce25();
            tb.DT = DateTime.Now;
            tb.t_aparat = _apparat.SensorState == Sensors.SensorS.SensorOk ? _apparat.Result : 0;
            tb.t_rub_niz = _rubNiz.SensorState == Sensors.SensorS.SensorOk ? _rubNiz.Result : 0;
            tb.t_rub_verh = _rubVerh.SensorState == Sensors.SensorS.SensorOk ? _rubVerh.Result : 0;
            tb.t_pod_para = _podPara.SensorState == Sensors.SensorS.SensorOk ? _podPara.Result : 0;
            tb.dav_aparat = _pApparat.SensorState == Sensors.SensorS.SensorOk ? _pApparat.Result : 0;
            tb.uroven = _uroven.SensorState == Sensors.SensorS.SensorOk ? _uroven.Result : 0;
            tb.korrozion = 0;
            return tb;
        }

        public ce3 GetTablece3()
        {
            if (_apparat == null) return null;
            var tb = new ce3();
            tb.DT = DateTime.Now;
            tb.t_aparat = _apparat.SensorState == Sensors.SensorS.SensorOk ? _apparat.Result : 0;
            tb.t_rub_niz = _rubNiz.SensorState == Sensors.SensorS.SensorOk ? _rubNiz.Result : 0;
            tb.t_rub_verh = _rubVerh.SensorState == Sensors.SensorS.SensorOk ? _rubVerh.Result : 0;
            tb.t_pod_para = _podPara.SensorState == Sensors.SensorS.SensorOk ? _podPara.Result : 0;
            tb.dav_aparat = _pApparat.SensorState == Sensors.SensorS.SensorOk ? _pApparat.Result : 0;
            tb.uroven = _uroven.SensorState == Sensors.SensorS.SensorOk ? _uroven.Result : 0;
            tb.korrozion = 0;
            return tb;
        }

        public ce4 GetTablece4()
        {
            if (_apparat == null) return null;
            var tb = new ce4();
            tb.DT = DateTime.Now;
            tb.t_aparat = _apparat.SensorState == Sensors.SensorS.SensorOk ? _apparat.Result : 0;
            tb.t_rub_niz = _rubNiz.SensorState == Sensors.SensorS.SensorOk ? _rubNiz.Result : 0;
            tb.t_rub_verh = _rubVerh.SensorState == Sensors.SensorS.SensorOk ? _rubVerh.Result : 0;
            tb.t_pod_para = _podPara.SensorState == Sensors.SensorS.SensorOk ? _podPara.Result : 0;
            tb.dav_aparat = _pApparat.SensorState == Sensors.SensorS.SensorOk ? _pApparat.Result : 0;
            tb.uroven = _uroven.SensorState == Sensors.SensorS.SensorOk ? _uroven.Result : 0;
            tb.korrozion = 0;
            return tb;
        }

    }
}