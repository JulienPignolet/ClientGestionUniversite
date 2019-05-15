using ClientGestionUniversite.businessLogic;
using ClientGestionUniversite.modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGestionUniversite.view
{
    public partial class InputModifPersonnelForm : Form
    {
        private bool input; // true = input / false = modif
        private long modifId;// id du personnel actuellement modifié
        private long modifCat; // categorie modifiée

        /// <summary>
        /// Constructeur de création
        /// </summary>
        /// <param name="name">nom de la fenetre</param>
        public InputModifPersonnelForm(string name)
        {
            input = true;
            this.Text = name;
            InitializeComponent();
            loadCategories();
        }

        /// <summary>
        /// Constructeur de modification
        /// </summary>
        /// <param name="name">nom de la fenetre</param>
        /// <param name="p">personnel</param>
        public InputModifPersonnelForm(string name, Personnel p)
        {
            input = false;
            this.modifCat = p.categoriePersonnel.id;
            this.Text = name;
            InitializeComponent();
            this.nomBox.Text = p.nom;
            this.prenomBox.Text = p.prenom;
            this.modifId = p.id;
            loadCategories();
        }

        private void loadCategories()
        {
            List<CategoriePersonnel> categories = CategoriePersonnelDAO.findAll();
            foreach (CategoriePersonnel cp in categories)
            {
                this.categorieComboBox.Items.Add(cp);
                if (cp.id == modifCat)
                {
                    this.categorieComboBox.SelectedItem = cp;
                }
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
        /// Evenement valider / modifier
        /// </summary>
        private void valider(object sender, EventArgs e)
        {
            CategoriePersonnel categorie = (CategoriePersonnel)categorieComboBox.SelectedItem;
            
            Boolean nomIncorrect = string.IsNullOrWhiteSpace(nomBox.Text);
            Boolean prenomIncorrect = string.IsNullOrWhiteSpace(prenomBox.Text);
            Boolean categorieIncorrecte = categorie == null;

            if (nomIncorrect || prenomIncorrect || categorieIncorrecte)
            {

                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "Erreur lors de la saisie des données \n";
                message += nomIncorrect ? " le nom est vide" : "";
                message += prenomIncorrect ? " le prenom est vide" : "";
                message += categorieIncorrecte ? " la categorie est incorrecte" : "";

                DiplomeView.afficherPopup(message);

            }
            else
            {
                Personnel p = new Personnel(this.nomBox.Text, this.prenomBox.Text,categorie);

                if (input)
                {
                    PersonnelDAO.create(p);
                }
                else
                {
                    p.id = modifId;
                    PersonnelDAO.update(p);
                }
                this.Close();
            }
        }
    }
}
