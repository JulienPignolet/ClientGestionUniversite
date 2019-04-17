using ClientGestionUniversite.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGestionUniversite.view
{
    public partial class InputModifCoursParPersonnelForm : Form
    {
        private bool input; // true = input / false = modif

        /// <summary>
        /// Constructeur de création
        /// </summary>
        /// <param name="name">nom de la fenetre</param>
        public InputModifCoursParPersonnelForm(string name)
        {
            input = true;
            this.Text = name;
            InitializeComponent();
        }

        /// <summary>
        /// Constructeur de modification
        /// </summary>
        /// <param name="name">nom de la fenetre</param>
        /// <param name="cppvm">affectation</param>
        public InputModifCoursParPersonnelForm(string name, CoursParPersonnelViewModel cppvm)
        {
            input = false;
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
            if (input)
            {

            }
            else
            {

            }
            this.Close();
        }
    }
}
