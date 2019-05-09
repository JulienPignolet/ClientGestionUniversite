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

        public String nom { get; set; }

        public String prenom { get; set; }

        public CategoriePersonnel categoriePersonnel { get; set; }

        public String text
        {
            get { return prenom + " - " + nom + " - " + categoriePersonnel.libelle; }
        }

        public Personnel()
        {

        }

        public Personnel(String nom, String prenom, CategoriePersonnel categoriePersonnel)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.categoriePersonnel = categoriePersonnel;
        }

        public override String ToString()
        {
            return "Personnel (id : " + id + " nom : " + nom + " prenom : " + prenom + ")";
        }
    }
}

