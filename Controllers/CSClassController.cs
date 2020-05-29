using CodeAnalyzer.Models;
using CodeAnalyzer.Repositories;
using System.Collections.Generic;

namespace CodeAnalyzer.Controllers
{
    public static class CSClassController
    {
        public static List<CSClass> GetCSClasses()
        {
            return CSClassRepository.GetCSClasses();
        }
    }
}
