﻿using System;
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
        private ConfInstruction clipboard1;
        public ConfInstruction Clipboard1
        {
            get { return clipboard1; }
            set
            {
                if (clipboard1 != value)
                {
                    clipboard1 = value;
                }

            }
        }
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
                if (clipboard != null)
                {
                    InsertIsEnabled(true);
                }
                else
                {
                    InsertIsEnabled(false);
                }
            }
        }

        private GrowingPlanList gpList;
        private ConfigurationList confList;

        private string gpFilePath = null;
        private string confFilePath = null;
        public MainWindow()
        {
            InitializeComponent();
            gpList = new GrowingPlanList();
            gpDataGrid.ItemsSource = gpList.Instructions;
            confList = new ConfigurationList();
            confDataGrid.ItemsSource = confList.Instructions;
            UpdateWindow();
            Clipboard = null;
        }

        private void InsertIsEnabled(bool b)
        {
            MenuEditInsert.IsEnabled = b;
            InsertBtn.IsEnabled = b;
            ContextMenuInsert.IsEnabled = b;
        }

        private void EditCopyClick(object sender, RoutedEventArgs e)
        {
            if (gpDataGrid.SelectedIndex >= 0 && gpDataGrid.SelectedIndex < gpList.Instructions.Count && gpList != null)
            {
                this.Clipboard = new GPInstruction((GPInstruction)gpList.Instructions[gpDataGrid.SelectedIndex]);
            }
        }

        private void EditInsertClick(object sender, RoutedEventArgs e)
        {
            if (Clipboard != null && gpList != null)
            {
                if (gpDataGrid.SelectedIndex >= 0 && gpDataGrid.SelectedIndex < gpList.Instructions.Count + 1)
                {
                    gpList.Instructions.Insert(gpDataGrid.SelectedIndex, new GPInstruction(Clipboard));
                }
                else
                {
                    gpList.Instructions.Insert(gpList.Instructions.Count, new GPInstruction(Clipboard));
                }
                UpdateWindow();
            }
        }

        private void EditDeleteClick(object sender, RoutedEventArgs e)
        {
            int i = gpDataGrid.SelectedIndex;
            try
            {
                gpList.Instructions.Remove(gpList.Instructions[i]);
                UpdateWindow();
            }
            catch (ArgumentOutOfRangeException)
            { }
        }

        private void EditCutClick(object sender, RoutedEventArgs e)
        {
            EditCopyClick(sender, e);
            EditDeleteClick(sender, e);
        }

        private void LoadGP()
        {
            if (!System.IO.File.Exists(gpFilePath))
            {
                MessageBox.Show("указанный файл (" + gpFilePath + ") отсутсвует", "Ошибка!");
            }
            XmlSerializer formatter = new XmlSerializer(typeof(GrowingPlanList));
            using (FileStream fs = new FileStream(gpFilePath, FileMode.OpenOrCreate))
            {
                gpList = (GrowingPlanList)formatter.Deserialize(fs);
            }
        }
        private void LoadConfiguration()
        {
            if (!System.IO.File.Exists(confFilePath))
            {
                MessageBox.Show("указанный файл (" + confFilePath + ") отсутсвует", "Ошибка!");
            }
            XmlSerializer formatter = new XmlSerializer(typeof(ConfigurationList));
            using (FileStream fs = new FileStream(confFilePath, FileMode.OpenOrCreate))
            {
                confList = (ConfigurationList)formatter.Deserialize(fs);
            }
        }
        private bool SaveGP()
        {
            //XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<GPInstruction>));
            XmlSerializer formatter = new XmlSerializer(typeof(GrowingPlanList));

            if (File.Exists(gpFilePath)) File.Delete(gpFilePath);

            using (FileStream fs = new FileStream(gpFilePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, gpList);
                return true;
            }
        }


        private void SaveAs_BtnClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "План выращивания"; // Default file name
            dlg.DefaultExt = ".xml"; // Default file extension
            dlg.Filter = "xml documents (.xml)|*.xml"; // Filter files by extension
            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                gpFilePath = dlg.FileName;
                bool tmp = SaveGP();
                if (tmp)
                {
                    MessageBox.Show("Сохранено", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Не сохранено", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Save_BtnClick(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(gpFilePath))
            {
                SaveAs_BtnClick(sender, e);
            }
            else
            {
                bool tmp = SaveGP();
                if (tmp)
                {
                    MessageBox.Show("Сохранено");
                }
                else
                {
                    MessageBox.Show("Не сохранено");
                }
            }
        }

        private void Open_BtnClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = ""; // Default file name
            dlg.DefaultExt = ".xml"; // Default file extension
            dlg.Filter = "xml documents (.xml)|*.xml"; // Filter files by extension
            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            // Process open file dialog box results
            if (result == true)
            {
                gpFilePath = dlg.FileName;
                LoadGP();
                UpdateWindow();
            }
        }
        private void Open_BtnClickConf(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = ""; // Default file name
            dlg.DefaultExt = ".xml"; // Default file extension
            dlg.Filter = "xml documents (.xml)|*.xml"; // Filter files by extension
            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            // Process open file dialog box results
            if (result == true)
            {
                confFilePath = dlg.FileName;
                LoadConfiguration();
                UpdateWindow();
            }
        }

        private void New_BtnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Все несохранённые данные будут утеряны! \nПродолжить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
                gpFilePath = null;
                gpList = new GrowingPlanList();
                Save_BtnClick(sender, e);
                UpdateWindow();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Все несохранённые данные будут утеряны! \nВыйти?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
                this.Close();
        }


        private void RunGC_BtnClick(object sender, RoutedEventArgs e)
        {

            IConfCommon configuration = new ConfCommon(confList.Instructions.ToList<IToConfAllowedStates>);

            IGrowingPlanCommon planForModel = new GrowingPlanCommon(gpList.Instructions.ToList<IToIGPAllowedStates>());

            String errorsMsg = planForModel.CheckGrowingPlan();
            if (errorsMsg.Length > 0)
            {
                MessageBox.Show(errorsMsg, "Ошибки в плане выращивания!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            IDispatcher dispatcher = new Dispatcher.Dispatcher(planForModel, configuration);
            GrowingCycleWindow gcw = new GrowingCycleWindow(dispatcher);
            gcw.Show();
        }

        private void UpdateWindow()
        {
            gpDataGrid.ItemsSource = null;
            gpDataGrid.ItemsSource = gpList.Instructions;
            confDataGrid.ItemsSource = null;
            confDataGrid.ItemsSource = confList.Instructions;
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
