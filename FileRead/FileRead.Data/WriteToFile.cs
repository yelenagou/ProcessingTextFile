﻿using System;
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
        public static bool IsFileFormatCorrect(string inputFilename)
        {
            var invalidChars = inputFilename.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0;
            return invalidChars;
        }
        public static bool DoesFileExist(string inputFileName)
        {
          bool doesExist =  !File.Exists(inputFileName);
            return doesExist;
        }
        public static string GetEnvironmentDirectory()
        {
            string wrkDir = Environment.CurrentDirectory;
            string workingDirectory = Directory.GetParent(wrkDir).Parent.FullName;
            var getParents = Directory.GetParent(wrkDir);
            var imARoot = getParents.Root;
            var imARootFullName = imARoot.FullName;
            var supParent = getParents.Parent.Parent.Parent;
            
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
            else
            {
                using (StreamWriter sw = File.AppendText(workingPath))
                {
                    sw.WriteLine(recToWrite);

                }
            }
            
        }

    }

}
