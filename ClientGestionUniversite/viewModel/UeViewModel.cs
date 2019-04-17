using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.viewModel
{
    public class UeViewModel
    {
        public long id { get; set; }

        public string Nom { get; set; }

        public string Annee { get; set; }

        public string Periode { get; set; }

        public UeViewModel(long id, string nom, string ann, string periode)
        {
            this.id = id;
            this.Nom = nom;
            this.Annee = ann;
            this.Periode = periode;
        }
    }
}
