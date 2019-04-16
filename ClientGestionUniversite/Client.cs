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
    public partial class Client : Form
    {
        private bool edit;

        public Client()
        {
            //
            // diplomesView
            //
            this.diplomesView = new System.Collections.Generic.List<view.DiplomeView>();
            int i = 1;
            foreach (Diplome d in DiplomeDAO.findAll())
            {
                DiplomeView dv = new DiplomeView();
                dv.Name = "diplomeView" + i;
                dv.Text = d.libelle;
                dv.UseVisualStyleBackColor = true;
                diplomesView.Add(dv);
            }
            InitializeComponent();
            edit = false;
            switchEdition(null, null);
        }

        /// <summary>
        /// Changement mode edition
        /// </summary>
        private void switchEdition(object sender, EventArgs e)
        {
            edit = !edit;
            editionMode.Text = (edit) ? ("Désactiver l'édition") : ("Activer l'édition");
            personnelView.editPanel.Visible = edit;
        }
    }
}
