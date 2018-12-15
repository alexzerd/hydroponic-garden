﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data;

namespace Greenhouse.Peripheral
{
    public interface IDevice : IPhysicalObject
    {
        void SetState(IMeasurment meas);
        IMeasurment GetState();
    }
}
