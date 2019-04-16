using ClientGestionUniversite.modele;
using ClientGestionUniversite.businessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDonneesTests.modele
{
    [TestClass]
    public class CategoriePersonnelTest
    {
        [TestMethod]
        public void executeTestsCategoriePersonnel()
        {
            TestFind();
            TestCreationCategoriePersonnel();
            TestFindAll();
            TestFindByLibelleCategoriePersonnel();
            TestUpdateCategoriePersonnel();
            TestDeleteCategoriePersonnel();

        }

        public void TestFind()
        {
            // test du find simple
            CategoriePersonnel resultatFind = CategoriePersonnelDAO.find(1);
            Assert.AreEqual("MC", resultatFind.libelle);
            Assert.AreNotEqual(0, resultatFind.id);
        }

        public void TestFindAll()
        {
            // test du fin by libelle
            List<CategoriePersonnel> resultatFind = CategoriePersonnelDAO.findAll();
            foreach (CategoriePersonnel res in resultatFind)
            {
                Assert.IsNotNull(res.id);
                Assert.IsNotNull(res.volumeHoraire);
                Assert.IsNotNull(res.libelle);
            }
        }

        public void TestCreationCategoriePersonnel()
        {
            // test la création d'une categorie et la recherche grace à son libelle
            CategoriePersonnel resultat = creerCategoriePersonnel("TEST_categ");

            Assert.AreNotEqual("", resultat.libelle);
            Assert.AreEqual("TEST_categ", resultat.libelle);
            Assert.AreEqual(999, resultat.volumeHoraire);
            Assert.IsTrue(resultat.id > 0);
        }


        public void TestFindByLibelleCategoriePersonnel()
        {
            // test du fin by libelle
            List<CategoriePersonnel> resultatFind = CategoriePersonnelDAO.findByLibelle("TEST_categ");
            foreach (CategoriePersonnel res in resultatFind)
            {
                Assert.AreEqual("TEST_categ", res.libelle);
                Assert.IsTrue(res.id > 0);
            }
        }


        public void TestUpdateCategoriePersonnel()
        {
            // test du delete
            List<CategoriePersonnel> resultatFind = CategoriePersonnelDAO.findByLibelle("TEST_categ");

            foreach (CategoriePersonnel res in resultatFind)
            {
                res.libelle = "TEST_categ_2";
                CategoriePersonnelDAO.update(res);
            }
            List<CategoriePersonnel> resultatFind2 = CategoriePersonnelDAO.findByLibelle("TEST_categ_2");

            Assert.IsTrue(resultatFind2.Count > 0);
        }

        public void TestDeleteCategoriePersonnel()
        {
            // test du delete
            List<CategoriePersonnel> resultatFind = CategoriePersonnelDAO.findByLibelle("TEST_%");

            foreach (CategoriePersonnel res in resultatFind)
            {
                supprimeCategoriePersonnel(res);
            }
            List<CategoriePersonnel> resultatFind2 = CategoriePersonnelDAO.findByLibelle("TEST_%");

            Assert.AreEqual(resultatFind2.Count, 0);
        }

        /** 
         * Methodes pour aider aux tests
         * **/
        public static CategoriePersonnel creerCategoriePersonnel(String libelle)
        {
            CategoriePersonnel res = new CategoriePersonnel();
            res.libelle = libelle;
            res.volumeHoraire = 999;
            CategoriePersonnel c = CategoriePersonnelDAO.create(res);
            return c;
        }

        public static void supprimeCategoriePersonnel(CategoriePersonnel categoriePersonnel)
        {
            CategoriePersonnelDAO.delete(categoriePersonnel);
        }
    }
}
