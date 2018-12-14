using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data;

namespace Greenhouse.DecisionMakerModule
{
    internal class LightStateFormer : IStateFormer
    {
        public IMeasurment FormDevicesInstruction(IMeasurment currentState, IGPAllowedStates allowedStates)
        {
            LightInstruction instr = (LightInstruction)allowedStates.GetStateByPropertyID(GetPropertyID());
            return ((Double)instr.HoursPerDay / 24) < allowedStates.Progress ? instr.GetMinAllowedState() : instr.GetMaxAllowedState();
        }

        public MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.LightPerDay;
        }
    }
}
