using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Peripheral;
using Greenhouse.Data.Classes;
using Greenhouse.Data.Interfaces.Measurments;

namespace Greenhouse.Peripheral
{
    abstract public class Device
    {
        IMeasurment state = null;
        protected Location location;

        public string Name { get; set; }
       
        public Device (string name, Location locc)
        {
            Name = name;
            location = locc;
        }
        public Greenhouse.Data.Classes.Location GetLocation()
        {
            return location;
        }

        public void SetLocation(Greenhouse.Data.Classes.Location locc)
        {
            location = locc;
        }

    }
}
