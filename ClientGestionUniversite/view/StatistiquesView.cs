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
            column.ChartAreas[0].AxisY.Maximum = 100;
        }

        public void updateCharts()
        {
            //Requête des cours
            cours = CoursDAO.findAllCours();
            //Vide les graphs
            chartT.Series["Series1"].Points.Clear();
            chartT.Series["Series2"].Points.Clear();

            //updateChartGauche();
            comboBox1.SelectedIndex = 0;
            updatePersonnelAffectation();
        }

        private void updateChartGauche()
        {
            column.Series["Series1"].Points.Clear();
            switch ((String)comboBox1.SelectedItem)
            {
                case "Année" :
                    updateTauxAffectationAnnee();
                    this.column.Titles[0].Text = "Taux d\'affectation des heures de cours par Années";
                    break;

                case "Période" :
                    updateTauxAffectationPeriode();
                    this.column.Titles[0].Text = "Taux d\'affectation des heures de cours par Périodes";
                    break;
                
                case "UE" :
                    updateTauxAffectationUE();
                    this.column.Titles[0].Text = "Taux d\'affectation des heures de cours par UE";
                    break;
                
                case "EC" :
                    updateTauxAffectationEC();
                    this.column.Titles[0].Text = "Taux d\'affectation des heures de cours par EC";
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateChartGauche();
        }

        private void updateTauxAffectationAnnee()
        {
            // On fait la somme par année des cours et des cours qui sont affectés
            var tabUe = new ArrayList();
            var tabAnneeSumCours = new List<int>();
            var tabAnneeSumCoursAffecte = new List<int>();
            foreach (Cours c in cours)
            {
                Annee ue = c.elementConstitutif.uniteEnseignement.periode.annee;
                int index = -1;
                for (int i = 0; i < tabUe.Count; i++)
                {
                    Annee tmp = (Annee)(tabUe[i]);
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
                Annee an = ((Annee)tabUe[i]);
                string libelle = an.diplome + " " + an.libelle;
                column.Series["Series1"].Points.AddXY(libelle, percentage);
            }
        }

        private void updateTauxAffectationPeriode()
        {
            // On fait la somme par année des cours et des cours qui sont affectés
            var tabUe = new ArrayList();
            var tabAnneeSumCours = new List<int>();
            var tabAnneeSumCoursAffecte = new List<int>();
            foreach (Cours c in cours)
            {
                Periode ue = c.elementConstitutif.uniteEnseignement.periode;
                int index = -1;
                for (int i = 0; i < tabUe.Count; i++)
                {
                    Periode tmp = (Periode)(tabUe[i]);
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
                Periode pe = ((Periode)tabUe[i]);
                string libelle = pe.annee + " " + pe.libelle;
                column.Series["Series1"].Points.AddXY(libelle, percentage);
            }
        }

        private void updateTauxAffectationUE()
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

        private void updateTauxAffectationEC()
        {
            // On fait la somme par année des cours et des cours qui sont affectés
            var tabUe = new ArrayList();
            var tabAnneeSumCours = new List<int>();
            var tabAnneeSumCoursAffecte = new List<int>();
            foreach (Cours c in cours)
            {
                ElementConstitutif ue = c.elementConstitutif;
                int index = -1;
                for (int i = 0; i < tabUe.Count; i++)
                {
                    ElementConstitutif tmp = (ElementConstitutif)(tabUe[i]);
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
                ElementConstitutif ec = ((ElementConstitutif)tabUe[i]);
                string libelle = ec.uniteEnseignement.periode.annee + " " + ec.uniteEnseignement + " " + ec.libelle;
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
