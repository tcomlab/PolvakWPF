using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolvakWPF.Logic
{
    internal class AutoklavData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        //NotifyChange(new PropertyChangedEventArgs("Text"));
        private float _apparat;
        private float _rubNiz;
        private float _rubVerh;
        private float _podPara;
        private float _pApparat;
        private float _uroven;

        public float Apparat
        {
            set
            {
                _apparat = value;
                NotifyChange(new PropertyChangedEventArgs("Apparat"));
            }
            get { return _apparat; }
        }

        public float RubNiz
        {
            set
            {
                _rubNiz = value;
                NotifyChange(new PropertyChangedEventArgs("RubNiz"));
            }
            get { return _rubNiz; }
        }

        public float RubVerh
        {
            set
            {
                _rubVerh = value;
                NotifyChange(new PropertyChangedEventArgs("RubVerh"));
            }
            get { return _rubVerh; }
        }

        public float PodPara
        {
            set
            {
                _podPara = value;
                NotifyChange(new PropertyChangedEventArgs("PodPara"));
            }
            get { return _podPara; }
        }

        public float PApparat
        {
            set
            {
                _pApparat = value;
                NotifyChange(new PropertyChangedEventArgs("PApparat"));
            }
            get { return _pApparat; }
        }

        public float Uroven
        {
            set
            {
                _uroven = value;
                NotifyChange(new PropertyChangedEventArgs("Uroven"));
            }
            get { return _uroven; }
        }

        public AutoklavData()
        {
            _apparat = 0;
            _rubNiz = 0;
            _rubVerh = 0;
            _podPara = 0;
            _pApparat = 0;
            _uroven = 0;
        }
    }
}