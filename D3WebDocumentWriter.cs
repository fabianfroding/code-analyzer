using CodeAnalyzer.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CodeAnalyzer
{
    // Class to generate a webpgage for the web-browser control
    // Generates sections of a page to dynamically display data in a force-directed graph.

    // Methods with ForClass-affix refers to the force-dir graph for specific class window.

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
            // Create empty file.
            File.WriteAllText(path, String.Empty);

            using (FileStream fs = File.OpenWrite(path))
            {
                byte[] b;

                for (int i = 0; i < FILE_NAMES.Length; i++)
                {
                    if (i == 6)
                    {
                        Debug.WriteLine(CreateHtmlJSONDataContent());
                        b = new UTF8Encoding(true).GetBytes(CreateHtmlJSONDataContent());
                        fs.Write(b, 0, b.Length);
                    }
                    else
                    {
                        b = new UTF8Encoding(true).GetBytes(GetFileContent(FILE_NAMES[i]));
                        fs.Write(b, 0, b.Length);
                    }
                    
                }
            }
        }

        public static void CreateJSDocumentForClass(string path, CSClass csClass)
        {
            File.WriteAllText(path, String.Empty);

            using (FileStream fs = File.OpenWrite(path))
            {
                byte[] b;

                for (int i = 0; i < FILE_NAMES.Length; i++)
                {
                    if (i == 6)
                    {
                        b = new UTF8Encoding(true).GetBytes(CreateHtmlJSONDataContentForClass(csClass));
                        fs.Write(b, 0, b.Length);
                    }
                    else
                    {
                        b = new UTF8Encoding(true).GetBytes(GetFileContent(FILE_NAMES[i]));
                        fs.Write(b, 0, b.Length);
                    }

                }
            }
        }

        private static string GetFileContent(string fileName)
        {
            return new StreamReader(PATH + fileName).ReadToEnd();
        }

        // Method for the dynamic data generation.
        private static string CreateHtmlJSONDataContent()
        {
            List<CSClass> csClasses = CSClassController.GetAllCSClasses();

            string htmlContent = 
                "<script>\n" +
                "var tempdata = {\n" +
                "\"nodes\": [\n";

            // Generate JSON data for each class
            for (int i = 0; i < csClasses.Count; i++)
            {
                htmlContent += "{ \"id\": \"" + csClasses[i].Name + "\", \"group\": 1 }";
                if (i == csClasses.Count - 1)
                {
                    htmlContent += "\n";
                }
                else
                {
                    htmlContent += ",\n";
                }
            }

            htmlContent += 
                "],\n" + 
                "\"links\": [\n";

            // Generate JSON data for each association in each class
            for (int i = 0; i < csClasses.Count; i++)
            {
                List<CSClass> associations = csClasses[i].GetAssociationsInList(csClasses);
                for (int j = 0; j < associations.Count; j++)
                {
                    if (csClasses[i].GetAssociationsInList(csClasses).Count > 0)
                    {
                        htmlContent += "{\"source\": \"" + csClasses[i].Name + "\", \"target\": \"" + associations[j].Name + "\"}";
                        if (i == csClasses.Count - 1 && j == associations.Count)
                        {
                            htmlContent += "\n";
                        }
                        else
                        {
                            htmlContent += ",\n";
                        }
                    }
                    
                }
            }

            htmlContent +=
                "]\n" +
                "};\n" +
                "</script>";

            return htmlContent;
        }

        private static string CreateHtmlJSONDataContentForClass(CSClass csClass)
        {
            List<CSClass> associations = csClass.GetAssociationsInList(CSClassController.GetAllCSClasses());
            associations.Add(csClass);

            string htmlContent =
                "<script>\n" +
                "var tempdata = {\n" +
                "\"nodes\": [\n";


            // Generate JSON data for each associated class of the csClass
            for (int i = 0; i < associations.Count; i++)
            {
                htmlContent += "{ \"id\": \"" + associations[i].Name + "\", \"group\": 1 }";
                if (i == associations.Count - 1)
                {
                    htmlContent += "\n";
                }
                else
                {
                    htmlContent += ",\n";
                }
            }

            htmlContent +=
                "],\n" +
                "\"links\": [\n";

            // Generate JSON data for each association in each association of the csClass
            for (int i = 0; i < associations.Count; i++)
            {
                List<CSClass> innerAssociations = associations[i].GetAssociationsInList(associations);
                for (int j = 0; j < innerAssociations.Count; j++)
                {
                    if (associations[i].GetAssociationsInList(associations).Count > 0)
                    {
                        htmlContent += "{\"source\": \"" + associations[i].Name + "\", \"target\": \"" + associations[j].Name + "\"}";
                        if (i == associations.Count - 1 && j == associations.Count)
                        {
                            htmlContent += "\n";
                        }
                        else
                        {
                            htmlContent += ",\n";
                        }
                    }

                }
            }

            htmlContent +=
                "]\n" +
                "};\n" +
                "</script>";

            return htmlContent;
        }
    }
}
