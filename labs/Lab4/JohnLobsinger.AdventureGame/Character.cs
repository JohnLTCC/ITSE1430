using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JohnLobsinger.AdventureGame
{
    /// <summary>
    /// Represents a character in the game
    /// </summary>
    public class Character : IValidatableObject
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
        public string Class
        {
            get { return _class ?? ""; }
            set { _class = value; }
        }
        private string _class;
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
            if (String.IsNullOrEmpty(Class))
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
            return $"{Name} ({Race} {Class})";
        }
        public int Id { get; set; }
        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            if (String.IsNullOrEmpty(_name))
                yield return new ValidationResult("Name is required", new[] { nameof(Name) });
            if (String.IsNullOrEmpty(_class))
                yield return new ValidationResult("Profession is required", new[] { nameof(Class) });
            if (String.IsNullOrEmpty(_race))
                yield return new ValidationResult($"Race is required", new[] { nameof(Race) });
            if (Strength > 100 || Strength < 1)
                yield return new ValidationResult("Strength must be between 1-100", new[] { nameof(Strength) });
            if (Agility > 100 || Agility < 1)
                yield return new ValidationResult("Agility must be between 1-100", new[] { nameof(Agility) });
            if (Intellect > 100 || Intellect < 1)
                yield return new ValidationResult("Intellect must be between 1-100", new[] { nameof(Intellect) });
            if (Stamina > 100 || Stamina < 1)
                yield return new ValidationResult("Stamina must be between 1-100", new[] { nameof(Stamina) });
            if (Charisma > 100 || Charisma < 1)
                yield return new ValidationResult("Charisma must be between 1-100", new[] { nameof(Charisma) });
        }
        public Character Copy () => new Character() {
            Id = Id,
            Name = Name,
            Description = Description,
            Class = Class,
            Race = Race,
            Strength = Strength,
            Agility = Agility,
            Intellect = Intellect,
            Stamina = Stamina,
            Charisma = Charisma
        };

        public void CopyFrom (Character source)
        {
            Id = source.Id;
            Name = source.Name;
            Description = source.Description;
            Class = source.Class;
            Race = source.Race;
            Strength = source.Strength;
            Agility = source.Agility;
            Intellect = source.Intellect;
            Stamina = source.Stamina;
            Charisma = source.Charisma;
        }
    }
}
