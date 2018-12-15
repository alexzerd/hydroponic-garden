using System;
using System.Collections.Generic;
using Greenhouse.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Dispatcher
{
    public interface IDispatcher
    {
        void RunFishGrowing();
        void StopFishGrowing();
        ICollection<IShowInfo> GetShowInfo();
        IGPAllowedStates GetCurrentInstruction();
        DateTime GetCurrentTime();
    }
}
