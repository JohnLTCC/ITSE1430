using System;

namespace JohnLobsinger.AdventureGame
{
    /// <summary>
    /// Represents a room
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Reads and writes the name of the room
        /// </summary>
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value; }
        }
        private string _name;
        /// <summary>
        /// Reads and writes the decription of the room
        /// </summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }
        private string _description;
        /// <summary>
        /// Reads and writes the room to the north
        /// </summary>
        public Room NorthRoom { get; set; }
        /// <summary>
        /// Determines if there is a room to the south
        /// </summary>
        public Room SouthRoom { get; set; }
        /// <summary>
        /// Determines if there is a room to the east
        /// </summary>
        public Room EastRoom { get; set; }
        /// <summary>
        /// Determines if there is a room to the west
        /// </summary>
        public Room WestRoom { get; set; }
    }

    /// <summary>
    /// Represents a set of rooms
    /// </summary>
    public class World
    {
        /// <summary>
        /// Reads and writes the NorthWestRoom
        /// </summary>
        public Room NorthWestRoom { get; set; }
        /// <summary>
        /// Reads and writes the NorthRoom
        /// </summary>
        public Room NorthRoom { get; set; }
        /// <summary>
        /// Reads and writes the NorthEastRoom
        /// </summary>
        public Room NorthEastRoom { get; set; }
        /// <summary>
        /// Reads and writes the WestRoom
        /// </summary>
        public Room WestRoom { get; set; }
        /// <summary>
        /// Reads and writes the CenterRoom
        /// </summary>
        public Room CenterRoom { get; set; }
        /// <summary>
        /// Reads and writes the EastRoom
        /// </summary>
        public Room EastRoom { get; set; }
        /// <summary>
        /// Reads and writes the SotuhWestRoom
        /// </summary>
        public Room SouthWestRoom { get; set; }
        /// <summary>
        /// Reads and writes the SouthRoom
        /// </summary>
        public Room SouthRoomStart { get; set; } // This will be the starting room
        /// <summary>
        /// Reads and writes the SouthEastRoom
        /// </summary>
        public Room SouthEastRoom { get; set; }

        public void Initialize()
        {
            // For the record I hate this.

            NorthWestRoom = new Room();
            NorthWestRoom.Name = "Barrel Room";
            NorthWestRoom.Description = "The room is filled with barrels from floor to ceiling. It smells of brine and salted meats.";

            NorthRoom = new Room();
            NorthRoom.Name = "Furniture Room";
            NorthRoom.Description = "The room is filled with old stools, tables, and various other furnitures for festivals.";

            NorthEastRoom = new Room();
            NorthEastRoom.Name = "Empty Room";
            NorthEastRoom.Description = "The room is empty, there is nothing notable except a few cracks and cobwebs";
            
            WestRoom = new Room();
            WestRoom.Name = "Barrel Room?";
            WestRoom.Description = "The room is filled with barrels from floor to ceiling. The smell of blood and brine is strong.";

            CenterRoom = new Room();
            CenterRoom.Name = "Shrine Room";
            CenterRoom.Description = "There is a mysterious shrine in the center of the room. The scratch marks seem to lead underneath it. It is too heavy to move.";
            
            EastRoom = new Room();
            EastRoom.Name = "Empty Room";
            EastRoom.Description = "The room is empty, there is nothing notable except a few cracks and cobwebs";
            
            SouthWestRoom = new Room();
            SouthWestRoom.Name = "Butchers' room";
            SouthWestRoom.Description = "The smell fo blood is thick in the air. You gaze around to see various blades and hooks coated in dried blood. This was likely used for butchering game, at least you hope";
            
            SouthRoomStart = new Room();
            SouthRoomStart.Name = "Start Room";
            SouthRoomStart.Description = "The room is mostly empty besides the ladder against the south wall and the rays of light from the surface. The scratch marks lead north.";
            
            SouthEastRoom = new Room();
            SouthEastRoom.Name = "Empty Room?";
            SouthEastRoom.Description = "The room is empty, there is nothing notable except a few cracks and cobwebs... and some strange... humming?";
            
            NorthWestRoom.SouthRoom = WestRoom;
            NorthWestRoom.EastRoom = NorthRoom;

            NorthRoom.SouthRoom = CenterRoom;
            NorthRoom.EastRoom = NorthEastRoom;
            NorthRoom.WestRoom = NorthWestRoom;

            NorthEastRoom.SouthRoom = EastRoom;
            NorthEastRoom.WestRoom = NorthRoom;

            WestRoom.NorthRoom = NorthWestRoom;
            WestRoom.SouthRoom = SouthWestRoom;
            WestRoom.EastRoom = CenterRoom;

            CenterRoom.SouthRoom = SouthRoomStart;
            CenterRoom.NorthRoom = NorthRoom;
            CenterRoom.EastRoom = EastRoom;
            CenterRoom.WestRoom = WestRoom;

            EastRoom.NorthRoom = NorthEastRoom;
            EastRoom.SouthRoom = SouthEastRoom;
            EastRoom.WestRoom = CenterRoom;

            SouthWestRoom.NorthRoom = WestRoom;
            SouthWestRoom.EastRoom = SouthRoomStart;

            SouthRoomStart.NorthRoom = CenterRoom;
            SouthRoomStart.EastRoom = SouthEastRoom;
            SouthRoomStart.WestRoom = SouthWestRoom;

            SouthEastRoom.NorthRoom = EastRoom;
            SouthEastRoom.WestRoom = SouthRoomStart;
        }
        /// <summary>
        /// Displays the game  world's setting
        /// </summary>
        public void DisplaySetting ()
        {
            Console.WriteLine("Greetings adventurer, while on a quest to track the disapearance of some villagers you arive to find it deserted");
            Console.WriteLine("While searching for the missing villagers you find scratch marks leading to a celler in the chiefs house.");
            Console.WriteLine("As you open the hatch and peer into a pitch black haze, you light your torch and venture down.\n");
        }
    }

    /// <summary>
    /// Represents a player
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Reads and writes the current room of the player
        /// </summary>
        public Room CurrentRoom { get; set; }
    }
}
