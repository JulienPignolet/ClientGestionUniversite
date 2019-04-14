using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.modele
{
    public class Diplome
    {
        public long id {get; set;}
     
        public String libelle { get; set; }

        public Diplome()
        {

        }

        public Diplome(String libelle)
        {
            this.id = 0;
            this.libelle = libelle;
        }

        public override String ToString()
        {
            return "Diplome (id : " + id + " libelle : " + libelle + ")";
        }
    }
}
