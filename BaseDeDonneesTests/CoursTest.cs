using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientGestionUniversite.modele;
using BaseDeDonneesTests.modele;
using ClientGestionUniversite.businessLogic;
using System.Collections.Generic;

namespace BaseDeDonneesTests
{
    [TestClass]
    public class CoursTest
    {
        [TestMethod]
        public void executeTestsCours()
        {
            TestFind();
            TestCreationCours();
            TestFindAll();
            TestFindByElementConstitutif();
            TestFindByPersonnel();
            TestUpdateCours();
            TestDeleteCours();
        }

        public void TestFind()
        {
            // test du find simple
            Cours resultatFind = CoursDAO.find(2);
            // cours
            Assert.AreEqual(7, resultatFind.volumeHoraire);
            Assert.AreEqual(2, resultatFind.numeroGroupe);
            // autres entites
            Assert.AreEqual(3, resultatFind.elementConstitutif.id);
            Assert.AreEqual(3, resultatFind.elementConstitutif.uniteEnseignement.id);
            Assert.AreEqual(1, resultatFind.elementConstitutif.uniteEnseignement.periode.id);

            Assert.AreNotEqual(0, resultatFind.id);
            Assert.AreNotEqual(0, resultatFind.elementConstitutif.uniteEnseignement.periode.annee.id);
            Assert.AreNotEqual(0, resultatFind.elementConstitutif.uniteEnseignement.periode.annee.diplome.id);

            Assert.AreNotEqual(0, resultatFind.typeCours.id);
            Assert.AreNotEqual(0, resultatFind.intervenant.id);
            Assert.AreNotEqual(0, resultatFind.intervenant.categoriePersonnel.id);
        }

        public void TestFindByElementConstitutif()
        {
            List<Cours> resultatFind = CoursDAO.findByElementConstitutif(3);
            foreach (Cours resultat in resultatFind)
            {

                Assert.AreNotEqual(0, resultat.id);
                Assert.AreNotEqual(0, resultat.numeroGroupe);
                Assert.AreNotEqual(0, resultat.volumeHoraire);

                Assert.AreNotEqual(0, resultat.elementConstitutif.id);
                Assert.AreNotEqual(0, resultat.elementConstitutif.uniteEnseignement.id);
                Assert.AreNotEqual(0, resultat.elementConstitutif.uniteEnseignement.periode.id);

                Assert.AreNotEqual(0, resultat.elementConstitutif.uniteEnseignement.periode.annee.id);
                Assert.AreNotEqual(0, resultat.elementConstitutif.uniteEnseignement.periode.annee.diplome.id);

                Assert.AreNotEqual(0, resultat.typeCours.id);
                Assert.AreNotEqual(0, resultat.intervenant.id);
                Assert.AreNotEqual(0, resultat.intervenant.categoriePersonnel.id);
            }
        }

        public void TestFindByPersonnel()
        {
            List<Cours> resultatFind = CoursDAO.findByPersonnel(39);
            foreach (Cours resultat in resultatFind)
            {

                Assert.AreNotEqual(0, resultat.id);
                Assert.AreNotEqual(0, resultat.numeroGroupe);
                Assert.AreNotEqual(0, resultat.volumeHoraire);

                Assert.AreNotEqual(0, resultat.elementConstitutif.id);
                Assert.AreNotEqual(0, resultat.elementConstitutif.uniteEnseignement.id);
                Assert.AreNotEqual(0, resultat.elementConstitutif.uniteEnseignement.periode.id);

                Assert.AreNotEqual(0, resultat.elementConstitutif.uniteEnseignement.periode.annee.id);
                Assert.AreNotEqual(0, resultat.elementConstitutif.uniteEnseignement.periode.annee.diplome.id);

                Assert.AreNotEqual(0, resultat.typeCours.id);
                Assert.AreNotEqual(0, resultat.intervenant.id);
                Assert.AreNotEqual(0, resultat.intervenant.categoriePersonnel.id);
            }
        }

        public void TestFindAll()
        {
            // test du find all
            List<Cours> resultatFind = CoursDAO.findAllCours();
            foreach (Cours resultat in resultatFind)
            {
                Assert.AreNotEqual(0, resultat.id);
                Assert.AreNotEqual(0, resultat.numeroGroupe);
                Assert.AreNotEqual(0, resultat.volumeHoraire);

                Assert.AreNotEqual(0, resultat.elementConstitutif.id);
                Assert.AreNotEqual(0, resultat.elementConstitutif.uniteEnseignement.id);
                Assert.AreNotEqual(0, resultat.elementConstitutif.uniteEnseignement.periode.id);

                Assert.AreNotEqual(0, resultat.elementConstitutif.uniteEnseignement.periode.annee.id);
                Assert.AreNotEqual(0, resultat.elementConstitutif.uniteEnseignement.periode.annee.diplome.id);

                Assert.AreNotEqual(0, resultat.typeCours.id);
                Assert.AreNotEqual(0, resultat.intervenant.id);
                Assert.AreNotEqual(0, resultat.intervenant.categoriePersonnel.id);
            }
        }
        public void TestUpdateCours()
        {

            List<Cours> cours = CoursDAO.findByGroupe(66);
            foreach (Cours resultat in cours)
            {
                resultat.numeroGroupe = 67;

                CoursDAO.update(resultat);

            }

            List<Cours> resultatFind2 = CoursDAO.findByGroupe(67);

            Assert.IsTrue(resultatFind2.Count > 0);
            Assert.IsTrue(resultatFind2.Count == cours.Count);

        }

        public void TestCreationCours()
        {
            // test la création d'un cours 
            Cours resultat = creerCours(66,66);

            Assert.AreEqual(66, resultat.numeroGroupe);
            Assert.AreEqual(66, resultat.volumeHoraire);
            Assert.IsTrue(resultat.id > 0);

        }

        public void TestDeleteCours()
        {
            // test du delete
            List<Cours> resultatFind = CoursDAO.findByGroupe(66);

            foreach (Cours resultat in resultatFind)
            {
                supprimerCours(resultat);
            }
            List<Cours> resultatFind2 = CoursDAO.findByGroupe(66);

            Assert.AreEqual(resultatFind2.Count, 0);

            // test du delete
            resultatFind = CoursDAO.findByGroupe(67);

            foreach (Cours resultat in resultatFind)
            {
                supprimerCours(resultat);
            }
             resultatFind2 = CoursDAO.findByGroupe(67);

            Assert.AreEqual(resultatFind2.Count, 0);
        }
        /** 
         * Methodes pour aider aux tests
         * **/
        public static Cours creerCours(int volume, int groupe)
        {
            Cours cours = new Cours();
            cours.volumeHoraire = volume;
            cours.numeroGroupe = groupe;
            cours.typeCours = TypeCoursTest.creerTypeCours("TEST_COURS");
            cours.intervenant = PersonnelTest.creerPersonnel("TEST_COURS", "TEST_COURS");
            cours.elementConstitutif = ElementConstitutifTest.creerElementConstitutif("TEST_COURS");

            Cours resultat = CoursDAO.create(cours);

            return resultat;
        }

        public static void supprimerCours(Cours cours)
        {
            TypeCoursTest.supprimeTypeCours(cours.typeCours);
            PersonnelTest.supprimerPersonnel(cours.intervenant);
            ElementConstitutifTest.supprimerElementConstitutif(cours.elementConstitutif);
            CoursDAO.delete(cours);
        }
    }
}
