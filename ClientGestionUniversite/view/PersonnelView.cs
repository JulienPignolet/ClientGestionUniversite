using ClientGestionUniversite.businessLogic;
using ClientGestionUniversite.modele;
using ClientGestionUniversite.viewModel;
using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientGestionUniversite.view
{
    public partial class PersonnelView : TabPage
    {
        private bool color;

        public PersonnelView()
        {
            color = false;
            InitializeComponent();
            personnelGridViewLoad();
        }

        /// <summary>
        /// Charge les données de la grille personnel
        /// </summary>
        public void personnelGridViewLoad()
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
                BindingListView<Cours> bindingSourcePersonnelDetails = new BindingListView<Cours>(coursAll);
                personnelDetailsGridView.DataSource = bindingSourcePersonnelDetails;
            }
        }

        /// <summary>
        /// Evenement changement de datasource
        /// </summary>
        private void personnelGridView_DataSourceChanged(object sender, EventArgs e)
        {
            colorPersonnelGridView();
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
        /// Coloration de la grille du personnel si il y a une sur/sous affectation
        /// </summary>
        private void colorPersonnelGridView()
        {
            for (int i = 0; i < personnelGridView.Rows.Count; i++)
            {
                Personnel personnel = ((ObjectView<Personnel>)personnelGridView.Rows[i].DataBoundItem).Object;
                double sHoraire = personnel.getSommeHorraire();
                if (sHoraire > personnel.categoriePersonnel.volumeHoraire + 10
                    || sHoraire < personnel.categoriePersonnel.volumeHoraire - 10)
                {
                    personnelGridView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
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
            else
            {
                string message = "Aucun personnel sélectionné \n";
                string caption = "Erreur";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Exclamation);
                DiplomeView.afficherPopup(message);      
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
                personnelViewModel.update(p);
                personnelGridViewLoad();
            }
            else
            {
                string message = "Aucun personnel sélectionné \n";
                string caption = "Erreur";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Exclamation);
                DiplomeView.afficherPopup(message);  
            }

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
            else
            {
                string message = "Aucun personnel sélectionné \n";
                string caption = "Erreur";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Exclamation);
                DiplomeView.afficherPopup(message);                
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
                personnelGridViewLoad();
            }
            else
            {
                string message = "Aucun personnel ou aucun cours sélectionné \n";
                string caption = "Erreur";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Exclamation);
                DiplomeView.afficherPopup(message);         
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
                formPopup.ShowDialog(this);
               
                personnelDetailsGridViewLoad();
                personnelGridViewLoad();
                personnelViewModel.update(p);
            }
        }

        /// <summary>
        /// Modification d'une categorie
        /// </summary>
        private void modifCategorie(object sender, EventArgs e)
        {

            var formPopup = new InputModifCategoriePersonnelForm();
            formPopup.ShowDialog(this);
            personnelGridViewLoad();
        }

        /// <summary>
        /// ajout d'une categorie
        /// </summary>
        private void ajouterCategorie(object sender, EventArgs e)
        {
            var formPopup = new InputAddCategoriePersonnelForm();
            formPopup.ShowDialog(this);
            personnelGridViewLoad();
        }

        private void supprimerCategorie(object sender, EventArgs e)
        {
            /*
             * pop up pour remplacer une categorie par une autre
             * pop up avec 2 combobox
             * categorie a supprimer
             * categorie qui remplace
             * */
            var formPopup = new InputRemplacerCategoriePersonnelForm();
            formPopup.ShowDialog(this);
            personnelGridViewLoad();
        }
    }
}
