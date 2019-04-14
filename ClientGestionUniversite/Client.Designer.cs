namespace ClientGestionUniversite
{
    partial class Client
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.editionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editionMode = new System.Windows.Forms.ToolStripMenuItem();
            this.personnelView = new ClientGestionUniversite.view.PersonnelView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editionMenu});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(790, 24);
            this.menu.TabIndex = 2;
            // 
            // editionMenu
            // 
            this.editionMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editionMode});
            this.editionMenu.Name = "editionMenu";
            this.editionMenu.Size = new System.Drawing.Size(56, 20);
            this.editionMenu.Text = "Edition";
            // 
            // editionMode
            // 
            this.editionMode.Name = "editionMode";
            this.editionMode.Size = new System.Drawing.Size(32, 19);
            this.editionMode.Text = "Activer l\'édition";
            this.editionMode.Click += new System.EventHandler(switchEdition);
            // 
            // personnelView
            // 
            this.personnelView.Name = "personnelView";
            this.personnelView.TabIndex = 0;
            this.personnelView.Text = "Personnel";
            this.personnelView.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.personnelView);
            foreach (ClientGestionUniversite.view.DiplomeView dv in diplomesView) {
                this.tabControl1.Controls.Add(dv);
            }
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(790, 434);
            this.tabControl1.TabIndex = 1;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 458);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menu);
            this.Name = "Client";
            this.Text = "Client";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem editionMenu;
        private System.Windows.Forms.ToolStripMenuItem editionMode;
        private ClientGestionUniversite.view.PersonnelView personnelView;
        private System.Collections.Generic.List<ClientGestionUniversite.view.DiplomeView> diplomesView;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

