using ClientGestionUniversite.businessLogic;
using ClientGestionUniversite.modele;
using ClientGestionUniversite.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ClientGestionUniversite.viewModel
{
    public class PersonnelViewModel : INotifyPropertyChanged
    {
        private PersonnelView view;

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

        public PersonnelViewModel(PersonnelView view)
        {
            this.view = view;
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
            double volumeEff = p.getSommeHorraire();
            heureEff = volumeEff + " / " + p.categoriePersonnel.volumeHoraire;
            if (volumeEff > p.categoriePersonnel.volumeHoraire + 10 || volumeEff < p.categoriePersonnel.volumeHoraire - 10)
            {
                view.nbHeureEffValue.ForeColor = Color.Red;
            }
            else
            {
                view.nbHeureEffValue.ForeColor = Color.Green;
            }
            titre = p.categoriePersonnel.libelle;
        }
    }
}
