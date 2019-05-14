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
        private Cours modifCours; // cours modifié
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
            this.groupBox1.Enabled = false;
        }

        /// <summary>
        /// Constructeur de modification
        /// </summary>
        /// <param name="name">nom de la fenetre</param>
        /// <param name="cppvm">affectation</param>
        public InputModifCoursParPersonnelForm(string name, Cours cours, Personnel p)
        {
            modifCours = cours;
            input = false;
            personnelId = p.id;
            this.Text = name;
            InitializeComponent();
            loadCours();
            loadType();
            this.coursBox.Enabled = false;
            this.coursBox.Items.Add(cours);
            this.coursBox.SelectedValue = cours.id;
            this.heureBox.Text = cours.volumeHoraire.ToString();
            this.groupBox.Text = cours.numeroGroupe;
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
            int volumeHoraire = 0;
            TypeCours typeCours = (TypeCours)this.typeBox.SelectedItem;

            Boolean typeCoursIncorrect = typeCours == null;
            Boolean volumeHoraireIncorrect = !Int32.TryParse(this.heureBox.Text, out volumeHoraire);

            if (typeCoursIncorrect || volumeHoraireIncorrect)
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "Erreur lors de la saisie des données \n";
                message += volumeHoraireIncorrect ? " le volume horaire est incorrect" : "";
                message += typeCoursIncorrect ? " le type de cours est incorrect" : "";
                DiplomeView.afficherPopup(message);

            }
            else
            {
                modifCours.numeroGroupe = this.groupBox.Text;
                modifCours.typeCours.id = typeCours.id;
                if (input)
                {
                    CoursDAO.updateIntervenant(personnelId, ((Cours)this.coursBox.SelectedItem).id);
                }
                else
                {
                    CoursDAO.update(modifCours);
                }
                this.Close();
            }
        }

        private void loadType()
        {
            List<TypeCours> typeCours = TypeCoursDAO.findAll();
            foreach (TypeCours tc in typeCours)
            {
                this.typeBox.Items.Add(tc);
                if (tc.id == modifCours.typeCours.id)
                {
                    this.typeBox.SelectedItem = tc;
                }
            }
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
