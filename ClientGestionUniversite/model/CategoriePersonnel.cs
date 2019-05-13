using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.modele
{
    public class CategoriePersonnel
    {
        public long id { get; set; }

        public String libelle { get; set; }

        public int volumeHoraire { get; set; }

        public CategoriePersonnel()
        {

        }

        public CategoriePersonnel(long id)
        {
            this.id = id;
        }

        public CategoriePersonnel(String libelle, int volumeHoraire)
        {
            this.libelle = libelle;
            this.volumeHoraire = volumeHoraire;
        }

        public override String ToString()
        {
            return libelle;
        }
    }
    
}
