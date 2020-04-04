// ITSE 1430
// Jose Gonzalez

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreator;

namespace CharacterCreator.Winforms
{
    public partial class CharacterForm : Form
    {
        public CharacterForm ()
        {
            InitializeComponent();
        }

        /// <summary> Constructor chaining </summary>
        public CharacterForm ( Character newCharacter ) : this(newCharacter != null ? "Edit" : "Add", newCharacter)
        {
        }

        /// <summary> Constructor chaining </summary>
        public CharacterForm ( string name, Character character ) : this()
        {
            Name = name;
            Character = character;
        }
        public Character Character { get; set; }
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            //populate profession combobox
            var professions = Professions.GetProfession();
            cmbProfession.Items.AddRange(professions);
            var professionPower = Powers.GetProfessionPower();
            cmbProfessionPower.Items.AddRange(professionPower);

            //populate races combobox
            var races = Races.GetRace();
            cmbRace.Items.AddRange(races);
            var racePower = Powers.GetRacePower();
            cmbRacePower.Items.AddRange(racePower);

            //populate attributes combobox
            var attributes = Attributes.GetAttributes();
            cmbAttributes.Items.AddRange(attributes);
            var attributePower = Powers.GetAttributePower();
            cmbAttributesPower.Items.AddRange(attributePower);

            if (Character != null)
            {
                // text box save
                txtName.Text = Character.Name;
                txtDescription.Text = Character.Description;

                // combo box save
                if (Character.Profession != null)
                    cmbProfession.SelectedText = Character.Profession.About;
                if (Character.Race != null)
                    cmbRace.SelectedText = Character.Race.About;
                if (Character.Attribute != null)
                    cmbAttributes.SelectedText = Character.Attribute.About;

                // combo box save
                if (Character.Power != null)
                    cmbProfessionPower.SelectedText = Character.Power.About;
                if (Character.Power != null)
                    cmbRacePower.SelectedText = Character.Power.About;
                if (Character.Power != null)
                    cmbAttributesPower.SelectedText = Character.Power.About;

                ValidateChildren();
            };
        }

        private void OnCancel ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnOk ( object sender, EventArgs e )
        {
            if (!ValidateChildren()) // if something return false during validation, it shows error.
                return;

            // Validation and error reporting
            var character = GetCharacter();

            var errors = ObjectValidator.Validate(character);
            if (errors.Any())
            {
                ShowError("error");
                return;
            }

            Character = character;
            DialogResult = DialogResult.OK;
            Close(); // -> dismisses the form
        }

        /// <summary> Shows an error in a dialog box </summary>
        private void ShowError ( string message )
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Character GetCharacter () // Todo: profession, race and attributes are required.
        {
            var character = new Character();

            //save the name/description
            character.Name = txtName.Text?.Trim();
            character.Description = txtDescription.Text.Trim();

            // save text combo boxes
            if (cmbProfession.SelectedItem is Profession profession)
                character.Profession = profession;
            if (cmbRace.SelectedItem is Race race)
                character.Race = race;
            if (cmbAttributes.SelectedItem is Attribute attribute)
                character.Attribute = attribute;

            // save power combo box
            if (cmbProfessionPower.SelectedItem is Power professionPow)
                character.Power = professionPow;
            if (cmbRacePower.SelectedItem is Power racePow)
                character.Power = racePow;
            if (cmbAttributesPower.SelectedItem is Power attributePow)
                character.Power = attributePow;

            return character;
        }

        private int GetAsInt32 ( Control control )
        {
            return GetAsInt32(control, 0);
        }
        private int GetAsInt32 ( Control control, int emptyValue )
        {
            // check for empty string
            if (String.IsNullOrEmpty(control.Text))
                return emptyValue;

            //convert string into int
            if (Int32.TryParse(control.Text, out var result))
                return result;
            //return errror
            return -1;
        }

        // Validating...
        //Name textBox
        private void OnValidateName ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            if (String.IsNullOrEmpty(control.Text))
            {
                ErrorProvider.SetError(control, "Name is required");
                e.Cancel = true;
            } else // will get rid of the error circle next to the box after inserting data
            {
                ErrorProvider.SetError(control, "");
            }
        }
        // Profession combobox
        private void OnValidateProfession ( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;
            if (String.IsNullOrEmpty(control.Text))
            {
                ErrorProvider.SetError(control, "Profession is required");
                e.Cancel = true;
            } else // will get rid of the error circle next to the box after inserting data
            {
                ErrorProvider.SetError(control, "");
            }
        }
        // Race combobox
        private void OnValidateRace ( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;
            if (String.IsNullOrEmpty(control.Text))
            {
                ErrorProvider.SetError(control, "Race is required");
                e.Cancel = true;
            } else // will get rid of the error circle next to the box after inserting data
            {
                ErrorProvider.SetError(control, "");
            }
        }
        // Attributes combobox
        private void OnValidateAttributes ( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;
            if (String.IsNullOrEmpty(control.Text))
            {
                ErrorProvider.SetError(control, "Attribute is required");
                e.Cancel = true;
            } else // will get rid of the error circle next to the box after inserting data
            {
                ErrorProvider.SetError(control, "");
            }
        }

    }
}
