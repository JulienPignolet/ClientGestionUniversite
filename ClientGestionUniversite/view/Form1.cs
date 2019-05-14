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
    public partial class Form1 : Form
    {

        private List<Cours> cours;

        public Form1()
        {
            InitializeComponent();

            //Configuration visuelles
            Series serie = column.Series["Series1"];
            serie.Points.Clear();
            column.ChartAreas[0].AxisY.Maximum = 100;
            serie.ToolTip = "#VALY1{#.##}%";
            serie.IsValueShownAsLabel = true;

            //Configurations visuelles chart2
            chartT.Series["Series2"].Color = System.Drawing.Color.FromArgb(120, 65, 140, 240);


            updateCharts();
        }

        private void updateCharts()
        {
            //Requête des cours
            cours = CoursDAO.findAllCours();
            //Vide les graphs
            column.Series["Series1"].Points.Clear();
            chartT.Series["Series1"].Points.Clear();
            chartT.Series["Series2"].Points.Clear();

            updateTauxAffectationAnnee();
            update2();
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
                //Met la couleur en fonction du pourcentage
                //int c = (int)(percentage * 2.55);
                //serie.Points[i].Color = Color.FromArgb(c-80, c-80, c);
            }
        }

        private void update2()
        {
            // On fait la somme des volumes de cours par personnel
            var tabPerso = new ArrayList();
            var tabSumHeures = new List<int>();
            var tabHeuresregime = new List<int>();
            foreach (Cours c in cours)
            {
                Personnel perso = c.intervenant;
                if (perso != null)
                {
                    int index = -1;
                    for (int i = 0; i < tabPerso.Count; i++)
                    {
                        Personnel tmp = (Personnel)(tabPerso[i]);
                        if (tmp.id == perso.id)
                        {
                            index = i;
                        }
                    }
                    if (index < 0)
                    {
                        tabPerso.Add(perso);
                        index = tabPerso.Count - 1;
                        tabHeuresregime.Add(perso.categoriePersonnel.volumeHoraire);
                        tabSumHeures.Add(0);
                    }
                    tabSumHeures[index] += c.volumeHoraire;
                }
            }

            //On ajoute pour chaque année le pourcentage
            for (int i = 0; i < tabPerso.Count; i++)
            {
                int restant = tabHeuresregime[i] - tabSumHeures[i];
                Personnel perso = ((Personnel)tabPerso[i]);
                string libelle = perso.prenom + " " + perso.nom;


                if (restant < 0)
                {
                    //chartT.Series["Series1"].Color = Color.Red;
                    chartT.Series["Series2"].Points.AddXY(libelle, tabSumHeures[i] - tabHeuresregime[i]);
                    chartT.Series["Series1"].Points.AddXY(libelle, tabHeuresregime[i]);
                    chartT.Series["Series2"].Points.Last().Color = System.Drawing.Color.FromArgb(255, 40, 40);
                }
                else
                {
                    chartT.Series["Series1"].Points.AddXY(libelle, tabSumHeures[i]);
                    chartT.Series["Series2"].Points.AddXY(libelle, tabHeuresregime[i]);
                }

                //Met la couleur en fonction du pourcentage
                //int c = (int)(percentage * 2.55);
                //serie.Points[i].Color = Color.FromArgb(c-80, c-80, c);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateCharts();
        }


    }
}
