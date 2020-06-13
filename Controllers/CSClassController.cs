using CodeAnalyzer.Repositories;
using System.Collections.Generic;
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
