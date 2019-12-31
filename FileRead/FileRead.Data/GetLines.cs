﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileRead.Data
{
    public static class GetLines
    {
        public static List<string> ReturnDetailRecords(string fileRecords)
        {
            var recordsReturned = fileRecords.Split('\n').ToList();
            return recordsReturned;
        }
        public static List<string> ReturnFields(string detailRecords)
        {
            List<string> parsedFields = new List<string>();
           
           return  parsedFields = detailRecords.Split(',').ToList();
       
        }
        public static List<string> ReturnFields(string detailRecords, char delimeter)
        {
            List<string> parsedFields = new List<string>();

            return parsedFields = detailRecords.Split(delimeter).ToList();

        }
        public static bool GetFieldCount(List<string> outputFields, int expectedFieldCount)
        {
            bool isCountCorrect = true;
            if(outputFields.Count != expectedFieldCount)
            {
                isCountCorrect = false;
            }
            return isCountCorrect;
        }
        public static string CheckFieldFormat(string fieldName)
        {
            bool isUpper = true;
            char[] capitalLetterPattern = fieldName.ToCharArray();
            if(capitalLetterPattern.Length >= 1)
            {
                if (char.IsLower(capitalLetterPattern[0]))
                {
                    char.IsUpper(capitalLetterPattern[0]);
                }

            }
            else
            if(capitalLetterPattern.Length == 0 || capitalLetterPattern.Equals(null))
            {
                isUpper = false;
            }
            

            return new string(capitalLetterPattern);


         
        }
    }
}