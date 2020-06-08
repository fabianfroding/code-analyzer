﻿using CodeAnalyzer.Controllers;
using CodeAnalyzer.Repositories;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;

namespace CodeAnalyzer
{
    public partial class MainWindow : Window
    {
        public ChartValues<CSClass> CSClasses { get; set; }
        

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<int, string> Formatter { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            CSClasses = new ChartValues<CSClass>(); // Init here to allow mapper to refer to the same instance of the chart values.
            ScatterPlot1.DataClick += ScatterPlot_ChartOnDataClick;
        }

        //============================================================
        //  UI INTERACTIVES
        //============================================================
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
                //ScatterPlot_PlotData();
                RowChart_PlotData();
            }
        }

        private void BTNScatterPlot_Click(object sender, RoutedEventArgs e)
        {
            Histogram1.IsEnabled = false;
            Histogram1.Visibility = Visibility.Hidden;

            ScatterPlot_PlotData();

            ScatterPlot1.Visibility = Visibility.Visible;
            ScatterPlot1.IsEnabled = true;
        }

        private void BTNHistogram_Cick(object sender, RoutedEventArgs e)
        {
            ScatterPlot1.IsEnabled = false;
            ScatterPlot1.Visibility = Visibility.Hidden;

            //RowChart_PlotData();

            Histogram1.Visibility = Visibility.Visible;
            Histogram1.IsEnabled = true;
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

        private void RowChart_PlotData()
        {
            ChartValues<int> LOC = new ChartValues<int>();
            List<string> classNames = new List<string>();

            foreach (CSClass _CSClass in CSClassController.GetAllCSClasses())
            {
                LOC.Add(_CSClass.CountLOC());
                classNames.Add(_CSClass.Name);
            }

            SeriesCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "Classes",
                    Values = new ChartValues<int> { 10, 50, 39, 50 }
                }
            };

            Labels = new[] { "Maria", "Susan", "Charles", "Frida" };
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

    }
}
