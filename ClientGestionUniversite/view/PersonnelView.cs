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
        /// Évènement fin de remplissage de la grille du personnel
        /// </summary>
        private void personnelGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            personnelGridView.Columns["id"].Visible = false;
            personnelGridView.Columns["categoriePersonnel"].Visible = false;
            personnelGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Évènement fin de remplissage de la grille affectation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void personnelDetailsGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
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
                BindingListView<CoursViewModel> bindingSourcePersonnelDetails = new BindingListView<CoursViewModel>(CoursDAO.findAll());
                personnelDetailsGridView.DataSource = bindingSourcePersonnelDetails;
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
        /// Application du filtre
        /// </summary>
        private void filterBox_TextChanged(object sender, EventArgs e)
        {
            ((BindingListView<Personnel>)personnelGridView.DataSource).ApplyFilter(
                delegate(Personnel personnel) { return personnel.Nom.ToLower().Contains(filterBox.Text.ToLower()) 
                    || personnel.Prenom.ToLower().Contains(filterBox.Text.ToLower()); });
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

        }

        /// <summary>
        /// Ajouter un personnel
        /// </summary>
        private void ajouterPersonnel(object sender, EventArgs e)
        {
            var formPopup = new InputModifPersonnelForm("Nouveau Personnel");
            formPopup.ShowDialog(this);
            personnelGridViewLoad();
            personnelGridView.Refresh();
        }

        /// <summary>
        /// Ajouter une affectation
        /// </summary>
        private void ajouterAffectation(object sender, EventArgs e)
        {

        }
    }
}
