using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data.Classes;

namespace Greenhouse.Peripheral.Devices
{
    public class FertilizerTank : Device
    {
        public FertilizerTank(string name = " Дозатор удобрений ", Location locc) : base(name, locc)
        {
        }
    }

}
