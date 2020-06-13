using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CodeAnalyzer
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
            bool multiLineComment = false;
            for (int i = 0; i < CodeLines.Count; i++)
            {
                string lineTrimmed = CodeLines[i].Trim();

                if (lineTrimmed.StartsWith("/*"))
                {
                    multiLineComment = true;
                }
                else if (lineTrimmed.Contains("/*"))
                {
                    lineCount++;
                    multiLineComment = true;
                }
                if (lineTrimmed.EndsWith("*/"))
                {
                    multiLineComment = false;
                }
                else if (lineTrimmed.Contains("*/"))
                {
                    lineCount++;
                    multiLineComment = false;
                }

                if (!multiLineComment)
                {
                    if (lineTrimmed != "" &&
                        !lineTrimmed.StartsWith("//") &&
                        !lineTrimmed.StartsWith("using") &&
                        lineTrimmed != "{" &&
                        lineTrimmed != "}" &&
                        lineTrimmed != "(" &&
                        lineTrimmed != ")"
                    )
                    {
                        lineCount++;
                    }
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
