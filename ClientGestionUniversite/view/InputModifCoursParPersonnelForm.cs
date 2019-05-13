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
        public InputModifCoursParPersonnelForm(string name, Cours cours, Personnel p)
        {
            input = false;
            personnelId = p.id;
            this.modifId = cours.id;
            this.modifCat = cours.typeCours.ToString();
            this.Text = name;
            InitializeComponent();
            loadCours();
            this.coursBox.Enabled = false;
            this.coursBox.Items.Add(cours);
            this.coursBox.SelectedValue = cours.id;
            this.heureBox.Text = cours.volumeHoraire.ToString();
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
                    Cours cppvm = c;
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
