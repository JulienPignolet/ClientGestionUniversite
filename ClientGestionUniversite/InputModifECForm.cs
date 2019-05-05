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
        private long modifId; // id du diplome actuellement modifié
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
            modifId = e.id;
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
            if (input)
            {
                ElementConstitutifDAO.create(ec);
            }
            else
            {
                ec.id = modifId;
                ElementConstitutifDAO.update(ec);
            }
            this.Close();
        }
    }
}
