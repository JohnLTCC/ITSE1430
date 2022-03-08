using System;

//Phoenix
namespace MovieLib.ConsoleHost
{
    class Program
    {
        static void Main ( string[] args )
        {
            var done = false;
            do
            {
                char input = DisplayMenu();

                /*Handle input
                *if (input == 'A')
                *    AddMovie();
                *else if (input == 'V')
                *    ViewMovie();
                *else if (input == 'Q')
                *    if (ConfirmQuit())
                *    break;  Exits the loop
                */
                switch (input)
                {
                    // Fall through is allowed when case statement is empty
                    case 'a':
                    case 'A': AddMovie(); break;

                    case 'v':
                    case 'V': ViewMovie(); break;

                    case 'd':
                    case 'D': DeleteMovie(); break;

                    case 'q':
                    case 'Q':
                    {
                        if (ConfirmQuit())
                            done = true;

                        break;
                    };
                    default: Console.WriteLine("Unknown option"); break;
                };
            } while (!done);
        }

        static Movie s_movie;
        static MemoryMovieDatabase s_movies = new MemoryMovieDatabase();
        
        private static char DisplayMenu ()
        {
            Console.WriteLine("Movie Library");
            //Console.WriteLine("-------------");
            Console.WriteLine("".PadLeft(20, '-'));
            Console.WriteLine("A)dd Movie");
            Console.WriteLine("V)iew Movie");
            Console.WriteLine("E)dit Movie");
            Console.WriteLine("D)elete Movie");
            Console.WriteLine("Q)uit");

            do
            {
                string input = Console.ReadLine();

                //Validate input
                if (String.Compare(input, "A", true) == 0)
                    return 'A';
                else if (String.Compare(input, "V", true) == 0)
                    return 'V';
                else if (String.Compare(input, "E", true) == 0)
                    return 'E';
                else if (String.Compare(input, "D", true) == 0)
                    return 'D';
                else if (String.Compare(input, "Q", true) == 0)
                    return 'Q';
                else
                    Console.WriteLine("Invalid Input");
            } while (true);
        }
        private static void AddMovie ()
        {
            s_movie = new Movie();

            

            do
            {
                s_movie.Title = ReadString("Enter a movie title: ", true);
                s_movie.Duration = ReadInt32("Enter duration in minutes (>=0): ", 0);
                s_movie.ReleaseYear = ReadInt32("Enter release year: ", 1900);
                s_movie.Rating = ReadString("Enter a rating (e.g. PG, PG-13): ", true);
                s_movie.Genre = ReadString("Enter a genre (optional): ", false);
                s_movie.IsClassic = ReadBoolean("ia a classic (Y/N)? ");
                s_movie.Description = ReadString("Enter a description (optional): ", false);

                //s_movie.CalculateBlackAndWhite();

                var error = s_movie.Validate();
                if (String.IsNullOrEmpty(error))
                    return;

                Console.WriteLine(error);
            } while (true);
        }
        private static void ViewMovie ()
        {
           
            if(s_movie == null)
            {
                Console.WriteLine("No movie to view.");
                return;
            }
            Console.WriteLine(s_movie.Title);

            /*Sample code
            * releaseYear (duration mins) rating
            *Formatting 1 string conacenation
            *Console.WriteLine(releaseYear + " (" + duration + " mins) " + rating);
            *
            *Formatting 2 - string formatting
            *Console.WriteLine("{0} ({1} mins) {2}", releaseYear, duration, rating);
            *
            *Formating 3 - String interpolation
            */
            Console.WriteLine($"{s_movie.ReleaseYear} ({s_movie.Duration} mins) {s_movie.Rating}");

            //genre (Color | Black/White)
            //if(isColor)
            //    Console.WriteLine($"{genre} (Color)");
            //else
            //    Console.WriteLine($"{genre} (Black/White)");
            // Conditional operator
            Console.WriteLine($"{s_movie.Genre} ({(s_movie.IsClassic ? "Classic" : "")})");

            //Console.WriteLine(duration);
            //Console.WriteLine(isColor);
            //Console.WriteLine(rating);
            //Console.WriteLine(genre);
            Console.WriteLine(s_movie.Description);
        }
        private static void DeleteMovie ()
        {
            if (s_movie == null)
            {
                Console.WriteLine("No movie to delete.");
                return;
            }

            // Confirm and delete the movie
            if (ReadBoolean($"Are you sure you want to delete '{s_movie.Title}' (Y/N)"))
                s_movie = null;
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
        private static string ReadString ( string message, bool required )
        {
            Console.WriteLine(message);

            do
            {
                string input = Console.ReadLine();

                if (!required || !String.IsNullOrEmpty(input))
                    return input;

                Console.WriteLine("Value is required.");
            } while (true);
        }
        private static bool ConfirmQuit ()
        {
            return ReadBoolean("Are you sure you want to quit? (Y/N) ");
        }
    }
}