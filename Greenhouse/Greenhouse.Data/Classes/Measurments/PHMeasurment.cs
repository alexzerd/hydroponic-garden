﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.Data
{
    public sealed class PHMeasurment : IPHMeasurment, IPhysicalObjectState
    {
        public PHMeasurment(Double ph)
        {
            PH = ph;
        }


        public Double GetPH()
        {
            return PH;
        }

        public MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.PH;
        }

        public int Compare(IMeasurment meas)
        {
            return PH.CompareTo(((PHMeasurment)meas).PH);
        }

        public String GetStringValue()
        {
            return PH.ToString();
        }

        //Data
        private Double PH;
    }
}
