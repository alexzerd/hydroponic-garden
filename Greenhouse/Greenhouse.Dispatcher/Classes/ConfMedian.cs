using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data;

namespace Greenhouse.Dispatcher
{
    public class ConfMedian
    {
        public static IList<Location> Configuration()
        {
            IList<Location> configuration = new List<Location>();
            Random rng = new Random();
            configuration.Add(new Location(rng.Next(0, 10), rng.Next(0, 10)));
            configuration.Add(new Location(rng.Next(80, 100), rng.Next(0, 20)));
            configuration.Add(new Location(rng.Next(0, 20), rng.Next(80, 100)));
            configuration.Add(new Location(rng.Next(80, 100), rng.Next(80, 100)));
            configuration.Add(new Location(rng.Next(50, 70), rng.Next(30, 40)));
            configuration.Add(new Location(rng.Next(0, 20), rng.Next(50, 68)));
            configuration.Add(new Location(rng.Next(70, 100), rng.Next(50, 68)));
            configuration.Add(new Location(rng.Next(50, 70), rng.Next(0, 10)));
            configuration.Add(new Location(rng.Next(10, 15), rng.Next(20, 30)));
            configuration.Add(new Location(rng.Next(76, 89), rng.Next(30, 40)));
            return configuration;
        }
    }
}
