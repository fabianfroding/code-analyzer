﻿using CodeAnalyzer.Models;
using LiveCharts;
using LiveCharts.Defaults;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CodeAnalyzer
{
    /// <summary>
    /// Interaction logic for ScatterPlot.xaml
    /// </summary>
    public partial class ScatterPlot : UserControl
    {
        public ChartValues<ObservablePoint> ValuesA { get; set; }
        public ChartValues<ObservablePoint> ValuesB { get; set; }
        public ChartValues<ObservablePoint> ValuesC { get; set; }

        public ScatterPlot()
        {
            InitializeComponent();

            ValuesA = new ChartValues<ObservablePoint>();
            foreach (CSharpClass cSharpClass in ClassFinder.CSharpClasses)
            {
                ValuesA.Add(new ObservablePoint(
                    cSharpClass.GetLOC(),
                    cSharpClass.FindAssociationsAmongCSharpClasses(ClassFinder.CSharpClasses).Count
                    ));
            }

            /*
            var r = new Random();
            ValuesA = new ChartValues<ObservablePoint>();
            ValuesB = new ChartValues<ObservablePoint>();
            ValuesC = new ChartValues<ObservablePoint>();

            for (var i = 0; i < 20; i++)
            {
                ValuesA.Add(new ObservablePoint(r.NextDouble() * 10, r.NextDouble() * 10));
                ValuesB.Add(new ObservablePoint(r.NextDouble() * 10, r.NextDouble() * 10));
                ValuesC.Add(new ObservablePoint(r.NextDouble() * 10, r.NextDouble() * 10));
            }
            */

            DataContext = this;
        }

        private void RandomizeOnClick(object sender, RoutedEventArgs e)
        {
            var r = new Random();
            for (var i = 0; i < 20; i++)
            {
                ValuesA[i].X = r.NextDouble() * 10;
                ValuesA[i].Y = r.NextDouble() * 10;
                ValuesB[i].X = r.NextDouble() * 10;
                ValuesB[i].Y = r.NextDouble() * 10;
                ValuesC[i].X = r.NextDouble() * 10;
                ValuesC[i].Y = r.NextDouble() * 10;
            }
        }
    }
}
