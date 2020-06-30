using CodeAnalyzer.Repositories;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CodeAnalyzer.Controllers
{
    public static class CSClassController
    {
        public static List<CSClass> GetAllCSClasses(bool sortByAssociations, bool sortByLOC)
        {
            List<CSClass> classes = CSClassRepository.GetAllCSClasses();
            if (sortByAssociations)
            {
                classes = classes.OrderByDescending(o => o.GetAssociationsInListOfCSClasses(classes).Count).ToList();
            }
            if (sortByLOC)
            {
                classes = classes.OrderByDescending(o => o.CountLOC()).ToList();
            }
            return classes;
        }

        public static List<CSClass> GetTopCSClasses(bool sortByAssociations, bool sortByLOC, int numClasses)
        {
            List<CSClass> classes = CSClassRepository.GetAllCSClasses();
            List<CSClass> topClasses = new List<CSClass>();

            if (sortByAssociations)
            {
                classes = classes.OrderByDescending(o => o.GetAssociationsInListOfCSClasses(classes).Count).ToList();
            }
            if (sortByLOC)
            {
                classes = classes.OrderByDescending(o => o.CountLOC()).ToList();
            }

            for (int i = 0; i < classes.Count && i < numClasses; i++)
            {
                topClasses.Add(classes[i]);
            }

            return topClasses;
        }

        public static CSClass GetCSClassByName(string name)
        {
            return CSClassRepository.GetCSClassByName(name);
        }

        public static CSClass GetCSClassByIndex(int index)
        {
            return CSClassRepository.GetCSClassByIndex(index);
        }

    }
}
