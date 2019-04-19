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
        private long modifId;// id du personnel actuellement modifié

        public InputModifUEForm(string name)
        {
            input = true;
            this.Text = name;
            InitializeComponent();
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
            /*Personnel p = new Personnel(this.nomBox.Text, this.prenomBox.Text, new CategoriePersonnel(Convert.ToInt64(((CategoriePersonnel)categorieComboBox.SelectedItem).id)));
            if (input)
            {
                PersonnelDAO.create(p);
            }
            else
            {
                p.id = modifId;
                PersonnelDAO.update(p);
            }
            this.Close();*/
        }
    }
}
