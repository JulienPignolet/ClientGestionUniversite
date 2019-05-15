using ClientGestionUniversite.businessLogic;
using ClientGestionUniversite.modele;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ClientGestionUniversite.view
{
    public partial class StatistiquesView :TabPage
    {
        private List<Cours> cours;
        private List<Personnel> personnes;

        public StatistiquesView()
        {
            InitializeComponent();
        }

        public void updateCharts()
        {
            //Requête des cours
            cours = CoursDAO.findAllCours();
            //Vide les graphs
            column.Series["Series1"].Points.Clear();
            chartT.Series["Series1"].Points.Clear();
            chartT.Series["Series2"].Points.Clear();

            updateTauxAffectationAnnee();
            updatePersonnelAffectation();
        }

        private void updateTauxAffectationAnnee()
        {
            // On fait la somme par année des cours et des cours qui sont affectés
            var tabUe = new ArrayList();
            var tabAnneeSumCours = new List<int>();
            var tabAnneeSumCoursAffecte = new List<int>();
            foreach (Cours c in cours)
            {
                UniteEnseignement ue = c.elementConstitutif.uniteEnseignement;
                int index = -1;
                for (int i = 0; i < tabUe.Count; i++)
                {
                    UniteEnseignement tmp = (UniteEnseignement)(tabUe[i]);
                    if (tmp.id == ue.id)
                    {
                        index = i;
                    }
                }
                if (index < 0)
                {
                    tabUe.Add(ue);
                    index = tabUe.Count - 1;
                    tabAnneeSumCours.Add(0);
                    tabAnneeSumCoursAffecte.Add(0);
                }
                tabAnneeSumCours[index] += c.volumeHoraire;
                if (c.intervenant != null)
                    tabAnneeSumCoursAffecte[index] += c.volumeHoraire;
            }

            //On ajoute pour chaque année le pourcentage
            for (int i = 0; i < tabUe.Count; i++)
            {
                float percentage = tabAnneeSumCoursAffecte[i] * 100 / tabAnneeSumCours[i];
                UniteEnseignement ue = ((UniteEnseignement)tabUe[i]);
                string libelle = ue.periode.annee + " " + ue.libelle;
                column.Series["Series1"].Points.AddXY(libelle, percentage);
            }
        }

        private void updatePersonnelAffectation()
        {
            List<Personnel> personnes = PersonnelDAO.findAll();
            var tabPerso = new ArrayList();

            foreach(Personnel personne in personnes)
            {
                double somme = personne.getSommeHorraire();
                int total = personne.categoriePersonnel.volumeHoraire;

                string libelle = personne.prenom + " " + personne.nom;

                if (somme > total)
                {
                    double diff = Math.Round(somme - total, 2);
                    chartT.Series["Series1"].Points.AddXY(libelle, total);
                    chartT.Series["Series2"].Points.AddXY(libelle, diff);
                    chartT.Series["Series2"].Points.Last().Color = System.Drawing.Color.FromArgb(255, 40, 40);
                }
                else
                {
                    double diff = Math.Round(total - somme, 2);
                    chartT.Series["Series1"].Points.AddXY(libelle, somme);
                    chartT.Series["Series2"].Points.AddXY(libelle, diff);
                }
            }
        }
    }
}
