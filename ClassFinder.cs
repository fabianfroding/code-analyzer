using CodeAnalyzer.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CodeAnalyzer
{
    static class ClassFinder
    {
        public static List<CSharpClass> CSharpClasses;
        private static List<FileInfo> CSFiles;

        //=============== Public Methods ===============//
        public static void FindCSFilesInDirectory(string dirPath)
        {
            CSFiles = GetCSFilesInDirectory(dirPath);
        }

        public static bool GenerateCSharpClasses()
        {
            if (CSFiles.Count == 0)
            {
                return false;
            }
            CSharpClasses = new List<CSharpClass>();
            foreach (FileInfo fi in CSFiles)
            {
                CSharpClass cSharpClass = new CSharpClass(fi.Name);
                cSharpClass.codeLines = File.ReadAllLines(fi.FullName).ToList();
                CSharpClasses.Add(cSharpClass);
            }
            return true;
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
