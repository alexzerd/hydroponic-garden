using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data;

namespace Greenhouse.Controllers
{
    public interface ISensorsController : IController
    {
        IList<IMeasurment> GetEnvironmentStates();
    }
}
