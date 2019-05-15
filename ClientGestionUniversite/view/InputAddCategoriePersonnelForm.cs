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
    public partial class InputAddCategoriePersonnelForm : Form
    {
        public InputAddCategoriePersonnelForm()
        {
            InitializeComponent();
          
        }

        /// <summary>
        /// Evenement annuler
        /// </summary>
        private void annulerAction(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evenement valider / modifier
        /// </summary>
        private void validerAction(object sender, EventArgs e)
        {
            CategoriePersonnel categorie = new CategoriePersonnel();
            int volumeHoraire = 0;

            Boolean categorieIncorrect = String.IsNullOrWhiteSpace(categorietextBox.Text);
            Boolean volumeHoraireIncorrect = !Int32.TryParse(volumeTextBox.Text, out volumeHoraire);

            if (categorieIncorrect || volumeHoraireIncorrect)
            {

                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "Erreur lors de la saisie des données \n";
                message += volumeHoraireIncorrect ? " le volume horaire est incorrect" : "";
                message += categorieIncorrect ? " le nom de la categorie est incorrect" : "";

                DiplomeView.afficherPopup(message);

            }
            else
            {
                categorie.libelle = categorietextBox.Text;
                categorie.volumeHoraire = volumeHoraire;
                categorie = CategoriePersonnelDAO.create(categorie);

                if (categorie != null)
                {

                    foreach (TypeCours typeCours in TypeCoursDAO.findAll())
                    {
                        Ratio temp = new Ratio();
                        temp.ratio = 1;
                        temp.typeCours = typeCours;
                        temp.categoriePersonnel = categorie;
                        RatioDAO.create(temp);
                    }
                       
                    this.Close();                  
                }
               
            }
        }
    }
}
