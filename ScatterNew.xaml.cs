using CodeAnalyzer.Controllers;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System.Windows;
using System.Windows.Controls;

namespace CodeAnalyzer
{
    public partial class ScatterNew : UserControl
    {
        public ChartValues<CSClass> CSClasses { get; set; }

        public ScatterNew()
        {
            InitializeComponent();

            CSClasses = new ChartValues<CSClass>();

            foreach (CSClass _CSClass in CSClassController.GetAllCSClasses())
            {
                _CSClass.GetAssociationsInListOfCSClasses(CSClassController.GetAllCSClasses());
                _CSClass.CountLOC();
                CSClasses.Add(_CSClass);
            }

            // Force y-axis to have interval based on 1.
            chart1.AxisY.Clear();
            chart1.AxisY.Add(new Axis
            {
                Title = "Associations",
                Separator = new LiveCharts.Wpf.Separator
                {
                    Step = 1,
                    IsEnabled = false // Does what? Maybe prevents separator step to automatically change when resizing window?
                }
            });

            chart1.DataClick += ChartOnDataClick;


            //let create a mapper so LiveCharts know how to plot our CustomerViewModel class
            var _CSClassVm = Mappers.Xy<CSClass>()
                .X(value => value.NumLOC) // lets use the position of the item as X
                .Y(value => value.NumAssociations); //and PurchasedItems property as Y

            //lets save the mapper globally
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
