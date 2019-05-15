using System;
namespace ClientGestionUniversite.view
{
    partial class InputModifCategoriPersonel
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.valueCMTB = new System.Windows.Forms.TextBox();
            this.valider = new System.Windows.Forms.Button();
            this.annuler = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.valueTDTB = new System.Windows.Forms.TextBox();
            this.valueTPTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // categorieCB
            // 
            this.categorieCB.FormattingEnabled = true;
            this.categorieCB.Location = new System.Drawing.Point(97, 24);
            this.categorieCB.Name = "categorieCB";
            this.categorieCB.Size = new System.Drawing.Size(185, 28);
            this.categorieCB.TabIndex = 0;
            this.categorieCB.SelectedIndexChanged += new System.EventHandler(this.categorieCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "catégorie ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "CM";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // valueCMTB
            // 
            this.valueCMTB.Location = new System.Drawing.Point(97, 85);
            this.valueCMTB.Name = "valueCMTB";
            this.valueCMTB.Size = new System.Drawing.Size(129, 26);
            this.valueCMTB.TabIndex = 4;
            this.valueCMTB.TextChanged += new System.EventHandler(this.valueCMTB_TextChanged);
            // 
            // valider
            // 
            this.valider.Location = new System.Drawing.Point(87, 238);
            this.valider.Name = "valider";
            this.valider.Size = new System.Drawing.Size(99, 43);
            this.valider.TabIndex = 5;
            this.valider.Text = "Valider";
            this.valider.UseVisualStyleBackColor = true;
            this.valider.Click += new EventHandler(validerAction);
            // 
            // annuler
            // 
            this.annuler.Location = new System.Drawing.Point(228, 238);
            this.annuler.Name = "annuler";
            this.annuler.Size = new System.Drawing.Size(99, 43);
            this.annuler.TabIndex = 6;
            this.annuler.Text = "Annuler";
            this.annuler.UseVisualStyleBackColor = true;
            this.annuler.Click += new EventHandler(annulerAction);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "TD";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "TP";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // valueTDTB
            // 
            this.valueTDTB.Location = new System.Drawing.Point(97, 134);
            this.valueTDTB.Name = "valueTDTB";
            this.valueTDTB.Size = new System.Drawing.Size(129, 26);
            this.valueTDTB.TabIndex = 9;
            this.valueTDTB.TextChanged += new System.EventHandler(this.valueTDTB_TextChanged);
            // 
            // valueTPTB
            // 
            this.valueTPTB.Location = new System.Drawing.Point(97, 177);
            this.valueTPTB.Name = "valueTPTB";
            this.valueTPTB.Size = new System.Drawing.Size(129, 26);
            this.valueTPTB.TabIndex = 10;
            this.valueTPTB.TextChanged += new System.EventHandler(this.valueTPTB_TextChanged);
            // 
            // InputModifCategoriPersonel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 293);
            this.Controls.Add(this.valueTPTB);
            this.Controls.Add(this.valueTDTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.annuler);
            this.Controls.Add(this.valider);
            this.Controls.Add(this.valueCMTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.categorieCB);
            this.Name = "InputModifCategoriPersonel";
            this.Text = "Modif Catégorie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox categorieCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox valueCMTB;
        private System.Windows.Forms.Button valider;
        private System.Windows.Forms.Button annuler;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox valueTDTB;
        private System.Windows.Forms.TextBox valueTPTB;
    }
}