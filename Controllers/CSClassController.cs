using CodeAnalyzer.Repositories;
using System.Collections.Generic;

namespace CodeAnalyzer.Controllers
{
    public static class CSClassController
    {
        public static List<CSClass> GetAllCSClasses()
        {
            return CSClassRepository.GetAllCSClasses();
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
