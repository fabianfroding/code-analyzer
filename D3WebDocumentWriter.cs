using System;
using System.IO;
using System.Text;

namespace CodeAnalyzer
{
    static class D3WebDocumentWriter
    {
        private static readonly string PATH = @"..\..\Resources\D3JSDocumentContent\";
        private static readonly string[] FILE_NAMES = new string[8] 
            {
                "DocType_Content.html",
                "StyleNodesLinks_Content.css",
                "StyleMain_Content.css",
                "HtmlBody_Content.html",
                "ScriptD3_Content.js",
                "ScriptLoadJSON_Content.js",
                "ScriptJSONData_Content.js",
                "ScriptInteractive_Content.js"
             };

        public static void CreateJSDocument(string path)
        {
            File.WriteAllText(path, String.Empty);

            using (FileStream fs = File.OpenWrite(path))
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

        private static string CreateScriptJSONDataContent()
        {

            return "";
        }
    }
}
