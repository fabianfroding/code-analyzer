using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            DrawHistogram();
        }

        public void DrawHistogram()
        {
            ((BarSeries)chart.Series[0]).ItemsSource =
                new KeyValuePair<string, int>[]{
                new KeyValuePair<string,int>("Information Holder", 12),
                new KeyValuePair<string,int>("Structurer", 25),
                new KeyValuePair<string,int>("Service Provider", 5),
                new KeyValuePair<string,int>("Controller", 6),
                new KeyValuePair<string,int>("Coordinator", 10),
                new KeyValuePair<string,int>("Interfacer", 4) };
        }
    }
}
