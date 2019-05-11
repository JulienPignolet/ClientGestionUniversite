using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.modele
{
    public class Annee
    {
        public long id {get; set;}
     
        public String libelle { get; set; }

        public Diplome diplome { get; set; }

        public Annee()
        {

        }

        public Annee(String libelle, Diplome diplome)
        {
            this.id = 0;
            this.libelle = libelle;
            this.diplome = diplome;
        }

        public override String ToString()
        {
            return "Annee (id : " + id + " libelle : " + libelle + " du diplome : "+ diplome.libelle + ")";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Annee);
        }


        public bool Equals(Annee other)
        {
            return other != null && id == other.id;
        }
        
    }
}
