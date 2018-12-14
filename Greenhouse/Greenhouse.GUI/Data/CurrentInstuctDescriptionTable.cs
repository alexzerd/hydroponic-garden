using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.GUI
{
    class CurrentInstuctDescriptionTable
    {
        public string ParamName { get; set; }
        public string ParamValue { get; set; }

        public CurrentInstuctDescriptionTable()
        {
        }
        public CurrentInstuctDescriptionTable(string paramName, string paramValue)
        {
            ParamName = paramName;
            ParamValue = paramValue;
        }
    }
}
