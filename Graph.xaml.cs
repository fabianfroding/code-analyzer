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

        public Graph(List<KeyValuePair<string, int>> values)
        {
            InitializeComponent();
            DrawBarGraph(values);
        }

        public void DrawBarGraph(List<KeyValuePair<string, int>> values)
        {
            values = values.OrderBy(x => x.Value).ToList();
            ((BarSeries)chart.Series[0]).ItemsSource = values.ToArray();
        }
    }
}
