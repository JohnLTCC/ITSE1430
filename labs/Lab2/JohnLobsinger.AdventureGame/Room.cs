using System;

namespace JohnLobsinger.AdventureGame
{
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
    }
}
