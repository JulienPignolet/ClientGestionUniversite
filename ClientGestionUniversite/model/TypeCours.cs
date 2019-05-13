using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.modele
{
    public class TypeCours
    {
        public long id { get; set; }

        public String libelle { get; set; }

        public TypeCours()
        {

        }

        public TypeCours(String libelle)
        {
            this.libelle = libelle;
        }

        public override String ToString()
        {
            return libelle;
        }
    
    }
}
