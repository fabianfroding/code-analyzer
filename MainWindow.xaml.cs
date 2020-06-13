﻿using CodeAnalyzer.Controllers;
using CodeAnalyzer.Repositories;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        //============================================================
        //  CONSTRUCTOR
        //============================================================
        public MainWindow()
        {
            InitializeComponent();

            CSClasses = new ChartValues<CSClass>(); // Init here to allow mapper to refer to the same instance of the chart values.
            ScatterPlot1.DataClick += ScatterPlot_ChartOnDataClick;

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
            }
        }

        private void BTNScatterPlot_Click(object sender, RoutedEventArgs e)
        {
            Histogram1.IsEnabled = false;
            Histogram1.Visibility = Visibility.Hidden;
            BTNToggleAssociatonsLOC.Visibility = Visibility.Hidden;

            ScatterPlot1.Visibility = Visibility.Visible;
            ScatterPlot1.IsEnabled = true;
        }

        private void BTNHistogram_Cick(object sender, RoutedEventArgs e)
        {
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

        //============================================================
        //  BACKEND
        //============================================================
        private void ScatterPlot_PlotData()
        {
            CSClasses.Clear();

            foreach (CSClass _CSClass in CSClassController.GetAllCSClasses(false, false))
            {
                _CSClass.GetAssociationsInListOfCSClasses(CSClassController.GetAllCSClasses(false, false));
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

        private void RowChart_PlotData(bool toggled)
        {
            ChartValues<int> Values = new ChartValues<int>();
            List<CSClass> SortedList = new List<CSClass>();
            names.Clear();

            if (toggled)
            {
                SortedList = CSClassController.GetAllCSClasses(true, false);
                Histogram1.AxisX.Clear();
                Histogram1.AxisX.Add(new Axis
                {
                    Title = "Associations",
                    Separator = new Separator
                    {
                        Step = 1,
                        IsEnabled = false // Does what? Maybe prevents separator step to automatically change when resizing window?
                    }
                });
            }
            else
            {
                SortedList = CSClassController.GetAllCSClasses(false, true);
                Histogram1.AxisX.Clear();
                Histogram1.AxisX.Add(new Axis
                {
                    Title = "LOC"
                });
            }

            for (int i = SortedList.Count < 25 ? SortedList.Count - 1 : 24; i >= 0; i--)
            {
                if (toggled)
                {
                    Values.Add(SortedList[i].GetAssociationsInListOfCSClasses(SortedList).Count);
                }
                else
                {
                    Values.Add(SortedList[i].CountLOC());
                }
                names.Add(SortedList[i].Name);
                Debug.WriteLine(i + " " + SortedList[i].Name);
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

    }
}
