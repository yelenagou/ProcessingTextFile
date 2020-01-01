using System;
using System.Collections.Generic;
using System.Text;

namespace FileRead.Data
{
    public class ValueFormatter
    {
        public static bool isEmpty(string inputValue)
        {
            bool isEmpty = false;
            if(string.IsNullOrWhiteSpace(inputValue))
            {
                isEmpty = true;
            }
            else if(string.IsNullOrEmpty(inputValue))
            {
                isEmpty = true;
            }
            return isEmpty;
        }
    }
}
