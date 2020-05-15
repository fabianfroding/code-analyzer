using System.Diagnostics;
using System.IO;

namespace CodeAnalyzer
{
    class CodeFinder
    {
        public void FindClasses(string dirPath)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            FileInfo[] files = di.GetFiles();

            foreach (FileInfo fi in files)
            {
                if (fi.Name.EndsWith(".cs"))
                {
                    Debug.WriteLine(fi.Name);
                }
            }
        }
    }
}
