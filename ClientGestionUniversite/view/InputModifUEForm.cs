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
        private UniteEnseignement ueModifie;// ue actuellement modifié
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
            ueModifie = ue;
            this.nomBox.Text = ue.libelle;
            this.periodeComboBox.SelectedValue = ue.periode;
            load();
           
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

            Boolean nomVide = string.IsNullOrWhiteSpace(nomBox.Text);
            Boolean periodeIncorrect = p == null;
            if (nomVide || periodeIncorrect)
            {

                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "Erreur lors de la saisie des données \n";
                message += nomVide ? " le nom est vide" : "";
                message += periodeIncorrect ? " la période est incorrecte" : "";
                DiplomeView.afficherPopup(message);

            }
            else
            {
                UniteEnseignement ue = new UniteEnseignement(nomBox.Text, p);
                if (input)
                {
                    UniteEnseignementDAO.create(ue);
                }
                else
                {
                    ue.id = ueModifie.id;
                    UniteEnseignementDAO.update(ue);
                }
                this.Close();
            }
        }

        private void load()
        {
            this.periodeComboBox.Items.Clear();
            List<Periode> periode = PeriodeDAO.findAll();
            foreach (Periode p in periode)
            {
                if(p.annee.diplome.id == diplome.id)
                    this.periodeComboBox.Items.Add(p);
            }
           // si modification on remet la bonne periode
            if (ueModifie != null && ueModifie.periode != null)
            {
                int indice=0;

                for(int i =0; i < periodeComboBox.Items.Count; i++ ){
                    if (((Periode)periodeComboBox.Items[i]).id == ueModifie.periode.id)
                    {
                        indice = i;
                    }            
                }
                this.periodeComboBox.SelectedIndex = indice;
            }

        }
    }
}
