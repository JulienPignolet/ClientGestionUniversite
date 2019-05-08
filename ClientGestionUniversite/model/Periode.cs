using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.modele
{
    public class Periode
    {
        public long id { get; set; }

        public String libelle { get; set; }

        public Annee annee { get; set; }

        public String text
        {
            get { return annee.libelle + " - " + libelle; }
        }

        public Periode()
        {

        }

        public Periode(String libelle, Annee annee)
        {
            this.libelle = libelle;
            this.annee = annee;
        }

        public override String ToString()
        {
            return "Periode (id : " + id + " libelle : " + libelle + " de l'année : " +  annee.libelle +")";
        }
    }
}
