using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Data
{
    public interface IOxygenMeasurrment : IMeasurment
    {
        Int32 GetOxygen();
    }
}
