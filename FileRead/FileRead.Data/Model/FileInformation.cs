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
        public List<string> NewResults { get; set; } = new List<string>();
        public List<string> Results { get; set; } = new List<string>();
        public string ReadResults { get; set; }
        public string EnvironmentDirectory { get; set; }
    }
}
