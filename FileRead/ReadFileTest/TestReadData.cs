using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileRead.Data;
using System.Collections.Generic;
using System;

namespace ReadFileTest
{
    [TestClass]
    public class TestReadData
    {
        public static String fut = null;
        public static List<string> readFileResults = new List<string>();
        [TestInitialize]
        public void TestInitialize()
        {
            fut = GetFileName.ReadFileName(@"C:\Temp\TestFile.csv");
            readFileResults = GetLines.ReturnDetailRecords(fut);

        }
        [TestMethod]
        public void GetLines_ReturnData()
        { 
            Console.WriteLine(readFileResults.Count);
        }
        /// <summary>
        /// After parsing each line, validate that the number of fields, matches
        /// teh input provided by the user
        /// </summary>
        [TestMethod]
        public void GetLines_ReturnFields()
        {
           
            List<string> fieldsReturned = new List<string>();
            //readFileResults
            foreach(var result in readFileResults)
            {
                fieldsReturned = GetLines.ReturnFields(result);
                Console.WriteLine(fieldsReturned.Count);
            }
            Assert.IsTrue(fieldsReturned.Count > 2,"Fields are not returned");  
        }
        [TestMethod]
        public void GetLines_CheckFieldFormat()
        {
           
            List<string> fieldsReturned = new List<string>();
            foreach (var result in readFileResults)
            {
                fieldsReturned = GetLines.ReturnFields(result);
                Console.WriteLine(fieldsReturned.Count);
                foreach (var fieldReturned in fieldsReturned)
                {
                    var formatted = GetLines.CheckFieldFormat(fieldReturned);
                    Console.WriteLine($"formatted{formatted}");
                }
            }
          
            Assert.IsTrue(fieldsReturned.Count > 2, "Fields are not returned");
        }
        [TestMethod]
        public void WriteToFile_GetCurrentDirectory()
        {
            var returnCurrentDirectory = WriteToFile.WriteReocrdAfterProcessing();
            Console.Out.WriteLine($"current directoyr is {returnCurrentDirectory}");
        }
        [TestMethod]
        public void WriteToFile_IsFileFormatCorrect()
        {
            var result = WriteToFile.IsFileFormatCorrect(@"C:\Temp\TestFile.csv");
            Assert.IsTrue(result, "File format is not correct");
        }
        [TestMethod]
        public void WriteToFile_DoesFileExist()
        {
            var result = WriteToFile.DoesFileExist(@"C:\Temp\TestFile.csv");
            Assert.IsTrue(result, "File format is not correct");
        }
    }
}
