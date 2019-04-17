﻿using ClientGestionUniversite.businessLogic;
using ClientGestionUniversite.modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGestionUniversite.view
{
    public partial class InputModifPersonnelForm : Form
    {
        private bool input; // true = input / false = modif
        private long modifId;// id du personnel actuellement modifié

        /// <summary>
        /// Constructeur de création
        /// </summary>
        /// <param name="name">nom de la fenetre</param>
        public InputModifPersonnelForm(string name)
        {
            input = true;
            this.Text = name;
            InitializeComponent();
        }

        /// <summary>
        /// Constructeur de modification
        /// </summary>
        /// <param name="name">nom de la fenetre</param>
        /// <param name="p">personnel</param>
        public InputModifPersonnelForm(string name, Personnel p)
        {
            input = false;
            this.Text = name;
            InitializeComponent();
            this.nomBox.Text = p.nom;
            this.prenomBox.Text = p.prenom;
            this.categorieComboBox.SelectedValue = p.categoriePersonnel.id;
            this.modifId = p.id;
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
            Personnel p = new Personnel(this.nomBox.Text, this.prenomBox.Text, new CategoriePersonnel(Convert.ToInt64(((CategoriePersonnel)categorieComboBox.SelectedItem).id)));
            if (input)
            {
                PersonnelDAO.create(p);
            }
            else
            {
                p.id = modifId;
                PersonnelDAO.update(p);
            }
            this.Close();
        }
    }
}
