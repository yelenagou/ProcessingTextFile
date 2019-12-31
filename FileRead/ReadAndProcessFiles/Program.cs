using FileRead.Data;
using FileRead.Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace ReadAndProcessFiles
{
    class Program
    {
        public static FileInformation FileInfo { get; set; }
        static void Main(string[] args)
        {
            FileInfo = new FileInformation();

            WriteLine("Please enter file name for .csv or .tsv file");
            FileInfo.InputFileName = ReadLine();
            var readResults = GetFileName.ReadFileName(FileInfo.InputFileName);
            WriteLine("Enter number of fields");
            var numberOfFields = ReadLine();
            int fieldsInRecords = 0;
            List<string> newResults = new List<string>();
            try
            {
                fieldsInRecords = Convert.ToInt32(numberOfFields);
                FileInfo.NumberOfFields = fieldsInRecords;

                List<string> results = GetLines.ReturnDetailRecords(readResults);
                newResults = results.Skip(1).ToList();
                char delimiter = GetFileName.CheckFileName(FileInfo.InputFileName);
               
                var dirName = WriteToFile.GetEnvironmentDirectory();

                    foreach (var rec in newResults)
                    {
                        var returnedFields = GetLines.ReturnFields(rec, delimiter);
                        var isRecordCorrect = GetLines.GetFieldCount(returnedFields, fieldsInRecords);
                        if (isRecordCorrect == false)
                        {

                            var pathCombined = Path.Combine(dirName, "errorrecs.txt");
                            Out.WriteLine($"directory is {pathCombined}");
                            WriteToFile.WriteErrorsToFile(pathCombined, rec);
                            //File.WriteAllText(pathCombined,rec);

                        }
                        else
                        {
                            var pathCombined = Path.Combine(dirName, "correct.txt");
                            Out.WriteLine($"directory is {pathCombined}");
                            WriteToFile.WriteErrorsToFile(pathCombined, rec);
                        }
                    }

                    Console.WriteLine($"the delimiter is {delimiter}");
                    Console.WriteLine(newResults.Count);
                

               // Console.WriteLine($"file name is not correct");
            }
            catch(System.FormatException fe)
            {
                Out.WriteLine("No fields were read");
            }

            //FileInfo.NumberOfFields = fieldsInRecords;

            //List<string> results = GetLines.ReturnDetailRecords(readResults);
         
            //char delimiter = GetFileName.CheckFileName(FileInfo.InputFileName);
            //if(delimiter != 'x')
            //{ 
            //foreach (var rec in results)
            //{
            //    var returnedFields = GetLines.ReturnFields(rec, delimiter);
            //    var isRecordCorrect = GetLines.GetFieldCount(returnedFields, fieldsInRecords);
            //    if(isRecordCorrect == false)
            //    {

            //        var dirName = WriteToFile.GetEnvironmentDirectory();
            //        var pathCombined = Path.Combine(dirName, "errorrecs.txt");
            //        Out.WriteLine($"directory is {pathCombined}");
            //        WriteToFile.WriteErrorsToFile(pathCombined, rec);
            //        //File.WriteAllText(pathCombined,rec);

            //    }
            //    else
            //    {
            //        var dirName = WriteToFile.GetEnvironmentDirectory();
            //        var pathCombined = Path.Combine(dirName, "correct.txt");
            //        Out.WriteLine($"directory is {pathCombined}");
            //        WriteToFile.WriteErrorsToFile(pathCombined, rec);
            //    }
            //}

            //    Console.WriteLine($"the delimiter is {delimiter}");
            //    Console.WriteLine(results.Count);
            //}

            //Console.WriteLine($"file name is not correct");
            
            
            Console.ReadKey();
        }
    }
}
