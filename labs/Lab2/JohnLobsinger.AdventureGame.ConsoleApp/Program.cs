using System;

namespace JohnLobsinger.AdventureGame.ConsoleApp
{
    class Program
    {
        static void Main ( string[] args )
        {
            Console.WriteLine("Cellar Crawl - a game made by John Lobsinger for ITSE1430 spring 2022\n");
            s_world.DisplaySetting();

            s_world.Initialize();
            s_player.CurrentRoom = s_world.SouthRoomStart;

            DisplayControls();
            bool exitFlag = true;
            do
            {
                DisplayAvailableRooms();

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.W :
                    {
                        if (s_player.CurrentRoom.NorthRoom != null)
                        {
                            Console.WriteLine("You moved into northern room\n");
                            s_player.CurrentRoom = s_player.CurrentRoom.NorthRoom;
                        } else Console.WriteLine("There is no room to the north. Only a wall.");
                        break;
                    }
                    case ConsoleKey.D :
                    {
                        if (s_player.CurrentRoom.EastRoom != null)
                        {
                            Console.WriteLine("You moved into eastern room\n");
                            s_player.CurrentRoom = s_player.CurrentRoom.EastRoom;
                        } else Console.WriteLine("There is no room to the east. Only a wall.");
                        break;
                    }
                    case ConsoleKey.S :
                    {
                        if (s_player.CurrentRoom.SouthRoom != null)
                        {
                            Console.WriteLine("You moved into southern room\n");
                            s_player.CurrentRoom = s_player.CurrentRoom.SouthRoom;
                        } else Console.WriteLine("There is no room to the south. Only a wall.");
                        break;
                    }
                    case ConsoleKey.A :
                    {
                        if (s_player.CurrentRoom.WestRoom != null)
                        {
                            Console.WriteLine("You moved into western room\n");
                            s_player.CurrentRoom = s_player.CurrentRoom.WestRoom;
                        } else Console.WriteLine("There is no room to the west. Only a wall.");
                        break;
                    }
                    case ConsoleKey.E :
                    {
                        Console.WriteLine("You look around.\n");
                        Console.WriteLine(s_player.CurrentRoom.Description);
                        break;
                    }
                    case ConsoleKey.C: DisplayControls(); break;
                    case ConsoleKey.Q : if(ConfirmQuit()) exitFlag=false; break;
                    default:
                    {
                        Console.WriteLine("Invalid input");
                        DisplayControls();
                        break;
                    }
                }
               
            } while (exitFlag);
        }

        static World s_world = new World();
        static Player s_player = new Player();

        static void DisplayAvailableRooms()
        {
            Console.WriteLine("\nThere are entryways to the:");
            if (s_player.CurrentRoom.NorthRoom != null) Console.WriteLine("North");
            if (s_player.CurrentRoom.SouthRoom != null) Console.WriteLine("South");
            if (s_player.CurrentRoom.EastRoom != null) Console.WriteLine("East");
            if (s_player.CurrentRoom.WestRoom != null) Console.WriteLine("West");
        }
        static void DisplayControls()
        {
            Console.WriteLine("W to move north.");
            Console.WriteLine("A to move west.");
            Console.WriteLine("S to move south.");
            Console.WriteLine("D to move east.");
            Console.WriteLine("E to look around.");
            Console.WriteLine("C to display controls.");
            Console.WriteLine("Q to quit program.");
        }
        private static bool ConfirmQuit ()
        {
            return ReadBoolean("Are you sure you want to quit? (y/n) ");
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
                } else if (key.Key == ConsoleKey.N)
                {
                    Console.WriteLine("N");
                    return false;
                }

                Console.WriteLine("Invalid Input. Must enter Y/N.");
            } while (true);
        }
    }
}
