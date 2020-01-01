using FileRead.Data;
using FileRead.Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace ReadAndProcessFiles
{
    public class Program
    {
        public static FileInformation FileInfo { get; set; }
        static void Main(string[] args)
        {
            FileInfo = new FileInformation();

            Out.WriteLine("Please copy and paste file path in .csv or .tsv format");
            FileInfo.InputFileName = ReadLine();
            while (!(FileInfo.InputFileName.Length > 0))
            {
                Out.WriteLine("Please copy and paste file path in .csv or .tsv format");
                FileInfo.InputFileName = ReadLine();
            }
            
                FileInfo.ReadResults = GetFileName.ReadFileName(FileInfo.InputFileName);
            
           
           
            string numberOfFields = null;
            int temp2 = 0;
            WriteLine("Enter number of fields");
            numberOfFields = ReadLine();
            while (!int.TryParse(numberOfFields, out temp2))
            {
                numberOfFields = ReadLine();
                WriteLine("Enter number of fields");
               
            } 

           // numberOfFields = ReadLine();
            int fieldsInRecords = 0;
          
            try
            {
                fieldsInRecords = Convert.ToInt32(numberOfFields);
                FileInfo.NumberOfFields = fieldsInRecords;

                FileInfo.Results = GetLines.ReturnDetailRecords(FileInfo.ReadResults);
                FileInfo.NewResults = FileInfo.Results.Skip(1).ToList();
                char delimiter = GetFileName.CheckFileName(FileInfo.InputFileName);
                //Once you run this, it'll write the files to your bin direcotry               
                FileInfo.EnvironmentDirectory= WriteToFile.GetEnvironmentDirectory();

                    foreach (var rec in FileInfo.NewResults)
                    {

                        var returnedFields = GetLines.ReturnFields(rec, delimiter);
                        var isRecordCorrect = GetLines.GetFieldCount(returnedFields, fieldsInRecords);
                        if (isRecordCorrect == false)
                        {

                            var pathCombined = Path.Combine(FileInfo.EnvironmentDirectory, "errorrecs.txt");
                            Out.WriteLine($"directory is {pathCombined}");
                            WriteToFile.WriteErrorsToFile(pathCombined, rec);
                        }
                        else
                        {
                            var pathCombined = Path.Combine(FileInfo.EnvironmentDirectory, "correct.txt");
                            Out.WriteLine($"directory is {pathCombined}");
                            WriteToFile.WriteErrorsToFile(pathCombined, rec);
                        }
                    }

                    Console.WriteLine($"the delimiter is {delimiter}");
                    Console.WriteLine(FileInfo.NewResults.Count);
               
            }
            catch(System.FormatException fe)
            {
                Out.WriteLine($"No fields were read {fe}");
            }

            Console.Out.WriteLine("Bonsoir, Elliot");
            Console.ReadKey();
        }
    }
}
