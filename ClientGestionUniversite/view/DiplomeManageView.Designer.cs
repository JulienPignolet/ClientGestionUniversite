using System;
using System.Windows.Forms;
namespace ClientGestionUniversite.view
{
    partial class DiplomeManageView 
    {
        private void InitializeComponent()
        {
            this.diplomeGridView = new System.Windows.Forms.DataGridView();
            this.anneeGridView = new System.Windows.Forms.DataGridView();
            this.periodeGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.filterBox = new System.Windows.Forms.TextBox();
            this.filterLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanelCours = new System.Windows.Forms.TableLayoutPanel();
            this.editPanel = new System.Windows.Forms.Panel();
            this.supprimerDiplomeButton = new System.Windows.Forms.Button();
            this.modifierDiplomeButton = new System.Windows.Forms.Button();
            this.ajouterDiplomeButton = new System.Windows.Forms.Button();
            this.supprimerAnneeButton = new System.Windows.Forms.Button();
            this.modifierAnneeButton = new System.Windows.Forms.Button();
            this.ajouterAnneeButton = new System.Windows.Forms.Button();
            this.supprimerPeriodeButton = new System.Windows.Forms.Button();
            this.modifierPeriodeButton = new System.Windows.Forms.Button();
            this.ajouterPeriodeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.diplomeGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anneeGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodeGridView)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.tableLayoutPanelCours.SuspendLayout();
            this.editPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // diplomeGridView
            // 
            this.diplomeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.diplomeGridView.AllowUserToAddRows = false;
            this.diplomeGridView.AllowUserToDeleteRows = false;
            this.diplomeGridView.AllowUserToResizeColumns = false;
            this.diplomeGridView.AllowUserToResizeRows = false;
            this.diplomeGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.diplomeGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diplomeGridView.Location = new System.Drawing.Point(3, 33);
            this.diplomeGridView.MultiSelect = false;
            this.diplomeGridView.Name = "diplomeGridView";
            this.diplomeGridView.ReadOnly = true;
            this.diplomeGridView.Size = new System.Drawing.Size(194, 372);
            this.diplomeGridView.TabIndex = 1;
            this.diplomeGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.diplomeGridView_DataBindingComplete);
            this.diplomeGridView.SelectionChanged += new System.EventHandler(this.diplomeGridView_SelectionChanged);
            // 
            // anneeGridView
            // 
            this.anneeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.anneeGridView.AllowUserToAddRows = false;
            this.anneeGridView.AllowUserToDeleteRows = false;
            this.anneeGridView.AllowUserToResizeColumns = false;
            this.anneeGridView.AllowUserToResizeRows = false;
            this.anneeGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.anneeGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.anneeGridView.Location = new System.Drawing.Point(3, 3);
            this.anneeGridView.MultiSelect = false;
            this.anneeGridView.Name = "anneeGridView";
            this.anneeGridView.ReadOnly = true;
            this.anneeGridView.Size = new System.Drawing.Size(287, 402);
            this.anneeGridView.TabIndex = 0;
            this.anneeGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.anneeGridView_DataBindingComplete);
            this.anneeGridView.SelectionChanged += new System.EventHandler(this.anneeGridView_SelectionChanged);
            // 
            // periodeGridView
            // 
            this.periodeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.periodeGridView.AllowUserToAddRows = false;
            this.periodeGridView.AllowUserToDeleteRows = false;
            this.periodeGridView.AllowUserToResizeColumns = false;
            this.periodeGridView.AllowUserToResizeRows = false;
            this.periodeGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.periodeGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.periodeGridView.Location = new System.Drawing.Point(296, 3);
            this.periodeGridView.MultiSelect = false;
            this.periodeGridView.Name = "periodeGridView";
            this.periodeGridView.ReadOnly = true;
            this.periodeGridView.Size = new System.Drawing.Size(678, 402);
            this.periodeGridView.TabIndex = 1;
            this.periodeGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.periodeGridView_DataBindingComplete);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.filterPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.diplomeGridView, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(200, 408);
            this.tableLayoutPanel.TabIndex = 0;
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
            this.filterBox.Size = new System.Drawing.Size(100, 22);
            this.filterBox.TabIndex = 1;
            this.filterBox.TextChanged += new System.EventHandler(this.filterBox_TextChanged);
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(11, 7);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(47, 17);
            this.filterLabel.TabIndex = 0;
            this.filterLabel.Text = "Filtre :";
            // 
            // tableLayoutPanelCours
            // 
            this.tableLayoutPanelCours.ColumnCount = 2;
            this.tableLayoutPanelCours.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelCours.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelCours.Controls.Add(this.anneeGridView, 0, 0);
            this.tableLayoutPanelCours.Controls.Add(this.periodeGridView, 1, 0);
            this.tableLayoutPanelCours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCours.Location = new System.Drawing.Point(200, 0);
            this.tableLayoutPanelCours.Name = "tableLayoutPanelCours";
            this.tableLayoutPanelCours.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCours.Size = new System.Drawing.Size(977, 408);
            this.tableLayoutPanelCours.TabIndex = 0;
            // 
            // editPanel
            // 
            this.editPanel.Controls.Add(this.supprimerDiplomeButton);
            this.editPanel.Controls.Add(this.modifierDiplomeButton);
            this.editPanel.Controls.Add(this.ajouterDiplomeButton);
            this.editPanel.Controls.Add(this.supprimerAnneeButton);
            this.editPanel.Controls.Add(this.modifierAnneeButton);
            this.editPanel.Controls.Add(this.ajouterAnneeButton);
            this.editPanel.Controls.Add(this.supprimerPeriodeButton);
            this.editPanel.Controls.Add(this.modifierPeriodeButton);
            this.editPanel.Controls.Add(this.ajouterPeriodeButton);
            this.editPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.editPanel.Location = new System.Drawing.Point(0, 408);
            this.editPanel.MaximumSize = new System.Drawing.Size(0, 35);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(1177, 35);
            this.editPanel.TabIndex = 0;
            // 
            // supprimerDiplomeButton
            // 
            this.supprimerDiplomeButton.AutoSize = true;
            this.supprimerDiplomeButton.Location = new System.Drawing.Point(5, 5);
            this.supprimerDiplomeButton.Name = "supprimerDiplomeButton";
            this.supprimerDiplomeButton.Size = new System.Drawing.Size(138, 27);
            this.supprimerDiplomeButton.TabIndex = 0;
            this.supprimerDiplomeButton.Text = "Supprimer Diplome";
            this.supprimerDiplomeButton.Click += new System.EventHandler(this.supprimerDiplome);
            // 
            // modifierDiplomeButton
            // 
            this.modifierDiplomeButton.AutoSize = true;
            this.modifierDiplomeButton.Location = new System.Drawing.Point(149, 5);
            this.modifierDiplomeButton.Name = "modifierDiplomeButton";
            this.modifierDiplomeButton.Size = new System.Drawing.Size(123, 27);
            this.modifierDiplomeButton.TabIndex = 1;
            this.modifierDiplomeButton.Text = "Modifier Diplome";
            this.modifierDiplomeButton.Click += new System.EventHandler(this.modifierDiplome);
            // 
            // ajouterDiplomeButton
            // 
            this.ajouterDiplomeButton.AutoSize = true;
            this.ajouterDiplomeButton.Location = new System.Drawing.Point(278, 5);
            this.ajouterDiplomeButton.Name = "ajouterDiplomeButton";
            this.ajouterDiplomeButton.Size = new System.Drawing.Size(118, 27);
            this.ajouterDiplomeButton.TabIndex = 2;
            this.ajouterDiplomeButton.Text = "Ajouter Diplome";
            this.ajouterDiplomeButton.Click += new System.EventHandler(this.ajouterDiplome);
            // 
            // supprimerAnneeButton
            // 
            this.supprimerAnneeButton.AutoSize = true;
            this.supprimerAnneeButton.Location = new System.Drawing.Point(402, 5);
            this.supprimerAnneeButton.Name = "supprimerAnneeButton";
            this.supprimerAnneeButton.Size = new System.Drawing.Size(128, 27);
            this.supprimerAnneeButton.TabIndex = 3;
            this.supprimerAnneeButton.Text = "Supprimer Année";
            this.supprimerAnneeButton.Click += new System.EventHandler(this.supprimerAnnee);
            // 
            // modifierAnneeButton
            // 
            this.modifierAnneeButton.AutoSize = true;
            this.modifierAnneeButton.Location = new System.Drawing.Point(536, 5);
            this.modifierAnneeButton.Name = "modifierAnneeButton";
            this.modifierAnneeButton.Size = new System.Drawing.Size(113, 27);
            this.modifierAnneeButton.TabIndex = 4;
            this.modifierAnneeButton.Text = "Modifier Année";
            this.modifierAnneeButton.Click += new System.EventHandler(this.modifierAnnee);
            // 
            // ajouterAnneeButton
            // 
            this.ajouterAnneeButton.AutoSize = true;
            this.ajouterAnneeButton.Location = new System.Drawing.Point(655, 5);
            this.ajouterAnneeButton.Name = "ajouterAnneeButton";
            this.ajouterAnneeButton.Size = new System.Drawing.Size(108, 27);
            this.ajouterAnneeButton.TabIndex = 5;
            this.ajouterAnneeButton.Text = "Ajouter Année";
            this.ajouterAnneeButton.Click += new System.EventHandler(this.ajouterAnnee);
            // 
            // supprimerPeriodeButton
            // 
            this.supprimerPeriodeButton.AutoSize = true;
            this.supprimerPeriodeButton.Location = new System.Drawing.Point(769, 5);
            this.supprimerPeriodeButton.Name = "supprimerPeriodeButton";
            this.supprimerPeriodeButton.Size = new System.Drawing.Size(150, 27);
            this.supprimerPeriodeButton.TabIndex = 6;
            this.supprimerPeriodeButton.Text = "Supprimer Période";
            this.supprimerPeriodeButton.Click += new System.EventHandler(this.supprimerperiode);
            // 
            // modifierPeriodeButton
            // 
            this.modifierPeriodeButton.AutoSize = true;
            this.modifierPeriodeButton.Location = new System.Drawing.Point(925, 6);
            this.modifierPeriodeButton.Name = "modifierPeriodeButton";
            this.modifierPeriodeButton.Size = new System.Drawing.Size(121, 27);
            this.modifierPeriodeButton.TabIndex = 7;
            this.modifierPeriodeButton.Text = "Modifier Période";
            this.modifierPeriodeButton.Click += new System.EventHandler(this.modifierPeriode);
            // 
            // ajouterPeriodeButton
            // 
            this.ajouterPeriodeButton.AutoSize = true;
            this.ajouterPeriodeButton.Location = new System.Drawing.Point(1052, 5);
            this.ajouterPeriodeButton.Name = "ajouterPeriodeButton";
            this.ajouterPeriodeButton.Size = new System.Drawing.Size(116, 27);
            this.ajouterPeriodeButton.TabIndex = 8;
            this.ajouterPeriodeButton.Text = "Ajouter Période";
            this.ajouterPeriodeButton.Click += new System.EventHandler(this.ajouterPeriode);
            // 
            // DiplomeManageView
            // 
            this.ClientSize = new System.Drawing.Size(1177, 443);
            this.Controls.Add(this.tableLayoutPanelCours);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.editPanel);
            this.Name = "DiplomeManageView";
            this.Text = "Modification Diplome";
            ((System.ComponentModel.ISupportInitialize)(this.diplomeGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anneeGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodeGridView)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.tableLayoutPanelCours.ResumeLayout(false);
            this.editPanel.ResumeLayout(false);
            this.editPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView diplomeGridView;
        private System.Windows.Forms.DataGridView anneeGridView;
        private System.Windows.Forms.DataGridView periodeGridView;
        private System.Windows.Forms.TextBox filterBox;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCours;

        public System.Windows.Forms.Panel editPanel;
        /* System.Windows.Forms.Label nbHeureEffValue;
        private System.Windows.Forms.Label nbHeureEffLabel;
        private System.Windows.Forms.Label titreValue;
        private System.Windows.Forms.Label titreLabel;
        private System.Windows.Forms.Label nomPrenomValue;
        private System.Windows.Forms.Label nomPrenomLabel;*/
        private System.Windows.Forms.Button supprimerDiplomeButton;
        private System.Windows.Forms.Button modifierDiplomeButton;
        private System.Windows.Forms.Button ajouterDiplomeButton;
        private System.Windows.Forms.Button supprimerAnneeButton;
        private System.Windows.Forms.Button modifierAnneeButton;
        private System.Windows.Forms.Button ajouterAnneeButton;
        private System.Windows.Forms.Button supprimerPeriodeButton;
        private System.Windows.Forms.Button modifierPeriodeButton;
        private System.Windows.Forms.Button ajouterPeriodeButton;
    }
}