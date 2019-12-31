using System;
using System.Collections.Generic;
using System.Text;

namespace FileRead.Data.Model
{
    public class FileInformation
    {
        public string InputFileName { get; set; }
        public int NumberOfFields { get; set; }
        public char Delimiter { get; set; }
        public string DirNamePath { get; set; }
    }
}
