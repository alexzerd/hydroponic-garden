using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Peripheral;
using Greenhouse.Data;

namespace Greenhouse.Controllers
{
    public class SensorsController : ISensorsController
    {
        protected Controller<ISensor> physicalObjectsController;
        public SensorsController(IList<Location> loc)
        {
            physicalObjectsController = new Controller<ISensor>();
            physicalObjectsController.AddObject(new TemperatureSensor(loc[5]));
            physicalObjectsController.AddObject(new TemperatureSensor(loc[6]));
            physicalObjectsController.AddObject(new OxygenSensor(loc[7]));
            physicalObjectsController.AddObject(new PhSensor(loc[8]));
            physicalObjectsController.AddObject(new LightSensor(loc[9]));
        }

        public IList<IMeasurment> GetEnvironmentStates()
        {
            IList<IMeasurment> ret = new List<IMeasurment>();
            IList<ISensor> sensors = physicalObjectsController.GetPhysicalObjects();

            foreach (ISensor sens in sensors)
                ret.Add(sens.Measure());

            return ret;
        }

        public ICollection<IShowInfo> GetShowInfo()
        {
            List<IShowInfo> ret = new List<IShowInfo>();
            IList<ISensor> sensors = physicalObjectsController.GetPhysicalObjects();

            foreach (ISensor it in sensors)
            {
                ShowInfo shInf = new ShowInfo();
                shInf.State = it.GetLastMeasurment();
                shInf.Item = it;
                ret.Add(shInf);
            }

            return ret;
        }
    }
}
