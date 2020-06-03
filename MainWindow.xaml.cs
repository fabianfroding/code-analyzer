using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Diagnostics;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CodeAnalyzer.Repositories;
using LiveCharts;
using CodeAnalyzer.Controllers;
using LiveCharts.Configurations;
using LiveCharts.Wpf;

namespace CodeAnalyzer
{
    public partial class MainWindow : Window
    {
        public ChartValues<CSClass> CSClasses { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            CSClasses = new ChartValues<CSClass>(); // Init here to allow mapper to refer to the same instance of the chart values.
            ScatterPlot1.DataClick += ChartOnDataClick;
        }

        private void BTNClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void GridBarTitle_MouseDown(object sender, RoutedEventArgs e)
        {
            DragMove();
        }

        private void BTNLoadProject_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select Project Directory";
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CSClassRepository.GetCSFilesInDirectory(fbd.SelectedPath);
                PlotData();
            }
        }

        private void PlotData()
        {
            CSClasses.Clear();

            foreach (CSClass _CSClass in CSClassController.GetAllCSClasses())
            {
                _CSClass.GetAssociationsInListOfCSClasses(CSClassController.GetAllCSClasses());
                _CSClass.CountLOC();
                CSClasses.Add(_CSClass);
            }

            
            // Force y-axis to have interval based on 1.
            ScatterPlot1.AxisY.Clear();
            ScatterPlot1.AxisY.Add(new Axis
            {
                Title = "Associations",
                Separator = new LiveCharts.Wpf.Separator
                {
                    Step = 1,
                    IsEnabled = false // Does what? Maybe prevents separator step to automatically change when resizing window?
                }
            });

            // Let create a mapper so LiveCharts know how to plot our CSClass class
            var _CSClassVm = Mappers.Xy<CSClass>()
                .X(value => value.NumLOC)
                .Y(value => value.NumAssociations);

            // Lets save the mapper globally
            Charting.For<CSClass>(_CSClassVm);

            DataContext = this;
        }

        private void ChartOnDataClick(object sender, ChartPoint p)
        {
            CSClass _CSClass = CSClassController.GetCSClassByIndex(p.Key);

            Window window = new Window
            {
                Title = _CSClass.Name,
                Content = new CSClassView(_CSClass)
            };

            window.ShowDialog();
        }

    }
}
