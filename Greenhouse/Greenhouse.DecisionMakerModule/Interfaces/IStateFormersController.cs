using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data;

namespace Greenhouse.DecisionMakerModule
{
    public interface IStateFormersController
    {
        IList<IMeasurment> FormDevicesInstructions(IList<IMeasurment> currentStates,
            IGPAllowedStates allowedStates);
    }
}
