using ClientGestionUniversite.businessLogic;
using ClientGestionUniversite.modele;
using ClientGestionUniversite.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGestionUniversite.view
{
    public partial class InputModifCoursParPersonnelForm : Form
    {
        private long personnelId; // personnel to add affectation
        private long modifId; // cours modifié
        private string modifCat; // catégorie modifiée
        private bool input;

        /// <summary>
        /// Constructeur de création
        /// </summary>
        /// <param name="name">nom de la fenetre</param>
        public InputModifCoursParPersonnelForm(string name, Personnel p)
        {
            input = true;
            personnelId = p.id;
            this.Text = name;
            InitializeComponent();
            loadCours();
        }

        /// <summary>
        /// Constructeur de modification
        /// </summary>
        /// <param name="name">nom de la fenetre</param>
        /// <param name="cppvm">affectation</param>
        public InputModifCoursParPersonnelForm(string name, CoursParPersonnelViewModel cppvm, Personnel p)
        {
            input = false;
            personnelId = p.id;
            this.modifId = cppvm.id;
            this.modifCat = cppvm.Type;
            this.Text = name;
            InitializeComponent();
            loadCours();
            this.coursBox.Enabled = false;
            this.coursBox.Items.Add(cppvm);
            this.coursBox.SelectedValue = cppvm.id;
            //this.heureBox.Text = cppvm.Heure + "" ;
            this.coursBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Evenement annuler
        /// </summary>
        private void annuler(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evenement valider / modifier
        /// </summary>
        private void valider(object sender, EventArgs e)
        {
            modifId = ((Cours)this.coursBox.SelectedItem).id;
            CoursDAO.updateIntervenant(personnelId, modifId);
            //CoursDAO.updateTypeCours(((TypeCours)this.typeBox.SelectedItem).id, modifId);
            //CoursDAO.updateVolumeHoraire(Convert.ToInt16(this.heureBox.Text), modifId);
            this.Close();
        }

        private void loadCours()
        {
            bool noCours = true;
            List<Cours> cours = CoursDAO.findAllCours();
            foreach (Cours c in cours)
            {
                if (c.intervenant == null)
                {
                    noCours = false;
                    CoursParPersonnelViewModel cppvm = new CoursParPersonnelViewModel(c.id, c.elementConstitutif.libelle, c.typeCours.libelle, c.volumeHoraire);
                    this.coursBox.Items.Add(c);
                }
            }
            if (noCours)
            {
                MessageBox.Show("Tous les cours sont déjà affectés");
                this.Close();
            }
            else
            {
                this.coursBox.SelectedIndex = 0;
            }
        }
    }
}
