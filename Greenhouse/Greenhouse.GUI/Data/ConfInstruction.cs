using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data;
using Greenhouse.Dispatcher;

namespace Greenhouse.GUI
{
    [Serializable]
    public class ConfInstruction : IToConfAllowedStates
    {
        public ConfInstruction() { }
        public ConfInstruction(string deviceName = "имя устройства", int locX = 0, int locY = 0)
        {
            this.DeviceName = deviceName;
            this.LocX = locX;
            this.LocY = locY;
        }
        public ConfInstruction(ConfInstruction cfn)
        {
            this.DeviceName = cfn.DeviceName;
            this.LocX = cfn.LocX;
            this.LocY = cfn.LocY;
        }
     
        private string deviceName;
        public string DeviceName
        {
            get
            {
                return deviceName;
            }
            set
            {
                if (value == null)
                {
                    deviceName = "";
                }
                else
                {
                    deviceName = value;
                }
            }
        }

        private int locX;
        public int LocX
        {
            get
            {
                return locX;
            }
            set
            {
                if ((value > 0) && (value < 100))
                {
                    locX = value;
                }
                else
                {
                    locX = 25;
                }
            }
        }

        private int locY;
        public int LocY
        {
            get
            {
                return locY;
            }
            set
            {
                if ((value > 0) && (value < 100))
                {
                    locY = value;
                }
                else
                {
                    locY = 25;
                }
            }
        }

        public IConfAllowedStates ToIConfAllowedStates()
        {
            return null;
        }

    }
}
