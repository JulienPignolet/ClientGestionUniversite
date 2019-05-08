using ClientGestionUniversite.modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.viewModel
{
    class CoursViewModel
    {
        public long id { get; set; }

        public ElementConstitutif elementConstitutif { get; set; }

        public Personnel intervenant { get; set; }

        public TypeCours typeCours { get; set; }

        public String numeroGroupe { get; set; }

        public int volumeHoraire { get; set; }

        public CoursViewModel(ElementConstitutif elementConstitutif, Personnel intervenant, TypeCours typeCours, String numeroGroupe, int volumeHoraire)
        {
            this.elementConstitutif = elementConstitutif;
            this.intervenant = intervenant;
            this.typeCours = typeCours;
            this.numeroGroupe = numeroGroupe;
            this.volumeHoraire = volumeHoraire;

        }
    }
}
