namespace ClientGestionUniversite.view
{
    partial class InputRemplacerCategoriePersonnelForm
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
            this.categorieASupprimerCB = new System.Windows.Forms.ComboBox();
            this.categoriesCB = new System.Windows.Forms.ComboBox();
            this.categorieRemplacementLabel = new System.Windows.Forms.Label();
            this.categorieASupprimerLabel = new System.Windows.Forms.Label();
            this.obligatoire = new System.Windows.Forms.TextBox();
            this.annulerButton = new System.Windows.Forms.Button();
            this.validerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // categorieASupprimerCB
            // 
            this.categorieASupprimerCB.FormattingEnabled = true;
            this.categorieASupprimerCB.Location = new System.Drawing.Point(239, 28);
            this.categorieASupprimerCB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.categorieASupprimerCB.Name = "categorieASupprimerCB";
            this.categorieASupprimerCB.Size = new System.Drawing.Size(205, 24);
            this.categorieASupprimerCB.TabIndex = 1;
            // 
            // categoriesCB
            // 
            this.categoriesCB.FormattingEnabled = true;
            this.categoriesCB.Location = new System.Drawing.Point(239, 63);
            this.categoriesCB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.categoriesCB.Name = "categoriesCB";
            this.categoriesCB.Size = new System.Drawing.Size(205, 24);
            this.categoriesCB.TabIndex = 2;
            // 
            // categorieRemplacementLabel
            // 
            this.categorieRemplacementLabel.AutoSize = true;
            this.categorieRemplacementLabel.Location = new System.Drawing.Point(22, 66);
            this.categorieRemplacementLabel.Name = "categorieRemplacementLabel";
            this.categorieRemplacementLabel.Size = new System.Drawing.Size(206, 17);
            this.categorieRemplacementLabel.TabIndex = 3;
            this.categorieRemplacementLabel.Text = "Catégorie qui va la remplacer :*";
            // 
            // categorieASupprimerLabel
            // 
            this.categorieASupprimerLabel.AutoSize = true;
            this.categorieASupprimerLabel.Location = new System.Drawing.Point(67, 31);
            this.categorieASupprimerLabel.Name = "categorieASupprimerLabel";
            this.categorieASupprimerLabel.Size = new System.Drawing.Size(161, 17);
            this.categorieASupprimerLabel.TabIndex = 4;
            this.categorieASupprimerLabel.Text = "Catégorie à supprimer :*";
            // 
            // obligatoire
            // 
            this.obligatoire.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.obligatoire.Location = new System.Drawing.Point(115, 154);
            this.obligatoire.Multiline = true;
            this.obligatoire.Name = "obligatoire";
            this.obligatoire.ReadOnly = true;
            this.obligatoire.Size = new System.Drawing.Size(329, 20);
            this.obligatoire.TabIndex = 25;
            this.obligatoire.Text = "* : Les champs marqués d\'une étoile sont obligatoire.";
            // 
            // annuler
            // 
            this.annulerButton.Location = new System.Drawing.Point(342, 178);
            this.annulerButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.annulerButton.Name = "annuler";
            this.annulerButton.Size = new System.Drawing.Size(88, 34);
            this.annulerButton.TabIndex = 24;
            this.annulerButton.Text = "Annuler";
            this.annulerButton.UseVisualStyleBackColor = true;
            this.annulerButton.Click += new System.EventHandler(this.annuler);
            // 
            // valider
            // 
            this.validerButton.Location = new System.Drawing.Point(216, 178);
            this.validerButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.validerButton.Name = "valider";
            this.validerButton.Size = new System.Drawing.Size(88, 34);
            this.validerButton.TabIndex = 23;
            this.validerButton.Text = "Valider";
            this.validerButton.UseVisualStyleBackColor = true;
            this.validerButton.Click += new System.EventHandler(this.valider);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Les personnels auront la catégorie choisie en dessous.";
            // 
            // InputRemplacerCategoriePersonnelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 236);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.obligatoire);
            this.Controls.Add(this.annulerButton);
            this.Controls.Add(this.validerButton);
            this.Controls.Add(this.categorieASupprimerLabel);
            this.Controls.Add(this.categorieRemplacementLabel);
            this.Controls.Add(this.categoriesCB);
            this.Controls.Add(this.categorieASupprimerCB);
            this.Name = "InputRemplacerCategoriePersonnelForm";
            this.Text = "InputRemplacerCategoriePersonnelForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox categorieASupprimerCB;
        private System.Windows.Forms.ComboBox categoriesCB;
        private System.Windows.Forms.Label categorieRemplacementLabel;
        private System.Windows.Forms.Label categorieASupprimerLabel;
        private System.Windows.Forms.TextBox obligatoire;
        private System.Windows.Forms.Button annulerButton;
        private System.Windows.Forms.Button validerButton;
        private System.Windows.Forms.Label label1;
    }
}