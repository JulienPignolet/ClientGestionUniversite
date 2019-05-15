using ClientGestionUniversite.businessLogic;
using ClientGestionUniversite.modele;
using ClientGestionUniversite.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGestionUniversite
{
    public partial class Client : Form
    {
        private bool edit;

        public Client()
        {
            InitializeComponent();
            diplomeViewLoad();
            edit = true;
            switchEdition(null, null);
            this.MinimumSize = new Size(1200, 600);
            //On charge une fois les statistiques car on arrive sur cette page
            this.statistiquesView.updateCharts();
        }

        /// <summary>
        /// Changement mode edition
        /// </summary>
        private void switchEdition(object sender, EventArgs e)
        {
            edit = !edit;
            editionMode.Text = (edit) ? ("Désactiver l'édition") : ("Activer l'édition");
            personnelView.editPanel.Visible = edit;
            if (edit)
            {
                this.mdv = new DiplomeManageView(this);
                this.tabControl1.Controls.Add(mdv);
                this.mdvIndex = this.mdv.TabIndex;
            }
            else
            {
                this.tabControl1.Controls.Remove(mdv);
            }
            foreach (DiplomeView dv in diplomesView)
                dv.editPanel.Visible = edit;
        }

        /// <summary>
        /// Charge les diplomes
        /// </summary>
        public void diplomeViewLoad()
        {
            if (diplomesView != null)
            {
                foreach (DiplomeView dv in diplomesView)
                {
                    tabControl1.Controls.Remove(dv);
                }
            }
            this.diplomesView = new System.Collections.Generic.List<view.DiplomeView>();
            int i = 1;
            foreach (Diplome d in DiplomeDAO.findAll())
            {
                DiplomeView dv = new DiplomeView(d);
                dv.Name = "diplomeView" + i;
                dv.Text = d.libelle;
                dv.Tag = d;
                dv.UseVisualStyleBackColor = true;
                diplomesView.Add(dv);
            }
            foreach (ClientGestionUniversite.view.DiplomeView dv in diplomesView)
            {
                this.tabControl1.Controls.Add(dv);
            }
            if(this.mdv != null)
                this.mdvIndex = tabControl1.TabPages.IndexOf(this.mdv);
        }

        /// <summary>
        /// Ajouter un diplome
        /// </summary>
        private void addDiplome(object sender, EventArgs e)
        {
            var formPopup = new InputModifDiplomeForm("Ajouter Diplome");
            formPopup.ShowDialog(this);
            diplomeViewLoad();
        }

        /// <summary>
        /// Modifier un diplome
        /// </summary>
        private void modDiplome(object sender, EventArgs e)
        {
            Diplome d = getCurrentDiplome();
            if (d != null)
            {
                var formPopup = new InputModifDiplomeForm("Modifier Diplome", d);
                formPopup.ShowDialog(this);
                diplomeViewLoad();
            }
        }

        /// <summary>
        /// Supprimer un diplome
        /// </summary>
        private void supDiplome(object sender, EventArgs e)
        {
            Diplome d = getCurrentDiplome();
            if (d != null)
            {
                DiplomeDAO.delete(d);
                diplomeViewLoad();
            }
        }

        /// <summary>
        /// Diplome sélectionnée
        /// </summary>
        /// <returns></returns>
        private Diplome getCurrentDiplome()
        {
            if (tabControl1.SelectedTab.Name.Contains("diplomeView"))
            {
                return (Diplome)tabControl1.SelectedTab.Tag;
            }
            else
            {
                return null;
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush br;
            if (e.Index == 0)
            {
                br = new SolidBrush(Color.FromArgb(255, 255, 234, 167));
            }
            else if (e.Index == 1)
            {
                br = new SolidBrush(Color.FromArgb(255, 129, 236, 236));
            } else if (e.Index == this.mdvIndex) {
                br = new SolidBrush(Color.FromArgb(255, 253, 121, 168));
            } else {
                br = new SolidBrush(Color.FromArgb(255, 162, 155, 254));
            }
            e.Graphics.FillRectangle(br, e.Bounds);
            SizeF sz = e.Graphics.MeasureString(tabControl1.TabPages[e.Index].Text, e.Font);
            e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2, e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2 + 1);

            Rectangle rect = e.Bounds;
            rect.Offset(0, 1);
            rect.Inflate(0, -1);
            e.Graphics.DrawRectangle(Pens.DarkGray, rect);
            e.DrawFocusRectangle();
        }

        private void updateStat(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                this.statistiquesView.updateCharts();
            }
            else if (this.tabControl1.SelectedIndex == 1)
            {
                this.personnelView.personnelGridViewLoad();
            }
        }
    }
}
