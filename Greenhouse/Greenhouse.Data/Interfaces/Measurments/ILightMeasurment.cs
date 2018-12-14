﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Data
{
    public interface ILightMeasurment : IMeasurment
    {
        // TRUE - turned ON
        // FALSE - turned OFF
        Boolean GetLightState();
    }
}
