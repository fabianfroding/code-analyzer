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
                classes = classes.OrderByDescending(o => o.GetAssociationsInListOfCSClasses(classes).Count).ToList();
                for (int i = 0; i < classes.Count && i < numClasses; i++)
                {
                    if (classes[i].GetAssociationsInListOfCSClasses(classes).Count > 0)
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

    }
}
