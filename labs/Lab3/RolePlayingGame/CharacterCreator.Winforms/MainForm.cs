// ITSE 1430
// Jose Gonzalez
// todo

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreator.Winforms;
using CharacterCreator;

namespace CharacterCreator.Winforms
{
    public partial class MainForm : Form
    {

        private readonly ICharacterRoster _characters;

        public MainForm ()
        {
            InitializeComponent();

            _characters = new CharacterDatabase();
        }

        /// <summary> Will display a dialog with a message </summary>
        private bool DisplayConfirmation ( string message, string title )
        {
            var result = MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return result == DialogResult.OK;
        }

        /// <summary> Shows an error in a dialog box </summary>
        private void ShowError ( string message )
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnCharacterAdd ( object sender, EventArgs e )
        {
            NewCharacter child = new NewCharacter();

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                //TODO: Save the character
                var character = _characters.Add(child.Character);
                if (character != null)
                {
                    UpdateUI();
                    return;
                }
                ShowError("Add failed");
            } while (true);
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            UpdateUI();
        }

        private void UpdateUI ()
        {
            listCharacters.Items.Clear(); // remove all items from lstBox

            var characters = _characters.GetAll();
            foreach (var character in characters)
            {
                listCharacters.Items.Add(character.Name);
            };
        }

        private Character GetSelectedCharacter ()
        {
            return listCharacters.SelectedItem as Character;
        }

        /// <summary> Edit the existing </summary>
        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            // Verify movie
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            var child = new NewCharacter();
            child.Character = character;

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                //TODO: Save the character
                var error = _characters.Update(character.Id, child.Character);
                if (String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                }
                ShowError(error);
            } while (true);
        }

        
        /// <summary> If character is not null it will asl for confirmation </summary>
        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();

            // Verify movie
            if (character == null)
                return;

            if (!DisplayConfirmation($"Are you sure you want to delete {character.Name}?", "Delete"))
                return;

            //TODO: Delete
            _characters.Delete(character.Id);
            UpdateUI();
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close(); // simply will terminate the program
        }

        /// <summary> Shows the AboutForm </summary>
        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutForm(); // create a new instance of AboutForm()
            about.ShowDialog(this);
        }
    }
}
