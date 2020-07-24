using CodeAnalyzer.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;

namespace CodeAnalyzer
{
    public partial class CSClassView : UserControl
    {

        public CSClassView(CSClass _CSClass)
        {
            InitializeComponent();
            SetProperties(_CSClass);
            GenerateForceDirectedGraph(_CSClass);
        }

        public void SetProperties(CSClass _CSClass)
        {
            List<CSClass> associations = _CSClass.GetAssociationsInList(CSClassController.GetAllCSClasses());

            TextBoxName.Text = _CSClass.Name;
            TextBoxLOC.Text = "LOC: " + _CSClass.CountLOC();
            TextBoxAssociations.Text = "Associations: " + associations.Count;
            foreach (CSClass csClass in associations)
            {
                AssociationsList.Items.Add(csClass.Name);
            }
        }

        private void GenerateForceDirectedGraph(CSClass csClass)
        {
            string path = @"..\..\Resources\ForceDirectedGraph.html";
            D3WebDocumentWriter.CreateJSDocumentForClass(path, csClass);

            webBrowser.Navigate(new Uri(String.Format("file:///{0}/{1}", Directory.GetCurrentDirectory(), path)));
        }
    }
}
