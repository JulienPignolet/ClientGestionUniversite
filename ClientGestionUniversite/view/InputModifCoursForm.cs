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
        private ElementConstitutif elementConstitutif;

        public InputModifCoursForm(String name, ElementConstitutif element)
        {
            input = true;
            this.Text = name;
            this.elementConstitutif = element;
            InitializeComponent();
            load();
            groupeLabel.Text = "Nombre de groupe :*";
        }

        public InputModifCoursForm(String name, Cours cours, ElementConstitutif element): this(name, element)
        {
            input = false;
            coursModifie = cours;
           
           // EC - Volume - Type de cours - Groupe s'il y en a un
            // Mais pas le prof -> optionnel
            this.groupeBox.Text = cours.numeroGroupe;
            this.volumeBox.Text = cours.volumeHoraire.ToString();
            load();
            groupeLabel.Text = "Nom du groupe :*";
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
            
            Personnel intervenant = (Personnel)intervenantBox.SelectedItem;
            TypeCours typeCours = (TypeCours)typeCoursBox.SelectedItem;

            int volumeHoraire;

            Boolean typeCoursIncorrect = typeCours == null;
            Boolean volumeHoraireIncorrect = !Int32.TryParse(volumeBox.Text, out volumeHoraire);

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
                
                if (input)
                {
                    int nbGroupe = 0;
                    if (Int32.TryParse(groupeBox.Text, out nbGroupe))
                    {
                        List<Cours> cours = new List<Cours>();
                        for (int i = 0; i < nbGroupe; i++)
                            cours.Add(new Cours(elementConstitutif, intervenant, typeCours, typeCours.ToString() + (i + 1).ToString(), System.Convert.ToInt32(volumeBox.Text)));
                        foreach (Cours c in cours)
                            CoursDAO.create(c);
                    }
                    else
                    {
                        DiplomeView.afficherPopup("Nombre de groupe incorrect, un int est attendu");
                    }              
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(groupeBox.Text))
                    {
                        DiplomeView.afficherPopup("Nom du groupe incorrect");
                    }
                    else
                    {
                        Cours cours = new Cours(elementConstitutif, intervenant, typeCours, groupeBox.Text, System.Convert.ToInt32(volumeBox.Text));
                        cours.id = coursModifie.id;
                        if (cours.intervenant != null) CoursDAO.updateIntervenant(cours.intervenant.id, cours.id);
                        CoursDAO.update(cours);
                        this.Close();
                    }
                }
                this.Close();
            }
        }

        private void load()
        {
            this.typeCoursBox.Items.Clear();
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

            this.intervenantBox.Items.Clear();
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
