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

        private void GenerateForceDirectedGraph(CSClass csClass)
        {
            string path = @"..\..\Resources\ForceDirectedGraph.html";
            D3WebDocumentWriter.CreateJSDocumentForClass(path, csClass);

            webBrowser.Navigate(new Uri(String.Format("file:///{0}/{1}", Directory.GetCurrentDirectory(), path)));
        }

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
