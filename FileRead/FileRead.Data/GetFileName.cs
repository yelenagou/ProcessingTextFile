using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileRead.Data
{
    /// <summary>
    /// Read aa file
    /// </summary>
    public static class GetFileName
    {
        /// <summary>
        /// Read a file and return a string of data to be parsed
        /// </summary>
        /// <param name="fileName">pass name of the file you want to read</param>
        /// <returns></returns>
        public static string ReadFileName(string fileName)
        {
            string familyCourtFileContent = null;
            try { 
              familyCourtFileContent = File.ReadAllText(fileName);      
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (DirectoryNotFoundException dir)
            {
                Console.WriteLine($"Directory cannot be found {dir.Message}");
            }
            catch (IOException e)
            {
                Console.Out.WriteLine($"File not found");
            }
            return familyCourtFileContent;
        }
    
    
        public static char CheckFileName(string fileName)
        {

            char delim = ' ';
            if (fileName.EndsWith(".csv"))
            {
                delim = ',';
            }
            else
                if(fileName.Contains(".tsv"))
                    {
                delim = '\t';
            
            }
            else
            {
                delim = 'x';
            }
            return delim;
        }


    }
}
