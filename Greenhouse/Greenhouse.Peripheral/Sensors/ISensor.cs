﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data;

namespace Greenhouse.Peripheral
{
    public interface ISensor : IPhysicalObject
    {
        // Предполагается, что датчик измеряет состояние среды,
        // а потом хранит его до следующей итерации цикла
        IMeasurment Measure();
        IMeasurment GetLastMeasurment();
    }
}
