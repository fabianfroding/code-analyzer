using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CodeAnalyzer
{
    static class ClassFinder
    {
        static string temp;

        public static void FindClassesInDirectory(string dirPath)
        {
            // TODO: Recursive through sub dirs
            DirectoryInfo di = new DirectoryInfo(dirPath);
            FileInfo[] fi = di.GetFiles();
            for (int i = 0; i < fi.Length; i++)
            {
                if (fi[i].Name.EndsWith(".cs"))
                {
                    Debug.WriteLine(fi[i].Name);
                }
            }
            temp = fi[0].FullName;
        }

        public static int CountLinesInFile(string filePath)
        {
            List<string> lines = File.ReadAllLines(temp).ToList();
            int lineCount = 0;

            foreach (string line in lines)
            {
                if (line != "")
                {
                    lineCount++;
                }
                Debug.WriteLine(line);
            }
            return lineCount;
        }
    }
}
