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

namespace CodeAnalyzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTN_Analyze_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            ClassFinder.FindCSFilesInDirectory(fbd.SelectedPath);
            ClassFinder.GenerateCSharpClasses();
        }

        private void BTN_Graph_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            ClassFinder.FindCSFilesInDirectory(fbd.SelectedPath);
            ClassFinder.GenerateCSharpClasses();

            Graph graphWindow = new Graph(ClassFinder.CSharpClasses);
            graphWindow.Show();
            this.Close();
        }
    }
}
