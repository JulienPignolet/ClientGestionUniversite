using ClientGestionUniversite.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.view
{
    public partial class PersonnelView
    {
        private void InitializeComponent()
        {
            this.personnelViewModel = new PersonnelViewModel(this);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.detailsPanel = new System.Windows.Forms.Panel();
            this.nbHeureEffValue = new System.Windows.Forms.Label();
            this.nbHeureEffLabel = new System.Windows.Forms.Label();
            this.titreValue = new System.Windows.Forms.Label();
            this.titreLabel = new System.Windows.Forms.Label();
            this.nomPrenomValue = new System.Windows.Forms.Label();
            this.nomPrenomLabel = new System.Windows.Forms.Label();
            this.personnelDetailsGridView = new System.Windows.Forms.DataGridView();
            this.editPanel = new System.Windows.Forms.Panel();
            this.supprimerPersonnelButton = new System.Windows.Forms.Button();
            this.modifierPersonnelButton = new System.Windows.Forms.Button();
            this.ajouterPersonnelButton = new System.Windows.Forms.Button();
            this.supprimerAffectationButton = new System.Windows.Forms.Button();
            this.modifierAffectationButton = new System.Windows.Forms.Button();
            this.ajouterAffectationButton = new System.Windows.Forms.Button();
            this.modCategorie = new System.Windows.Forms.Button();
            this.addCategorie = new System.Windows.Forms.Button();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.filterBox = new System.Windows.Forms.TextBox();
            this.supprimerCategorieButton = new System.Windows.Forms.Button(); 
            this.filterLabel = new System.Windows.Forms.Label();
            this.personnelGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2.SuspendLayout();
            this.detailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personnelDetailsGridView)).BeginInit();
            this.editPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personnelGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.detailsPanel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.personnelDetailsGridView, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(203, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(0, 59);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // detailsPanel
            // 
            this.detailsPanel.Controls.Add(this.nbHeureEffValue);
            this.detailsPanel.Controls.Add(this.nbHeureEffLabel);
            this.detailsPanel.Controls.Add(this.titreValue);
            this.detailsPanel.Controls.Add(this.titreLabel);
            this.detailsPanel.Controls.Add(this.nomPrenomValue);
            this.detailsPanel.Controls.Add(this.nomPrenomLabel);
            this.detailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsPanel.Location = new System.Drawing.Point(3, 3);
            this.detailsPanel.MaximumSize = new System.Drawing.Size(0, 100);
            this.detailsPanel.Name = "detailsPanel";
            this.detailsPanel.Size = new System.Drawing.Size(1, 74);
            this.detailsPanel.TabIndex = 0;
            // 
            // nbHeureEffValue
            // 
            this.nbHeureEffValue.AutoSize = true;
            this.nbHeureEffValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personnelViewModel, "heureEff", true));
            this.nbHeureEffValue.Location = new System.Drawing.Point(140, 45);
            this.nbHeureEffValue.Name = "nbHeureEffValue";
            this.nbHeureEffValue.Size = new System.Drawing.Size(0, 13);
            this.nbHeureEffValue.TabIndex = 5;
            // 
            // nbHeureEffLabel
            // 
            this.nbHeureEffLabel.AutoSize = true;
            this.nbHeureEffLabel.Location = new System.Drawing.Point(5, 45);
            this.nbHeureEffLabel.Name = "nbHeureEffLabel";
            this.nbHeureEffLabel.Size = new System.Drawing.Size(140, 13);
            this.nbHeureEffLabel.TabIndex = 4;
            this.nbHeureEffLabel.Text = "Nombre d\'heures affectées :";
            // 
            // titreValue
            // 
            this.titreValue.AutoSize = true;
            this.titreValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personnelViewModel, "titre", true));
            this.titreValue.Location = new System.Drawing.Point(140, 25);
            this.titreValue.Name = "titreValue";
            this.titreValue.Size = new System.Drawing.Size(0, 13);
            this.titreValue.TabIndex = 3;
            // 
            // titreLabel
            // 
            this.titreLabel.AutoSize = true;
            this.titreLabel.Location = new System.Drawing.Point(5, 25);
            this.titreLabel.Name = "titreLabel";
            this.titreLabel.Size = new System.Drawing.Size(34, 13);
            this.titreLabel.TabIndex = 2;
            this.titreLabel.Text = "Titre :";
            // 
            // nomPrenomValue
            // 
            this.nomPrenomValue.AutoSize = true;
            this.nomPrenomValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personnelViewModel, "nomPrenom", true));
            this.nomPrenomValue.Location = new System.Drawing.Point(140, 5);
            this.nomPrenomValue.Name = "nomPrenomValue";
            this.nomPrenomValue.Size = new System.Drawing.Size(0, 13);
            this.nomPrenomValue.TabIndex = 1;
            // 
            // nomPrenomLabel
            // 
            this.nomPrenomLabel.AutoSize = true;
            this.nomPrenomLabel.Location = new System.Drawing.Point(5, 5);
            this.nomPrenomLabel.Name = "nomPrenomLabel";
            this.nomPrenomLabel.Size = new System.Drawing.Size(48, 13);
            this.nomPrenomLabel.TabIndex = 0;
            this.nomPrenomLabel.Text = "Identité :";
            // 
            // personnelDetailsGridView
            // 
            this.personnelDetailsGridView.AllowUserToAddRows = false;
            this.personnelDetailsGridView.AllowUserToDeleteRows = false;
            this.personnelDetailsGridView.AllowUserToResizeColumns = false;
            this.personnelDetailsGridView.AllowUserToResizeRows = false;
            this.personnelDetailsGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.personnelDetailsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.personnelDetailsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.personnelDetailsGridView.Location = new System.Drawing.Point(3, 83);
            this.personnelDetailsGridView.MultiSelect = false;
            this.personnelDetailsGridView.Name = "personnelDetailsGridView";
            this.personnelDetailsGridView.ReadOnly = true;
            this.personnelDetailsGridView.Size = new System.Drawing.Size(1, 150);
            this.personnelDetailsGridView.TabIndex = 1;
            this.personnelDetailsGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.personnelDetailsGridView_DataBindingComplete);
            // 
            // editPanel
            // 
            this.editPanel.Controls.Add(this.supprimerPersonnelButton);
            this.editPanel.Controls.Add(this.modifierPersonnelButton);
            this.editPanel.Controls.Add(this.ajouterPersonnelButton);
            this.editPanel.Controls.Add(this.supprimerAffectationButton);
            this.editPanel.Controls.Add(this.modifierAffectationButton);
            this.editPanel.Controls.Add(this.ajouterAffectationButton);
            this.editPanel.Controls.Add(this.modCategorie);
            this.editPanel.Controls.Add(this.addCategorie);
            this.editPanel.Controls.Add(this.supprimerCategorieButton);
            this.editPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.editPanel.Location = new System.Drawing.Point(3, 62);
            this.editPanel.MaximumSize = new System.Drawing.Size(0, 35);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(194, 35);
            this.editPanel.TabIndex = 0;
            // 
            // supprimerPersonnelButton
            // 
            this.supprimerPersonnelButton.AutoSize = true;
            this.supprimerPersonnelButton.Location = new System.Drawing.Point(5, 5);
            this.supprimerPersonnelButton.Name = "supprimerPersonnelButton";
            this.supprimerPersonnelButton.Size = new System.Drawing.Size(128, 23);
            this.supprimerPersonnelButton.TabIndex = 0;
            this.supprimerPersonnelButton.Text = "Supprimer ce personnel";
            this.supprimerPersonnelButton.Click += new System.EventHandler(this.supprimerPersonnel);
            // 
            // modifierPersonnelButton
            // 
            this.modifierPersonnelButton.AutoSize = true;
            this.modifierPersonnelButton.Location = new System.Drawing.Point(135, 5);
            this.modifierPersonnelButton.Name = "modifierPersonnelButton";
            this.modifierPersonnelButton.Size = new System.Drawing.Size(118, 23);
            this.modifierPersonnelButton.TabIndex = 1;
            this.modifierPersonnelButton.Text = "Modifier ce personnel";
            this.modifierPersonnelButton.Click += new System.EventHandler(this.modifierPersonnel);
            // 
            // ajouterPersonnelButton
            // 
            this.ajouterPersonnelButton.AutoSize = true;
            this.ajouterPersonnelButton.Location = new System.Drawing.Point(255, 5);
            this.ajouterPersonnelButton.Name = "ajouterPersonnelButton";
            this.ajouterPersonnelButton.Size = new System.Drawing.Size(114, 23);
            this.ajouterPersonnelButton.TabIndex = 2;
            this.ajouterPersonnelButton.Text = "Ajouter du personnel";
            this.ajouterPersonnelButton.Click += new System.EventHandler(this.ajouterPersonnel);
            // 
            // supprimerAffectationButton
            // 
            this.supprimerAffectationButton.AutoSize = true;
            this.supprimerAffectationButton.Location = new System.Drawing.Point(370, 5);
            this.supprimerAffectationButton.Name = "supprimerAffectationButton";
            this.supprimerAffectationButton.Size = new System.Drawing.Size(144, 23);
            this.supprimerAffectationButton.TabIndex = 3;
            this.supprimerAffectationButton.Text = "Supprimer cette affectation";
            this.supprimerAffectationButton.Click += new System.EventHandler(this.supprimerAffectation);
            // 
            // modifierAffectationButton
            // 
            this.modifierAffectationButton.AutoSize = true;
            this.modifierAffectationButton.Location = new System.Drawing.Point(515, 5);
            this.modifierAffectationButton.Name = "modifierAffectationButton";
            this.modifierAffectationButton.Size = new System.Drawing.Size(134, 23);
            this.modifierAffectationButton.TabIndex = 4;
            this.modifierAffectationButton.Text = "Modifier cette affectation";
            this.modifierAffectationButton.Click += new System.EventHandler(this.modifierAffectation);
            // 
            // ajouterAffectationButton
            // 
            this.ajouterAffectationButton.AutoSize = true;
            this.ajouterAffectationButton.Location = new System.Drawing.Point(650, 5);
            this.ajouterAffectationButton.Name = "ajouterAffectationButton";
            this.ajouterAffectationButton.Size = new System.Drawing.Size(124, 23);
            this.ajouterAffectationButton.TabIndex = 5;
            this.ajouterAffectationButton.Text = "Ajouter une affectation";
            this.ajouterAffectationButton.Click += new System.EventHandler(this.ajouterAffectation);
            // 
            // modifierCategorie
            // 
            this.modCategorie.AutoSize = true;
            this.modCategorie.Location = new System.Drawing.Point(779, 5);
            this.modCategorie.Name = "modifCategorie";
            this.modCategorie.Size = new System.Drawing.Size(124, 23);
            this.modCategorie.TabIndex = 6;
            this.modCategorie.Text = "Modifier categorie";
            this.modCategorie.Click += new System.EventHandler(this.modifCategorie);
            // 
            // addCategorie
            // 
            this.addCategorie.AutoSize = true;
            this.addCategorie.Location = new System.Drawing.Point(909, 5);
            this.addCategorie.Name = "addCategorie";
            this.addCategorie.Size = new System.Drawing.Size(124, 23);
            this.addCategorie.TabIndex = 6;
            this.addCategorie.Text = "Ajouter categorie";
            this.addCategorie.Click += new System.EventHandler(this.ajouterCategorie);

            // supprimerCategorie
            // 
            this.supprimerCategorieButton.AutoSize = true;
            this.supprimerCategorieButton.Location = new System.Drawing.Point(1039, 5);
            this.supprimerCategorieButton.Name = "supprimerCategorieButton";
            this.supprimerCategorieButton.Size = new System.Drawing.Size(128, 23);
            this.supprimerCategorieButton.TabIndex = 0;
            this.supprimerCategorieButton.Text = "Supprimer catégorie";
            this.supprimerCategorieButton.Click += new System.EventHandler(this.supprimerCategorie);
           
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.filterBox);
            this.filterPanel.Controls.Add(this.filterLabel);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterPanel.Location = new System.Drawing.Point(3, 3);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(194, 24);
            this.filterPanel.TabIndex = 0;
            // 
            // filterBox
            // 
            this.filterBox.Location = new System.Drawing.Point(46, 4);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(100, 20);
            this.filterBox.TabIndex = 1;
            this.filterBox.TextChanged += new System.EventHandler(this.filterBox_TextChanged);
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(11, 7);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(35, 13);
            this.filterLabel.TabIndex = 0;
            this.filterLabel.Text = "Filtre :";
            // 
            // personnelGridView
            // 
            this.personnelGridView.AllowUserToAddRows = false;
            this.personnelGridView.AllowUserToDeleteRows = false;
            this.personnelGridView.AllowUserToResizeColumns = false;
            this.personnelGridView.AllowUserToResizeRows = false;
            this.personnelGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.personnelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.personnelGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.personnelGridView.Location = new System.Drawing.Point(3, 33);
            this.personnelGridView.MultiSelect = false;
            this.personnelGridView.Name = "personnelGridView";
            this.personnelGridView.ReadOnly = true;
            this.personnelGridView.Size = new System.Drawing.Size(194, 150);
            this.personnelGridView.TabIndex = 1;
            this.personnelGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.personnelGridView_DataBindingComplete);
            this.personnelGridView.DataSourceChanged += new EventHandler(this.personnelGridView_DataSourceChanged);
            this.personnelGridView.SelectionChanged += new System.EventHandler(this.personnelGridView_SelectionChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.filterPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.personnelGridView, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 59);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // PersonnelView
            // 
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.editPanel);
            this.Name = "personnelView";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Personnel";
            this.UseVisualStyleBackColor = true;
            this.tableLayoutPanel2.ResumeLayout(false);
            this.detailsPanel.ResumeLayout(false);
            this.detailsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personnelDetailsGridView)).EndInit();
            this.editPanel.ResumeLayout(false);
            this.editPanel.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personnelGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel detailsPanel;
        public System.Windows.Forms.Panel editPanel;
        public System.Windows.Forms.Label nbHeureEffValue;
        private System.Windows.Forms.Label nbHeureEffLabel;
        private System.Windows.Forms.Label titreValue;
        private System.Windows.Forms.Label titreLabel;
        private System.Windows.Forms.Label nomPrenomValue;
        private System.Windows.Forms.Label nomPrenomLabel;
        private System.Windows.Forms.Button supprimerPersonnelButton;
        private System.Windows.Forms.Button modifierPersonnelButton;
        private System.Windows.Forms.Button ajouterPersonnelButton;
        private System.Windows.Forms.Button supprimerAffectationButton;
        private System.Windows.Forms.Button modifierAffectationButton;
        private System.Windows.Forms.Button ajouterAffectationButton;
        private System.Windows.Forms.Button modCategorie;
        private System.Windows.Forms.Button addCategorie;
        private System.Windows.Forms.Button supprimerCategorieButton;
        private System.Windows.Forms.DataGridView personnelDetailsGridView;
        private System.Windows.Forms.TextBox filterBox;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.DataGridView personnelGridView;
        private PersonnelViewModel personnelViewModel;
    }
}
