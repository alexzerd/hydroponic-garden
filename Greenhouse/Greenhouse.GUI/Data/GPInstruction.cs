﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data;
using Greenhouse.Dispatcher;

namespace Greenhouse.GUI
{
    [Serializable]
    public class GPInstruction : IToIGPAllowedStates
    {
        public GPInstruction() { }

        public GPInstruction(IGPAllowedStates gpas)
        {
            InstructionName = gpas.Name;
            Hours = gpas.Hours;
            Minutes = gpas.Minutes;
            IMeasurment temp;
            temp = (IMeasurment)gpas.GetStateByPropertyID(MeasurmentTypes.Type.Temperature).GetMaxAllowedState();
            TemperatureMax = ((ITemperatureMeasurment)temp).GetTemperature();

            temp = (IMeasurment)gpas.GetStateByPropertyID(MeasurmentTypes.Type.Temperature).GetMinAllowedState();
            TemperatureMin = ((ITemperatureMeasurment)temp).GetTemperature();

            temp = (IMeasurment)gpas.GetStateByPropertyID(MeasurmentTypes.Type.Oxygen).GetMinAllowedState();
            Oxygen = ((IOxygenMeasurrment)temp).GetOxygen();

            temp = (IMeasurment)gpas.GetStateByPropertyID(MeasurmentTypes.Type.PH).GetMinAllowedState();
            PH = ((IPHMeasurment)temp).GetPH();

            // temp = (IMeasurment)gpas.GetStateByPropertyID(MeasurmentTypes.Type.LightPerDay).GetMinAllowedState();
            LightHoursPerDay = 0;
        }
        public GPInstruction(string instructionName = "имя интсрукции", int hours = 0, int minutes = 0,
            int temperatureMax = 25, int temperatureMin = 25, int oxygen = 20, int lightHoursPerDay = 12, double pH = 7)
        {
            this.InstructionName = instructionName;
            this.Hours = hours;
            this.Minutes = minutes;
            this.TemperatureMax = temperatureMax;
            this.TemperatureMin = temperatureMin;
            this.Oxygen = oxygen;
            this.LightHoursPerDay = lightHoursPerDay;
            this.PH = pH;
        }
        public GPInstruction(GPInstruction gpn)
        {
            this.InstructionName = gpn.InstructionName;
            this.Hours = gpn.Hours;
            this.Minutes = gpn.Minutes;
            this.TemperatureMax = gpn.TemperatureMax;
            this.TemperatureMin = gpn.TemperatureMin;
            this.Oxygen = gpn.Oxygen;
            this.LightHoursPerDay = gpn.LightHoursPerDay;
            this.PH = gpn.PH;
        }

        public IGPAllowedStates ToIGPAllowedStates()
        {
            IList<IInstruction> ret_states = new List<IInstruction>();

            ret_states.Add(new Instruction(new TemperatureMeasurment(TemperatureMax), new TemperatureMeasurment(TemperatureMin)));
            ret_states.Add(new Instruction(new PHMeasurment(PH)));
            ret_states.Add(new Instruction(new OxygenMeasurment(Oxygen)));
            ret_states.Add(new LightInstruction(LightHoursPerDay));

            return new GPAllowedStates(InstructionName, Hours, Minutes, ret_states);
        }


        private string instructionName;
        public string InstructionName
        {
            get
            {
                return instructionName;
            }
            set
            {
                if (value == null)
                {
                    instructionName = "";
                }
                else
                {
                    instructionName = value;
                }
            }
        }

        private int hours;
        public int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (value >= 0)
                {
                    hours = value;
                }
                else
                {
                    hours = 0;
                }
            }
        }

        private int minutes;
        public int Minutes
        {
            get
            {
                return minutes;
            }

            set
            {
                if ((value >= 0) && (value < 60))
                {
                    minutes = value;
                }
                else
                {
                    minutes = 0;
                }
            }
        }

        private int temperatureMin = 25;
        public int TemperatureMin
        {
            get
            {
                return temperatureMin;
            }
            set
            {
                if ((value > 0) && (value < 100))
                {
                    temperatureMin = value;
                }
                else
                {
                    temperatureMin = 25;
                }
            }
        }

        private int temperatureMax = 25;
        public int TemperatureMax
        {
            get
            {
                return temperatureMax;
            }
            set
            {
                if ((value > 0) && (value < 100))
                {
                    temperatureMax = value;
                }
                else
                {
                    temperatureMax = 25;
                }
            }
        }

        private int oxygen = 0;
        public int Oxygen
        {
            get
            {
                return oxygen;
            }
            set
            {
                if (value >= 0)
                {
                    oxygen = value;
                }
                else
                {
                    oxygen = 0;
                }
            }
        }

        private int lightHoursPerDay;
        public int LightHoursPerDay
        {
            get
            {
                return lightHoursPerDay;
            }
            set
            {
                if ((value >= 0) && (value <= 24))
                {
                    lightHoursPerDay = value;
                }
                else
                {
                    lightHoursPerDay = 0;
                }
            }
        }

        private double ph;
        public double PH
        {
            get
            {
                return ph;
            }
            set
            {
                if ((value >= 0) && (value <= 20))
                {
                    ph = value;
                }
                else
                {
                    ph = 7;
                }
            }
        }



    }
}
