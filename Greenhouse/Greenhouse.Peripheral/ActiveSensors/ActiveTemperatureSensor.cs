﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data;

namespace Greenhouse.Peripheral
{
    public class ActiveTemperatureSensor : ActiveSensor
    {
        public ActiveTemperatureSensor(Location loc, String name = "Активный датчик температуры")
            : base(loc, name)
        {
        }

        public override IMeasurment GetState()
        {
            return Nature.Temperature;
        }

        public override MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.Temperature;
        }
    }
}
