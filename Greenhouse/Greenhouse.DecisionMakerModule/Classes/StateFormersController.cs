﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data;

namespace Greenhouse.DecisionMakerModule
{
    public class StateFormersController : IStateFormersController
    {
        private IList<IStateFormer> StateFormers;
        public StateFormersController()
        {
            StateFormers = new List<IStateFormer>();
            StateFormers.Add(new DefaultStateFormer());
            StateFormers.Add(new LightStateFormer());
        }

        public IList<IMeasurment> FormDevicesInstructions(IList<IMeasurment> currentStates, IGPAllowedStates allowedStates)
        {
            IList<IMeasurment> ret = new List<IMeasurment>();

            foreach (IMeasurment curState in currentStates)
            {
                IStateFormer former = null;

                foreach (IStateFormer sf in StateFormers)
                {
                    if (null == former && sf.GetPropertyID() == MeasurmentTypes.Type.DefaultType
                        || sf.GetPropertyID() == curState.GetPropertyID())
                        former = sf;
                }

                ret.Add(former.FormDevicesInstruction(curState, allowedStates));
            }

            return ret;
        }
    }
}
