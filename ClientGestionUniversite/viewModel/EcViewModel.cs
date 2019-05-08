using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.viewModel
{
    class EcViewModel
    {
        public long id { get; set; }

        public String Nom { get; set; }

        public EcViewModel(long id, string nom)
        {
            this.id = id;
            this.Nom = nom;
        }
    }
}
