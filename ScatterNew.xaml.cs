using CodeAnalyzer.Models;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System.Windows.Controls;

namespace CodeAnalyzer
{
    public partial class ScatterNew : UserControl
    {
        public ChartValues<CSharpClassVm> CSharpClasses { get; set; }

        public ScatterNew()
        {
            InitializeComponent();

            CSharpClasses = new ChartValues<CSharpClassVm>();

            foreach (CSharpClass cSharpClass in ClassFinder.CSharpClasses)
            {
                CSharpClassVm vm = new CSharpClassVm
                {
                    Name = cSharpClass.name,
                    NumAssociations = cSharpClass.FindAssociationsAmongCSharpClasses(ClassFinder.CSharpClasses).Count,
                    NumLOC = cSharpClass.GetLOC()
                };
                CSharpClasses.Add(vm);
                System.Diagnostics.Debug.WriteLine(vm.ToString());
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

            //Labels = new[] { "Irvin", "Malcolm", "Anne", "Vivian", "Caleb" };

            //let create a mapper so LiveCharts know how to plot our CustomerViewModel class
            var cSharpClassVmMapper = Mappers.Xy<CSharpClassVm>()
                .X(value => value.NumLOC) // lets use the position of the item as X
                .Y(value => value.NumAssociations); //and PurchasedItems property as Y

            //lets save the mapper globally
            Charting.For<CSharpClassVm>(cSharpClassVmMapper);

            DataContext = this;
        }

        
        //public string[] Labels { get; set; }
    }
}
