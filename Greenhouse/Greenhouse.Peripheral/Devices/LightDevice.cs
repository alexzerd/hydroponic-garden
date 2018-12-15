using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data;

namespace Greenhouse.Peripheral
{
    public class LightDevice : Device
    {
        public LightDevice(Location loc, String name = "Лампа") : base(loc, name)
        {
            SetState(new LightMeasurment(false));
        }
        public override void SetState(IMeasurment state)
        {
            State = null != (LightMeasurment)state ? state : new LightMeasurment(false);
            Nature.Light = (LightMeasurment)State;
        }

        public override MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.LightPerDay;
        }
    }
}
