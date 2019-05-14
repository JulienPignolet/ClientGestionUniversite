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
    public partial class InputModifPeriodeForm : Form
    {
        private bool input; // true = input / false = modif
        private long modifId; // id du diplome actuellement modifié
        private Annee a;

        public InputModifPeriodeForm(String name, Annee a)
        {
            input = true;
            this.Text = name;
            this.a = a;
            InitializeComponent();
        }

        public InputModifPeriodeForm(String name, Annee a, Periode p)
        {
            input = false;
            this.Text = name;
            this.modifId = p.id;
            this.a = a;
            InitializeComponent();
            this.nomBox.Text = p.libelle;
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
                DiplomeView.afficherPopup("Le nom de la période est vide");
            }
            else
            {
                Periode p = new Periode(this.nomBox.Text, a);
                if (input)
                {
                    PeriodeDAO.create(p);
                }
                else
                {
                    p.id = modifId;
                    PeriodeDAO.update(p);
                }
                this.Close();
            }
        }
    }
}
