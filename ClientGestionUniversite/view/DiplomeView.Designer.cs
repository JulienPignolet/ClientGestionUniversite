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
            this.filterPanel = new System.Windows.Forms.Panel();
            this.filterBox = new System.Windows.Forms.TextBox();
            this.filterLabel = new System.Windows.Forms.Label();
            this.editPanel = new System.Windows.Forms.Panel();
            this.supprimerUEButton = new System.Windows.Forms.Button();
            this.modifierUEButton = new System.Windows.Forms.Button();
            this.ajouterUEButton = new System.Windows.Forms.Button();
            this.supprimerAffectationButton = new System.Windows.Forms.Button();
            this.modifierAffectationButton = new System.Windows.Forms.Button();
            this.ajouterAffectationButton = new System.Windows.Forms.Button();
            this.filterPanel.SuspendLayout();
            this.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
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
            this.ueGridView.AllowUserToAddRows = false;
            this.ueGridView.AllowUserToDeleteRows = false;
            this.ueGridView.AllowUserToResizeColumns = false;
            this.ueGridView.AllowUserToResizeRows = false;
            this.ueGridView.MultiSelect = false;
            this.ueGridView.ReadOnly = true;
            this.ueGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.ueGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ueGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ueGridView_DataBindingComplete);
            ///
            /// ecGridView
            ///
            this.ecGridView.Dock = System.Windows.Forms.DockStyle.Left;
            ///
            /// ecDetailsGridView
            ///
            this.ecDetailsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            ///
            /// DiplomeView
            ///
            this.Controls.Add(this.ecGridView);
            this.Controls.Add(this.ecDetailsGridView);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.editPanel);
            this.tableLayoutPanel.ResumeLayout(false);
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
            this.editPanel.Controls.Add(this.supprimerAffectationButton);
            this.editPanel.Controls.Add(this.modifierAffectationButton);
            this.editPanel.Controls.Add(this.ajouterAffectationButton);
            this.editPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.editPanel.Location = new System.Drawing.Point(3, 62);
            this.editPanel.MaximumSize = new System.Drawing.Size(0, 35);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(194, 35);
            this.editPanel.TabIndex = 0;
            // 
            // supprimerPersonnelButton
            // 
            this.supprimerUEButton.AutoSize = true;
            this.supprimerUEButton.Location = new System.Drawing.Point(5, 5);
            this.supprimerUEButton.Name = "supprimerUEButton";
            this.supprimerUEButton.Size = new System.Drawing.Size(128, 23);
            this.supprimerUEButton.TabIndex = 0;
            this.supprimerUEButton.Text = "Supprimer cette UE";
            this.supprimerUEButton.Click += new System.EventHandler(this.supprimerPersonnel);
            // 
            // modifierPersonnelButton
            // 
            this.modifierUEButton.AutoSize = true;
            this.modifierUEButton.Location = new System.Drawing.Point(135, 5);
            this.modifierUEButton.Name = "modifierUEButton";
            this.modifierUEButton.Size = new System.Drawing.Size(118, 23);
            this.modifierUEButton.TabIndex = 1;
            this.modifierUEButton.Text = "Modifier cette UE";
            this.modifierUEButton.Click += new System.EventHandler(this.modifierPersonnel);
            // 
            // ajouterPersonnelButton
            // 
            this.ajouterUEButton.AutoSize = true;
            this.ajouterUEButton.Location = new System.Drawing.Point(255, 5);
            this.ajouterUEButton.Name = "ajouterUEButton";
            this.ajouterUEButton.Size = new System.Drawing.Size(114, 23);
            this.ajouterUEButton.TabIndex = 2;
            this.ajouterUEButton.Text = "Ajouter une UE";
            this.ajouterUEButton.Click += new System.EventHandler(this.ajouterPersonnel);
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
        }

        private System.Windows.Forms.DataGridView ueGridView;
        private System.Windows.Forms.DataGridView ecGridView;
        private System.Windows.Forms.DataGridView ecDetailsGridView;
        private System.Windows.Forms.TextBox filterBox;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.Panel filterPanel; 
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;

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
        private System.Windows.Forms.Button supprimerAffectationButton;
        private System.Windows.Forms.Button modifierAffectationButton;
        private System.Windows.Forms.Button ajouterAffectationButton; 
    }
}
