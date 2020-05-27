using System.Collections.Generic;
using System.Diagnostics;

namespace CodeAnalyzer.Models
{
    public class CSharpClass
    {
        public string name;
        public List<string> codeLines;
        public int numAssociations = 0;
        public int numLOC = 0;

        public CSharpClass(string name)
        {
            this.name = name;
            codeLines = new List<string>();
            numLOC = 0;
            numAssociations = 0;
        }

        public int GetLOC()
        {
            int lineCount = 0;
            for (int i = 0; i < codeLines.Count; i++)
            {
                if (codeLines[i] != "")
                {
                    lineCount++;
                }
            }

            this.numLOC = lineCount;
            return lineCount;
        }

        public List<CSharpClass> FindAssociationsAmongCSharpClasses(List<CSharpClass> cSharpClasses)
        {
            List<CSharpClass> associations = new List<CSharpClass>();

            for (int i = 0; i < cSharpClasses.Count; i++)
            {
                bool associationAlreadyFound = false;

                for (int j = 0; j < codeLines.Count && !associationAlreadyFound; j++)
                {
                    if (codeLines[j].Contains(cSharpClasses[i].name) && this.name != cSharpClasses[i].name)
                    {
                        Debug.WriteLine(name + " uses " + cSharpClasses[i].name);
                        associations.Add(cSharpClasses[i]);
                        associationAlreadyFound = true;
                    }
                }
            }

            this.numAssociations = associations.Count;
            return associations;
        }
    }
}
