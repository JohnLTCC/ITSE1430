using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnLobsinger.AdventureGame
{
    public interface ICharacterRoster
    {
        /// <summary>
        /// Adds a character to the roster.
        /// </summary>
        /// <param name="character">The character to be added.</param>
        /// <returns></returns>
        string Add ( Character character);
        /// <summary>
        /// Deletes a character from the roster.
        /// </summary>
        /// <param name="id">The id of the character to delete.</param>
        string Delete ( int id );
        /// <summary>
        /// Gets a character from the roster.
        /// </summary>
        /// <param name="id">The id of the character to get.</param>
        /// <returns></returns>
        Character Get ( int id );
        /// <summary>
        /// Gets all characters from the roster.
        /// </summary>
        /// <returns>An IEnumerable of Characters.</returns>
        IEnumerable<Character> GetAll ();
        /// <summary>
        /// Updates a character in the roster.
        /// </summary>
        /// <param name="id">The id of the character to update.</param>
        /// <param name="character">The character to update.</param>
        string Update ( int id, Character character );
    }
}
