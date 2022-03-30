using System;

namespace JohnLobsinger.AdventureGame
{
    /// <summary>
    /// Represents a character in the game
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Reads and writes the name of the character
        /// </summary>
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value; }
        }
        private string _name;
        /// <summary>
        /// Reads and writes the description of the character
        /// </summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }
        private string _description;
        /// <summary>
        /// Reads and writes the profession of the character
        /// </summary>
        public string Profession
        {
            get { return _profession ?? ""; }
            set { _profession = value; }
        }
        private string _profession;
        /// <summary>
        /// Reads and writes the race of the character
        /// </summary>
        public string Race
        {
            get { return _race ?? ""; }
            set { _race = value; }
        }
        private string _race;
        /// <summary>
        /// Reads and writes the strength of the character
        /// </summary>
        public int Strength { get; set; }
        /// <summary>
        /// Reads and writes the agility of the character
        /// </summary>
        public int Agility { get; set; }
        /// <summary>
        /// Reads and writes the intellect of the character
        /// </summary>
        public int Intellect { get; set; }
        /// <summary>
        /// Reads and writes the stamina of the character
        /// </summary>
        public int Stamina { get; set; }
        /// <summary>
        /// Reads and writes the charisma of the character
        /// </summary>
        public int Charisma { get; set; }
       
        /// <summary>
        /// Validates the data of the character
        /// </summary>
        /// <returns> returns an error string </returns>
        public string Validate()
        {
            if (String.IsNullOrEmpty(Name))
                return "Name is required.";
            if (String.IsNullOrEmpty(Profession))
                return "Profession is required.";
            if (String.IsNullOrEmpty(Race))
                return "Race is required.";
            if (Strength > 100 || Strength < 1)
                return "Strength must be between 1-100";
            if (Agility > 100 || Agility < 1)
                return "Agility must be between 1-100";
            if (Intellect > 100 || Intellect < 1)
                return "Intellect must be between 1-100";
            if (Stamina > 100 || Stamina < 1)
                return "Stamina must be between 1-100";
            if (Charisma > 100 || Charisma < 1)
                return "Charisma must be between 1-100";
            return "";
        }
        public override string ToString ()
        {
            return $"{Name} ({Profession})";
        }
    }
}
