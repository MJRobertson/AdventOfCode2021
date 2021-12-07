using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace adventofcode.source
{
    public static class TextParser
    {
       public static string[] ReadLines(string path)
        {
            return File.ReadAllLines(path);
        }

    }
}
