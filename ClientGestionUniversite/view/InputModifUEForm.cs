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
        private Diplome diplome;

        public InputModifUEForm(string name, Diplome diplome)
        {
            input = true;
            this.Text = name;
            this.diplome = diplome;
            InitializeComponent();
            load();
        }

        public InputModifUEForm(string name, UniteEnseignement ue, Diplome diplome) : this(name, diplome)
        {
            input = false;
            modifId = ue.id;
            periodeID = ue.periode.id;
            anneeID = ue.periode.annee.id;
            this.nomBox.Text = ue.libelle;
            this.periodeComboBox.SelectedValue = ue.periode;

            //this.periodeComboBox.Text = ue.periode.libelle.ToString();
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
         
            Periode p = (Periode)periodeComboBox.SelectedItem;

            UniteEnseignement ue = new UniteEnseignement(nomBox.Text, p);
            if (input)
            {
                UniteEnseignementDAO.create(ue);
            }
            else
            {
                ue.id = modifId;
                //p.id = periodeID;
                
                UniteEnseignementDAO.update(ue);
            }
            this.Close();
        }

        private void load()
        {
            List<Periode> periode = PeriodeDAO.findAll();
            foreach (Periode p in periode)
            {
                if(p.annee.diplome.id == diplome.id)
                    this.periodeComboBox.Items.Add(p);
            }
            if (this.periodeComboBox.Items.Count > 0)
                this.periodeComboBox.SelectedIndex = 0;

            /*
            List<Annee> annee = AnneeDAO.findAll();
            foreach (Annee cp in annee)
            {
                this.anneeComboBox.Items.Add(cp);
            }
            if(this.anneeComboBox.Items.Count > 0)
                this.anneeComboBox.SelectedIndex = 0;
             */
        }
    }
}
