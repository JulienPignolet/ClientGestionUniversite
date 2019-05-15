namespace ClientGestionUniversite.view
{
    partial class InputModifCategoriePersonnel
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
            this.categorieCB = new System.Windows.Forms.ComboBox();
            this.categorieLabel = new System.Windows.Forms.Label();
            this.valider = new System.Windows.Forms.Button();
            this.annuler = new System.Windows.Forms.Button();
            this.volumeTextBox = new System.Windows.Forms.TextBox();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.typeCoursComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ratioLabel = new System.Windows.Forms.Label();
            this.ratioTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // categorieCB
            // 
            this.categorieCB.FormattingEnabled = true;
            this.categorieCB.Location = new System.Drawing.Point(129, 22);
            this.categorieCB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.categorieCB.Name = "categorieCB";
            this.categorieCB.Size = new System.Drawing.Size(205, 24);
            this.categorieCB.TabIndex = 0;
            this.categorieCB.SelectedIndexChanged += new System.EventHandler(this.categorieCB_SelectedIndexChanged);
            // 
            // categorieLabel
            // 
            this.categorieLabel.AutoSize = true;
            this.categorieLabel.Location = new System.Drawing.Point(46, 25);
            this.categorieLabel.Name = "categorieLabel";
            this.categorieLabel.Size = new System.Drawing.Size(77, 17);
            this.categorieLabel.TabIndex = 1;
            this.categorieLabel.Text = "Catégorie :";
            // 
            // valider
            // 
            this.valider.Location = new System.Drawing.Point(77, 242);
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
            this.annuler.Location = new System.Drawing.Point(203, 242);
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
            this.volumeLabel.Size = new System.Drawing.Size(112, 17);
            this.volumeLabel.TabIndex = 9;
            this.volumeLabel.Text = "Volume horaire :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ratioTextBox);
            this.groupBox1.Controls.Add(this.ratioLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.typeCoursComboBox);
            this.groupBox1.Location = new System.Drawing.Point(14, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 123);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ratio";
            // 
            // typeCoursComboBox
            // 
            this.typeCoursComboBox.FormattingEnabled = true;
            this.typeCoursComboBox.Location = new System.Drawing.Point(115, 31);
            this.typeCoursComboBox.Name = "typeCoursComboBox";
            this.typeCoursComboBox.Size = new System.Drawing.Size(205, 24);
            this.typeCoursComboBox.TabIndex = 0;
            this.typeCoursComboBox.SelectedIndexChanged += new System.EventHandler(this.typeCours_SelectedIndexChanged);
            
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Type de cours :";
            // 
            // ratioLabel
            // 
            this.ratioLabel.AutoSize = true;
            this.ratioLabel.Location = new System.Drawing.Point(60, 77);
            this.ratioLabel.Name = "ratioLabel";
            this.ratioLabel.Size = new System.Drawing.Size(49, 17);
            this.ratioLabel.TabIndex = 11;
            this.ratioLabel.Text = "Ratio :";
            // 
            // ratioTextBox
            // 
            this.ratioTextBox.Location = new System.Drawing.Point(115, 77);
            this.ratioTextBox.Name = "ratioTextBox";
            this.ratioTextBox.Size = new System.Drawing.Size(205, 22);
            this.ratioTextBox.TabIndex = 11;
            // 
            // InputModifCategoriePersonnel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 296);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.volumeLabel);
            this.Controls.Add(this.volumeTextBox);
            this.Controls.Add(this.annuler);
            this.Controls.Add(this.valider);
            this.Controls.Add(this.categorieLabel);
            this.Controls.Add(this.categorieCB);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "InputModifCategoriePersonnel";
            this.Text = "Modif Catégorie";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox categorieCB;
        private System.Windows.Forms.Label categorieLabel;
        private System.Windows.Forms.Button valider;
        private System.Windows.Forms.Button annuler;
        private System.Windows.Forms.TextBox volumeTextBox;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ratioTextBox;
        private System.Windows.Forms.Label ratioLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox typeCoursComboBox;
    }
}