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

namespace ClientGestionUniversite
{
    public partial class InputModifECForm : Form
    {
        private bool input; // true = input / false = modif
        private ElementConstitutif elementModifie; // id du diplome actuellement modifié
        private UniteEnseignement ue;

        public InputModifECForm(String name, UniteEnseignement ue)
        {
            input = true;
            this.Text = name;
            this.ue = ue;
            InitializeComponent();
        }

        public InputModifECForm(String name, UniteEnseignement ue, ElementConstitutif e)
        {
            input = false;
            elementModifie = e;
            this.Text = name;
            this.ue = ue;
            InitializeComponent();
            this.nomBox.Text = e.libelle;
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
            ElementConstitutif ec = new ElementConstitutif(this.nomBox.Text, ue);

            Boolean elementConstitutifIncorrect = string.IsNullOrWhiteSpace(nomBox.Text);

            if (elementConstitutifIncorrect)
            {

                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "Erreur lors de la saisie des données \n";
                message += " le nom de l'élément constitutif est vide !";
                string caption = "Erreur";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Exclamation);

            }
            else
            {
                if (input)
                {
                    ElementConstitutifDAO.create(ec);
                }
                else
                {
                    ec.id = elementModifie.id;
                    ElementConstitutifDAO.update(ec);
                }
                this.Close();
            }
        }
    }
}
