using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwenProtokol;

namespace PolvakWPF.Logic
{
    interface IDevice
    {
        byte Adress { set; get; }
        void ReadTemperature(Owen proto,Sensors[] temperatureOutBuff);
    }
}
