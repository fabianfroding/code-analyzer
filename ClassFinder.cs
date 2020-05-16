using System.Diagnostics;
using System.IO;

namespace CodeAnalyzer
{
    static class ClassFinder
    {
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
        }
    }
}
