﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data;

namespace Greenhouse.DecisionMakerModule
{
    internal class DefaultStateFormer : IStateFormer
    {
        public IMeasurment FormDevicesInstruction(IMeasurment currentState, IGPAllowedStates allowedStates)
        {
            IInstruction stateByProp = allowedStates.GetStateByPropertyID(currentState.GetPropertyID());
            if (currentState.Compare(stateByProp.GetMinAllowedState()) == -1)
                return stateByProp.GetMaxAllowedState();

            if (currentState.Compare(stateByProp.GetMaxAllowedState()) == 1)
                return stateByProp.GetMinAllowedState();

            return currentState;
        }

        public MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.DefaultType;
        }
    }
}
