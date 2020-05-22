using System.Collections.Generic;
using System.Diagnostics;

namespace CodeAnalyzer.Models
{
    public class CSharpClass
    {
        public string name;
        public List<string> codeLines;

        public CSharpClass(string name)
        {
            this.name = name;
            codeLines = new List<string>();
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
            return lineCount;
        }

        public List<CSharpClass> FindAssociationsAmongCSharpClasses(List<CSharpClass> cSharpClasses)
        {
            List<CSharpClass> associations = new List<CSharpClass>();

            for (int i = 0; i < cSharpClasses.Count; i++)
            {
                foreach (string line in cSharpClasses[i].codeLines)
                {
                    if (this.name != cSharpClasses[i].name && line.Contains(this.name))
                    {
                        bool associationAlreadyFound = false;
                        foreach (CSharpClass cSharpClass in associations)
                        {
                            if (cSharpClasses[i].name == cSharpClass.name)
                            {
                                associationAlreadyFound = true;
                            }
                        }

                        if (!associationAlreadyFound)
                        {
                            Debug.WriteLine(this.name + " found in " + cSharpClasses[i].name);
                            associations.Add(cSharpClasses[i]);
                        }
                    }
                }
            }

            return associations;
        }
    }
}
