using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data;

namespace Greenhouse.Dispatcher
{
    public interface IToConfAllowedStates
    {
        IConfAllowedStates ToIConfAllowedStates();
    }
}
