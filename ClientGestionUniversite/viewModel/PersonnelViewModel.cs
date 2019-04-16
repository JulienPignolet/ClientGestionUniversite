using ClientGestionUniversite.modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ClientGestionUniversite.viewModel
{
    public class PersonnelViewModel : INotifyPropertyChanged
    {
        private string _nomPrenom;

        public string nomPrenom
        {
            get { return _nomPrenom; }
            set
            {
                _nomPrenom = value;
                OnPropertyChanged("nomPrenom");
            }
        }

        private string _titre;

        public string titre
        {
            get { return _titre; }
            set
            {
                _titre = value;
                OnPropertyChanged("titre");
            }
        }

        private string _heureEff;

        public string heureEff
        {
            get { return _heureEff; }
            set
            {
                _heureEff = value;
                OnPropertyChanged("heureEff");
            }
        }

        private void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Mise à jour des variables
        /// </summary>
        /// <param name="p">personnel</param>
        public void update(Personnel p)
        {
            nomPrenom = p.nom.ToUpper() + " " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.prenom.ToLower()) 
                + " ( " + p.id + " )";
            heureEff = "100 / " + p.categoriePersonnel.volumeHoraire;
            titre = p.categoriePersonnel.libelle;
        }
    }
}
