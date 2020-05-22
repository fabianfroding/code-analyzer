using CodeAnalyzer.Models;
using System.Collections.Generic;

namespace CodeAnalyzer
{
    static class AssociationFinder
    {
        public static void FindCSFilesAssociations(List<CSharpClass> cSharpClasses)
        {
            for (int i = 0; i < cSharpClasses.Count; i++)
            {
                for (int j = 0; j < cSharpClasses[i].associations.Count; j++)
                {
                    if (i != j && cSharpClasses[i].name == cSharpClasses[j].name)
                    {
                        cSharpClasses[i].associations.Add(cSharpClasses[j]);
                    }
                }
            }
        }

    }
}
