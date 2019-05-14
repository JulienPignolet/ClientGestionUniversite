using ClientGestionUniversite.businessLogic;
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

        public double getSommeHorraire()
        {
            List<Ratio> ratio = RatioDAO.findAll();
            List<Cours> cours = CoursDAO.findByPersonnel(this.id);

            double somme = 0;

            foreach(Cours c in cours)
            {
                Ratio r = ratio.Find(x => x.typeCours.id == c.typeCours.id);
                somme += r.ratio * c.volumeHoraire;
            }
            return Math.Round(somme, 2);
        }

        public override String ToString()
        {
            return prenom + " - " + nom + " - " + categoriePersonnel.libelle; 
        }
    }
}

