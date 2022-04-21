using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnLobsinger.AdventureGame.Memory
{
    public class MemoryCharacterRoster : ICharacterRoster
    {
        private readonly List<Character> _characters = new List<Character>();

        #region ICharacterRoster Implementation
        public string Add ( Character character)
        {
            if(character == null)
            {
                return "Character cannot be empty.";
                
            }

            ObjectValidator.ValidateObject(character);

            var existing = FindByName(character.Name);
            if (existing != null)
            {
                return "Character must be unique.";
            }

            character.Id = ++_nextId;
            _characters.Add(character.Copy());
            return "";
        }
        public string Delete ( int id )
        {
            if (id <= 0)
                return "Character must exist in the roster.";

            var character = _characters.FirstOrDefault(x => x.Id == id);
            if (character == null)
                return "Character cannot be null.";

            _characters.Remove(character);
            return "";
        }
        public Character Get ( int id )
        {
            return FindById(id)?.Copy();
        }
        public IEnumerable<Character> GetAll ()
        {
            return _characters.Select(x => x.Copy());
        }
        public string Update ( int id, Character character )
        {
            if (id <= 0)
                return "ID must be greater than 0";

            if (character == null)
                return "Character cannot be empty.";

            ObjectValidator.ValidateObject(character);

            var existing = FindByName(character.Name);
            if (existing != null && existing.Id != id)
                return "Character must be unique.";

            existing = Get(id);
            if (existing == null)
                return "ID must already exist.";

            var result = FindById(id);
            result.CopyFrom(character);
            return "";
        }
        #endregion

        /// <summary>
        /// Finds a character by its name
        /// </summary>
        /// <param name="name">Name of the character to look for.</param>
        /// <returns>The character searched for if a match is found.</returns>
        private Character FindByName ( string name )
        {
            return (from m in _characters
                    where String.Equals(m.Name, name, StringComparison.CurrentCultureIgnoreCase)
                    select m).FirstOrDefault();
        }

        private Character FindById ( int id )
        {
            return _characters.FirstOrDefault(x => x.Id == id);
        }
            

        private int _nextId = 0;
    }
}

