using ClientGestionUniversite.businessLogic;
using ClientGestionUniversite.modele;
using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientGestionUniversite;

namespace ClientGestionUniversite.view
{
    public partial class InputModifCategoriPersonel : Form
    {
        CategoriePersonnel categorie = null;

        public InputModifCategoriPersonel()
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
            categorie = (CategoriePersonnel)categorieCB.SelectedItem;
            List<TypeCours> tcs = TypeCoursDAO.findAll();
            if (categorie != null)
            {

                foreach (TypeCours tc in tcs)
                {
                    Ratio r = new Ratio(tc, categorie);
                    if (tc.libelle == "CM")
                    {
                        valueCMTB.Text = (categorie.volumeHoraire * r.ratio).ToString();
                    }

                    if (tc.libelle == "TP\r\n")
                    {
                        valueTPTB.Text = (categorie.volumeHoraire * r.ratio).ToString();
                    }

                    if (tc.libelle == "TD")
                    {
                        valueTDTB.Text = (categorie.volumeHoraire * r.ratio).ToString();
                    }
                }
                
                
                
            }
        }

        private void valueCMTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void valueTDTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void valueTPTB_TextChanged(object sender, EventArgs e)
        {

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
            /*Annee a = new Annee(this.nomBox.Text, d);
            if (input)
            {
                AnneeDAO.create(a);
            }
            else
            {
                a.id = modifId;
                AnneeDAO.update(a);
            }*/
            categorie = (CategoriePersonnel)categorieCB.SelectedItem;
            List<TypeCours> tcs = TypeCoursDAO.findAll();
            if (categorie != null)
            {

                foreach (TypeCours tc in tcs)
                {
                    Ratio r = new Ratio(tc, categorie);
                    if (tc.libelle == "CM")
                    {
                        r.ratio = Int32.Parse(valueCMTB.Text);
                    }

                    if (tc.libelle == "TP\r\n")
                    {
                        r.ratio = Int32.Parse(valueTPTB.Text);
                    }

                    if (tc.libelle == "TD")
                    {
                        r.ratio = Int32.Parse(valueTDTB.Text);
                    }
                    RatioDAO.update(r);
                }



            }
            this.Close();
        }
    }
}
