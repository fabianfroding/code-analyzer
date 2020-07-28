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

        public static List<CSClass> GetTopCSClassesByAssociations(int numClasses)
        {
            List<CSClass> classes = GetAllCSClasses().OrderByDescending(o => o.GetAssociationsInList(GetAllCSClasses()).Count).ToList();
            List<CSClass> topClasses = new List<CSClass>();

            for (int i = 0; i < classes.Count && i < numClasses; i++)
            {
                if (classes[i].GetAssociationsInList(classes).Count > 0)
                {
                    topClasses.Add(classes[i]);
                }
            }

            topClasses.Reverse();
            return topClasses;
        }

        public static List<CSClass> GetTopCSClassesByLOC(int numClasses)
        {
            List<CSClass> classes = GetAllCSClasses().OrderByDescending(o => o.CountLOC()).ToList();
            List<CSClass> topClasses = new List<CSClass>();

            for (int i = 0; i < classes.Count && i < numClasses; i++)
            {
                if (classes[i].CountLOC() > 0)
                {
                    topClasses.Add(classes[i]);
                }
            }

            topClasses.Reverse();
            return topClasses;
        }

        public static CSClass GetCSClassByIndex(int index)
        {
            return CSClassRepository.GetCSClassByIndex(index);
        }

        public static CSClass GetCSClassByName(string name)
        {
            return CSClassRepository.GetCSClassByName(name);
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

        public static List<string> GetTopCSClassNamesByAssociations(int numNames)
        {
            List<CSClass> classes = GetAllCSClasses().OrderByDescending(o => o.GetAssociationsInList(GetAllCSClasses()).Count).ToList();
            List<string> topNames = new List<string>();

            for (int i = 0; i < classes.Count && i < numNames; i++)
            {
                if (classes[i].GetAssociationsInList(classes).Count > 0)
                {
                    topNames.Add(classes[i].Name);
                }
            }

            topNames.Reverse();
            return topNames;
        }

        public static List<string> GetTopCSClassNamesByLOC(int numNames)
        {
            List<CSClass> classes = GetAllCSClasses().OrderByDescending(o => o.CountLOC()).ToList();
            List<string> topNames = new List<string>();

            for (int i = 0; i < classes.Count && i < numNames; i++)
            {
                if (classes[i].CountLOC() > 0)
                {
                    topNames.Add(classes[i].Name);
                }
            }

            topNames.Reverse();
            return topNames;
        }

    }
}
