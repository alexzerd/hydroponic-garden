using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data;

namespace Greenhouse.Controllers
{
    public interface IDevicesController : IController
    {
        IList<IMeasurment> GetDevicesStates();
        void AffectEnvironment(IList<IMeasurment> reauiredStates);
    }
}
