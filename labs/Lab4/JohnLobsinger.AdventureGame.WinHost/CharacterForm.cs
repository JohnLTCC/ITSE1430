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
    public partial class CharacterForm : Form
    {
        public CharacterForm ()
        {
            InitializeComponent();
        }
        public Character Character { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (Character != null)
            {
                _txtName.Text = Character.Name;
                _comboBoxProfession.Text = Character.Profession;
                _comboBoxRace.Text = Character.Race;
                _txtStrength.Text = Character.Strength.ToString();
                _txtAgility.Text = Character.Agility.ToString();
                _txtIntellect.Text = Character.Intellect.ToString();
                _txtStamina.Text = Character.Stamina.ToString();
                _txtCharisma.Text = Character.Charisma.ToString();
                _txtDescription.Text = Character.Description;
            }
        }

        private void OnSave ( object sender, EventArgs e )
        {
            // prevents save if there are errors
            if (!ValidateChildren())
                return;

            // hold the data to be passed back
            var character = new Character();

            // Sets the properties
            character.Name = _txtName.Text;
            character.Profession = _comboBoxProfession.Text;
            character.Race = _comboBoxRace.Text;
            character.Strength = ReadAsInt32(_txtStrength, -1);
            character.Agility = ReadAsInt32(_txtAgility, -1);
            character.Intellect = ReadAsInt32(_txtIntellect, -1);
            character.Stamina = ReadAsInt32(_txtStamina, -1);
            character.Charisma = ReadAsInt32(_txtCharisma, -1);
            character.Description = _txtDescription.Text;

            // Validates the data
            var error = character.Validate();
            if(String.IsNullOrEmpty(error))
            {
                Character = character;
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            // Displays an error if data is invalide.
            MessageBox.Show(this, error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void OnCancel ( object sender, EventArgs e )
        {
            if (MessageBox.Show(this, "Are you sure you want to exit?\n This could changes unsaved.", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }

        private void OnValidatingName ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Name is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
        private void OnValidatingProfession ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Profession is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
        private void OnValidatingRace ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Race is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
        private void OnValidatingStats ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = ReadAsInt32(control, -1);
            if (value > 100 || value < 1)
            {
                _errors.SetError(control, "Stat must be between 1-100");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private int ReadAsInt32 ( Control control, int defaultValue )
        {
            return Int32.TryParse(control.Text, out var result) ? result : defaultValue;
        }
    }
}
