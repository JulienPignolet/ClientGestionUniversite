using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.view
{
    public partial class DiplomeView
    {
        private void InitializeComponent()
        {
            this.ueGridView = new System.Windows.Forms.DataGridView();
            this.ecGridView = new System.Windows.Forms.DataGridView();
            this.ecDetailsGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelCours = new System.Windows.Forms.TableLayoutPanel();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.filterBox = new System.Windows.Forms.TextBox();
            this.filterLabel = new System.Windows.Forms.Label();
            this.editPanel = new System.Windows.Forms.Panel();
            this.supprimerUEButton = new System.Windows.Forms.Button();
            this.modifierUEButton = new System.Windows.Forms.Button();
            this.ajouterUEButton = new System.Windows.Forms.Button();
            this.supprimerEcButton = new System.Windows.Forms.Button();
            this.modifierEcButton = new System.Windows.Forms.Button();
            this.ajouterEcButton = new System.Windows.Forms.Button();
            this.supprimerCoursButton = new System.Windows.Forms.Button();
            this.modifierCoursButton = new System.Windows.Forms.Button();
            this.ajouterCoursButton = new System.Windows.Forms.Button();
            this.filterPanel.SuspendLayout();
            this.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.tableLayoutPanelCours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ecGridView)).BeginInit();
            this.editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ueGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ecDetailsGridView)).BeginInit();
            ///
            /// tableLayoutPanel
            ///
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.filterPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.ueGridView, 0, 1);
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
            this.tableLayoutPanelCours.Controls.Add(this.ecGridView, 0, 0);
            this.tableLayoutPanelCours.Controls.Add(this.ecDetailsGridView, 1, 0);
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
            this.ueGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ueGridView.AllowUserToAddRows = false;
            this.ueGridView.AllowUserToDeleteRows = false;
            this.ueGridView.AllowUserToResizeColumns = false;
            this.ueGridView.AllowUserToResizeRows = false;
            this.ueGridView.MultiSelect = false;
            this.ueGridView.ReadOnly = true;
            this.ueGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.ueGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ueGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ueGridView_DataBindingComplete);
            this.ueGridView.SelectionChanged += new EventHandler(this.ueGridView_SelectionChanged);
            ///
            /// ecGridView
            ///
            this.ecGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ecGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ecGridView.AllowUserToAddRows = false;
            this.ecGridView.AllowUserToDeleteRows = false;
            this.ecGridView.AllowUserToResizeColumns = false;
            this.ecGridView.AllowUserToResizeRows = false;
            this.ecGridView.MultiSelect = false;
            this.ecGridView.ReadOnly = true;
            this.ecGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.ecGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ecGridView_DataBindingComplete);
            this.ecGridView.SelectionChanged += new EventHandler(this.ecGridView_SelectionChanged);
            ///
            /// ecDetailsGridView
            ///
            this.ecDetailsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ecDetailsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ecDetailsGridView.AllowUserToAddRows = false;
            this.ecDetailsGridView.AllowUserToDeleteRows = false;
            this.ecDetailsGridView.AllowUserToResizeColumns = false;
            this.ecDetailsGridView.AllowUserToResizeRows = false;
            this.ecDetailsGridView.MultiSelect = false;
            this.ecDetailsGridView.ReadOnly = true;
            this.ecDetailsGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.ecDetailsGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ecDetailsGridView_DataBindingComplete);
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
            ((System.ComponentModel.ISupportInitialize)(this.ecGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ueGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ecDetailsGridView)).EndInit();
            this.ResumeLayout(false);
            // 
            // editPanel
            // 
            this.editPanel.Controls.Add(this.supprimerUEButton);
            this.editPanel.Controls.Add(this.modifierUEButton);
            this.editPanel.Controls.Add(this.ajouterUEButton);
            this.editPanel.Controls.Add(this.supprimerEcButton);
            this.editPanel.Controls.Add(this.modifierEcButton);
            this.editPanel.Controls.Add(this.ajouterEcButton);
            this.editPanel.Controls.Add(this.supprimerCoursButton);
            this.editPanel.Controls.Add(this.modifierCoursButton);
            this.editPanel.Controls.Add(this.ajouterCoursButton);
            this.editPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.editPanel.Location = new System.Drawing.Point(3, 62);
            this.editPanel.MaximumSize = new System.Drawing.Size(0, 35);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(194, 35);
            this.editPanel.TabIndex = 0;
            // 
            // supprimerUEButton
            // 
            this.supprimerUEButton.AutoSize = true;
            this.supprimerUEButton.Location = new System.Drawing.Point(5, 5);
            this.supprimerUEButton.Name = "supprimerUEButton";
            this.supprimerUEButton.Size = new System.Drawing.Size(95, 23);
            this.supprimerUEButton.TabIndex = 0;
            this.supprimerUEButton.Text = "Supprimer UE";
            this.supprimerUEButton.Click += new System.EventHandler(this.supprimerUE);
            // 
            // modifierUEButton
            // 
            this.modifierUEButton.AutoSize = true;
            this.modifierUEButton.Location = new System.Drawing.Point(101, 5);
            this.modifierUEButton.Name = "modifierUEButton";
            this.modifierUEButton.Size = new System.Drawing.Size(95, 23);
            this.modifierUEButton.TabIndex = 1;
            this.modifierUEButton.Text = "Modifier UE";
            this.modifierUEButton.Click += new System.EventHandler(this.modifierUE);
            // 
            // ajouterUEButton
            // 
            this.ajouterUEButton.AutoSize = true;
            this.ajouterUEButton.Location = new System.Drawing.Point(197, 5);
            this.ajouterUEButton.Name = "ajouterUEButton";
            this.ajouterUEButton.Size = new System.Drawing.Size(95, 23);
            this.ajouterUEButton.TabIndex = 2;
            this.ajouterUEButton.Text = "Ajouter UE";
            this.ajouterUEButton.Click += new System.EventHandler(this.ajouterUE);
            // 
            // supprimerEcButton
            // 
            this.supprimerEcButton.AutoSize = true;
            this.supprimerEcButton.Location = new System.Drawing.Point(293, 5);
            this.supprimerEcButton.Name = "supprimerECButton";
            this.supprimerEcButton.Size = new System.Drawing.Size(95, 23);
            this.supprimerEcButton.TabIndex = 3;
            this.supprimerEcButton.Text = "Supprimer EC";
            this.supprimerEcButton.Click += new System.EventHandler(this.supprimerEc);
            // 
            // modifierEcButton
            // 
            this.modifierEcButton.AutoSize = true;
            this.modifierEcButton.Location = new System.Drawing.Point(389, 5);
            this.modifierEcButton.Name = "modifierEcButton";
            this.modifierEcButton.Size = new System.Drawing.Size(95, 23);
            this.modifierEcButton.TabIndex = 4;
            this.modifierEcButton.Text = "Modifier EC";
            this.modifierEcButton.Click += new System.EventHandler(this.modifierEc);
            // 
            // ajouterEcButton
            // 
            this.ajouterEcButton.AutoSize = true;
            this.ajouterEcButton.Location = new System.Drawing.Point(485, 5);
            this.ajouterEcButton.Name = "ajouterEcButton";
            this.ajouterEcButton.Size = new System.Drawing.Size(95, 23);
            this.ajouterEcButton.TabIndex = 5;
            this.ajouterEcButton.Text = "Ajouter EC";
            this.ajouterEcButton.Click += new System.EventHandler(this.ajouterEc);
            // 
            // supprimerCoursButton
            // 
            this.supprimerCoursButton.AutoSize = true;
            this.supprimerCoursButton.Location = new System.Drawing.Point(581, 5);
            this.supprimerCoursButton.Name = "supprimerCoursButton";
            this.supprimerCoursButton.Size = new System.Drawing.Size(95, 23);
            this.supprimerCoursButton.TabIndex = 6;
            this.supprimerCoursButton.Text = "Supprimer Cours";
            this.supprimerCoursButton.Click += new System.EventHandler(this.supprimerCours);
            // 
            // modifierCoursButton
            // 
            this.modifierCoursButton.AutoSize = true;
            this.modifierCoursButton.Location = new System.Drawing.Point(677, 5);
            this.modifierCoursButton.Name = "modifierCoursButton";
            this.modifierCoursButton.Size = new System.Drawing.Size(95, 23);
            this.modifierCoursButton.TabIndex = 7;
            this.modifierCoursButton.Text = "Modifier Cours";
            this.modifierCoursButton.Click += new System.EventHandler(this.modifierCours);
            // 
            // ajouterCoursButton
            // 
            this.ajouterCoursButton.AutoSize = true;
            this.ajouterCoursButton.Location = new System.Drawing.Point(773, 5);
            this.ajouterCoursButton.Name = "ajouterCoursButton";
            this.ajouterCoursButton.Size = new System.Drawing.Size(95, 23);
            this.ajouterCoursButton.TabIndex = 8;
            this.ajouterCoursButton.Text = "Ajouter Cours";
            this.ajouterCoursButton.Click += new System.EventHandler(this.ajouterCours);
        }

        private System.Windows.Forms.DataGridView ueGridView;
        private System.Windows.Forms.DataGridView ecGridView;
        private System.Windows.Forms.DataGridView ecDetailsGridView;
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
        private System.Windows.Forms.Button supprimerUEButton;
        private System.Windows.Forms.Button modifierUEButton;
        private System.Windows.Forms.Button ajouterUEButton;
        private System.Windows.Forms.Button supprimerEcButton;
        private System.Windows.Forms.Button modifierEcButton;
        private System.Windows.Forms.Button ajouterEcButton;
        private System.Windows.Forms.Button supprimerCoursButton;
        private System.Windows.Forms.Button modifierCoursButton;
        private System.Windows.Forms.Button ajouterCoursButton;
    }
}
