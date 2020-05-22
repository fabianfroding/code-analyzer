using System.Collections.Generic;

namespace CodeAnalyzer.Models
{
    public class CSharpClass
    {
        public string name;
        public List<string> codeLines;
        public List<CSharpClass> associations;

        public CSharpClass(string name)
        {
            this.name = name;
            codeLines = new List<string>();
            associations = new List<CSharpClass>();
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
    }
}
