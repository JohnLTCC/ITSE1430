using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JohnLobsinger.AdventureGame.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private readonly ICharacterRoster _characters = new Memory.MemoryCharacterRoster();
        private Character _character;

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }
        private void OnCharacterNew ( object sender, EventArgs e )
        {
            var dlg = new CharacterForm();
            do
            {
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                var error = _characters.Add(dlg.Character);
                // Saves the movie
                if (String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                };

                MessageBox.Show(this, error, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);
        }
        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            var dlg = new CharacterForm 
            {
                Text = "Edit Character",
                Character = character
            };
            dlg.Character = character;

            do
            {
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                var error = _characters.Update(character.Id, dlg.Character);
                if (String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                }

                MessageBox.Show(this, error, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);
        }
        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            if (MessageBox.Show(this, $"Are you sure you want to delete {character.Name}?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            _characters.Delete(character.Id);
            UpdateUI();
        }
        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var form = new AboutBox1();
            form.ShowDialog(this);
        }
        protected override void OnFormClosing ( FormClosingEventArgs e )
        {
            // Asks if the user wants to quit in a message box
            if (MessageBox.Show(this, "Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                e.Cancel = true;
        }

        private void UpdateUI ()
        {
            _lstCharacters.Items.Clear();
            var characters = from m in _characters.GetAll()
                         orderby m.Name, m.Class
                         select m;
            _lstCharacters.Items.AddRange(characters.ToArray());
        }
        private Character GetSelectedCharacter ()
        {
            return _lstCharacters.SelectedItem as Character;
        }


    }
}
