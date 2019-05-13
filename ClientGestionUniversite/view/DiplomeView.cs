﻿using ClientGestionUniversite.businessLogic;
using ClientGestionUniversite.modele;
using ClientGestionUniversite.viewModel;
using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGestionUniversite.view
{
    public partial class DiplomeView : TabPage
    {
        Diplome d;
        public DiplomeView(Diplome d)
        {
            this.d = d;
            InitializeComponent();
            ueGridViewLoad();
            ecGridViewLoad();
            ecDetailGridViewLoad();
        }

        /// <summary>
        /// Charge les données de la grille ue
        /// </summary>
        private void ueGridViewLoad()
        {
            List<UniteEnseignement> allUE = UniteEnseignementDAO.findAll();
            List<UniteEnseignement> ue = new List<UniteEnseignement>();
            foreach (UniteEnseignement tempUe in allUE)
            {
                if (d != null && d.id == tempUe.periode.annee.diplome.id)
                    ue.Add(tempUe);
            }
            BindingListView<UniteEnseignement> bindingSourceUe = new BindingListView<UniteEnseignement>(ue);
            ueGridView.DataSource = bindingSourceUe;
        }

        /// <summary>
        /// Charge les données de la grille ec
        /// </summary>
        private void ecGridViewLoad()
        {
            UniteEnseignement ue = getCurrentUE();
            List<ElementConstitutif> ecs = ElementConstitutifDAO.findAll();
            List<EcViewModel> ecvm = new List<EcViewModel>();
            foreach (ElementConstitutif ec in ecs)
            {
                if(ue != null && ue.id == ec.uniteEnseignement.id)
                    ecvm.Add(new EcViewModel(ec.id, ec.libelle));
            }
            BindingListView<EcViewModel> bindingSourceEc = new BindingListView<EcViewModel>(ecvm);
            ecGridView.DataSource = bindingSourceEc;
        }

        /// <summary>
        /// Charge les données de la grille ec
        /// </summary>
        private void ecDetailGridViewLoad()
        {
            ElementConstitutif ec = getCurrentEC();
            List<Cours> allCours = CoursDAO.findAllCours();
            List<Cours> cours = new List<Cours>();
            foreach (Cours c in allCours)
            {
                if (ec != null && ec.id == c.elementConstitutif.id) { 
                    cours.Add(c);
                }
            }
            BindingListView<Cours> bindingSourceCours = new BindingListView<Cours>(cours);
            ecDetailsGridView.DataSource = bindingSourceCours;
        }

        /// <summary>
        /// Évènement changement de sélection
        /// </summary>
        private void ueGridView_SelectionChanged(object sender, EventArgs e)
        {
            UniteEnseignement uevm = getCurrentUe();
            if (uevm != null)
            {
                ecGridViewLoad();
            }
        }

        /// <summary>
        /// Évènement changement de sélection
        /// </summary>
        private void ecGridView_SelectionChanged(object sender, EventArgs e)
        {
            EcViewModel ecvm = getCurrentEc();
            if (ecvm != null)
            {
                ecDetailGridViewLoad();
            }
        }

        /// <summary>
        /// Évènement changement de sélection
        /// </summary>
        private void ecDetailsGridView_SelectionChanged(object sender, EventArgs e)
        {
            Cours c = getCurrentCours();
            if (c != null)
            {

            }
        }

        /// <summary>
        /// UE sélectionnée
        /// </summary>
        /// <returns>ue</returns>
        private UniteEnseignement getCurrentUe()
        {
            if (ueGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = ueGridView.SelectedCells[0].RowIndex;
                UniteEnseignement ue = ((ObjectView<UniteEnseignement>)ueGridView.Rows[selectedRowIndex].DataBoundItem).Object;
                return ue;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// EC sélectionnée
        /// </summary>
        /// <returns>ue</returns>
        private EcViewModel getCurrentEc()
        {
            if (ecGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = ecGridView.SelectedCells[0].RowIndex;
                EcViewModel ecvm = ((ObjectView<EcViewModel>)ecGridView.Rows[selectedRowIndex].DataBoundItem).Object;
                return ecvm;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Cours sélectionnée
        /// </summary>
        /// <returns>ue</returns>
        private Cours getCurrentCours()
        {
            if (ecDetailsGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = ecDetailsGridView.SelectedCells[0].RowIndex;
                Cours selectedCours = ((ObjectView<Cours>)ecDetailsGridView.Rows[selectedRowIndex].DataBoundItem).Object;

                return selectedCours;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Évènement fin de remplissage de la grille ue
        /// </summary>
        private void ueGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ueGridView.Columns["id"].Visible = false;
            ueGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Évènement fin de remplissage de la grille ec
        /// </summary>
        private void ecGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ecGridView.Columns["id"].Visible = false;
            ecGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Évènement fin de remplissage de la grille ecDetails
        /// </summary>
        private void ecDetailsGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ecDetailsGridView.Columns["id"].Visible = false;
            ecDetailsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void filterBox_TextChanged(object sender, EventArgs e)
        {
            ((BindingListView<UniteEnseignement>)ueGridView.DataSource).ApplyFilter(
                delegate(UniteEnseignement uevm)
                {
                    return uevm.libelle.ToLower().Contains(filterBox.Text)
                        || uevm.periode.annee.ToString().ToLower().Contains(filterBox.Text)
                        || uevm.periode.ToString().ToLower().Contains(filterBox.Text);
                });
        }

        /// <summary>
        /// Supression d'un UE
        /// </summary>
        private void supprimerUE(object sender, EventArgs e)
        {
            UniteEnseignement p = getCurrentUE();
            if (p != null)
            {
                UniteEnseignementDAO.delete(p);
                ueGridViewLoad();
            }
        }

        /// <summary>
        /// Modification d'un UE
        /// </summary>
        private void modifierUE(object sender, EventArgs e)
        {
            UniteEnseignement ue = getCurrentUE();
            if (ue != null)
            {
                var formPopup = new InputModifUEForm("Modifier UE", ue, d);
                formPopup.ShowDialog(this);
                ueGridViewLoad();
            }

            /*Personnel p = getCurrentPersonnel();
            if (p != null)
            {
                var formPopup = new InputModifPersonnelForm("Modifier Personnel", p);
                formPopup.ShowDialog(this);
                personnelGridViewLoad();

            }*/
        }

        /// <summary>
        /// Ajouter un UE
        /// </summary>
        private void ajouterUE(object sender, EventArgs e)
        {
            var formPopup = new InputModifUEForm("Nouvelle UE", d);
            formPopup.ShowDialog(this);
            ueGridViewLoad();
        }

        /// <summary>
        /// Suppression d'une Ec
        /// </summary>
        private void supprimerEc(object sender, EventArgs e)
        {
            ElementConstitutif ec = getCurrentEC();
            if (ec != null)
            {
                ElementConstitutifDAO.delete(ec);
                ecGridViewLoad();
            }
        }

        /// <summary>
        /// Modification d'une Ec
        /// </summary>
        private void modifierEc(object sender, EventArgs e)
        {
            UniteEnseignement ue = getCurrentUE();
            ElementConstitutif ec = getCurrentEC();
            var formPopup = new InputModifECForm("Nouvel Ec", ue, ec);
            formPopup.ShowDialog(this);
            ecGridViewLoad();
        }

        /// <summary>
        /// Ajouter une Ec
        /// </summary>
        private void ajouterEc(object sender, EventArgs e)
        {
            UniteEnseignement ue = getCurrentUE();
            var formPopup = new InputModifECForm("Nouvel Ec", ue);
            formPopup.ShowDialog(this);
            ecGridViewLoad();
        }

        /// <summary>
        /// Suppression d'un Cours
        /// </summary>
        private void supprimerCours(object sender, EventArgs e)
        {
            Cours cours = getCurrentCours();
            if (cours != null)
            {
                CoursDAO.delete(cours);
                ecGridViewLoad();
            }
        }

        /// <summary>
        /// Modification d'un Cours
        /// </summary>
        private void modifierCours(object sender, EventArgs e)
        {
            Cours cours = getCurrentCours();
            if (cours != null)
            {
                var formPopup = new InputModifCoursForm("Modifier cours", cours, d);
                formPopup.ShowDialog(this);
                ueGridViewLoad();
            }
        }

        /// <summary>
        /// Ajouter un Cours
        /// </summary>
        private void ajouterCours(object sender, EventArgs e)
        {
            var formPopup = new InputModifCoursForm("Nouveau cours", d);
            formPopup.ShowDialog(this);
            ueGridViewLoad();
        }

        /// <summary>
        /// UE sélectionné
        /// </summary>
        /// <returns>personnel</returns>
        private UniteEnseignement getCurrentUE()
        {
            if (ueGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = ueGridView.SelectedCells[0].RowIndex;
                UniteEnseignement ue = ((ObjectView<UniteEnseignement>)ueGridView.Rows[selectedRowIndex].DataBoundItem).Object;
                return ue;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// EC sélectionné
        /// </summary>
        /// <returns>personnel</returns>
        private ElementConstitutif getCurrentEC()
        {
            if (ecGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = ecGridView.SelectedCells[0].RowIndex;
                EcViewModel ecV = ((ObjectView<EcViewModel>)ecGridView.Rows[selectedRowIndex].DataBoundItem).Object;
                ElementConstitutif ec = new ElementConstitutif(ecV.Nom, getCurrentUE());
                ec.id = ecV.id;
                return ec;
            }
            else
            {
                return null;
            }
        }
    }
}
