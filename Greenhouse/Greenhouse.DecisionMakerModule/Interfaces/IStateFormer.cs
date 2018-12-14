using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Greenhouse.Data;
using System.Threading.Tasks;

namespace Greenhouse.DecisionMakerModule
{
    internal interface IStateFormer : IPropertyID
    {
        IMeasurment FormDevicesInstruction(IMeasurment currentState, IGPAllowedStates allowedStates);
    }
}
