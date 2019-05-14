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
    public partial class InputModifAnneeForm : Form
    {
        private bool input; // true = input / false = modif
        private long modifId; // id du diplome actuellement modifié
        private Diplome d;

        public InputModifAnneeForm(String name, Diplome d)
        {
            input = true;
            this.Text = name;
            this.d = d;
            InitializeComponent();
        }

        public InputModifAnneeForm(String name, Diplome d, Annee a)
        {
            input = false;
            this.Text = name;
            this.modifId = a.id;
            this.d = d;
            InitializeComponent();
            this.nomBox.Text = a.libelle;
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
            Annee a = new Annee(this.nomBox.Text, d);
            if (input)
            {
                AnneeDAO.create(a);
            }
            else
            {
                a.id = modifId;
                AnneeDAO.update(a);
            }
            this.Close();
        }
    }
}
