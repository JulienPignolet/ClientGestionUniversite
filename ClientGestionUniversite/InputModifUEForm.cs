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
    public partial class InputModifUEForm : Form
    {
        private bool input; // true = input / false = modif
        private long modifId;// id du ue actuellement modifié
        private long periodeID;
        private long anneeID;

        public InputModifUEForm(string name)
        {
            input = true;
            this.Text = name;
            InitializeComponent();
        }

        public InputModifUEForm(string name, UniteEnseignement ue)
        {
            input = false;
            this.Text = name;
            InitializeComponent();
            modifId = ue.id;
            periodeID = ue.periode.id;
            anneeID = ue.periode.annee.id;
            this.nomBox.Text = ue.libelle;
            this.periodeComboBox.Text = ue.periode.libelle.ToString();
            this.anneeComboBox.Text = ue.periode.annee.libelle.ToString();
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
            Diplome d = new Diplome(nomBox.Text);
            Annee a = new Annee(nomBox.Text, d);
            
            //a.libelle = anneeComboBox.SelectedItem.ToString();
            Periode p = new Periode(nomBox.Text, a);
            //p.libelle = periodeComboBox.Text;

            UniteEnseignement ue = new UniteEnseignement(nomBox.Text, p);
            if (input)
            {
                UniteEnseignementDAO.create(ue);
            }
            else
            {
                ue.id = modifId;
                p.id = periodeID;
                a.id = anneeID;
                
                UniteEnseignementDAO.update(ue);
            }
            this.Close();
        }
    }
}
