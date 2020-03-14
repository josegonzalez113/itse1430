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

namespace CharacterCreator.Winforms
{
    public partial class NewCharacter : Form
    {

        public NewCharacter ()
        {
            InitializeComponent();
        }

        /// <summary> Constructor chaining </summary>
        public NewCharacter ( Character newCharacter ) : this(newCharacter != null ? "Edit" : "Add", newCharacter)
        {
        }

        /// <summary> Constructor chaining </summary>
        public NewCharacter ( string name, Character newCharacter ) : this()
        {
            Name = name;
            Character = newCharacter;
        }

        /// <summary> Shows an error in a dialog box </summary>
        private void ShowError ( string message )
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnOk ( object sender, EventArgs e )
        {
            // Validation and error reporting
            var character = GetCharacter();
            if (!character.Validate(out var error))
            {
                ShowError(error);
                return;
            }

            Character = character;
            DialogResult = DialogResult.OK;
            Close(); // -> dismisses the form
        }

        private void OnCancel ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        public Character Character { get; set; }
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            //populate profession combobox
            var professions = Professions.GetProfession();
            cmbProfession.Items.AddRange(professions);

            //populate races combobox
            var races = Races.GetRace();
            cmbRace.Items.AddRange(races);

            //populate attributes combobox
            var attributes = Attributes.GetAttributes();
            cmbAttributes.Items.AddRange(attributes);

            if (Character != null)
            {
                txtName.Text = Character.Name;
                txtDescription.Text = Character.Description;

                if (Character.Profession != null)
                    cmbProfession.SelectedItem = Character.Profession.About;

                if (Character.Race != null)
                    cmbRace.SelectedItem = Character.Race.About;

                if (Character.Attribute != null)
                    cmbAttributes.SelectedItem = Character.Attribute.About;
            };
        }

        private Character GetCharacter ()
        {
            var character = new Character();

            //save the name/description
            character.Name = txtName.Text?.Trim();
            character.Description = txtDescription.Text.Trim();

            // save all the combo boxes
            if (cmbProfession.SelectedItem is Profession profession)
                character.Profession = profession;
            if (cmbRace.SelectedItem is Race race)
                character.Race = race;
            if (cmbAttributes.SelectedItem is Attribute attribute)
                character.Attribute = attribute;

            return character;
        }

    }
}
