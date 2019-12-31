using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileRead.Data
{
    public static class GetLines
    {
        public static List<string> ReturnDetailRecords(string fileRecords)
        {
            List<string> recordsReturned = new List<string>();
            try { 
             recordsReturned = fileRecords.Split('\n').ToList();
          
            }
            catch (ArgumentNullException ne)
            {
                Console.WriteLine("Is your file correct?");
            }
            catch(NullReferenceException nr)
            {
                Console.WriteLine("Is your file correct?");
            }
            return recordsReturned;
        }
        /// <summary>
        /// Take each line in the files and splits it by a comma
        /// </summary>
        /// <param name="detailRecords"></param>
        /// <returns></returns>
        public static List<string> ReturnFields(string detailRecords)
        {
            List<string> parsedFields = new List<string>();
           
           return  parsedFields = detailRecords.Split(',').ToList();
       
        }
        /// <summary>
        /// Each line in file is separate by delimter determined by a file type
        /// </summary>
        /// <param name="detailRecords"></param>
        /// <param name="delimeter"></param>
        /// <returns></returns>
        public static List<string> ReturnFields(string detailRecords, char delimeter)
        {
            List<string> parsedFields = new List<string>();

            return parsedFields = detailRecords.Split(delimeter).ToList();

        }
        /// <summary>
        /// Count number of fields
        /// </summary>
        /// <param name="outputFields"></param>
        /// <param name="expectedFieldCount"></param>
        /// <returns></returns>
        public static bool GetFieldCount(List<string> outputFields, int expectedFieldCount)
        {
            bool isCountCorrect = true;
            if(outputFields.Count != expectedFieldCount)
            {
                isCountCorrect = false;
            }
            return isCountCorrect;
        }
        /// <summary>
        /// Check to see if the first letter is capital. 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns>new string with capital letter</returns>
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
