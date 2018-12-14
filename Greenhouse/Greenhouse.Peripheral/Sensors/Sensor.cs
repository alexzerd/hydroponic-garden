using System;
using Greenhouse.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Peripheral
{
    public abstract class Sensor : ISensor
    {
        protected IMeasurment lastMeasurment = null;
        protected Location location;
        public String Name { get; set; }


        public Sensor(Location loc, String name)
        {
            location = loc;
            Name = name;
        }

        public IMeasurment GetLastMeasurment()
        {
            return lastMeasurment;
        }

        public Location GetLocation()
        {
            return location;
        }

        public void SetLocation(Location loc)
        {
            location = loc;
        }

        public abstract MeasurmentTypes.Type GetPropertyID();

        public abstract IMeasurment Measure();
    }
}
