using ClientGestionUniversite.businessLogic;
using ClientGestionUniversite.modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGestionUniversite.view
{
    public partial class InputModifPersonnelForm
    {
        private void InitializeComponent()
        {
            this.nomLabel = new System.Windows.Forms.Label();
            this.prenomLabel = new System.Windows.Forms.Label();
            this.categorieLabel = new System.Windows.Forms.Label();
            this.nomBox = new System.Windows.Forms.TextBox();
            this.prenomBox = new System.Windows.Forms.TextBox();
            this.validerButton = new System.Windows.Forms.Button();
            this.annulerButton = new System.Windows.Forms.Button();
            this.categorieComboBox = new System.Windows.Forms.ComboBox();
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
            this.prenomLabel.AutoSize = true;
            this.prenomLabel.Location = new System.Drawing.Point(15, 45);
            this.prenomLabel.Name = "prenomLabel";
            this.prenomLabel.Size = new System.Drawing.Size(49, 13);
            this.prenomLabel.TabIndex = 1;
            this.prenomLabel.Text = "Prenom :";
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
            // prenomBox
            // 
            this.prenomBox.Location = new System.Drawing.Point(79, 45);
            this.prenomBox.Name = "prenomBox";
            this.prenomBox.Size = new System.Drawing.Size(329, 20);
            this.prenomBox.TabIndex = 4;
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
            // categorieComboBox
            // 
            this.categorieComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categorieComboBox.FormattingEnabled = true;
            this.categorieComboBox.Location = new System.Drawing.Point(79, 71);
            this.categorieComboBox.Name = "categorieComboBox";
            this.categorieComboBox.Size = new System.Drawing.Size(329, 21);
            this.categorieComboBox.TabIndex = 5;
            this.categorieComboBox.DisplayMember = "libelle";
            this.categorieComboBox.ValueMember = "id";
            List<CategoriePersonnel> categories = CategoriePersonnelDAO.findAll();
            foreach (CategoriePersonnel cp in categories)
            {
                this.categorieComboBox.Items.Add(cp);
            }
            this.categorieComboBox.SelectedIndex = 0;
            // 
            // InputModifPersonnelForm
            // 
            this.ClientSize = new System.Drawing.Size(421, 142);
            this.Controls.Add(this.annulerButton);
            this.Controls.Add(this.validerButton);
            this.Controls.Add(this.categorieComboBox);
            this.Controls.Add(this.prenomBox);
            this.Controls.Add(this.nomBox);
            this.Controls.Add(this.categorieLabel);
            this.Controls.Add(this.prenomLabel);
            this.Controls.Add(this.nomLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InputModifPersonnelForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label prenomLabel;
        private Label categorieLabel;
        private TextBox nomBox;
        private TextBox prenomBox;
        private Button validerButton;
        private Button annulerButton;
        private Label nomLabel;
        private ComboBox categorieComboBox;
    }
}
