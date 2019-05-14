using System;
using System.Windows.Forms;
namespace ClientGestionUniversite.view
{
    partial class InputModifAnneeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
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
        private void InitializeComponent()
        {
            this.nomLabel = new System.Windows.Forms.Label();
            this.nomBox = new System.Windows.Forms.TextBox();
            this.validerButton = new System.Windows.Forms.Button();
            this.annulerButton = new System.Windows.Forms.Button();
            this.obligatoire = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nomLabel
            // 
            this.nomLabel.AutoSize = true;
            this.nomLabel.Location = new System.Drawing.Point(15, 15);
            this.nomLabel.Name = "nomLabel";
            this.nomLabel.Size = new System.Drawing.Size(50, 17);
            this.nomLabel.TabIndex = 0;
            this.nomLabel.Text = "Nom :*";
            // 
            // nomBox
            // 
            this.nomBox.Location = new System.Drawing.Point(79, 15);
            this.nomBox.Name = "nomBox";
            this.nomBox.Size = new System.Drawing.Size(295, 22);
            this.nomBox.TabIndex = 3;
            // 
            // validerButton
            // 
            this.validerButton.Location = new System.Drawing.Point(79, 69);
            this.validerButton.Name = "validerButton";
            this.validerButton.Size = new System.Drawing.Size(133, 23);
            this.validerButton.TabIndex = 6;
            this.validerButton.Text = "Valider";
            this.validerButton.UseVisualStyleBackColor = true;
            this.validerButton.Click += new System.EventHandler(this.valider);
            // 
            // annulerButton
            // 
            this.annulerButton.Location = new System.Drawing.Point(241, 69);
            this.annulerButton.Name = "annulerButton";
            this.annulerButton.Size = new System.Drawing.Size(133, 23);
            this.annulerButton.TabIndex = 7;
            this.annulerButton.Text = "Annuler";
            this.annulerButton.UseVisualStyleBackColor = true;
            this.annulerButton.Click += new System.EventHandler(this.annuler);
            // 
            // obligatoire
            // 
            this.obligatoire.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.obligatoire.Location = new System.Drawing.Point(45, 43);
            this.obligatoire.Multiline = true;
            this.obligatoire.Name = "obligatoire";
            this.obligatoire.ReadOnly = true;
            this.obligatoire.Size = new System.Drawing.Size(329, 20);
            this.obligatoire.TabIndex = 22;
            this.obligatoire.Text = "* : Les champs marqués d\'une étoile sont obligatoire.";
            // 
            // InputModifAnneeForm
            // 
            this.ClientSize = new System.Drawing.Size(421, 114);
            this.Controls.Add(this.obligatoire);
            this.Controls.Add(this.annulerButton);
            this.Controls.Add(this.validerButton);
            this.Controls.Add(this.nomBox);
            this.Controls.Add(this.nomLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InputModifAnneeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private TextBox nomBox;
        private Button validerButton;
        private Button annulerButton;
        private Label nomLabel;

        #endregion
        private TextBox obligatoire;
    }
}