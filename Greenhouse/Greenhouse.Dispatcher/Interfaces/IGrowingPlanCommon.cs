using System;
using Greenhouse.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Dispatcher
{
    interface IGrowingPlanCommon
    {
        IGPAllowedStates GetAllowedStates(Int32 hours, Int32 minutes);

        String CheckGrowingPlan();
    }
}
