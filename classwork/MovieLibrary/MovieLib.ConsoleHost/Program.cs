using System;

namespace MovieLib.ConsoleHost
{
    class Program
    {
        static void Main ( string[] args )
        {
            do
            {
                char input = DisplayMenu();

                //Handle input
                //if (input == 'A')
                //    AddMovie();
                //else if (input == 'V')
                //    ViewMovie();
                //else if (input == 'Q')
                //    if (ConfirmQuit())
                //        break; // Exits the loop
                switch (input)
                {
                    // Fall through is allowed when case statement is empty
                    case 'a':
                    case 'A': AddMovie(); break;

                    case 'v':
                    case 'V': ViewMovie(); break;

                    case 'q':
                    case 'Q':
                    {
                        if (ConfirmQuit())
                            break;

                        break;
                    };
                    default: Console.WriteLine("Unknown option"); break;
                };
            } while (true);
        }

        private static void ViewMovie ()
        {
            // TODO: Does movie exist
            Console.WriteLine(title);

            // releaseYear (duration mins) rating
            //Formatting 1 string conacenation
            //Console.WriteLine(releaseYear + " (" + duration + " mins) " + rating);

            //Formatting 2 - string formatting
            //Console.WriteLine("{0} ({1} mins) {2}", releaseYear, duration, rating);

            //Formating 3 - String interpolation
            Console.WriteLine($"{releaseYear} ({duration} mins) {rating}");

            //genre (Color | Black/White)
            //if(isColor)
            //    Console.WriteLine($"{genre} (Color)");
            //else
            //    Console.WriteLine($"{genre} (Black/White)");
            // Conditional operator
            Console.WriteLine($"{genre} ({(isColor ? "Color" : "Black/White")})");

            //Console.WriteLine(duration);
            //Console.WriteLine(isColor);
            //Console.WriteLine(rating);
            //Console.WriteLine(genre);
            Console.WriteLine(description);
        }

        private static bool ConfirmQuit()
        {
            return ReadBoolean("Are you sure you want to quit? (y/n) ");
        }
        private static void AddMovie ()
        {
            title = ReadString("Enter a movie title: ", true);
            duration = ReadInt32("Enter duration in minutes (>=0): ", 0);
            releaseYear = ReadInt32("Enter release year: ", 1900);
            rating = ReadString("Enter a rating (e.g. PG, PG-13): ", true);
            genre = ReadString("Enter a genre (optional): ", false);
            isColor = ReadBoolean("in color (Y/N)? ");
            description = ReadString("Enter a description (optional): ", false);
        }

        static string title;
        static int duration;
        static int releaseYear;
        static string rating;
        static string genre;
        static bool isColor;
        static string description;

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
                //Type inferencing - compiler infers actual type based upon usage
                //has 0 impact on runtime behaviour
                //string input = Console.ReadLine();
                var input = Console.ReadLine();

                //Validate
                // int result = Int32.Parse(input);
                //int result;
                //if (Int32.TryParse(input, out result))
                //if (Int32.TryParse(input, out int result))
                //    if (result >= minimumValue)
                if (Int32.TryParse(input, out var result) && result >= minimumValue)
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