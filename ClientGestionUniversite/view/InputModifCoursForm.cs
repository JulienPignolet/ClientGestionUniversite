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

        private long modifId;// id du cours actuellement modifié
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
            modifId = cours.id;
           
           // EC - Volume - Type de cours - Groupe s'il y en a un
            // Mais pas le prof -> optionnel
            this.groupeBox.Text = cours.numeroGroupe;
            this.volumeBox.Text = cours.volumeHoraire.ToString();

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

            Cours cours = new Cours(element, intervenant, typeCours, groupeBox.Text, System.Convert.ToInt32(volumeBox.Text));
            if (input)
            {
                CoursDAO.create(cours);
            }
            else
            {
                cours.id = modifId;
                if(cours.intervenant != null) CoursDAO.updateIntervenant(cours.intervenant.id, cours.id);
                CoursDAO.update(cours);
            }
            this.Close();
        }

        private void load()
        {
            List<ElementConstitutif> elementConstitutifs = ElementConstitutifDAO.findAll();
            foreach (ElementConstitutif e in elementConstitutifs)
            {
                if (e.uniteEnseignement.periode.annee.diplome.id == diplome.id)
                    this.elemConstitutifComboBox.Items.Add(e);
            }
            if (this.elemConstitutifComboBox.Items.Count > 0)
                this.elemConstitutifComboBox.SelectedIndex = 0;

            List<TypeCours> typeCours = TypeCoursDAO.findAll();
            foreach (TypeCours t in typeCours)
            {              
                    this.typeCoursBox.Items.Add(t);
            }
            if (this.typeCoursBox.Items.Count > 0)
                this.typeCoursBox.SelectedIndex = 0;

            List<Personnel> personnels = PersonnelDAO.findAll();
            foreach (Personnel p in personnels)
            {
                this.intervenantBox.Items.Add(p);
            }
        }

      
    }
}
