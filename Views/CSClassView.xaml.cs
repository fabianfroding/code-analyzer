using CodeAnalyzer.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
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

        // Set the display properties of the class.
        public void SetProperties(CSClass _CSClass)
        {
            List<CSClass> associations = _CSClass.GetAssociationsInList(CSClassController.GetAllCSClasses());

            TextBoxName.Text = _CSClass.Name;
            TextBoxLOC.Text = "LOC: " + _CSClass.CountLOC();
            TextBoxAssociations.Text = "Associations: " + associations.Count;
            foreach (CSClass csClass in associations)
            {
                ListBoxItem lbi = new ListBoxItem
                {
                    Content = csClass.Name
                };
                lbi.Selected += AssociationListBoxItem_Click;
                AssociationsList.Items.Add(lbi);
            }
        }

        // Create the web browser content to display the force directed graph of the associations of the class.
        private void GenerateForceDirectedGraph(CSClass csClass)
        {
            string path = @"..\..\Resources\ForceDirectedGraph.html";
            D3WebDocumentWriter.CreateJSDocumentForClass(path, csClass);

            // Navigate to the generated content using web browser control.
            webBrowser.Navigate(new Uri(String.Format("file:///{0}/{1}", Directory.GetCurrentDirectory(), path)));
        }

        // Link to new class window if an association is clicked.
        private void AssociationListBoxItem_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem lbi = e.Source as ListBoxItem;
            CSClass _CSClass = null;

            if (lbi != null)
            {
                _CSClass = CSClassController.GetCSClassByName(lbi.Content.ToString());
                Window window = new Window
                {
                    Title = _CSClass.Name,
                    Content = new CSClassView(_CSClass)
                };

                window.ShowDialog();
            }
            else
            {
                Debug.WriteLine("Error getting clicked class.");
            }

            
        }
    }
}
