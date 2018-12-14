using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data.Classes;

namespace Greenhouse.Peripheral.Devices
{
    public class Heater : Device
    {
        public Heater(string name = " Нагреватель ", Location locc) : base(name, locc)
        {
        }
    }
}
