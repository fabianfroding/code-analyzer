using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CodeAnalyzer
{
    static class ClassFinder
    {
        public static List<FileInfo> CSFiles;


        //=============== Public Methods ===============//
        public static void FindCSFilesInDirectory(string dirPath)
        {
            CSFiles = GetCSFilesInDirectory(dirPath);
            foreach (FileInfo fi in CSFiles)
            {
                Debug.WriteLine(fi.Name);
            }
        }

        public static List<KeyValuePair<string, int>> GetCSFilesLOC(string dirPath)
        {
            FindCSFilesInDirectory(dirPath);

            var list = new List<KeyValuePair<string, int>>();

            foreach (FileInfo fi in CSFiles)
            {
                
                List<string> lines = File.ReadAllLines(fi.FullName).ToList();
                int lineCount = 0;

                foreach (string line in lines)
                {
                    if (line != "")
                    {
                        lineCount++;
                    }
                    Debug.WriteLine(line);
                }
                list.Add(new KeyValuePair<string, int>(fi.Name, lineCount));
            }
            
            return list;
        }

        //=============== Private Methods ===============//
        private static List<FileInfo> GetCSFilesInDirectory(string dirPath)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            List<FileInfo> csFiles = new List<FileInfo>();

            foreach (FileInfo fi in di.GetFiles())
            {
                if (fi.Name.EndsWith(".cs"))
                {
                    csFiles.Add(fi);
                }
            }
            foreach (DirectoryInfo _di in di.GetDirectories())
            {
                csFiles.AddRange(GetCSFilesInDirectory(_di.FullName));
            }

            return csFiles;
        }
    }
}
