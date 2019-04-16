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
            this.tableLayoutPanel.Controls.Add(this.ueGridView, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel1";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.34625F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.65375F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(200, 387);
            this.tableLayoutPanel.TabIndex = 0;
            ///
            /// ueGridView
            ///
            this.ueGridView.Dock = System.Windows.Forms.DockStyle.Fill;
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
            ((System.ComponentModel.ISupportInitialize)(this.ecGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ueGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ecDetailsGridView)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView ueGridView;
        private System.Windows.Forms.DataGridView ecGridView;
        private System.Windows.Forms.DataGridView ecDetailsGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    }
}
