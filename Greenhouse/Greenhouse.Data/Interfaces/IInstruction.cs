using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Data
{
    public interface IInstruction : IPropertyID
    {
        IMeasurment GetMaxAllowedState();
        IMeasurment GetMinAllowedState();
        String ToString();
    }
}
