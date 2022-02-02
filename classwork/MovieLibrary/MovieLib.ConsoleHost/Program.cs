using System;

namespace MovieLib.ConsoleHost
{
    class Program
    {
        static void Main ( string[] args )
        {
            char input = DisplayMenu();
            
            //TODO: Handle input
            if (input == 'A')
                AddMovie();
        }

        private static void AddMovie ()
        {
            string title = ReadString("Enter a movie title: ", true);
            int duration = ReadInt32("Enter duration in minutes (>=0): ", 0);
            int releaseYear = ReadInt32("Enter release year: ", 1900);
            string rating = ReadString("Enter a rating (e.g. PG, PG-13): ", true);
            string genre = ReadString("Enter a genre (optional): ", false);
            bool isColor = ReadBoolean("in color (Y/N)? ");
            string description = ReadString("Enter a description (optional): ", false);
        }

        private static bool ReadBoolean ( string message )
        {
            Console.Write(message);
            Console.WriteLine();

            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Y)
                {
                    Console.WriteLine("Y");
                    return true;
                }
                else if (key.Key == ConsoleKey.N)
                {
                    Console.WriteLine("N");
                    return false;
                }

                Console.WriteLine("Invalid Input. Must enter Y/N.");
            } while (true);
        }

        private static int ReadInt32 ( string message, int minimumValue )
        {
            Console.Write(message);

            while (true)
            {
                string input = Console.ReadLine();

                //TODO: Validate
                // int result = Int32.Parse(input);
                //int result;
                //if (Int32.TryParse(input, out result))
                if (Int32.TryParse(input, out int result))
                    if (result >= minimumValue)
                        return result;

                Console.WriteLine("Invalid Input. Must be a whole number and greater than " + minimumValue);
            };
        }

        //Function naming rules
        //Functions are verbs
        //Functions are always Pascal cased
        //Functions should do a single, logical thing. Name should describe the action.
        private static string ReadString ( string message, bool required )
        {
            Console.WriteLine(message);

            string input = Console.ReadLine();

            //TODO: Validate input, if required

            return input;
        }

        static char DisplayMenu()
        {
            Console.WriteLine("A)dd Movie");
            Console.WriteLine("V)iew Movie");
            Console.WriteLine("E)dit Movie");
            Console.WriteLine("D)elete Movie");
            Console.WriteLine("Q)uit");

            string input = Console.ReadLine();

            //Validate input
            if (input == "A")
                return 'A';
            else if (input == "V")
                return 'V';
            else if (input == "E")
                return 'E';
            else if (input == "D")
                return 'D';
            else if (input == "Q")
                return 'Q';
            else
            {
                Console.WriteLine("Invalid Input");
                return 'X';
            };
        }
    }
}