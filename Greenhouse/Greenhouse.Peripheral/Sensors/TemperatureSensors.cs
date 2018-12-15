﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data;

namespace Greenhouse.Peripheral
{
    public class TemperatureSensor : Sensor
    {
        public TemperatureSensor(Location loc, String name = "Датчик температуры") : base(loc, name)
        {
            Measure();
        }

        public override IMeasurment Measure()
        {
            lastMeasurment = Nature.Temperature;
            return lastMeasurment;
        }

        public override MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.Temperature;
        }
    }
}
