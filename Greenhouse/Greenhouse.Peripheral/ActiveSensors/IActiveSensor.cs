using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data;

namespace Greenhouse.Peripheral
{
    public interface IActiveSensor : IPhysicalObject
    {
        IMeasurment GetState();
        Boolean IsEnvironmentOK(IInstruction allowedStates);
    }
}
