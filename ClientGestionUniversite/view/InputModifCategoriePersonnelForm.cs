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
    public partial class InputModifCategoriePersonnelForm : Form
    {
        CategoriePersonnel categorie = null;
        TypeCours typeCours = null;
        Ratio ratioModif = null;

        public InputModifCategoriePersonnelForm()
        {
           
            InitializeComponent();
            initType();
        }

        private void initType()
        {
            List<CategoriePersonnel> allCP = CategoriePersonnelDAO.findAll();
            foreach (CategoriePersonnel cp in allCP)
            {
                categorieCB.Items.Add(cp);
            }
        }



        private void categorieCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = true;
            categorie = (CategoriePersonnel)categorieCB.SelectedItem;
            List<TypeCours> tcs = TypeCoursDAO.findAll();

            List<Ratio> listeRatio = RatioDAO.findAll();

            this.typeCoursComboBox.Items.Clear();
            this.volumeTextBox.Text = categorie.volumeHoraire.ToString();
            foreach (Ratio ratio in listeRatio)
            {
                if (ratio.categoriePersonnel.id == categorie.id)
                {
                    this.typeCoursComboBox.Items.Add(ratio.typeCours);
                }
            }
                        
             
        }

        private void typeCours_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeCours = (TypeCours)typeCoursComboBox.SelectedItem;
            List<Ratio> listeRatio = RatioDAO.findAll();
            ratioModif = listeRatio.Find(x => x.categoriePersonnel.id == categorie.id && x.typeCours.id == typeCours.id);
            this.ratioTextBox.Text = ratioModif.ratio.ToString();
           
        }

        /// <summary>
        /// Evenement annuler
        /// </summary>
        private void annulerAction(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evenement valider / modifier
        /// </summary>
        private void validerAction(object sender, EventArgs e)
        {
            categorie = (CategoriePersonnel)categorieCB.SelectedItem;
           
            if (categorie != null)
            {
                categorie.volumeHoraire = Int32.Parse(volumeTextBox.Text);
                CategoriePersonnelDAO.update(categorie);
            }
            if (ratioModif != null)
            {
                ratioModif.ratio = Convert.ToDouble(ratioTextBox.Text);
                RatioDAO.update(ratioModif);
            }
            this.Close();
        }
    }
}
