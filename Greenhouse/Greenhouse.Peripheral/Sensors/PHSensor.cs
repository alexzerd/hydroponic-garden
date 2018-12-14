using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data;

namespace Greenhouse.Peripheral
{
    public class PhSensor : Sensor
    {
        public PhSensor(Location loc, String name = "Датчик кислотности") : base(loc, name)
        {
            Measure();
        }

        public override IMeasurment Measure()
        {
            lastMeasurment = Nature.PH;
            return lastMeasurment;
        }

        public override MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.PH;
        }
    }
}
