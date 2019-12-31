using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace FileRead.Data
{
    public class WriteToFile
    {
        public static string  WriteReocrdAfterProcessing()
        {
            var currentDirectoryIs = Directory.GetCurrentDirectory();
            //Console.Out.WriteLine($"Directory.GetCurrentDirectory is {currentDirectoryIs}");
            var currentDirectoryPathIs = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            //Console.Out.WriteLine($"System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) {currentDirectoryPathIs}");
            return currentDirectoryPathIs;
        }
        public static string GetEnvironmentDirectory()
        {
            string wrkDir = Environment.CurrentDirectory;
            string workingDirectory = Directory.GetParent(wrkDir).Parent.FullName;

            
            return workingDirectory;
        }
        public static void WriteErrorsToFile(string workingPath, string recToWrite)
        {
            if (!File.Exists(workingPath))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(workingPath))
                {
                    sw.WriteLine(recToWrite);
                   
                }
            }
            using (StreamWriter sw = File.AppendText(workingPath))
            {
                sw.WriteLine(recToWrite);
               
            }
        }

    }

}
