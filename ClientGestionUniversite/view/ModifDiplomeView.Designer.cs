using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.view
{
    public partial class ModifDiplomeView
    {
        private void InitializeComponent()
        {
            this.diplomeGridView = new System.Windows.Forms.DataGridView();
            this.anneeGridView = new System.Windows.Forms.DataGridView();
            this.periodeGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelCours = new System.Windows.Forms.TableLayoutPanel();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.filterBox = new System.Windows.Forms.TextBox();
            this.filterLabel = new System.Windows.Forms.Label();
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
            this.filterPanel.SuspendLayout();
            this.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.tableLayoutPanelCours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.anneeGridView)).BeginInit();
            this.editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diplomeGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodeGridView)).BeginInit();
            this.Text = "Modification Diplome";
            ///
            /// tableLayoutPanel
            ///
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.filterPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.diplomeGridView, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel1";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(200, 387);
            this.tableLayoutPanel.TabIndex = 0;
            ///
            /// tableLayoutPanelCours
            ///
            this.tableLayoutPanelCours.ColumnCount = 2;
            this.tableLayoutPanelCours.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelCours.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelCours.Controls.Add(this.anneeGridView, 0, 0);
            this.tableLayoutPanelCours.Controls.Add(this.periodeGridView, 1, 0);
            this.tableLayoutPanelCours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCours.Location = new System.Drawing.Point(tableLayoutPanel.Location.X + tableLayoutPanel.Size.Width, 3);
            this.tableLayoutPanelCours.Name = "tableLayoutPanelCours1";
            this.tableLayoutPanelCours.TabIndex = 0;
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
            ///
            /// ueGridView
            ///
            this.diplomeGridView.AllowUserToAddRows = false;
            this.diplomeGridView.AllowUserToDeleteRows = false;
            this.diplomeGridView.AllowUserToResizeColumns = false;
            this.diplomeGridView.AllowUserToResizeRows = false;
            this.diplomeGridView.MultiSelect = false;
            this.diplomeGridView.ReadOnly = true;
            this.diplomeGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.diplomeGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diplomeGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.diplomeGridView_DataBindingComplete);
            this.diplomeGridView.SelectionChanged += new EventHandler(this.diplomeGridView_SelectionChanged);
            ///
            /// ecGridView
            ///
            this.anneeGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.anneeGridView.AllowUserToAddRows = false;
            this.anneeGridView.AllowUserToDeleteRows = false;
            this.anneeGridView.AllowUserToResizeColumns = false;
            this.anneeGridView.AllowUserToResizeRows = false;
            this.anneeGridView.MultiSelect = false;
            this.anneeGridView.ReadOnly = true;
            this.anneeGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.anneeGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.anneeGridView_DataBindingComplete);
            this.anneeGridView.SelectionChanged += new EventHandler(this.anneeGridView_SelectionChanged);
            ///
            /// ecDetailsGridView
            ///
            this.periodeGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.periodeGridView.AllowUserToAddRows = false;
            this.periodeGridView.AllowUserToDeleteRows = false;
            this.periodeGridView.AllowUserToResizeColumns = false;
            this.periodeGridView.AllowUserToResizeRows = false;
            this.periodeGridView.MultiSelect = false;
            this.periodeGridView.ReadOnly = true;
            this.periodeGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.periodeGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.periodeGridView_DataBindingComplete);
            ///
            /// DiplomeView
            ///
            //this.Controls.Add(this.ecGridView);
            //this.Controls.Add(this.ecDetailsGridView);
            this.Controls.Add(tableLayoutPanelCours);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.editPanel);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanelCours.ResumeLayout(false);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.anneeGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diplomeGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodeGridView)).EndInit();
            this.ResumeLayout(false);
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
            this.editPanel.Location = new System.Drawing.Point(3, 62);
            this.editPanel.MaximumSize = new System.Drawing.Size(0, 35);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(194, 35);
            this.editPanel.TabIndex = 0;
            // 
            // supprimerdIPLMEButton
            // 
            this.supprimerDiplomeButton.AutoSize = true;
            this.supprimerDiplomeButton.Location = new System.Drawing.Point(5, 5);
            this.supprimerDiplomeButton.Name = "supprimerDiplomeButton";
            this.supprimerDiplomeButton.Size = new System.Drawing.Size(95, 23);
            this.supprimerDiplomeButton.TabIndex = 0;
            this.supprimerDiplomeButton.Text = "Supprimer Diplome";
            this.supprimerDiplomeButton.Click += new System.EventHandler(this.supprimerDiplome);
            // 
            // modifierUEButton
            // 
            this.modifierDiplomeButton.AutoSize = true;
            this.modifierDiplomeButton.Location = new System.Drawing.Point(101, 5);
            this.modifierDiplomeButton.Name = "modifierDiplomeButton";
            this.modifierDiplomeButton.Size = new System.Drawing.Size(95, 23);
            this.modifierDiplomeButton.TabIndex = 1;
            this.modifierDiplomeButton.Text = "Modifier Diplome";
            this.modifierDiplomeButton.Click += new System.EventHandler(this.modifierDiplome);
            // 
            // ajouterUEButton
            // 
            this.ajouterDiplomeButton.AutoSize = true;
            this.ajouterDiplomeButton.Location = new System.Drawing.Point(197, 5);
            this.ajouterDiplomeButton.Name = "ajouterUEButton";
            this.ajouterDiplomeButton.Size = new System.Drawing.Size(95, 23);
            this.ajouterDiplomeButton.TabIndex = 2;
            this.ajouterDiplomeButton.Text = "Ajouter Diplome";
            this.ajouterDiplomeButton.Click += new System.EventHandler(this.ajouterDiplome);
            // 
            // supprimerEcButton
            // 
            this.supprimerAnneeButton.AutoSize = true;
            this.supprimerAnneeButton.Location = new System.Drawing.Point(293, 5);
            this.supprimerAnneeButton.Name = "supprimerECButton";
            this.supprimerAnneeButton.Size = new System.Drawing.Size(95, 23);
            this.supprimerAnneeButton.TabIndex = 3;
            this.supprimerAnneeButton.Text = "Supprimer Année";
            this.supprimerAnneeButton.Click += new System.EventHandler(this.supprimerAnnee);
            // 
            // modifierEcButton
            // 
            this.modifierAnneeButton.AutoSize = true;
            this.modifierAnneeButton.Location = new System.Drawing.Point(389, 5);
            this.modifierAnneeButton.Name = "modifierEcButton";
            this.modifierAnneeButton.Size = new System.Drawing.Size(95, 23);
            this.modifierAnneeButton.TabIndex = 4;
            this.modifierAnneeButton.Text = "Modifier Année";
            this.modifierAnneeButton.Click += new System.EventHandler(this.modifierAnnee);
            // 
            // ajouterEcButton
            // 
            this.ajouterAnneeButton.AutoSize = true;
            this.ajouterAnneeButton.Location = new System.Drawing.Point(485, 5);
            this.ajouterAnneeButton.Name = "ajouterEcButton";
            this.ajouterAnneeButton.Size = new System.Drawing.Size(95, 23);
            this.ajouterAnneeButton.TabIndex = 5;
            this.ajouterAnneeButton.Text = "Ajouter Année";
            this.ajouterAnneeButton.Click += new System.EventHandler(this.ajouterAnnee);
            // 
            // supprimerCoursButton
            // 
            this.supprimerPeriodeButton.AutoSize = true;
            this.supprimerPeriodeButton.Location = new System.Drawing.Point(581, 5);
            this.supprimerPeriodeButton.Name = "supprimerCoursButton";
            this.supprimerPeriodeButton.Size = new System.Drawing.Size(95, 23);
            this.supprimerPeriodeButton.TabIndex = 6;
            this.supprimerPeriodeButton.Text = "Supprimer Période";
            this.supprimerPeriodeButton.Click += new System.EventHandler(this.supprimerperiode);
            // 
            // modifierCoursButton
            // 
            this.modifierPeriodeButton.AutoSize = true;
            this.modifierPeriodeButton.Location = new System.Drawing.Point(677, 5);
            this.modifierPeriodeButton.Name = "modifierCoursButton";
            this.modifierPeriodeButton.Size = new System.Drawing.Size(95, 23);
            this.modifierPeriodeButton.TabIndex = 7;
            this.modifierPeriodeButton.Text = "Modifier Période";
            this.modifierPeriodeButton.Click += new System.EventHandler(this.modifierPeriode);
            // 
            // ajouterCoursButton
            // 
            this.ajouterPeriodeButton.AutoSize = true;
            this.ajouterPeriodeButton.Location = new System.Drawing.Point(773, 5);
            this.ajouterPeriodeButton.Name = "ajouterCoursButton";
            this.ajouterPeriodeButton.Size = new System.Drawing.Size(95, 23);
            this.ajouterPeriodeButton.TabIndex = 8;
            this.ajouterPeriodeButton.Text = "Ajouter Période";
            this.ajouterPeriodeButton.Click += new System.EventHandler(this.ajouterPeriode);
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
