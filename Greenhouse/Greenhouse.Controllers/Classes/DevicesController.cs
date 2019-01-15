using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Peripheral;
using Greenhouse.Data;

namespace Greenhouse.Controllers
{
    public class DevicesController : IDevicesController
    {
        protected Controller<IDevice> physicalObjectsController;
        public DevicesController(IList<Location> loc)
        {

            physicalObjectsController = new Controller<IDevice>();
            physicalObjectsController.AddObject(new TemperatureDevice(loc[0]));
            physicalObjectsController.AddObject(new TemperatureDevice(loc[1]));
            physicalObjectsController.AddObject(new OxygenDevice(loc[2]));
            physicalObjectsController.AddObject(new PhDevice(loc[3]));
            physicalObjectsController.AddObject(new LightDevice(loc[4]));
        }

        public IList<IMeasurment> GetDevicesStates()
        {
            IList<IMeasurment> ret = new List<IMeasurment>();
            IList<IDevice> devices = physicalObjectsController.GetPhysicalObjects();

            foreach (IDevice dev in devices)
                ret.Add(dev.GetState());

            return ret;
        }

        public void AffectEnvironment(IList<IMeasurment> reauiredStates)
        {
            IList<IDevice> devices = physicalObjectsController.GetPhysicalObjects();

            foreach (IMeasurment meas in reauiredStates)
                foreach (IDevice dev in devices)
                    if (dev.GetPropertyID() == meas.GetPropertyID())
                        dev.SetState(meas);
        }

        public ICollection<IShowInfo> GetShowInfo()
        {
            List<IShowInfo> ret = new List<IShowInfo>();
            IList<IDevice> devices = physicalObjectsController.GetPhysicalObjects();

            foreach (IDevice it in devices)
            {
                ShowInfo shInf = new ShowInfo();
                shInf.State = it.GetState();
                shInf.Item = it;
                ret.Add(shInf);
            }

            return ret;
        }
    }
}
