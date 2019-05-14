using ClientGestionUniversite.businessLogic;
using ClientGestionUniversite.modele;
using ClientGestionUniversite.viewModel;
using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientGestionUniversite.view
{
    public partial class PersonnelView : TabPage
    {
        public PersonnelView()
        {
            InitializeComponent();
            personnelGridViewLoad();
        }

        /// <summary>
        /// Charge les données de la grille personnel
        /// </summary>
        private void personnelGridViewLoad()
        {
            BindingListView<Personnel> bindingSourcePersonnel = new BindingListView<Personnel>(PersonnelDAO.findAll());
            personnelGridView.DataSource = bindingSourcePersonnel;
        }

        /// <summary>
        /// Charge les données des affectations
        /// </summary>
        private void personnelDetailsGridViewLoad()
        {
            Personnel p = getCurrentPersonnel();
            if (p != null)
            {
                List<Cours> coursAll = CoursDAO.findByPersonnel(p.id);
                List<Cours> cours = new List<Cours>();
                foreach (Cours c in coursAll)
                {
                    cours.Add(c);
                }
                BindingListView<Cours> bindingSourcePersonnelDetails = new BindingListView<Cours>(cours);
                personnelDetailsGridView.DataSource = bindingSourcePersonnelDetails;
            }
        }

        /// <summary>
        /// Évènement fin de remplissage de la grille du personnel
        /// </summary>
        private void personnelGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            personnelGridView.Columns["id"].Visible = false;
            personnelGridView.Columns["categoriePersonnel"].Visible = false;
            personnelGridView.Columns["nom"].HeaderText = "Nom";
            personnelGridView.Columns["prenom"].HeaderText = "Prenom";
            personnelGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Évènement fin de remplissage de la grille affectation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void personnelDetailsGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            personnelDetailsGridView.Columns["id"].Visible = false;
            personnelDetailsGridView.Columns["text"].Visible = false;
            personnelDetailsGridView.Columns["elementConstitutif"].HeaderText = "Cours";
            personnelDetailsGridView.Columns["intervenant"].HeaderText = "Intervenant";
            personnelDetailsGridView.Columns["typeCours"].HeaderText = "Type de cours";
            personnelDetailsGridView.Columns["numeroGroupe"].HeaderText = "Groupe";
            personnelDetailsGridView.Columns["volumeHoraire"].HeaderText = "Volume Horaire";
            personnelDetailsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Évènement changement de sélection
        /// </summary>
        private void personnelGridView_SelectionChanged(object sender, EventArgs e)
        {
            Personnel p = getCurrentPersonnel();
            if (p != null)
            {
                personnelViewModel.update(p);
                personnelDetailsGridViewLoad();
            }
        }

        /// <summary>
        /// Personnel sélectionné
        /// </summary>
        /// <returns>personnel</returns>
        private Personnel getCurrentPersonnel()
        {
            if (personnelGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = personnelGridView.SelectedCells[0].RowIndex;
                Personnel personnel = ((ObjectView<Personnel>)personnelGridView.Rows[selectedRowIndex].DataBoundItem).Object;
                return personnel;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Affectation sélectionnée
        /// </summary>
        /// <returns>affectation</returns>
        private Cours getCurrentAffectation()
        {
            if (personnelDetailsGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = personnelDetailsGridView.SelectedCells[0].RowIndex;
                Cours cours = ((ObjectView<Cours>)personnelDetailsGridView.Rows[selectedRowIndex].DataBoundItem).Object;
                return cours;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Application du filtre
        /// </summary>
        private void filterBox_TextChanged(object sender, EventArgs e)
        {
            ((BindingListView<Personnel>)personnelGridView.DataSource).ApplyFilter(
                delegate(Personnel personnel)
                {
                    return personnel.nom.ToLower().Contains(filterBox.Text.ToLower())
                        || personnel.prenom.ToLower().Contains(filterBox.Text.ToLower());
                });
        }

        /// <summary>
        /// Supression d'un personnel
        /// </summary>
        private void supprimerPersonnel(object sender, EventArgs e)
        {
            Personnel p = getCurrentPersonnel();
            if (p != null)
            {
                PersonnelDAO.delete(p);
                personnelGridViewLoad();
            }
        }

        /// <summary>
        /// Suppression d'une affectation
        /// </summary>
        private void supprimerAffectation(object sender, EventArgs e)
        {
            Cours cppvm = getCurrentAffectation();
            Personnel p = getCurrentPersonnel();
            if (cppvm != null && p != null)
            {
                CoursDAO.updateIntervenant(null, cppvm.id);
                personnelDetailsGridViewLoad();
            }
            personnelViewModel.update(p);
        }

        /// <summary>
        /// Modification d'un personnel
        /// </summary>
        private void modifierPersonnel(object sender, EventArgs e)
        {
            Personnel p = getCurrentPersonnel();
            if (p != null)
            {
                var formPopup = new InputModifPersonnelForm("Modifier Personnel", p);
                formPopup.ShowDialog(this);
                personnelGridViewLoad();

            }
        }

        /// <summary>
        /// Modification d'une affectation
        /// </summary>
        private void modifierAffectation(object sender, EventArgs e)
        {
            Cours cours = getCurrentAffectation();
            Personnel p = getCurrentPersonnel();
            if (cours != null && p != null)
            {
                var formPopup = new InputModifCoursParPersonnelForm("Modifier Affectation", cours, p);
                formPopup.ShowDialog(this);
                personnelDetailsGridViewLoad();
                personnelViewModel.update(p);
            }
        }

        /// <summary>
        /// Ajouter un personnel
        /// </summary>
        private void ajouterPersonnel(object sender, EventArgs e)
        {
            var formPopup = new InputModifPersonnelForm("Nouveau Personnel");
            formPopup.ShowDialog(this);
            personnelGridViewLoad();
        }

        /// <summary>
        /// Ajouter une affectation
        /// </summary>
        private void ajouterAffectation(object sender, EventArgs e)
        {
            Personnel p = getCurrentPersonnel();
            if (p != null)
            {
                var formPopup = new InputModifCoursParPersonnelForm("Ajouter Affectation", p);
                try
                {
                    formPopup.ShowDialog(this);
                }
                catch (Exception ignored) { }
                personnelDetailsGridViewLoad();
                personnelViewModel.update(p);
            }
        }
    }
}
