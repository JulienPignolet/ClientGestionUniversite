﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.view
{
    public partial class InputModifCoursParPersonnelForm
    {
        private void InitializeComponent()
        {
            this.coursLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.heureLabel = new System.Windows.Forms.Label();
            this.heureBox = new System.Windows.Forms.TextBox();
            this.validerButton = new System.Windows.Forms.Button();
            this.annulerButton = new System.Windows.Forms.Button();
            this.coursBox = new System.Windows.Forms.ComboBox();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // coursLabel
            // 
            this.coursLabel.AutoSize = true;
            this.coursLabel.Location = new System.Drawing.Point(15, 15);
            this.coursLabel.Name = "coursLabel";
            this.coursLabel.Size = new System.Drawing.Size(35, 13);
            this.coursLabel.TabIndex = 0;
            this.coursLabel.Text = "Cours :";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(15, 45);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(35, 13);
            this.typeLabel.TabIndex = 1;
            this.typeLabel.Text = "Type :";
            // 
            // heureLabel
            // 
            this.heureLabel.AutoSize = true;
            this.heureLabel.Location = new System.Drawing.Point(15, 75);
            this.heureLabel.Name = "heureLabel";
            this.heureLabel.Size = new System.Drawing.Size(58, 13);
            this.heureLabel.TabIndex = 2;
            this.heureLabel.Text = "Nombre d'heures :";
            // 
            // heureBox
            // 
            this.heureBox.Location = new System.Drawing.Point(110, 71);
            this.heureBox.Name = "heureBox";
            this.heureBox.Size = new System.Drawing.Size(280, 20);
            this.heureBox.TabIndex = 3;
            // 
            // coursBox
            // 
            this.coursBox.FormattingEnabled = true;
            this.coursBox.Location = new System.Drawing.Point(110, 13);
            this.coursBox.Name = "coursBox";
            this.coursBox.Size = new System.Drawing.Size(280, 21);
            this.coursBox.TabIndex = 4;
            // 
            // typeBox
            // 
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Location = new System.Drawing.Point(110, 41);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(280, 21);
            this.typeBox.TabIndex = 5;
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
            // InputModifCoursParPersonnelForm
            // 
            this.ClientSize = new System.Drawing.Size(421, 142);
            this.Controls.Add(this.annulerButton);
            this.Controls.Add(this.validerButton);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.coursBox);
            this.Controls.Add(this.heureBox);
            this.Controls.Add(this.heureLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.coursLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InputModifCoursParPersonnelForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label coursLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label heureLabel;
        private System.Windows.Forms.TextBox heureBox;
        private System.Windows.Forms.ComboBox coursBox;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.Button validerButton;
        private System.Windows.Forms.Button annulerButton;
    }
}