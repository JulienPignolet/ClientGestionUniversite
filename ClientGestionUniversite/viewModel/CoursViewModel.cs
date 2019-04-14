using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.viewModel
{
    public class CoursViewModel
    {
        public string Cours { get; set; }

        public string Type { get; set; }

        public int Heure { get; set; }

        public CoursViewModel(string lib, string type, int volume)
        {
            this.Cours = lib;
            this.Type = type;
            this.Heure = volume;
        }
    }
}
