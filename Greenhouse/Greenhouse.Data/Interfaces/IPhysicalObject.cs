using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Data
{
    public interface IPhysicalObject : IPropertyID
    {
        Location GetLocation();
        void SetLocation(Location location);
        String Name { get; set; }
    }
}
