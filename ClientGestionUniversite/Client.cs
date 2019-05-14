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
        private ModifDiplomeView mdv;

        public Client()
        {
            InitializeComponent();
            diplomeViewLoad();
            edit = false;
            switchEdition(null, null);
            mdv = new ModifDiplomeView();
            tabControl1.Controls.Add(mdv);
            this.MinimumSize = new Size(900, 500);
        }

        /// <summary>
        /// Changement mode edition
        /// </summary>
        private void switchEdition(object sender, EventArgs e)
        {
            edit = !edit;
            editionMode.Text = (edit) ? ("Désactiver l'édition") : ("Activer l'édition");
            ajouterDiplome.Visible = edit;
            modifierDiplome.Visible = edit;
            supprimerDiplome.Visible = edit;
            personnelView.editPanel.Visible = edit;
            foreach(DiplomeView dv in diplomesView)
                dv.editPanel.Visible = edit;
        }

        /// <summary>
        /// Charge les diplomes
        /// </summary>
        private void diplomeViewLoad()
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
            if (this.tabControl1.SelectedIndex == 1)
            {
                this.statistiquesView.updateCharts();
            }
        }

    }
}
