using CodeAnalyzer.Repositories;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CodeAnalyzer.Controllers
{
    public static class CSClassController
    {
        public static List<CSClass> GetAllCSClasses()
        {
            return CSClassRepository.GetAllCSClasses();
        }

        public static List<CSClass> GetTopCSClasses(bool sortByAssociations, bool sortByLOC, int numClasses)
        {
            List<CSClass> classes = CSClassRepository.GetAllCSClasses();
            List<CSClass> topClasses = new List<CSClass>();

            if (sortByAssociations)
            {
                classes = classes.OrderByDescending(o => o.GetAssociationsInList(classes).Count).ToList();
                for (int i = 0; i < classes.Count && i < numClasses; i++)
                {
                    if (classes[i].GetAssociationsInList(classes).Count > 0)
                    {
                        topClasses.Add(classes[i]);
                    }
                }
            }
            if (sortByLOC)
            {
                classes = classes.OrderByDescending(o => o.CountLOC()).ToList();
                for (int i = 0; i < classes.Count && i < numClasses; i++)
                {
                    if (classes[i].CountLOC() > 0)
                    {
                        topClasses.Add(classes[i]);
                    }
                }
            }

            topClasses.Reverse();
            return topClasses;
        }

        public static CSClass GetCSClassByIndex(int index)
        {
            return CSClassRepository.GetCSClassByIndex(index);
        }

        public static List<int> GetTopAssociations(int numValues)
        {
            List<CSClass> classes = CSClassRepository.GetAllCSClasses();
            List<int> values = new List<int>();

            classes = classes.OrderByDescending(o => o.GetAssociationsInList(classes).Count).ToList();
            for (int i = 0; i < classes.Count && i < numValues; i++)
            {
                int numAssociations = classes[i].GetAssociationsInList(classes).Count;
                if (numAssociations > 0)
                {
                    values.Add(numAssociations);
                }
            }

            values.Reverse();
            return values;
        }

        public static List<int> GetTopLOC(int numValues)
        {
            List<CSClass> classes = CSClassRepository.GetAllCSClasses();
            List<int> values = new List<int>();

            classes = classes.OrderByDescending(o => o.CountLOC()).ToList();
            for (int i = 0; i < classes.Count && i < numValues; i++)
            {
                if (classes[i].CountLOC() > 0)
                {
                    values.Add(classes[i].CountLOC());
                }
            }

            values.Reverse();
            return values;
        }

        public static List<string> GetTopCSClassNames(bool sortByAssociations, bool sortByLOC, int numNames)
        {
            List<CSClass> classes = CSClassRepository.GetAllCSClasses();
            List<string> topNames = new List<string>();

            if (sortByAssociations)
            {
                classes = classes.OrderByDescending(o => o.GetAssociationsInList(classes).Count).ToList();
                for (int i = 0; i < classes.Count && i < numNames; i++)
                {
                    if (classes[i].GetAssociationsInList(classes).Count > 0)
                    {
                        topNames.Add(classes[i].Name);
                    }
                }
            }
            if (sortByLOC)
            {
                classes = classes.OrderByDescending(o => o.CountLOC()).ToList();
                for (int i = 0; i < classes.Count && i < numNames; i++)
                {
                    if (classes[i].CountLOC() > 0)
                    {
                        topNames.Add(classes[i].Name);
                    }
                }
            }

            topNames.Reverse();
            return topNames;
        }

    }
}
