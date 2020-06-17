using CodeAnalyzer.Controllers;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

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
            List<CSClass> associations = _CSClass.GetAssociationsInListOfCSClasses(CSClassController.GetAllCSClasses(false, false));

            TextBoxName.Text = _CSClass.Name;
            TextBoxLOC.Text = "LOC: " + _CSClass.CountLOC();
            TextBoxAssociations.Text = "Associations: " + associations.Count;
            foreach (CSClass csClass in associations)
            {
                ListBox1.Items.Add(csClass.Name);
            }
        }
    }
}
