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
            this.filterPanel.SuspendLayout();
            this.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ecGridView)).BeginInit();
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
            this.tableLayoutPanel.ResumeLayout(false);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ecGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ueGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ecDetailsGridView)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView ueGridView;
        private System.Windows.Forms.DataGridView ecGridView;
        private System.Windows.Forms.DataGridView ecDetailsGridView;
        private System.Windows.Forms.TextBox filterBox;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.Panel filterPanel; 
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    }
}
