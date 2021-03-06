﻿namespace CharacterCreator.Winforms
{
    partial class CharacterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this.labelName = new System.Windows.Forms.Label();
            this.labelProfession = new System.Windows.Forms.Label();
            this.labelRace = new System.Windows.Forms.Label();
            this.labelAttributes = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbProfession = new System.Windows.Forms.ComboBox();
            this.cmbRace = new System.Windows.Forms.ComboBox();
            this.cmbAttributes = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbProfessionPower = new System.Windows.Forms.ComboBox();
            this.cmbRacePower = new System.Windows.Forms.ComboBox();
            this.cmbAttributesPower = new System.Windows.Forms.ComboBox();
            this.optional = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(26, 46);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 10;
            this.labelName.Text = "Name";
            // 
            // labelProfession
            // 
            this.labelProfession.AutoSize = true;
            this.labelProfession.Location = new System.Drawing.Point(20, 103);
            this.labelProfession.Name = "labelProfession";
            this.labelProfession.Size = new System.Drawing.Size(56, 13);
            this.labelProfession.TabIndex = 11;
            this.labelProfession.Text = "Profession";
            // 
            // labelRace
            // 
            this.labelRace.AutoSize = true;
            this.labelRace.Location = new System.Drawing.Point(26, 162);
            this.labelRace.Name = "labelRace";
            this.labelRace.Size = new System.Drawing.Size(33, 13);
            this.labelRace.TabIndex = 12;
            this.labelRace.Text = "Race";
            // 
            // labelAttributes
            // 
            this.labelAttributes.AutoSize = true;
            this.labelAttributes.Location = new System.Drawing.Point(20, 222);
            this.labelAttributes.Name = "labelAttributes";
            this.labelAttributes.Size = new System.Drawing.Size(51, 13);
            this.labelAttributes.TabIndex = 13;
            this.labelAttributes.Text = "Attributes";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(20, 302);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 14;
            this.labelDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(92, 278);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(216, 82);
            this.txtDescription.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(92, 43);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(121, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateName);
            // 
            // cmbProfession
            // 
            this.cmbProfession.FormattingEnabled = true;
            this.cmbProfession.Location = new System.Drawing.Point(92, 103);
            this.cmbProfession.Name = "cmbProfession";
            this.cmbProfession.Size = new System.Drawing.Size(121, 21);
            this.cmbProfession.TabIndex = 1;
            this.cmbProfession.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateProfession);
            // 
            // cmbRace
            // 
            this.cmbRace.FormattingEnabled = true;
            this.cmbRace.Location = new System.Drawing.Point(92, 159);
            this.cmbRace.Name = "cmbRace";
            this.cmbRace.Size = new System.Drawing.Size(121, 21);
            this.cmbRace.TabIndex = 3;
            this.cmbRace.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateRace);
            // 
            // cmbAttributes
            // 
            this.cmbAttributes.FormattingEnabled = true;
            this.cmbAttributes.Location = new System.Drawing.Point(92, 219);
            this.cmbAttributes.Name = "cmbAttributes";
            this.cmbAttributes.Size = new System.Drawing.Size(121, 21);
            this.cmbAttributes.TabIndex = 5;
            this.cmbAttributes.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateAttributes);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(277, 391);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.OnOk);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(181, 391);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ErrorProvider.ContainerControl = this;
            // 
            // cmbProfessionPower
            // 
            this.cmbProfessionPower.FormattingEnabled = true;
            this.cmbProfessionPower.Location = new System.Drawing.Point(230, 103);
            this.cmbProfessionPower.Name = "cmbProfessionPower";
            this.cmbProfessionPower.Size = new System.Drawing.Size(48, 21);
            this.cmbProfessionPower.TabIndex = 2;
            this.cmbProfessionPower.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidatePower);
            // 
            // cmbRacePower
            // 
            this.cmbRacePower.FormattingEnabled = true;
            this.cmbRacePower.Location = new System.Drawing.Point(230, 159);
            this.cmbRacePower.Name = "cmbRacePower";
            this.cmbRacePower.Size = new System.Drawing.Size(48, 21);
            this.cmbRacePower.TabIndex = 4;
            this.cmbRacePower.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidatePower);
            // 
            // cmbAttributesPower
            // 
            this.cmbAttributesPower.FormattingEnabled = true;
            this.cmbAttributesPower.Location = new System.Drawing.Point(230, 219);
            this.cmbAttributesPower.Name = "cmbAttributesPower";
            this.cmbAttributesPower.Size = new System.Drawing.Size(48, 21);
            this.cmbAttributesPower.TabIndex = 6;
            this.cmbAttributesPower.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidatePower);
            // 
            // optional
            // 
            this.optional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.optional.AutoSize = true;
            this.optional.Location = new System.Drawing.Point(323, 302);
            this.optional.Name = "optional";
            this.optional.Size = new System.Drawing.Size(50, 13);
            this.optional.TabIndex = 15;
            this.optional.Text = "(optional)";
            // 
            // CharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 440);
            this.Controls.Add(this.optional);
            this.Controls.Add(this.cmbAttributesPower);
            this.Controls.Add(this.cmbRacePower);
            this.Controls.Add(this.cmbProfessionPower);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbAttributes);
            this.Controls.Add(this.cmbRace);
            this.Controls.Add(this.cmbProfession);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelAttributes);
            this.Controls.Add(this.labelRace);
            this.Controls.Add(this.labelProfession);
            this.Controls.Add(this.labelName);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(401, 479);
            this.Name = "CharacterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Character";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelProfession;
        private System.Windows.Forms.Label labelRace;
        private System.Windows.Forms.Label labelAttributes;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbProfession;
        private System.Windows.Forms.ComboBox cmbRace;
        private System.Windows.Forms.ComboBox cmbAttributes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.ComboBox cmbAttributesPower;
        private System.Windows.Forms.ComboBox cmbRacePower;
        private System.Windows.Forms.ComboBox cmbProfessionPower;
        private System.Windows.Forms.Label optional;
    }
}