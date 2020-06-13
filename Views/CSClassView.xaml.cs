using CodeAnalyzer.Controllers;
using System.Windows.Controls;

namespace CodeAnalyzer
{
    public partial class CSClassView : UserControl
    {

        public CSClassView(CSClass _CSClass)
        {
            InitializeComponent();
            SetProperties(_CSClass);
        }

        public void SetProperties(CSClass _CSClass)
        {
            TextBoxName.Text = _CSClass.Name;
            TextBoxLOC.Text = "LOC: " + _CSClass.CountLOC();
            TextBoxAssociations.Text = "Associations: " + _CSClass.GetAssociationsInListOfCSClasses(CSClassController.GetAllCSClasses(false, false)).Count;
        }
    }
}
