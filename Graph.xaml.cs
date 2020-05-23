using CodeAnalyzer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;

namespace CodeAnalyzer
{
    /// <summary>
    /// Interaction logic for Graph.xaml
    /// </summary>
    public partial class Graph : Window
    {
        public Graph()
        {
            InitializeComponent();
        }

        public Graph(List<CSharpClass> cSharpClasses)
        {
            InitializeComponent();
            //DrawBarGraph(cSharpClasses);
            DrawScatterPlot(cSharpClasses);
        }

        /*public void DrawBarGraph(List<CSharpClass> cSharpClasses)
        {
            var list = new List<KeyValuePair<string, int>>();

            foreach (CSharpClass cSharpClass in cSharpClasses)
            {
                list.Add(new KeyValuePair<string, int>(cSharpClass.name, cSharpClass.FindAssociationsAmongCSharpClasses(ClassFinder.CSharpClasses).Count));
            }

            list = list.OrderBy(x => x.Value).ToList();
            ((BarSeries)chart.Series[0]).ItemsSource = list.ToArray();
        }*/

        public void DrawScatterPlot(List<CSharpClass> cSharpClasses)
        {
            var list = new List<KeyValuePair<int, int>>();

            foreach (CSharpClass cSharpClass in cSharpClasses)
            {
                list.Add(new KeyValuePair<int, int>(cSharpClass.GetLOC(), cSharpClass.FindAssociationsAmongCSharpClasses(ClassFinder.CSharpClasses).Count));
            }

            //list = list.OrderBy(x => x.Value).ToList();
            ((ScatterSeries)scatterChart.Series[0]).ItemsSource = list.ToArray();
        }
    }
}
