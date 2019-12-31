using System;
using System.Collections.Generic;
using System.Linq;

namespace ParseString
{
    public static class ParseString
    {
            public static List<string> ReturnDetailRecords(string fileRecords)
            {
                var recordsReturned = fileRecords.Split('\n').ToList();
                return recordsReturned;
            }
    }
}
