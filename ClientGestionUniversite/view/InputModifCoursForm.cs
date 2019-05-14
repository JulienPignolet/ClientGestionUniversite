using ClientGestionUniversite.businessLogic;
using ClientGestionUniversite.modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGestionUniversite.view
{
    public partial class InputModifCoursForm : Form
    {
        private bool input; // true = input / false = modif

        private Cours coursModifie;// id du cours actuellement modifié
        private Diplome diplome;

        public InputModifCoursForm(String name, Diplome diplome)
        {
            input = true;
            this.Text = name;
            this.diplome = diplome;
            InitializeComponent();
            load();
        }

        public InputModifCoursForm(String name,Cours cours, Diplome diplome) : this(name, diplome)
        {
            input = false;
            coursModifie = cours;
           
           // EC - Volume - Type de cours - Groupe s'il y en a un
            // Mais pas le prof -> optionnel
            this.groupeBox.Text = cours.numeroGroupe;
            this.volumeBox.Text = cours.volumeHoraire.ToString();
            load();
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
            
            ElementConstitutif element = (ElementConstitutif)elemConstitutifComboBox.SelectedItem;
            Personnel intervenant = (Personnel)intervenantBox.SelectedItem;
            TypeCours typeCours = (TypeCours)typeCoursBox.SelectedItem;

            int volumeHoraire;

            Boolean elementIncorrect = element == null;
            Boolean typeCoursIncorrect = typeCours == null;
            Boolean volumeHoraireIncorrect = !Int32.TryParse(volumeBox.Text, out volumeHoraire);

            if (elementIncorrect || typeCoursIncorrect || volumeHoraireIncorrect)
            {

                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "Erreur lors de la saisie des données \n";
                message += elementIncorrect ? " l'élément constitutif est incorrect" : "";
                message += volumeHoraireIncorrect ? " le volume horaire est incorrect" : "";
                message += typeCoursIncorrect ? " le type de cours est incorrect" : "";
                string caption = "Erreur";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Exclamation);
                
            }
            else
            {
                Cours cours = new Cours(element, intervenant, typeCours, groupeBox.Text, System.Convert.ToInt32(volumeBox.Text));
                if (input)
                {
                    CoursDAO.create(cours);
                }
                else
                {
                    cours.id = coursModifie.id;
                    if (cours.intervenant != null) CoursDAO.updateIntervenant(cours.intervenant.id, cours.id);
                    CoursDAO.update(cours);
                }
                this.Close();
            }
        }

        private void load()
        {
            // selecteur liste element constitutif
            List<ElementConstitutif> elementConstitutifs = ElementConstitutifDAO.findAll();
            foreach (ElementConstitutif e in elementConstitutifs)
            {
                if (e.uniteEnseignement.periode.annee.diplome.id == diplome.id)
                    this.elemConstitutifComboBox.Items.Add(e);
            }
            // si modif on remet le bon element constitutif
            if (coursModifie != null && coursModifie.elementConstitutif != null)
            {
                this.elemConstitutifComboBox.SelectedIndex = elemConstitutifComboBox.FindStringExact(coursModifie.elementConstitutif.ToString());
            }

            // selecteur liste type cours
            List<TypeCours> typeCours = TypeCoursDAO.findAll();
            foreach (TypeCours t in typeCours) // filtre
            {              
                    this.typeCoursBox.Items.Add(t);
            }
            // si modif on remet le bon type cours
            if (coursModifie != null && coursModifie.typeCours != null)
            {
                this.typeCoursBox.SelectedIndex = typeCoursBox.FindStringExact(coursModifie.typeCours.libelle);
            }

            // selecteur liste personnel
            List<Personnel> personnels = PersonnelDAO.findAll();
            foreach (Personnel p in personnels)
            {
                this.intervenantBox.Items.Add(p);
            }
            if (coursModifie != null && coursModifie.intervenant != null)
            {
                this.intervenantBox.SelectedIndex = intervenantBox.FindStringExact(coursModifie.intervenant.ToString());
            }
        }

      
    }
}
