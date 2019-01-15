using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.GUI
{
    [Serializable]
    public class ConfigurationList
    {
        public List<ConfInstruction> Instructions { get; set; }
        public ConfigurationList()
        {
            Instructions = new List<ConfInstruction>();
        }
    }
}
