using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Peripheral;
using Greenhouse.Data;


namespace Greenhouse.Peripheral
{
    abstract public class Device: IDevice
    {
        protected IMeasurment State = null;
        protected Location location;
        public String Name { get; set; }
        public Device(Location loc, String name)
        {
            location = loc;
            Name = name;
        }

        public abstract void SetState(IMeasurment state);

        public IMeasurment GetState()
        {
            return State;
        }

        public Greenhouse.Data.Location GetLocation()
        {
            return location;
        }

        public void SetLocation(Greenhouse.Data.Location loc)
        {
            location = loc;
        }

        public abstract MeasurmentTypes.Type GetPropertyID();

    }
}
