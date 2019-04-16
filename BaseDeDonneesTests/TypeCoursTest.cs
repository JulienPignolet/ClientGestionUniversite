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
    public class TypeCoursTest
    {
        [TestMethod]
        public void executeTestsTypeCours()
        {
            TestFind();
            TestCreationTypeCours();
            TestFindAll();
            TestFindByLibelleTypeCours();
            TestUpdateTypeCours();
            TestDeleteTypeCours();

        }

        public void TestFind()
        {
            // test du find simple
            TypeCours resultatFind = TypeCoursDAO.find(1);
            Assert.AreEqual("CM", resultatFind.libelle);
            Assert.AreNotEqual(0, resultatFind.id);
        }

        public void TestFindAll()
        {
            // test du fin by libelle
            List<TypeCours> resultatFind = TypeCoursDAO.findAll();
            foreach (TypeCours res in resultatFind)
            {
                Assert.IsNotNull(res.id);
                Assert.IsNotNull(res.libelle);
            }
        }

        public void TestCreationTypeCours()
        {
            // test la création d'un type de cours et la recherche grace à son libelle
            TypeCours resultat = creerTypeCours("TEST_type_cours");

            Assert.AreNotEqual("", resultat.libelle);
            Assert.AreEqual("TEST_type_cours", resultat.libelle);
            Assert.IsTrue(resultat.id > 0);
        }


        public void TestFindByLibelleTypeCours()
        {
            // test du fin by libelle
            List<TypeCours> resultatFind = TypeCoursDAO.findByLibelle("TEST_type_cours");
            foreach (TypeCours res in resultatFind)
            {
                Assert.AreEqual("TEST_type_cours", res.libelle);
                Assert.IsTrue(res.id > 0);
            }
        }


        public void TestUpdateTypeCours()
        {
            // test du delete
            List<TypeCours> resultatFind = TypeCoursDAO.findByLibelle("TEST_type_cours");

            foreach (TypeCours res in resultatFind)
            {
                res.libelle = "TEST_type_cours_2";
                TypeCoursDAO.update(res);
            }
            List<TypeCours> resultatFind2 = TypeCoursDAO.findByLibelle("TEST_type_cours_2");

            Assert.IsTrue(resultatFind2.Count > 0);
        }

        public void TestDeleteTypeCours()
        {
            // test du delete
            List<TypeCours> resultatFind = TypeCoursDAO.findByLibelle("TEST_%");

            foreach (TypeCours res in resultatFind)
            {
                supprimeTypeCours(res);
            }
            List<TypeCours> resultatFind2 = TypeCoursDAO.findByLibelle("TEST_%");

            Assert.AreEqual(resultatFind2.Count, 0);
        }

        /** 
         * Methodes pour aider aux tests
         * **/
        public static TypeCours creerTypeCours(String libelle)
        {
            TypeCours res = new TypeCours();
            res.libelle = libelle;

            TypeCours c = TypeCoursDAO.create(res);
            return c;
        }

        public static void supprimeTypeCours(TypeCours typeCours)
        {
            TypeCoursDAO.delete(typeCours);
        }
    }
}
