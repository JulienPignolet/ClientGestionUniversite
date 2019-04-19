using ClientGestionUniversite.businessLogic;
using ClientGestionUniversite.modele;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace ClientGestionUniversite.view
{
    partial class InputModifUEForm
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
            this.periodeLabel = new System.Windows.Forms.Label();
            this.categorieLabel = new System.Windows.Forms.Label();
            this.nomBox = new System.Windows.Forms.TextBox();
            this.periodeComboBox = new System.Windows.Forms.ComboBox();
            this.validerButton = new System.Windows.Forms.Button();
            this.annulerButton = new System.Windows.Forms.Button();
            this.anneeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // nomLabel
            // 
            this.nomLabel.AutoSize = true;
            this.nomLabel.Location = new System.Drawing.Point(15, 15);
            this.nomLabel.Name = "nomLabel";
            this.nomLabel.Size = new System.Drawing.Size(35, 13);
            this.nomLabel.TabIndex = 0;
            this.nomLabel.Text = "Nom :";
            // 
            // prenomLabel
            // 
            this.periodeLabel.AutoSize = true;
            this.periodeLabel.Location = new System.Drawing.Point(15, 45);
            this.periodeLabel.Name = "periodeLabel";
            this.periodeLabel.Size = new System.Drawing.Size(49, 13);
            this.periodeLabel.TabIndex = 1;
            this.periodeLabel.Text = "Période :";
            // 
            // categorieLabel
            // 
            this.categorieLabel.AutoSize = true;
            this.categorieLabel.Location = new System.Drawing.Point(15, 75);
            this.categorieLabel.Name = "categorieLabel";
            this.categorieLabel.Size = new System.Drawing.Size(58, 13);
            this.categorieLabel.TabIndex = 2;
            this.categorieLabel.Text = "Catégorie :";
            // 
            // nomBox
            // 
            this.nomBox.Location = new System.Drawing.Point(79, 15);
            this.nomBox.Name = "nomBox";
            this.nomBox.Size = new System.Drawing.Size(329, 20);
            this.nomBox.TabIndex = 3;
            // 
            // periodeComboBox
            // 
            this.periodeComboBox.Location = new System.Drawing.Point(79, 45);
            this.periodeComboBox.Name = "prenomBox";
            this.periodeComboBox.Size = new System.Drawing.Size(329, 20);
            this.periodeComboBox.TabIndex = 4;
            List<Periode> periode = PeriodeDAO.findAll();
            foreach (Periode p in periode)
            {
                this.periodeComboBox.Items.Add(p.id);
            }
            this.periodeComboBox.SelectedIndex = 0;
            // 
            // validerButton
            // 
            this.validerButton.Location = new System.Drawing.Point(79, 107);
            this.validerButton.Name = "validerButton";
            this.validerButton.Size = new System.Drawing.Size(133, 23);
            this.validerButton.TabIndex = 6;
            this.validerButton.Text = "Valider";
            this.validerButton.UseVisualStyleBackColor = true;
            this.validerButton.Click += new EventHandler(valider);
            // 
            // annulerButton
            // 
            this.annulerButton.Location = new System.Drawing.Point(241, 107);
            this.annulerButton.Name = "annulerButton";
            this.annulerButton.Size = new System.Drawing.Size(133, 23);
            this.annulerButton.TabIndex = 7;
            this.annulerButton.Text = "Annuler";
            this.annulerButton.UseVisualStyleBackColor = true;
            this.annulerButton.Click += new System.EventHandler(this.annuler);
            // 
            // anneeComboBox
            // 
            this.anneeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.anneeComboBox.FormattingEnabled = true;
            this.anneeComboBox.Location = new System.Drawing.Point(79, 71);
            this.anneeComboBox.Name = "anneeComboBox";
            this.anneeComboBox.Size = new System.Drawing.Size(329, 21);
            this.anneeComboBox.TabIndex = 5;
            this.anneeComboBox.DisplayMember = "libelle";
            this.anneeComboBox.ValueMember = "id";
            List<Annee> annee = AnneeDAO.findAll();
            foreach (Annee cp in annee)
            {
                this.anneeComboBox.Items.Add(cp);
            }
            this.anneeComboBox.SelectedIndex = 0;
            // 
            // InputModifPersonnelForm
            // 
            this.ClientSize = new System.Drawing.Size(421, 142);
            this.Controls.Add(this.annulerButton);
            this.Controls.Add(this.validerButton);
            this.Controls.Add(this.periodeComboBox);
            this.Controls.Add(this.anneeComboBox);
            this.Controls.Add(this.nomBox);
            this.Controls.Add(this.categorieLabel);
            this.Controls.Add(this.periodeLabel);
            this.Controls.Add(this.nomLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InputModifPersonnelForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label periodeLabel;
        private Label categorieLabel;
        private TextBox nomBox;      
        private Button validerButton;
        private Button annulerButton;
        private Label nomLabel;
        private ComboBox anneeComboBox;
        private ComboBox periodeComboBox;

        #endregion
    }
}