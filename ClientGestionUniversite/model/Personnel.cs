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
            return prenom + " - " + nom + " - " + categoriePersonnel.libelle; 
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

