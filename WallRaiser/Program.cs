using System;
using MesoketesBattle;

namespace WallRaiser
{
    class Program
    {
        static void Main(string[] args)
        {
            StartProgram();
            Console.ReadLine();
        }

        public static void StartProgram()
        {
            Console.WriteLine("Provide initial height of the wall DEFAULT=0");
            var defHeight = Console.ReadLine();

            int initialHeight;
            int.TryParse(defHeight, out initialHeight);

            var reader = GetInputReader();
            var input = reader.ReadInput();

            if (string.IsNullOrEmpty(input))
            {
                StopApplication();
            }

            Console.WriteLine("Initializing Battle...");
            var successfulAttacks = StartBattle(input, initialHeight);
            Console.WriteLine("Collating Battle Results...");
            Console.WriteLine("Total Successful Attacks:  {0}", successfulAttacks);
        }

        public static int StartBattle(string input, int initialHeight)
        {
            var battle = new Battle();
            try
            {
                battle.Initialize(input);
                Console.WriteLine("Processing Battle...");
                var successfulAttacks = battle.ProcessBattle(initialHeight);
                Console.WriteLine("Battle completed...");
                return successfulAttacks;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }

        private static void StopApplication()
        {
            Environment.Exit(1);
        }

        private static InputReader GetInputReader()
        {
            Console.WriteLine("Enter the Input Format 1 - Console, 2 - File, DEFAULT - static input");
            string inpFormat = Console.ReadLine();
            var reader = ReaderFactory.GetReader(inpFormat);
            return reader;
        }
    }
}
