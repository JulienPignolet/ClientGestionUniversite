using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.modele
{
    public class Ratio
    {
        public TypeCours typeCours { get; set; }

        public CategoriePersonnel categoriePersonnel{ get; set; }

        public int ratio { get; set; }

        public Ratio(TypeCours type, CategoriePersonnel categorie)
        {
            this.typeCours = type;
            this.categoriePersonnel = categorie;
        }

        public Ratio()
        {

        }

        public override String ToString()
        {
            return "Ratio " + " TypeCours : " + typeCours + " de la categorie de personnel : " + categoriePersonnel.libelle + ")";
        }


    }
}
