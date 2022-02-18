/*
 * John Lobsinger
 * ITSE 1430
 * Lab 1
 */


using System;

namespace CharacterCreator.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var done = false;
            //Story 2
            Console.WriteLine("John lobsinger.");
            Console.WriteLine("ITSE 1430");
            Console.WriteLine("Lorem Ipsum"); // TODO: Add a date

            //Story 3 - Set Up Main Menu
            do
            {
                char input = DisplayMainMenu();
                
                switch(input)
                {
                    case '1': AddCharacter(); break;
                    case '2': ViewCharacter(); break;
                    case '3': EditCharacter(); break;
                    case '4': DeleteCharacter(); break;
                    case '5':
                    {
                        if (ConfirmQuit())
                            done = true;
                        break;
                    }
                }
            } while (!done);
        }

        static Character character = new Character();
        private static char DisplayMainMenu ()
        {
            Console.WriteLine("Character Creator");
            Console.WriteLine("-----------------");
            Console.WriteLine("1) Create Character");
            Console.WriteLine("2) View Character");
            Console.WriteLine("3) Edit Character");
            Console.WriteLine("4) Delete Character");
            Console.WriteLine("5) Quit");

            return MenuSelect();
        }
        private static void AddCharacter ()
        {
            character.name = ReadString("Please enter a name for your character:", true);
            character.profession = fiveOptionSelect("Please pick a profession", "Warrior", "Hunter", "Rogue", "Priest", "Mage");
            character.race = fiveOptionSelect("Please pick a race", "Human", "Elf", "Dwarf", "Orc", "Goblin");
            character.strength = ReadInt32("Please enter a stength value (1-100): ", 1, 100);
            character.intelligence = ReadInt32("Please enter a intelligence value (1-100): ", 1, 100);
            character.agility = ReadInt32("Please enter a agility value (1-100): ", 1, 100);
            character.constitution = ReadInt32("Please enter a constitution value (1-100): ", 1, 100);
            character.charisma = ReadInt32("Please enter a charisma value (1-100): ", 1, 100);
            character.description = ReadString("Enter a description for your character:", false);
            Console.WriteLine("\nCharacter created successfully\n");
        }
        private static void ViewCharacter ()
        {
            if (String.IsNullOrEmpty(character.name))
            {
                Console.WriteLine("No Character to view.");
                return;
            }
            Console.WriteLine("Character");
            Console.WriteLine("---------------");
            Console.WriteLine("Name - " + character.name);
            Console.WriteLine("Profession - " + character.profession);
            Console.WriteLine("Race - " + character.race);
            Console.WriteLine("Strength - " + character.strength);
            Console.WriteLine("Intelligence - " + character.intelligence);
            Console.WriteLine("Agility - " + character.agility);
            Console.WriteLine("Constitution - " + character.constitution);
            Console.WriteLine("Charisma - " + character.charisma);
            Console.WriteLine(character.description + "\n");
        }
        private static void EditCharacter ()
        {
            if (String.IsNullOrEmpty(character.name))
            {
                Console.WriteLine("No character to edit.");
                return;
            }

            if(ReadBoolean("Do you want to change your character's name (currently: " + character.name + ")? (Y/N)"))
                character.name = ReadString("Please enter a name for your character:", true);

            if (ReadBoolean("Do you want to change your character's profession (currently: " + character.profession + ")? (Y/N)"))
                character.profession = fiveOptionSelect("Please pick a profession", "Warrior", "Hunter", "Rogue", "Priest", "Mage");

            if (ReadBoolean("Do you want to change your character's race (currently: " + character.race + ")? (Y/N)"))
                character.race = fiveOptionSelect("Please pick a race", "Human", "Elf", "Dwarf", "Orc", "Goblin");

            if (ReadBoolean("Do you want to change your character's strength (currently: " + character.strength + ")? (Y/N)"))
                character.strength = ReadInt32("Please enter a stength value (1-100): ", 1, 100);

            if (ReadBoolean("Do you want to change your character's intelligence (currently: " + character.intelligence + ")? (Y/N)"))
                character.intelligence = ReadInt32("Please enter a intelligence value (1-100): ", 1, 100);

            if (ReadBoolean("Do you want to change your character's agility (currently: " + character.agility + ")? (Y/N)"))
                character.agility = ReadInt32("Please enter a agility value (1-100): ", 1, 100);

            if (ReadBoolean("Do you want to change your character's constitution (currently: " + character.constitution + ")? (Y/N)"))
                character.constitution = ReadInt32("Please enter a constitution value (1-100): ", 1, 100);

            if (ReadBoolean("Do you want to change your character's charisma (currently: " + character.charisma + ")? (Y/N)"))
                character.charisma = ReadInt32("Please enter a charisma value (1-100): ", 1, 100);

            if (ReadBoolean("Do you want to change your character's description (currently: " + character.description + ")? (Y/N)"))
                character.description = ReadString("Enter a description for your character:", false);

            Console.WriteLine("\nCharacter changed successfully\n");
        }
        private static void DeleteCharacter ()
        {
            if(String.IsNullOrEmpty(character.name))
            {
                Console.WriteLine("No character to delete.");
                return;
            }
            if (ReadBoolean("Are you sure you want to delete your character, this is permanent? (Y/N)"))
            {
                character = new Character();
                Console.WriteLine("Character successfully deleted.");
            }
            return;
        }

        private static char MenuSelect()
        {
            do
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": return '1';
                    case "2": return '2';
                    case "3": return '3';
                    case "4": return '4';
                    case "5": return '5';
                    default: Console.WriteLine("Please enter a valid number"); break;
                }
            } while (true);
        }
        private static string fiveOptionSelect(string message, string firstOption, string secondOption, string thirdOption, string fourthOption, string fifthOption)
        {
            Console.WriteLine(message);
            Console.WriteLine("-----------------");
            Console.WriteLine("1) " + firstOption);
            Console.WriteLine("2) " + secondOption);
            Console.WriteLine("3) " + thirdOption);
            Console.WriteLine("4) " + fourthOption);
            Console.WriteLine("5) " + fifthOption);

            char input = MenuSelect();

            switch (input)
            {
                case '1': return firstOption;
                case '2': return secondOption;
                case '3': return thirdOption;
                case '4': return fourthOption;
                case '5': return fifthOption;
                default: return firstOption;
            }
        }
        private static int ReadInt32 ( string message, int minimumValue , int maximumValue)
        {
            Console.Write(message);

            while (true)
            {
                var input = Console.ReadLine();

                if (Int32.TryParse(input, out var result) && result >= minimumValue && result <= maximumValue)
                    return result;

                Console.WriteLine("Invalid Input. Must be a whole number within the range of " + minimumValue + "-" + maximumValue);
            };
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
            return ReadBoolean("Are you sure you want to quit? (y/n) ");
        }
    }
}
