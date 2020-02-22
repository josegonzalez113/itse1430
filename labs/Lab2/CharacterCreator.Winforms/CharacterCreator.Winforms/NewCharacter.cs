﻿using System;
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

        public NewCharacter ( Character newCharacter ) : this(newCharacter != null ? "Edit" : "Add", newCharacter)
        {
        }

        public Character Character { get; set; }
        public NewCharacter ( string title, Character newCharacter ) : this()
        {
            Text = title;
            Character = newCharacter;
        }

        private void OnOk ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        private void OnCancel ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            //populate combo
            var professions = Characters.GetProfessions();
            cmbProfession.Items.AddRange(professions);

            if (Character != null)
            {
                txtName.Text = Character.Name;
                txtDescription.Text = Character.Description;

                if (Character != null)
                    cmbProfession.SelectedText = Character.Description;
            };
         
        }

        private Character GetCharacter ()
        {
            var newCharacter = new Character();

            //Null conditional
            newCharacter.Name = txtName.Text?.Trim();
            newCharacter.Description = txtDescription.Text.Trim();

            //Pattern match
            if (cmbProfession.SelectedItem is Character character)
                newCharacter.Character = character;

            return newCharacter;
        }

    }
}
