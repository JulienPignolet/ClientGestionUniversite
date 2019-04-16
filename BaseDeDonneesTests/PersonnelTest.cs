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
    public class PersonnelTest
    {
        [TestMethod]
        public void executeTestsPersonnel()
        {
           
            TestFind();
            TestCreationPersonnel();
            TestFindAll(); // DEBUG PURPOSE : add breakpoint in it
            TestCategorieLienAvecPersonnel();
            TestFindByNomPersonnel();
            TestFindByPrenomPersonnel();
            TestUpdatePersonnel();
            TestDeletePersonnel();
        }

        public void TestFindAll()
        {
            // test du fin by libelle
            List<Personnel> resultatFind = PersonnelDAO.findAll();
            foreach (Personnel res in resultatFind)
            {
                Assert.IsNotNull(res.id);
                Assert.IsNotNull(res.categoriePersonnel.id);
            }
        }

        public void TestFind()
        {
            // test du find simple
            Personnel resultatFind = PersonnelDAO.find(34);
            Assert.AreEqual("Jacquie", resultatFind.nom);
            Assert.AreEqual("Pierre", resultatFind.prenom);
            Assert.AreEqual(1, resultatFind.categoriePersonnel.id);
        }

        public void TestCreationPersonnel()
        {
            // test la création d'un personnel 
            Personnel resultat = creerPersonnel("TEST_Personnel","TEST_Personnel");

            Assert.AreEqual("TEST_Personnel", resultat.prenom);
            Assert.AreEqual("TEST_Personnel", resultat.nom);
            Assert.IsTrue(resultat.id > 0);
            Assert.IsTrue(resultat.categoriePersonnel.id > 0);

        }


        public void TestCategorieLienAvecPersonnel()
        {
            List<Personnel> resultats = PersonnelDAO.findByNom("TEST_Personnel");
            foreach (Personnel res in resultats)
            {
                Assert.AreEqual("TEST_Personnel", res.nom);
                Assert.AreNotEqual(0, res.categoriePersonnel.id);
            }
        }

        public void TestFindByNomPersonnel()
        {
            // test du fin by nom
            List<Personnel> resultatFind = PersonnelDAO.findByNom("TEST_Personnel");
            foreach (Personnel res in resultatFind)
            {
                Assert.AreEqual("TEST_Personnel", res.nom);
                Assert.AreNotEqual(0, res.id);
                Assert.AreNotEqual(0, res.categoriePersonnel.id);
            }
        }

        public void TestFindByPrenomPersonnel()
        {
            // test du fin by prenom
            List<Personnel> resultatFind = PersonnelDAO.findByPrenom("TEST_Personnel");
            foreach (Personnel res in resultatFind)
            {
                Assert.AreEqual("TEST_Personnel", res.prenom);
                Assert.AreNotEqual(0, res.id);
                Assert.AreNotEqual(0, res.categoriePersonnel.id);
            }
        }

        public void TestUpdatePersonnel()
        {

            List<Personnel> resultats = PersonnelDAO.findByNom("TEST_Personnel%");
            foreach (Personnel res in resultats)
            {
                // modification annees
                res.nom = "TEST_Personnel_2";

                PersonnelDAO.update(res);
            }

            List<Personnel> resultatFind2 = PersonnelDAO.findByNom("TEST_Personnel_2");

            Assert.IsTrue(resultatFind2.Count > 0);

        }

        public void TestDeletePersonnel()
        {
            // test du delete
            List<Personnel> resultatFind = PersonnelDAO.findByNom("test%");

            foreach (Personnel res in resultatFind)
            {
                supprimerPersonnel(res);
            }
            List<Personnel> resultatFind2 = PersonnelDAO.findByNom("test%");

            Assert.AreEqual(resultatFind2.Count, 0);

            // delete aussi par prenom s'il en reste
            List<Personnel> resultatFindPrenom = PersonnelDAO.findByPrenom("test%");

            foreach (Personnel res in resultatFindPrenom)
            {
                supprimerPersonnel(res);
            }
            List<Personnel> resultatFindByPrenom2 = PersonnelDAO.findByPrenom("test%");

            Assert.AreEqual(resultatFindByPrenom2.Count, 0);
        }


        /** 
         * Methodes pour aider aux tests
         * **/
        public static Personnel creerPersonnel(String nom, String prenom)
        {
            Personnel obj = new Personnel();
            obj.nom = nom;
            obj.prenom = prenom;
            obj.categoriePersonnel = CategoriePersonnelTest.creerCategoriePersonnel("TEST_PERSONNEL");
            Personnel resultat = PersonnelDAO.create(obj);

            return resultat;
        }

        public static void supprimerPersonnel(Personnel personnel)
        {           
            PersonnelDAO.delete(personnel);
            CategoriePersonnelTest.supprimeCategoriePersonnel(personnel.categoriePersonnel);
        }
    }
}
