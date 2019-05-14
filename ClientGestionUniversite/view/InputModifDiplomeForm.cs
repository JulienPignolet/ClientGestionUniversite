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
    public partial class InputModifDiplomeForm : Form
    {
        private bool input; // true = input / false = modif
        private long modifId; // id du diplome actuellement modifié

        /// <summary>
        /// Constructeur de création
        /// </summary>
        /// <param name="name">nom de la fenetre</param>
        public InputModifDiplomeForm(string name)
        {
            input = true;
            this.Text = name;
            InitializeComponent();
        }

        /// <summary>
        /// Constructeur de modification
        /// </summary>
        /// <param name="name">nom de la fenetre</param>
        /// <param name="d">diplome a modifier</param>
        public InputModifDiplomeForm(string name, Diplome d)
        {
            input = false;
            this.Text = name;
            this.modifId = d.id;
            InitializeComponent();
            this.nomBox.Text = d.libelle;
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
            if (string.IsNullOrWhiteSpace(this.nomBox.Text))
            {
                DiplomeView.afficherPopup("Le nom du diplome est vide");
            }
            else
            {
                Diplome d = new Diplome(this.nomBox.Text);
                if (input)
                {
                    DiplomeDAO.create(d);
                }
                else
                {
                    d.id = modifId;
                    DiplomeDAO.update(d);
                }
                this.Close();
            }
        }
    }
}
