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
            InitializeComponent();
            edit = false;
            switchEdition(null, null);
        }

        private void switchEdition(object sender, EventArgs e)
        {
            edit = !edit;
            editionMode.Text = (edit) ? ("Désactiver l'édition") : ("Activer l'édition");
            personnelView.editPanel.Visible = edit;
        }
    }
}
