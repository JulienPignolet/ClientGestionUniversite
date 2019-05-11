using ClientGestionUniversite.businessLogic;
using ClientGestionUniversite.modele;
using ClientGestionUniversite.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGestionUniversite.view
{
    public partial class InputModifCoursParPersonnelForm
    {
        private void InitializeComponent()
        {
            this.coursLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.heureLabel = new System.Windows.Forms.Label();
            this.validerButton = new System.Windows.Forms.Button();
            this.annulerButton = new System.Windows.Forms.Button();
            this.coursBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox = new System.Windows.Forms.TextBox();
            this.heureBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // coursLabel
            // 
            this.coursLabel.AutoSize = true;
            this.coursLabel.Location = new System.Drawing.Point(15, 15);
            this.coursLabel.Name = "coursLabel";
            this.coursLabel.Size = new System.Drawing.Size(53, 17);
            this.coursLabel.TabIndex = 0;
            this.coursLabel.Text = "Cours :";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(8, 74);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(48, 17);
            this.typeLabel.TabIndex = 1;
            this.typeLabel.Text = "Type :";
            // 
            // heureLabel
            // 
            this.heureLabel.AutoSize = true;
            this.heureLabel.Location = new System.Drawing.Point(6, 39);
            this.heureLabel.Name = "heureLabel";
            this.heureLabel.Size = new System.Drawing.Size(125, 17);
            this.heureLabel.TabIndex = 2;
            this.heureLabel.Text = "Nombre d\'heures :";
            // 
            // validerButton
            // 
            this.validerButton.Location = new System.Drawing.Point(44, 216);
            this.validerButton.Name = "validerButton";
            this.validerButton.Size = new System.Drawing.Size(133, 23);
            this.validerButton.TabIndex = 6;
            this.validerButton.Text = "Valider";
            this.validerButton.UseVisualStyleBackColor = true;
            this.validerButton.Click += new System.EventHandler(this.valider);
            // 
            // annulerButton
            // 
            this.annulerButton.Location = new System.Drawing.Point(216, 216);
            this.annulerButton.Name = "annulerButton";
            this.annulerButton.Size = new System.Drawing.Size(133, 23);
            this.annulerButton.TabIndex = 7;
            this.annulerButton.Text = "Annuler";
            this.annulerButton.UseVisualStyleBackColor = true;
            this.annulerButton.Click += new System.EventHandler(this.annuler);
            // 
            // coursBox
            // 
            this.coursBox.DisplayMember = "text";
            this.coursBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coursBox.FormattingEnabled = true;
            this.coursBox.Location = new System.Drawing.Point(110, 13);
            this.coursBox.Name = "coursBox";
            this.coursBox.Size = new System.Drawing.Size(280, 24);
            this.coursBox.TabIndex = 4;
            this.coursBox.ValueMember = "id";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox);
            this.groupBox1.Controls.Add(this.heureBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.typeBox);
            this.groupBox1.Controls.Add(this.typeLabel);
            this.groupBox1.Controls.Add(this.heureLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 153);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modifier également le cours séléctionné";
            // 
            // groupBox
            // 
            this.groupBox.Location = new System.Drawing.Point(137, 112);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(235, 22);
            this.groupBox.TabIndex = 15;
            // 
            // heureBox
            // 
            this.heureBox.Location = new System.Drawing.Point(137, 39);
            this.heureBox.Name = "heureBox";
            this.heureBox.Size = new System.Drawing.Size(235, 22);
            this.heureBox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Groupe :";
            // 
            // typeBox
            // 
            this.typeBox.DisplayMember = "text";
            this.typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Location = new System.Drawing.Point(137, 74);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(235, 24);
            this.typeBox.TabIndex = 11;
            this.typeBox.ValueMember = "id";
            // 
            // InputModifCoursParPersonnelForm
            // 
            this.ClientSize = new System.Drawing.Size(402, 254);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.annulerButton);
            this.Controls.Add(this.validerButton);
            this.Controls.Add(this.coursBox);
            this.Controls.Add(this.coursLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InputModifCoursParPersonnelForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label coursLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label heureLabel;
        private System.Windows.Forms.ComboBox coursBox;
        private System.Windows.Forms.Button validerButton;
        private System.Windows.Forms.Button annulerButton;
        private GroupBox groupBox1;
        private ComboBox typeBox;
        private Label label1;
        private TextBox groupBox;
        private TextBox heureBox;
    }
}
