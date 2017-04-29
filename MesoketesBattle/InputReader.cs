using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MesoketesBattle
{
    public class InputReader
    {
        public virtual string ReadInput()
        {
            return "";
        }
    }

    public class StaticReader : InputReader
    {
        public override string ReadInput()
        {
            var n = "Day 1$ T1 - N - x - 5 : T2 - W - X - 3;Day 2$ T1 - S - X - 2";
            return n.RemoveWhiteSpaces();
        }
    }

    public class ConsoleReader : InputReader
    {
        public override string ReadInput()
        {
            Console.WriteLine("Enter the battle details");
            var input = Console.ReadLine();
            return input.RemoveWhiteSpaces();
        }
    }

    public class FileReader : InputReader
    {
        public override string ReadInput()
        {
            Console.WriteLine("Enter full file path");
            var path = Console.ReadLine();
            if (string.IsNullOrEmpty(path))
            {
                // TODO: Throw Exception instead of setting Default file.
                path = @"C:\Battle.txt";
            }
            var input = File.ReadAllText(path, Encoding.UTF8);
            return input.RemoveWhiteSpaces();
        }
    }
}
