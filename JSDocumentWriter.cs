using System.IO;
using System.Text;

namespace CodeAnalyzer
{
    static class JSDocumentWriter
    {
        private static readonly string PATH = @"..\..\Resources\D3JSDocumentContent\";
        private static readonly string[] FILE_NAMES = new string[8] 
            {
                "DocType_Content.txt",
                "StyleNodesLinks_Content.txt",
                "StyleMain_Content.txt",
                "HtmlBody_Content.txt",
                "ScriptD3_Content.txt",
                "ScriptLoadJSON_Content.txt",
                "ScriptJSONData_Content.txt",
                "ScriptInteractive_Content.txt"
             };

        public static void CreateJSDocument(string path)
        {
            using (FileStream fs = File.Create(path))
            {
                byte[] b;

                for (int i = 0; i < FILE_NAMES.Length; i++)
                {
                    b = new UTF8Encoding(true).GetBytes(GetFileContent(FILE_NAMES[i]));
                    fs.Write(b, 0, b.Length);
                }
            }
        }

        private static string GetFileContent(string fileName)
        {
            return new StreamReader(PATH + fileName).ReadToEnd();
        }
    }
}
