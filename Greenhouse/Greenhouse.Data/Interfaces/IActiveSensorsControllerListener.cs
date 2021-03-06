﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Data
{
    public interface IActiveSensorsControllerListener
    {
        void Notify(IList<IMeasurment> dangerStates);
        IGPAllowedStates GetCurrentInstruction();
    }
}
