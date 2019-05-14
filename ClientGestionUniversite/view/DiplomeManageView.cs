using ClientGestionUniversite.businessLogic;
using ClientGestionUniversite.modele;
using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGestionUniversite.view
{
    public partial class DiplomeManageView : TabPage
    {
        private Client client;
        public DiplomeManageView(Client c)
        {
            client = c;
            InitializeComponent();
            diplomeGridViewLoad();
            anneeGridViewLoad();
            periodeGridViewLoad();
        }

        /// <summary>
        /// Charge les données de la grille Diplome
        /// </summary>
        private void diplomeGridViewLoad()
        {
            List<Diplome> allDip = DiplomeDAO.findAll();
            BindingListView<Diplome> bindingSourceUe = new BindingListView<Diplome>(allDip);
            diplomeGridView.DataSource = bindingSourceUe;
            anneeGridViewLoad();
            periodeGridViewLoad();
            client.diplomeViewLoad();
        }

        /// <summary>
        /// Évènement fin de remplissage de la grille Diplome
        /// </summary>
        private void diplomeGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            diplomeGridView.Columns["id"].Visible = false;
            diplomeGridView.Columns["libelle"].HeaderText = "Diplome";
            diplomeGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Évènement changement de sélection diplome
        /// </summary>
        private void diplomeGridView_SelectionChanged(object sender, EventArgs e)
        {
            Diplome d = getCurrentDiplome();
            if (d != null)
            {
                anneeGridViewLoad();
            }
        }

        /// <summary>
        /// Diplome sélectionnée
        /// </summary>
        /// <returns>ue</returns>
        private Diplome getCurrentDiplome()
        {
            if (diplomeGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = diplomeGridView.SelectedCells[0].RowIndex;
                Diplome d = ((ObjectView<Diplome>)diplomeGridView.Rows[selectedRowIndex].DataBoundItem).Object;
                return d;
            }
            else
            {
                return null;
            }
        }

        /////////
        /////////
        /////////

        /// <summary>
        /// Charge les données de la grille Diplome
        /// </summary>
        private void anneeGridViewLoad()
        {
            List<Annee> allAnnee = AnneeDAO.findAll();
            List<Annee> annee = new List<Annee>();
            foreach (Annee tempA in allAnnee)
            {
                if (getCurrentDiplome() != null && getCurrentDiplome().id == tempA.diplome.id)
                    annee.Add(tempA);
            }
            BindingListView<Annee> bindingSourceUe = new BindingListView<Annee>(annee);
            anneeGridView.DataSource = bindingSourceUe;
            periodeGridViewLoad();
        }

        /// <summary>
        /// Évènement fin de remplissage de la grille annee
        /// </summary>
        private void anneeGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            anneeGridView.Columns["id"].Visible = false;
            anneeGridView.Columns["diplome"].Visible = false;
            anneeGridView.Columns["libelle"].HeaderText = "Année";
            anneeGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Évènement changement de sélection diplome
        /// </summary>
        private void anneeGridView_SelectionChanged(object sender, EventArgs e)
        {
            Annee a = getCurrentAnnee();
            if (a != null)
            {
                periodeGridViewLoad();
            }
        }

        /// <summary>
        /// Année sélectionnée
        /// </summary>
        /// <returns>ue</returns>
        private Annee getCurrentAnnee()
        {
            if (anneeGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = anneeGridView.SelectedCells[0].RowIndex;
                Annee a = ((ObjectView<Annee>)anneeGridView.Rows[selectedRowIndex].DataBoundItem).Object;
                return a;
            }
            else
            {
                return null;
            }
        }

        /////////
        /////////
        /////////

        /// <summary>
        /// Charge les données de la grille periode
        /// </summary>
        private void periodeGridViewLoad()
        {
            List<Periode> allp = PeriodeDAO.findAll();
            List<Periode> p = new List<Periode>();
            foreach (Periode tempP in allp)
            {
                if (getCurrentAnnee() != null && getCurrentAnnee().id == tempP.annee.id)
                p.Add(tempP);
            }
            BindingListView<Periode> bindingSourceUe = new BindingListView<Periode>(p);
            periodeGridView.DataSource = bindingSourceUe;
        }

        /// <summary>
        /// Évènement fin de remplissage de la grille periode
        /// </summary>
        private void periodeGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            periodeGridView.Columns["id"].Visible = false;
            periodeGridView.Columns["text"].Visible = false;
            periodeGridView.Columns["annee"].Visible = false;
            periodeGridView.Columns["libelle"].HeaderText = "Période";
            periodeGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Évènement changement de sélection periode
        /// </summary>
        private void periodeGridView_SelectionChanged(object sender, EventArgs e)
        {
            Periode p = getCurrentPeriode();
            if (p != null)
            {
                //diplomeGridViewLoad();
            }
        }

        /// <summary>
        /// Periode sélectionnée
        /// </summary>
        /// <returns>ue</returns>
        private Periode getCurrentPeriode()
        {
            if (periodeGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = periodeGridView.SelectedCells[0].RowIndex;
                Periode p = ((ObjectView<Periode>)periodeGridView.Rows[selectedRowIndex].DataBoundItem).Object;
                return p;
            }
            else
            {
                return null;
            }
        }

        private void filterBox_TextChanged(object sender, EventArgs e)
        {
            ((BindingListView<Diplome>)diplomeGridView.DataSource).ApplyFilter(
                delegate(Diplome uevm)
                {
                    return uevm.libelle.ToLower().Contains(filterBox.Text);
                });
        }

        /// <summary>
        /// Supression d'un Diplome
        /// </summary>
        private void supprimerDiplome(object sender, EventArgs e)
        {
            Diplome d = getCurrentDiplome();
            if (d != null)
            {
                DiplomeDAO.delete(d);
                diplomeGridViewLoad();
            }
            else
            {
                DiplomeView.afficherPopup("Aucun diplome selectionnée");
            }
        }


        /// <summary>
        /// Modifier d'un Diplome
        /// </summary>
        private void modifierDiplome(object sender, EventArgs e)
        {
            Diplome d = getCurrentDiplome();
            if (d != null)
            {
                var formPopup = new InputModifDiplomeForm("Modifier Diplome", d);
                formPopup.ShowDialog(this);
                diplomeGridViewLoad();
            }
            else
            {
                DiplomeView.afficherPopup("Aucun diplome selectionnée");
            }
        }

        /// <summary>
        /// ajouter d'un Diplome
        /// </summary>
        private void ajouterDiplome(object sender, EventArgs e)
        {
            var formPopup = new InputModifDiplomeForm("Modifier Diplome");
            formPopup.ShowDialog(this);
            diplomeGridViewLoad();
            
        }

        /// <summary>
        /// Supression d'une annee
        /// </summary>
        private void supprimerAnnee(object sender, EventArgs e)
        {
            Annee a = getCurrentAnnee();
            if (a != null)
            {
                AnneeDAO.delete(a);
                anneeGridViewLoad();
            }
            else
            {
                DiplomeView.afficherPopup("Aucune année selectionnée");
            }
        }


        /// <summary>
        /// Modifier d'un annee
        /// </summary>
        private void modifierAnnee(object sender, EventArgs e)
        {
            Annee a = getCurrentAnnee();
            Diplome d = getCurrentDiplome();
            if (a != null && d!=null)
            {
                var formPopup = new InputModifAnneeForm("Modifier Annee", d, a);
                formPopup.ShowDialog(this);
                anneeGridViewLoad();
            }
            else
            {
                DiplomeView.afficherPopup("Aucune année selectionnée");
            }
        }

        /// <summary>
        /// ajouter d'un annee
        /// </summary>
        private void ajouterAnnee(object sender, EventArgs e)
        {
            Diplome d = getCurrentDiplome();
            if (d != null)
            {
                var formPopup = new InputModifAnneeForm("Ajouter Annee", d);
                formPopup.ShowDialog(this);
                anneeGridViewLoad();
            }
            else
            {
                DiplomeView.afficherPopup("Aucun diplome selectionnée");
            }
            

        }


        /// <summary>
        /// Supression d'un periode
        /// </summary>
        private void supprimerperiode(object sender, EventArgs e)
        {
            Periode p = getCurrentPeriode();
            if (p != null)
            {
                PeriodeDAO.delete(p);
                periodeGridViewLoad();
            }
            else
            {
                DiplomeView.afficherPopup("Aucune période selectionnée");
            }
        }


        /// <summary>
        /// Modifier d'un periode
        /// </summary>
        private void modifierPeriode(object sender, EventArgs e)
        {
            Periode p = getCurrentPeriode();
            Annee a = getCurrentAnnee();
            if (p != null && a!= null)
            {
                var formPopup = new InputModifPeriodeForm("Modifier Periode", a, p);
                formPopup.ShowDialog(this);
                periodeGridViewLoad();
            }
            else
            {
                DiplomeView.afficherPopup("Aucune période selectionnée");
            }
        }

        /// <summary>
        /// ajouter d'un periode
        /// </summary>
        private void ajouterPeriode(object sender, EventArgs e)
        {
            Annee a = getCurrentAnnee();
            if (a != null)
            {
                var formPopup = new InputModifPeriodeForm("Ajouter Periode", a);
                formPopup.ShowDialog(this);
                periodeGridViewLoad();
            }
            else
            {
                DiplomeView.afficherPopup("Aucune année selectionnée");
            }
            

        } 
    }
}
