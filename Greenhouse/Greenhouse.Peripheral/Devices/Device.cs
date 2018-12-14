using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Peripheral;
using Greenhouse.Data;


namespace Greenhouse.Peripheral
{
    abstract public class Device
    {
        protected IMeasurment State = null;
        protected Location location;

        public string Name { get; set; }
        public Device (string name)
        {
            Name = name;
        }


    }
}
