using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileRead.Data;
using System.Collections.Generic;
using System;

namespace ReadFileTest
{
    [TestClass]
    public class TestReadData
    {
        [TestMethod]
        public void GetLines_ReturnData()
        {
            var readResults = GetFileName.ReadFileName(@"C:\Users\919842\source\repos\TechTest\TestFile.csv");
            List<string> results = GetLines.ReturnDetailRecords(readResults);
            Console.WriteLine(results.Count);
        }
        [TestMethod]
        public void GetLines_ReturnFields()
        {
            var readResults = GetFileName.ReadFileName(@"C:\Users\919842\source\repos\TechTest\TestFile.csv");
            List<string> results = GetLines.ReturnDetailRecords(readResults);
            List<string> fieldsReturned = new List<string>();
            foreach(var result in results)
            {
                fieldsReturned = GetLines.ReturnFields(result);
                Console.WriteLine(fieldsReturned.Count);
            }
            Assert.IsTrue(fieldsReturned.Count > 2,"Fields are not returned");  
        }
        [TestMethod]
        public void GetLines_CheckFieldFormat()
        {
            var readResults = GetFileName.ReadFileName(@"C:\Users\919842\source\repos\TechTest\TestFile.csv");
            List<string> results = GetLines.ReturnDetailRecords(readResults);
            Console.WriteLine($"number of lines is {results.Count}");
            List<string> fieldsReturned = new List<string>();
            foreach (var result in results)
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
    }
}
