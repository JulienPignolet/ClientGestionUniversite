namespace ClientGestionUniversite.view
{
    partial class InputModifCoursForm
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
            this.annulerButton = new System.Windows.Forms.Button();
            this.validerButton = new System.Windows.Forms.Button();
            this.groupeBox = new System.Windows.Forms.TextBox();
            this.groupeLabel = new System.Windows.Forms.Label();
            this.typeCoursLabel = new System.Windows.Forms.Label();
            this.typeCoursBox = new System.Windows.Forms.ComboBox();
            this.intervenantBox = new System.Windows.Forms.ComboBox();
            this.intervenantLabel = new System.Windows.Forms.Label();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.volumeBox = new System.Windows.Forms.TextBox();
            this.obligatoire = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // annulerButton
            // 
            this.annulerButton.Location = new System.Drawing.Point(368, 191);
            this.annulerButton.Name = "annulerButton";
            this.annulerButton.Size = new System.Drawing.Size(133, 23);
            this.annulerButton.TabIndex = 13;
            this.annulerButton.Text = "Annuler";
            this.annulerButton.UseVisualStyleBackColor = true;
            this.annulerButton.Click += new System.EventHandler(this.annuler);
            // 
            // validerButton
            // 
            this.validerButton.Location = new System.Drawing.Point(172, 191);
            this.validerButton.Name = "validerButton";
            this.validerButton.Size = new System.Drawing.Size(133, 23);
            this.validerButton.TabIndex = 12;
            this.validerButton.Text = "Valider";
            this.validerButton.UseVisualStyleBackColor = true;
            this.validerButton.Click += new System.EventHandler(this.valider);
            // 
            // groupeBox
            // 
            this.groupeBox.Location = new System.Drawing.Point(172, 27);
            this.groupeBox.Name = "groupeBox";
            this.groupeBox.Size = new System.Drawing.Size(329, 22);
            this.groupeBox.TabIndex = 10;
            // 
            // groupeLabel
            // 
            this.groupeLabel.AutoSize = true;
            this.groupeLabel.Location = new System.Drawing.Point(12, 27);
            this.groupeLabel.Name = "groupeLabel";
            this.groupeLabel.Size = new System.Drawing.Size(69, 17);
            this.groupeLabel.TabIndex = 8;
            this.groupeLabel.Text = "Groupe :*";
            // 
            // typeCoursLabel
            // 
            this.typeCoursLabel.AutoSize = true;
            this.typeCoursLabel.Location = new System.Drawing.Point(59, 58);
            this.typeCoursLabel.Name = "typeCoursLabel";
            this.typeCoursLabel.Size = new System.Drawing.Size(112, 17);
            this.typeCoursLabel.TabIndex = 14;
            this.typeCoursLabel.Text = "Type de cours :*";
            // 
            // typeCoursBox
            // 
            this.typeCoursBox.DisplayMember = "libelle";
            this.typeCoursBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeCoursBox.FormattingEnabled = true;
            this.typeCoursBox.Location = new System.Drawing.Point(172, 55);
            this.typeCoursBox.Name = "typeCoursBox";
            this.typeCoursBox.Size = new System.Drawing.Size(328, 24);
            this.typeCoursBox.TabIndex = 15;
            this.typeCoursBox.ValueMember = "id";
            // 
            // intervenantBox
            // 
            this.intervenantBox.DisplayMember = "text";
            this.intervenantBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.intervenantBox.FormattingEnabled = true;
            this.intervenantBox.Location = new System.Drawing.Point(172, 89);
            this.intervenantBox.Name = "intervenantBox";
            this.intervenantBox.Size = new System.Drawing.Size(329, 24);
            this.intervenantBox.TabIndex = 16;
            this.intervenantBox.ValueMember = "id";
            // 
            // intervenantLabel
            // 
            this.intervenantLabel.AutoSize = true;
            this.intervenantLabel.Location = new System.Drawing.Point(79, 92);
            this.intervenantLabel.Name = "intervenantLabel";
            this.intervenantLabel.Size = new System.Drawing.Size(87, 17);
            this.intervenantLabel.TabIndex = 17;
            this.intervenantLabel.Text = "Intervenant :";
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(103, 124);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(68, 17);
            this.volumeLabel.TabIndex = 18;
            this.volumeLabel.Text = "Volume :*";
            // 
            // volumeBox
            // 
            this.volumeBox.Location = new System.Drawing.Point(172, 124);
            this.volumeBox.Name = "volumeBox";
            this.volumeBox.Size = new System.Drawing.Size(328, 22);
            this.volumeBox.TabIndex = 19;
            // 
            // obligatoire
            // 
            this.obligatoire.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.obligatoire.Location = new System.Drawing.Point(171, 165);
            this.obligatoire.Multiline = true;
            this.obligatoire.Name = "obligatoire";
            this.obligatoire.ReadOnly = true;
            this.obligatoire.Size = new System.Drawing.Size(329, 20);
            this.obligatoire.TabIndex = 21;
            this.obligatoire.Text = "* : Les champs marqués d\'une étoile sont obligatoire.";
            // 
            // InputModifCoursForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 232);
            this.Controls.Add(this.obligatoire);
            this.Controls.Add(this.volumeBox);
            this.Controls.Add(this.volumeLabel);
            this.Controls.Add(this.intervenantLabel);
            this.Controls.Add(this.intervenantBox);
            this.Controls.Add(this.typeCoursBox);
            this.Controls.Add(this.typeCoursLabel);
            this.Controls.Add(this.annulerButton);
            this.Controls.Add(this.validerButton);
            this.Controls.Add(this.groupeBox);
            this.Controls.Add(this.groupeLabel);
            this.Name = "InputModifCoursForm";
            this.Text = "Ajouter ou modifier un cours";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button annulerButton;
        private System.Windows.Forms.Button validerButton;
        private System.Windows.Forms.TextBox groupeBox;
        private System.Windows.Forms.Label groupeLabel;
        private System.Windows.Forms.Label typeCoursLabel;
        private System.Windows.Forms.ComboBox typeCoursBox;
        private System.Windows.Forms.ComboBox intervenantBox;
        private System.Windows.Forms.Label intervenantLabel;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.TextBox volumeBox;
        private System.Windows.Forms.TextBox obligatoire;

    }
}