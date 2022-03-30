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

                // Saves the movie
                if (dlg.Character != null)
                {
                    _character = dlg.Character;
                    UpdateUI();
                    return;
                };

                MessageBox.Show(this, "", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            _character = dlg.Character;
            UpdateUI();
        }
        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            var movie = GetSelectedCharacter();
            if (movie == null)
                return;

            if (MessageBox.Show(this, $"Are you sure you want to delete {movie.Name}?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            _character = null;
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
            if (_character !=null)
                _lstCharacters.Items.Add(_character);
        }
        private Character GetSelectedCharacter ()
        {
            return _lstCharacters.SelectedItem as Character;
        }


    }
}
