using System;
using System.Collections.Generic;
using System.IO;
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
using Greenhouse.Dispatcher;
using System.Xml.Serialization;

namespace Greenhouse.GUI
{
    public partial class MainWindow : Window
    {
        private GPInstruction clipboard;
        public GPInstruction Clipboard
        {
            get { return clipboard; }
            set
            {
                if (clipboard != value)
                {
                    clipboard = value;
                }

            }
        }

        private GrowingPlanList gpList;

        private string gpFilePath = null;
        public MainWindow()
        {
            InitializeComponent();
            gpList = new GrowingPlanList();
            gpDataGrid.ItemsSource = gpList.Instructions;
            UpdateWindow();
            Clipboard = null;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Все несохранённые данные будут утеряны! \nВыйти?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
                this.Close();
        }


        private void RunGC_BtnClick(object sender, RoutedEventArgs e)
        {
       
            IGrowingPlanCommon planForModel = new GrowingPlanCommon(gpList.Instructions.ToList<IToIGPAllowedStates>());

            String errorsMsg = planForModel.CheckGrowingPlan();
            if (errorsMsg.Length > 0)
            {
                MessageBox.Show(errorsMsg, "Ошибки в плане выращивания!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            IDispatcher dispatcher = new Dispatcher.Dispatcher(planForModel);
            GrowingCycleWindow gcw = new GrowingCycleWindow(dispatcher);
            gcw.Show();
        }

        private void UpdateWindow()
        {
            gpDataGrid.ItemsSource = null;
            gpDataGrid.ItemsSource = gpList.Instructions;
        }

        private void SelectLineClick(object sender, RoutedEventArgs e)
        {
            if (gpList.Instructions.Count > 1)
            {
                SelectStringWindow ssw = new SelectStringWindow(gpList.Instructions.Count);
                if (ssw.ShowDialog() == true)
                {
                    try
                    {
                        gpDataGrid.SelectedIndex = ssw.LineNumber - 1;
                    }
                    catch (ArgumentOutOfRangeException)
                    { }
                }
            }
        }

    }
}
