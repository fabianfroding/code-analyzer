using CodeAnalyzer.Models;
using System.Windows.Controls;

namespace CodeAnalyzer
{
    public partial class CSharpClassView : UserControl
    {

        public CSharpClassView(CSharpClass cSharpClass)
        {
            InitializeComponent();
            SetProperties(cSharpClass);
        }

        public void SetProperties(CSharpClass cSharpClass)
        {
            TextBoxName.Text = cSharpClass.name;
            TextBoxLOC.Text = "LOC: " + cSharpClass.GetLOC();
            TextBoxAssociations.Text = "Associations: " + cSharpClass.FindAssociationsAmongCSharpClasses(ClassFinder.CSharpClasses).Count;
        }
    }
}
