using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data;

namespace Greenhouse.Dispatcher
{
    public class ConfCommon : IConfCommon
    {
        protected IList<IConfAllowedStates> AllowedStatesList;
        private Func<List<IToConfAllowedStates>> toList;

        public ConfCommon(Func<List<IToConfAllowedStates>> toList)
        {
            this.toList = toList;
        }

        public ConfCommon(ICollection<IToConfAllowedStates> allowedStatesList)
        {
            AllowedStatesList = new List<IConfAllowedStates>();
            foreach (IToConfAllowedStates state in allowedStatesList)
            {
                AllowedStatesList.Add(state.ToIConfAllowedStates());
            }
        }
        
        public IConfAllowedStates GetAllowedStates(String name){
            Location loc = new Location(32, 15);
            return null;
        }
    }
}
