using System.ComponentModel;
using LiveCharts;
using LiveCharts.Wpf;

namespace CodeAnalyzer
{
    public partial class CSharpClassesTooltip : IChartTooltip
    {
        private TooltipData _data;

        public CSharpClassesTooltip()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TooltipData Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged("Data");
            }
        }

        public TooltipSelectionMode? SelectionMode { get; set; }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }  
        }
    }
}
