using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data.Classes;

namespace Greenhouse.Peripheral.Devices
{
    public class Lamp : Device
    {
        public Lamp(string name="Лампа", Location locc) : base(name, locc)
        {
        }
    }
}
