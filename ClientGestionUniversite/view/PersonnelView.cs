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
            BindingListView<Personnel> bindingSourcePersonnel = new BindingListView<Personnel>(PersonnelDAO.getAll());
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

        private void personnelDetailsGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            personnelDetailsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Évènement changement de sélection
        /// </summary>
        private void personnelGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (personnelGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = personnelGridView.SelectedCells[0].RowIndex;
                Personnel personnel = ((ObjectView<Personnel>)personnelGridView.Rows[selectedRowIndex].DataBoundItem).Object;
                personnelViewModel.update(personnel);
                BindingListView<CoursViewModel> bindingSourcePersonnelDetails = new BindingListView<CoursViewModel>(CoursDAO.getAll());
                personnelDetailsGridView.DataSource = bindingSourcePersonnelDetails;
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

        }

        /// <summary>
        /// Ajouter une affectation
        /// </summary>
        private void ajouterAffectation(object sender, EventArgs e)
        {

        }
    }
}
