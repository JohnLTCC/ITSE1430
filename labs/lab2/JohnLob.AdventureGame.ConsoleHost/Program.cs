using System;

namespace JohnLob.AdventureGame.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplaySetting();
        }

        static void DisplaySetting ()
        {
            Console.WriteLine("Cellar Crawl - a game made by John Lobsinger for ITSE1430 spring 2022\n");
            Console.WriteLine("Greetings adventurer, while on a quest to track the disapearance of some villagers you arive to find it deserted");
            Console.WriteLine("While searching for the missing villagers you find scratch marks leading to a celler in the chiefs house.");
            Console.WriteLine("As you open the hatch and peer into a pitch black haze, you light your torch and venture down.");
        }
    }
}
