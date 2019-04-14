using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.modele
{
    public class Personnel
    {
        public long id { get; set; }

        public String Nom { get; set; }

        public String Prenom { get; set; }

        public CategoriePersonnel categoriePersonnel { get; set; }

        public Personnel()
        {

        }

        public Personnel(String nom, String prenom, CategoriePersonnel categoriePersonnel)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.categoriePersonnel = categoriePersonnel;
        }

        public override String ToString()
        {
            return "Personnel (id : " + id + " nom : " + Nom + " prenom : " + Prenom + ")";
        }
    }
}

