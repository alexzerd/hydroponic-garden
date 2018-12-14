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
        void RunGrowing();
        void StopGrowing();
        ICollection<IShowInfo> GetShowInfo();
        IGPAllowedStates GetCurrentInstruction();
        DateTime GetCurrentTime();
    }
}
