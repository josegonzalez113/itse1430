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
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();
        }

        private Character _character;
        private void OnFileExit ( object sender, EventArgs e )
        {
            Close(); // simply will terminate the program
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutForm(); // create a new instance of AboutForm()
            about.ShowDialog(this);
        }

        private void OnNewCharacter ( object sender, EventArgs e )
        {
            NewCharacter temp = new NewCharacter();
            // show NewCharacter form as a dialog
            if (temp.ShowDialog(this) != DialogResult.OK) 
                return;

            //TODO: Save the character
            _character = temp.Character;
        }

        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            var temp = new NewCharacter();
            temp.Character = _character;
            if (temp.ShowDialog(this) != DialogResult.OK)
                return;

            //TODO: Save the character
            _character = temp.Character;
        }

        //Will display an error
        private bool DisplayConfirmation ( string message, string title )
        {
            var result = MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return result == DialogResult.OK;
        }

        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            // Verify character is empty
            if (_character == null)
                return;

            if (!DisplayConfirmation($"Are you sure you want to delete {_character.Name}?", "Delete"))
                return;
            _character = null; // set all characteristics back to null
        }
    }
}
