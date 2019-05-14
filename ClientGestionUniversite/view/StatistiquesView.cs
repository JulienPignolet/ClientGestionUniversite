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
            var tabAnnee = new ArrayList();
            var tabAnneeSumCours = new List<int>();
            var tabAnneeSumCoursAffecte = new List<int>();
            foreach (Cours c in cours)
            {
                Annee annee = c.elementConstitutif.uniteEnseignement.periode.annee;
                int index = -1;
                for (int i = 0; i < tabAnnee.Count; i++)
                {
                    Annee tmp = (Annee)(tabAnnee[i]);
                    if (tmp.id == annee.id)
                    {
                        index = i;
                    }
                }
                if (index < 0)
                {
                    tabAnnee.Add(annee);
                    index = tabAnnee.Count - 1;
                    tabAnneeSumCours.Add(0);
                    tabAnneeSumCoursAffecte.Add(0);
                }
                tabAnneeSumCours[index] += c.volumeHoraire;
                if (c.intervenant != null)
                    tabAnneeSumCoursAffecte[index] += c.volumeHoraire;
            }

            //On ajoute pour chaque année le pourcentage
            for (int i = 0; i < tabAnnee.Count; i++)
            {
                float percentage = tabAnneeSumCoursAffecte[i] * 100 / tabAnneeSumCours[i];
                string libelle = ((Annee)tabAnnee[i]).libelle;
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

                chartT.Series["Series1"].Points.AddXY(libelle, somme);
                if (somme > total)
                {
                    chartT.Series["Series2"].Points.AddXY(libelle, somme - total);
                    chartT.Series["Series2"].Points.Last().Color = System.Drawing.Color.FromArgb(255, 40, 40);
                }
                else
                {

                    chartT.Series["Series2"].Points.AddXY(libelle, total - somme);
                }
            }
        }
    }
}
