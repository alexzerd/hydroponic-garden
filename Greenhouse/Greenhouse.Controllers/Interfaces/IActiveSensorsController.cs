using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Controllers
{
    interface IActiveSensorsController : IController
    {
        void RunMonitoring();
        void StopMonitoring();
    }
}
