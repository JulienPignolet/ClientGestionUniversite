using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientGestionUniversite.modele;
using ClientGestionUniversite.businessLogic;
using MySql.Data.MySqlClient;
using BaseDeDonneesTests.modele;
using System.Collections.Generic;

namespace modele.BaseDeDonneesTests
{
    [TestClass]
    public class DiplomeTest
    {
        [TestMethod]
        public void executeTestsDiplome()
            {
            TestFind();
            TestCreationDiplome();
            TestFindByLibelleDiplome();
            TestUpdateDiplome();
            TestFindByDiplome();
            TestDeleteDiplome();

        }

        public void TestFind()
        {
            // test du find simple
            Diplome resultat = creerDiplome("TEST_1");
            Diplome resultatFind = DiplomeDAO.find(resultat.id);
            Assert.AreEqual("TEST_1", resultatFind.libelle);
        }

        public void TestCreationDiplome()
        {
            // test la création d'un diplome et la recherche grace à son libelle
            Diplome resultat = creerDiplome("TEST_1");

            Assert.AreNotEqual("", resultat.libelle);
            Assert.AreEqual("TEST_1", resultat.libelle);
            Assert.IsTrue(resultat.id > 0);
        }

        
        public void TestFindByLibelleDiplome()
        {
            // test du fin by libelle
            List<Diplome> resultatFind = DiplomeDAO.findByLibelle("TEST_1");
            foreach (Diplome dip in resultatFind)
            {
                Assert.AreEqual("TEST_1", dip.libelle);
            }
        }

        
        public void TestUpdateDiplome()
        {
            // test du delete
            List<Diplome> resultatFind = DiplomeDAO.findByLibelle("TEST_1");

            foreach (Diplome dip in resultatFind)
            {
                dip.libelle = "TEST_2";
                DiplomeDAO.update(dip);
            }
            List<Diplome> resultatFind2 = DiplomeDAO.findByLibelle("TEST_2");

            Assert.IsTrue(resultatFind2.Count > 0);
        }

        public void TestDeleteDiplome()
        {
            // test du delete
            List<Diplome> resultatFind = DiplomeDAO.findByLibelle("test%");
            
            foreach (Diplome dip in resultatFind)
            {
                supprimerDiplome(dip);
            }
            List<Diplome> resultatFind2 = DiplomeDAO.findByLibelle("TEST_1");

            Assert.AreEqual(resultatFind2.Count, 0);
        }

        public void TestFindByDiplome()
        {
            // test du fin by avec n'importe
            // ne fonctionne pas car l'attribut est en format string : avec les " " et ça ne marche pas en sql pour le nom de la colonne
            List<Diplome> resultatFind = DiplomeDAO.findBy("libelle","TEST%");
            foreach (Diplome dip in resultatFind)
            {
                Assert.AreEqual("TEST_1", dip.libelle);
            }
        }

        /** 
         * Methodes pour aider aux tests
         * **/
        public static Diplome creerDiplome(String libelle)
        {
            Diplome dip = new Diplome();
            dip.libelle = libelle;
            Diplome d = DiplomeDAO.create(dip);
            return d ;
        }

        public static void supprimerDiplome(Diplome diplome)
        {
                DiplomeDAO.delete(diplome);
        }
    }
}
