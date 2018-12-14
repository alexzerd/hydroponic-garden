﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Greenhouse.Data
{
    public class Instruction : IInstruction
    {
        private IMeasurment MaxAllowedState;
        private IMeasurment MinAllowedState;

        public Instruction(IMeasurment maxAllowedState, IMeasurment minAllowedState)
        {
            if (null == maxAllowedState || null == minAllowedState)
                throw new NullReferenceException();

            if (0 != maxAllowedState.Compare(minAllowedState))
            {
                MaxAllowedState = maxAllowedState.Compare(minAllowedState) == 1 ? maxAllowedState : minAllowedState;
                MinAllowedState = maxAllowedState.Compare(minAllowedState) == -1 ? maxAllowedState : minAllowedState; ;
            }
            else
            {
                MaxAllowedState = maxAllowedState;
                MinAllowedState = minAllowedState;
            }
        }
        public Instruction(IMeasurment allowedState)
        {
            if (null == allowedState)
                throw new NullReferenceException();

            MaxAllowedState = allowedState;
            MinAllowedState = allowedState;
        }

        public IMeasurment GetMaxAllowedState()
        {
            return MaxAllowedState;
        }

        public IMeasurment GetMinAllowedState()
        {
            return MinAllowedState;
        }

        public MeasurmentTypes.Type GetPropertyID()
        {
            return MaxAllowedState.GetPropertyID();
        }

        public override String ToString()
        {
            return MaxAllowedState.Compare(MinAllowedState) == 0 ?
                MaxAllowedState.GetStringValue() :
                MinAllowedState.GetStringValue() + " - " + MaxAllowedState.GetStringValue();
        }
    }
}
