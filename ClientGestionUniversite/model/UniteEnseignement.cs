using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.modele
{
    public class UniteEnseignement
    {
        public long id { get; set; }

        public String libelle { get; set; }

        public Periode periode { get; set; }

        public UniteEnseignement()
        {

        }

        public UniteEnseignement(String libelle, Periode periode)
        {
            this.libelle = libelle;
            this.periode = periode;
        }

        public override String ToString()
        {
            return libelle;
        }
    }
    
}
