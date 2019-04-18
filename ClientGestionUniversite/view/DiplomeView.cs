using ClientGestionUniversite.businessLogic;
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
        public DiplomeView()
        {
            InitializeComponent();
            ueGridViewLoad();
        }

        /// <summary>
        /// Charge les données de la grille ue
        /// </summary>
        private void ueGridViewLoad()
        {
            List<UniteEnseignement> ues = UniteEnseignementDAO.findAll();
            List<UeViewModel> uevm = new List<UeViewModel>();
            foreach (UniteEnseignement ue in ues)
            {
                uevm.Add(new UeViewModel(ue.id, ue.libelle, ue.periode.annee.libelle, ue.periode.libelle));
            }
            BindingListView<UeViewModel> bindingSourceUe = new BindingListView<UeViewModel>(uevm);
            ueGridView.DataSource = bindingSourceUe;
        }

        /// <summary>
        /// Évènement changement de sélection
        /// </summary>
        private void ueGridView_SelectionChanged(object sender, EventArgs e)
        {
            UeViewModel uevm = getCurrentUe();
            if (uevm != null)
            {

            }
        }

        /// <summary>
        /// UE sélectionnée
        /// </summary>
        /// <returns>ue</returns>
        private UeViewModel getCurrentUe()
        {
            if (ueGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = ueGridView.SelectedCells[0].RowIndex;
                UeViewModel uevm = ((ObjectView<UeViewModel>)ueGridView.Rows[selectedRowIndex].DataBoundItem).Object;
                return uevm;
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

        private void filterBox_TextChanged(object sender, EventArgs e)
        {
            ((BindingListView<UeViewModel>)ueGridView.DataSource).ApplyFilter(
                delegate(UeViewModel uevm) { return uevm.Nom.ToLower().Contains(filterBox.Text) 
                    || uevm.Annee.ToLower().Contains(filterBox.Text) 
                    || uevm.Periode.ToLower().Contains(filterBox.Text); });
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
            /*var formPopup = new InputModifPersonnelForm("Nouveau Personnel");
            formPopup.ShowDialog(this);
            personnelGridViewLoad();
            personnelGridView.Refresh();*/
        }

        /// <summary>
        /// Suppression d'une affectation
        /// </summary>
        private void supprimerAffectation(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Modification d'une affectation
        /// </summary>
        private void modifierAffectation(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Ajouter une affectation
        /// </summary>
        private void ajouterAffectation(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Personnel sélectionné
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
    }
}
