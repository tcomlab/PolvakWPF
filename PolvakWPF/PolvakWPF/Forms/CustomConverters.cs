using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using OwenProtokol;

namespace PolvakWPF.Forms
{
    public class SensorToStringLabel : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            var res = value as Sensors;
            if (res == null) return "NoInit";
            switch (res.SensorState)
            {
                case Sensors.SensorS.SensorNodata:
                    return "un0";
                case Sensors.SensorS.SensorErrore:
                    return "Er2";
                case Sensors.SensorS.SensorOk:
                    switch (res.ScaleControlVal)
                    {
                        case Sensors.ScaleControl.Celsium:
                            return String.Format("{0:0.0} C*", res.Result);
                        case Sensors.ScaleControl.Bar:
                            return String.Format("{0:0.0} Bar", res.Result);
                        case Sensors.ScaleControl.Meters:
                            return String.Format("{0:0.0} M", res.Result);
                    }
                    return "Er index";
                case Sensors.SensorS.SensorDestroy:
                    return "Er1"; 
            }
            return "Test";
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return new Sensors();
        }
    }
 
}
