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
            List<UniteEnseignement> ues = UniteEnseignementDAO.findAll();
            List<UeViewModel> uevm = new List<UeViewModel>();
            foreach (UniteEnseignement ue in ues)
            {
                if(d != null && d.id == ue.periode.annee.diplome.id)
                    uevm.Add(new UeViewModel(ue.id, ue.libelle, ue.periode.annee.libelle, ue.periode.libelle));
            }
            BindingListView<UeViewModel> bindingSourceUe = new BindingListView<UeViewModel>(uevm);
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
            List<Cours> cs = CoursDAO.findAllCours();
            List<CoursViewModel> cvm = new List<CoursViewModel>();
            foreach (Cours c in cs)
            {
                if(ec!= null && ec.id == c.elementConstitutif.id)
                    cvm.Add(new CoursViewModel(c.elementConstitutif, c.intervenant, c.typeCours, c.numeroGroupe, c.volumeHoraire));
            }
            BindingListView<CoursViewModel> bindingSourceCours = new BindingListView<CoursViewModel>(cvm);
            ecDetailsGridView.DataSource = bindingSourceCours;
        }

        /// <summary>
        /// Évènement changement de sélection
        /// </summary>
        private void ueGridView_SelectionChanged(object sender, EventArgs e)
        {
            UeViewModel uevm = getCurrentUe();
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
            CoursViewModel cvm = getCurrentCours();
            if (cvm != null)
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
        private CoursViewModel getCurrentCours()
        {
            if (ecDetailsGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = ecDetailsGridView.SelectedCells[0].RowIndex;
                CoursViewModel cvm = ((ObjectView<CoursViewModel>)ecDetailsGridView.Rows[selectedRowIndex].DataBoundItem).Object;
                return cvm;
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
            ((BindingListView<UeViewModel>)ueGridView.DataSource).ApplyFilter(
                delegate(UeViewModel uevm)
                {
                    return uevm.Nom.ToLower().Contains(filterBox.Text)
                        || uevm.Annee.ToLower().Contains(filterBox.Text)
                        || uevm.Periode.ToLower().Contains(filterBox.Text);
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

        }

        /// <summary>
        /// Modification d'un Cours
        /// </summary>
        private void modifierCours(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Ajouter un Cours
        /// </summary>
        private void ajouterCours(object sender, EventArgs e)
        {

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
                UeViewModel ueV = ((ObjectView<UeViewModel>)ueGridView.Rows[selectedRowIndex].DataBoundItem).Object;
                UniteEnseignement ue = new UniteEnseignement(ueV.Nom, new Periode(ueV.Nom, new Annee(ueV.Nom, new Diplome(ueV.Nom))));
                ue.id = ueV.id;
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
