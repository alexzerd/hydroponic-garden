﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Greenhouse.GUI.UIElements
{
    /// <summary>
    /// Логика взаимодействия для TemperatureDeviceUI.xaml
    /// </summary>
    public partial class TemperatureDeviceUI : UserControl, IHaveProp_Value
    {
        private string temperatureValue;
        public string Value
        {
            get
            {
                return temperatureValue;
            }
            set
            {
                temperatureValue = value;
                value_lbl.Content = temperatureValue;
            }
        }
        public TemperatureDeviceUI()
        {
            InitializeComponent();
            value_lbl.Content = Value;
        }
    }
}
