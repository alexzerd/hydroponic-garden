﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Controllers
{
    public interface IActiveSensorsController : IController
    {
        void RunMonitoring();
        void StopMonitoring();
    }
}
