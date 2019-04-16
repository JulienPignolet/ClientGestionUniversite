using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientGestionUniversite.modele;
using ClientGestionUniversite.businessLogic;
using modele.BaseDeDonneesTests;
using System.Collections.Generic;

namespace BaseDeDonneesTests.modele
{
    [TestClass]
    public class AnneeTest
    {
        [TestMethod]
        public void executeTestsAnnee()
        {
            TestFindAll(); // DEBUG PURPOSE : add breakpoint in it
            TestFind();
            TestCreationAnnee();
            TestDiplomeLienAvecAnnee();
            TestFindByLibelleAnnee();
            TestUpdateAnnee();
            TestDeleteAnnee();
        }

        public void TestFindAll()
        {
            // test du fin by libelle
            List<Annee> resultatFind = AnneeDAO.findAll();
            foreach (Annee annee in resultatFind)
            {
                Assert.IsNotNull(annee.diplome.id);
            }
        }

        public void TestFind()
        {
            // test du find simple
            Annee resultatFind = AnneeDAO.find(1);
            Assert.AreEqual("L1 informatique", resultatFind.libelle);
            Assert.AreEqual(3, resultatFind.diplome.id);
        }

        public void TestCreationAnnee()
        {
            // test la création d'une annee et la recherche grace à son libelle
            Annee resultat = creerAnnee("TEST_ANNEE");

            Assert.AreNotEqual("", resultat.libelle);
            Assert.AreEqual("TEST_ANNEE", resultat.libelle);
            Assert.IsTrue(resultat.id > 0);
            Assert.IsTrue(resultat.diplome.id > 0);
           
        }

        
        public void TestDiplomeLienAvecAnnee()
        {
            List<Annee> resultats = AnneeDAO.findByLibelle("TEST_ANNEE");
            foreach (Annee annee in resultats)
            {
                Assert.AreEqual("TEST_ANNEE", annee.libelle);
                Assert.AreNotEqual(0,annee.diplome.id);
            }
        }

        public void TestFindByLibelleAnnee()
        {
            // test du fin by libelle
            List<Annee> resultatFind = AnneeDAO.findByLibelle("TEST_ANNEE");
            foreach (Annee annee in resultatFind)
            {
                Assert.AreEqual("TEST_ANNEE", annee.libelle);
                Assert.AreNotEqual(0, annee.diplome.id);
            }
        }

        public void TestUpdateAnnee()
        {

            List<Annee> annees = AnneeDAO.findByLibelle("TEST_ANNEE%");
            foreach (Annee annee in annees)
            {
                long temp = annee.diplome.id;
                // modification annees
                annee.libelle = "TEST_ANNEE_2";

                AnneeDAO.update(annee);
            }

            List<Annee> resultatFind2 = AnneeDAO.findByLibelle("TEST_ANNEE_2");

            Assert.IsTrue(resultatFind2.Count > 0);
            
        }

        public void TestDeleteAnnee()
        {
            // test du delete
            List<Annee> resultatFind = AnneeDAO.findByLibelle("test%");

            foreach (Annee annee in resultatFind)
            {
                supprimerAnnee(annee);
            }
            List<Annee> resultatFind2 = AnneeDAO.findByLibelle("test%");

            Assert.AreEqual(resultatFind2.Count, 0);
        }

        /** 
         * Methodes pour aider aux tests
         * **/
        public static Annee creerAnnee(String libelle)
        {
            Annee annee = new Annee();
            annee.libelle = libelle;
            annee.diplome = DiplomeTest.creerDiplome(libelle);
            Annee resultat = AnneeDAO.create(annee);

            return resultat;
        }

        public static void supprimerAnnee(Annee annee)
        {
                DiplomeTest.supprimerDiplome(annee.diplome);
                AnneeDAO.delete(annee);            
        }
    }
}
