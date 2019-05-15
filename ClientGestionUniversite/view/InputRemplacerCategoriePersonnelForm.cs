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
    public partial class InputRemplacerCategoriePersonnelForm : Form
    {
        public InputRemplacerCategoriePersonnelForm()
        {
            InitializeComponent();
            List<CategoriePersonnel> categorieList = CategoriePersonnelDAO.findAll();
            foreach (CategoriePersonnel categ in categorieList)
            {
                this.categorieASupprimerCB.Items.Add(categ);
                this.categoriesCB.Items.Add(categ);
            }
        }

        /// <summary>
        /// Evenement annuler
        /// </summary>
        private void annuler(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evenement annuler
        /// </summary>
        private void valider(object sender, EventArgs e)
        {
            CategoriePersonnel categASupprimer = (CategoriePersonnel)this.categorieASupprimerCB.SelectedItem;
            CategoriePersonnel categRemplacement = (CategoriePersonnel)this.categoriesCB.SelectedItem;

            if (categASupprimer != null && categRemplacement != null)
            {
                List<Personnel> listePersonnel = PersonnelDAO.findAll();
                foreach (Personnel p in listePersonnel)
                {
                    if (p.categoriePersonnel.id == categASupprimer.id)
                    {
                        p.categoriePersonnel = categRemplacement;
                        PersonnelDAO.update(p);
                    }
                }
                CategoriePersonnelDAO.delete(categASupprimer);

                this.Close();
            }
            else
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "Erreur lors de la saisie des données, il faut choisir une catégorie de personnel \n";
                DiplomeView.afficherPopup(message);
            }
            
        }

    }
}
