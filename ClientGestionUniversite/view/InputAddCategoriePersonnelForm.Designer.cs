namespace ClientGestionUniversite.view
{
    partial class InputAddCategoriePersonnelForm
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
            this.categorieLabel = new System.Windows.Forms.Label();
            this.valider = new System.Windows.Forms.Button();
            this.annuler = new System.Windows.Forms.Button();
            this.volumeTextBox = new System.Windows.Forms.TextBox();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.categorietextBox = new System.Windows.Forms.TextBox();
            this.obligatoire = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // categorieLabel
            // 
            this.categorieLabel.AutoSize = true;
            this.categorieLabel.Location = new System.Drawing.Point(46, 25);
            this.categorieLabel.Name = "categorieLabel";
            this.categorieLabel.Size = new System.Drawing.Size(82, 17);
            this.categorieLabel.TabIndex = 1;
            this.categorieLabel.Text = "Catégorie :*";
            // 
            // valider
            // 
            this.valider.Location = new System.Drawing.Point(115, 190);
            this.valider.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.valider.Name = "valider";
            this.valider.Size = new System.Drawing.Size(88, 34);
            this.valider.TabIndex = 5;
            this.valider.Text = "Valider";
            this.valider.UseVisualStyleBackColor = true;
            this.valider.Click += new System.EventHandler(this.validerAction);
            // 
            // annuler
            // 
            this.annuler.Location = new System.Drawing.Point(241, 190);
            this.annuler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.annuler.Name = "annuler";
            this.annuler.Size = new System.Drawing.Size(88, 34);
            this.annuler.TabIndex = 6;
            this.annuler.Text = "Annuler";
            this.annuler.UseVisualStyleBackColor = true;
            this.annuler.Click += new System.EventHandler(this.annulerAction);
            // 
            // volumeTextBox
            // 
            this.volumeTextBox.Location = new System.Drawing.Point(129, 54);
            this.volumeTextBox.Name = "volumeTextBox";
            this.volumeTextBox.Size = new System.Drawing.Size(205, 22);
            this.volumeTextBox.TabIndex = 8;
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(11, 57);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(117, 17);
            this.volumeLabel.TabIndex = 9;
            this.volumeLabel.Text = "Volume horaire :*";
            // 
            // categorietextBox
            // 
            this.categorietextBox.Location = new System.Drawing.Point(130, 25);
            this.categorietextBox.Name = "categorietextBox";
            this.categorietextBox.Size = new System.Drawing.Size(204, 22);
            this.categorietextBox.TabIndex = 11;
            // 
            // obligatoire
            // 
            this.obligatoire.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.obligatoire.Location = new System.Drawing.Point(14, 165);
            this.obligatoire.Multiline = true;
            this.obligatoire.Name = "obligatoire";
            this.obligatoire.ReadOnly = true;
            this.obligatoire.Size = new System.Drawing.Size(329, 20);
            this.obligatoire.TabIndex = 22;
            this.obligatoire.Text = "* : Les champs marqués d\'une étoile sont obligatoire.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Les ratios sont tous initialisés à 1.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Allez dans modifier catégorie pour les gérer.";
            // 
            // InputAddCategoriePersonnelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 234);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.obligatoire);
            this.Controls.Add(this.categorietextBox);
            this.Controls.Add(this.volumeLabel);
            this.Controls.Add(this.volumeTextBox);
            this.Controls.Add(this.annuler);
            this.Controls.Add(this.valider);
            this.Controls.Add(this.categorieLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "InputAddCategoriePersonnelForm";
            this.Text = "Modif Catégorie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label categorieLabel;
        private System.Windows.Forms.Button valider;
        private System.Windows.Forms.Button annuler;
        private System.Windows.Forms.TextBox volumeTextBox;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.TextBox categorietextBox;
        private System.Windows.Forms.TextBox obligatoire;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}