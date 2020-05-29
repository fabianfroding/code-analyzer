using System.Collections.Generic;
using System.Diagnostics;

namespace CodeAnalyzer.Models
{
    public class CSClass
    {
        public string Name { get; set; }
        public List<string> CodeLines { get; set; }
        public int NumAssociations { get; set; }
        public int NumLOC { get; set; }

        public CSClass(string Name)
        {
            this.Name = Name;
            CodeLines = new List<string>();
            NumAssociations = 0;
            NumLOC = 0;
        }

        public int CountLOC()
        {
            int lineCount = 0;
            for (int i = 0; i < CodeLines.Count; i++)
            {
                if (CodeLines[i] != "")
                {
                    lineCount++;
                }
            }
            NumLOC = lineCount;
            return lineCount;
        }

        public List<CSClass> GetAssociationsInListOfCSClasses(List<CSClass> CSClasses)
        {
            List<CSClass> associations = new List<CSClass>();

            for (int i = 0; i < CSClasses.Count; i++)
            {
                bool associationAlreadyFound = false;

                for (int j = 0; j < CodeLines.Count && !associationAlreadyFound; j++)
                {
                    if (CodeLines[j].Contains(CSClasses[i].Name) && Name != CSClasses[i].Name)
                    {
                        Debug.WriteLine(Name + " uses " + CSClasses[i].Name);
                        associations.Add(CSClasses[i]);
                        associationAlreadyFound = true;
                    }
                }
            }

            NumAssociations = associations.Count;
            return associations;
        }
    }
}
