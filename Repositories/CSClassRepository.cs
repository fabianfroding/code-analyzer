using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeAnalyzer.Repositories
{
    static class CSClassRepository
    {
        private static List<CSClass> CSClasses;
        private static List<FileInfo> CSFiles;

        //=============== Public Methods ===============//
        public static void GetCSFilesInDirectory(string dirPath)
        {
            CSFiles = GetCSFilesInSubDirectories(dirPath);
            GenerateCSClasses();
        }

        public static List<CSClass> GetAllCSClasses()
        {
            return CSClasses;
        }

        public static CSClass GetCSClassByName(string name)
        {
            foreach (CSClass _CSClass in CSClasses)
            {
                if (_CSClass.Name == name)
                {
                    return _CSClass;
                }
            }
            return null;
        }

        public static CSClass GetCSClassByIndex(int index)
        {
            for (int i = 0; i < CSClasses.Count; i++)
            {
                if (i == index)
                {
                    return CSClasses[i];
                }
            }
            return null;
        }

        //=============== Private Methods ===============//
        // Recursive method to get files in sub-directories.
        private static List<FileInfo> GetCSFilesInSubDirectories(string dirPath)
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
                csFiles.AddRange(GetCSFilesInSubDirectories(_di.FullName));
            }

            return csFiles;
        }

        // Method to generate CSClass-classes based on the files found.
        private static void GenerateCSClasses()
        {
            if (CSFiles.Count != 0)
            {
                CSClasses = new List<CSClass>();
                foreach (FileInfo fi in CSFiles)
                {
                    CSClass _CSClass = new CSClass(fi.Name.Replace(".cs", ""))
                    {
                        CodeLines = File.ReadAllLines(fi.FullName).ToList()
                    };
                    CSClasses.Add(_CSClass);
                }
            }
        }
    }
}
