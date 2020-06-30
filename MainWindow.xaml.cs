using CodeAnalyzer.Controllers;
using CodeAnalyzer.Repositories;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace CodeAnalyzer
{
    public partial class MainWindow : Window
    {
        // Scatter Plot chart properties.
        public ChartValues<CSClass> CSClasses { get; set; }

        // Row chart properties.
        public SeriesCollection SeriesCollection { get; set; }
        public Func<int, string> Formatter { get; set; }
        public List<string> names { get; set; }
        private RowSeries RowSeries;
        private bool ToggledAssociationsLOC = true;
        private List<CSClass> SortedList;

        //============================================================
        //  CONSTRUCTOR
        //============================================================
        public MainWindow()
        {
            //Debug.Listeners.Add(new TextWriterTraceListener(Console.Out)); // Causes methods to run twice... ? Or just the Debug.WriteLine?
            Debug.AutoFlush = true;
            InitializeComponent();

            CSClasses = new ChartValues<CSClass>(); // Init here to allow mapper to refer to the same instance of the chart values.
            ScatterPlot1.DataClick += ScatterPlot_ChartOnDataClick;
            Histogram1.DataClick += RowChart_ChartOnDataClick;

            SeriesCollection = new SeriesCollection();
            names = new List<string>();
        }

        //============================================================
        //  UI INTERACTIVES
        //============================================================
        private void BTNClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void BTNMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BTNMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (BTNFullScreenIcon.Kind == MaterialDesignThemes.Wpf.PackIconKind.WindowMaximize)
            {
                this.WindowState = WindowState.Maximized;
                BTNFullScreenIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowRestore;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                BTNFullScreenIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowMaximize;
            }
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
                RowChart_PlotData(false);
                ToggledAssociationsLOC = true;
                ScatterPlot_PlotData();

                // If current view is Force Directed Graph, refresh the graph to show the loaded project.
                if (webBrowser.Visibility == Visibility.Visible)
                {
                    BTNAssociations_Click(this, null);
                }
            }

            BTNScatterPlot.IsEnabled = true;
            BTNRowChart.IsEnabled = true;
            BTNForceDirectedGraph.IsEnabled = true;
        }

        private void BTNScatterPlot_Click(object sender, RoutedEventArgs e)
        {
            webBrowser.Visibility = Visibility.Hidden;

            Histogram1.IsEnabled = false;
            Histogram1.Visibility = Visibility.Hidden;
            BTNToggleAssociatonsLOC.Visibility = Visibility.Hidden;

            ScatterPlot1.Visibility = Visibility.Visible;
            ScatterPlot1.IsEnabled = true;
        }

        private void BTNHistogram_Cick(object sender, RoutedEventArgs e)
        {
            webBrowser.Visibility = Visibility.Hidden;

            ScatterPlot1.IsEnabled = false;
            ScatterPlot1.Visibility = Visibility.Hidden;

            Histogram1.Visibility = Visibility.Visible;
            Histogram1.IsEnabled = true;
            BTNToggleAssociatonsLOC.Visibility = Visibility.Visible;
        }

        private void BTNToggleAssociatonsLOC_Click(object sender, RoutedEventArgs e)
        {
            if (ToggledAssociationsLOC)
            {
                RowChart_PlotData(true);
                ToggledAssociationsLOC = false;
            }
            else
            {
                RowChart_PlotData(false);
                ToggledAssociationsLOC = true;
            }
            
        }

        private void BTNAssociations_Click(object sender, RoutedEventArgs e)
        {
            ScatterPlot1.IsEnabled = false;
            ScatterPlot1.Visibility = Visibility.Hidden;

            Histogram1.IsEnabled = false;
            Histogram1.Visibility = Visibility.Hidden;
            BTNToggleAssociatonsLOC.Visibility = Visibility.Hidden;

            string path = @"..\..\Resources\ForceDirectedGraph.html";
            D3WebDocumentWriter.CreateJSDocument(path);

            webBrowser.Visibility = Visibility.Visible;
            webBrowser.Navigate(new Uri(String.Format("file:///{0}/{1}", Directory.GetCurrentDirectory(), path)));
        }

        //============================================================
        //  BACKEND
        //============================================================
        private void ScatterPlot_PlotData()
        {
            CSClasses.Clear();

            foreach (CSClass _CSClass in CSClassController.GetAllCSClasses())
            {
                _CSClass.GetAssociationsInListOfCSClasses(CSClassController.GetAllCSClasses());
                _CSClass.CountLOC();
                CSClasses.Add(_CSClass);
            }

            // Let create a mapper so LiveCharts know how to plot our CSClass class
            var _CSClassVm = Mappers.Xy<CSClass>()
                .X(value => value.NumLOC)
                .Y(value => value.NumAssociations);

            // Lets save the mapper globally
            Charting.For<CSClass>(_CSClassVm);

            DataContext = this;
        }

        private void RowChart_PlotData(bool toggled)
        {
            ChartValues<int> Values = new ChartValues<int>();
            SortedList = new List<CSClass>();
            names.Clear();

            Histogram1.AxisX.Clear();
            Axis axis = new Axis
            {
                Title = toggled ? "Associations" : "LOC"
            };
            Histogram1.AxisX.Add(axis);

            int numClasses = 25;
            SortedList = toggled ? CSClassController.GetTopCSClasses(true, false, numClasses) : CSClassController.GetTopCSClasses(false, true, numClasses);
            for (int i = SortedList.Count < numClasses ? SortedList.Count - 1 : numClasses - 1; i >= 0; i--)
            {
                int vals = toggled ? SortedList[i].GetAssociationsInListOfCSClasses(CSClassController.GetAllCSClasses()).Count : SortedList[i].CountLOC();
                if (vals > 0)
                {
                    Values.Add(vals);
                    names.Add(SortedList[i].Name);
                }
            }

            if (RowSeries != null)
            {
                SeriesCollection.Remove(RowSeries);
            }
            RowSeries = new RowSeries
            {
                Title = toggled ? "Associations" : "LOC",
                Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#6df4e9"),
                Values = Values
            };

            SeriesCollection.Add(RowSeries);
            Formatter = value => value.ToString("N");
            DataContext = this;
        }

        private void ScatterPlot_ChartOnDataClick(object sender, ChartPoint p)
        {
            CSClass _CSClass = CSClassController.GetCSClassByIndex(p.Key);

            Window window = new Window
            {
                Title = _CSClass.Name,
                Content = new CSClassView(_CSClass)
            };

            window.ShowDialog();
        }

        private void RowChart_ChartOnDataClick(object sender, ChartPoint p)
        {
            CSClass _CSClass = SortedList[SortedList.Count - 1 - p.Key];

            Window window = new Window
            {
                Title = _CSClass.Name,
                Content = new CSClassView(_CSClass)
            };

            window.ShowDialog();
        }

    }
}
