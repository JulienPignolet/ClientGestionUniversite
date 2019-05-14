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
            this.MinimumSize = new Size(900, 500);
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
                this.tabControl1.SelectedTab = mdv;
            }
            else
            {
                this.tabControl1.Controls.Remove(mdv);
            }
            foreach(DiplomeView dv in diplomesView)
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
        }

        /// <summary>
        /// Ajouter un diplome
        /// </summary>
        private void addDiplome(object sender, EventArgs e) {
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
            if (d != null) {
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

        private void updateStat(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                this.statistiquesView.updateCharts();
            }
        }

    }
}
