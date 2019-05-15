using ClientGestionUniversite.businessLogic;
using ClientGestionUniversite.modele;
using ClientGestionUniversite.view;
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
    public partial class InputTypesCours : Form
    {

        private List<TypeCours> typesListe;

        public InputTypesCours()
        {
            InitializeComponent();
            upadateList();
        }

        private void upadateList()
        {
            this.listBox1.Items.Clear();
            typesListe = TypeCoursDAO.findAll();
            foreach (TypeCours type in typesListe)
            {
                this.listBox1.Items.Add(type);
            }
        }

        //Ajout
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                DiplomeView.afficherPopup("Le nom est vide");
            }
            else
            {
                TypeCours type = new TypeCours(textBox1.Text);
                TypeCoursDAO.create(type);
                upadateList();
                List<CategoriePersonnel> catList = CategoriePersonnelDAO.findAll();
                foreach (CategoriePersonnel cat in catList)
                {
                    Ratio r = new Ratio(type, cat);
                    r.ratio = 1;
                    RatioDAO.create(r);
                }
            }
        }

        //Delete
        private void button1_Click_1(object sender, EventArgs e)
        {
            TypeCours type = (TypeCours)listBox1.Items[listBox1.SelectedIndex];
            List<Cours> cours = CoursDAO.findAllCours();
            bool doDelete = true;
            foreach(Cours c in cours)
            {
                if(c.typeCours.id == type.id)
                {
                    MessageBox.Show("Au moins un cours est de ce type, veuillez le modifier avant la suppression",
                        "Note",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);
                    doDelete = false;
                    break;
                }
            }
            if(doDelete)
            {
                TypeCoursDAO.delete(type);
                upadateList();
            }
        }
    }
}
