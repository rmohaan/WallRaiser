using System.Collections.Generic;

namespace MesoketesBattle
{
    public static class ReaderFactory
    {
        private static readonly Dictionary<string, InputReader> Reader = new Dictionary<string, InputReader>();
        public static InputReader GetReader(string inpFormat)
        {
            if (!Reader.ContainsKey(inpFormat))
            {
                if (inpFormat == 1.ToString())
                {
                    Reader.Add(inpFormat, new ConsoleReader());
                }
                else if (inpFormat == 2.ToString())
                {
                    Reader.Add(inpFormat, new FileReader());
                }
                else
                {
                    Reader.Add(inpFormat, new StaticReader());
                }
            }
            return Reader[inpFormat];
        }
    }
}
