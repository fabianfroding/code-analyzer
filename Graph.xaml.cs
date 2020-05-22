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
            DrawBarGraph(cSharpClasses);
        }

        public void DrawBarGraph(List<CSharpClass> cSharpClasses)
        {
            var list = new List<KeyValuePair<string, int>>();

            foreach (CSharpClass cSharpClass in cSharpClasses)
            {
                list.Add(new KeyValuePair<string, int>(cSharpClass.name, cSharpClass.GetLOC()));
            }

            list = list.OrderBy(x => x.Value).ToList();
            ((BarSeries)chart.Series[0]).ItemsSource = list.ToArray();
        }
    }
}
