using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.modele
{
    public class ElementConstitutif
    {
        public long id { get; set; }

        public String libelle { get; set; }

        public UniteEnseignement uniteEnseignement { get; set; }

        public ElementConstitutif()
        {

        }

        public ElementConstitutif(String libelle, UniteEnseignement uniteEnseignement)
        {
            this.libelle = libelle;
            this.uniteEnseignement = uniteEnseignement;
        }

        public override String ToString()
        {
            return  libelle ;
        }
    }
}
