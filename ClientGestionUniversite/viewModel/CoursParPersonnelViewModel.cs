using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.viewModel
{
    public class CoursParPersonnelViewModel
    {
        public long id { get; set; }

        public string Cours { get; set; }

        public string Type { get; set; }

        public int Heure { get; set; }

        public CoursParPersonnelViewModel(long id, string lib, string type, int volume)
        {
            this.id = id;
            this.Cours = lib;
            this.Type = type;
            this.Heure = volume;
        }
    }
}
