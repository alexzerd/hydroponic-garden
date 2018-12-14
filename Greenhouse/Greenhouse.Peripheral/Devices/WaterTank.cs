using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data.Classes;

namespace Greenhouse.Peripheral.Devices
{
    public class WaterTank : Device
    {
        public WaterTank(string name = "Устройство полива", Location locc) : base(name, locc)
        {
        }
    }
}
