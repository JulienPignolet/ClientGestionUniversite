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
     public class UniteEnseignementTest
     {
         [TestMethod]
         public void executeTestsUniteEnseignement()
         {

             TestFind();
             TestCreationUniteEnseignement();
             TestFindAll(); // DEBUG PURPOSE : add breakpoint in it
             TestUniteEnseignementLienAvecPeriode();
             TestFindByLibelleUniteEnseignement();
             TestUpdateUniteEnseignement();
             TestFindByDiplomeUniteEnseignement();
             TestDeleteUniteEnseignement();
         }

         public void TestFindAll()
         {
             // test du fin by libelle
             List<UniteEnseignement> resultatFind = UniteEnseignementDAO.findAll();
             foreach (UniteEnseignement resultat in resultatFind)
             {
                 Assert.AreNotEqual(0, resultat.id);
                 Assert.AreNotEqual(0, resultat.periode.id);
                 Assert.AreNotEqual(0, resultat.periode.annee.id);
                 Assert.AreNotEqual(0, resultat.periode.annee.diplome.id);
             }
         }

         public void TestFind()
         {
             // test du find simple
             UniteEnseignement resultat = creerUniteEnseignement("TEST_UniteEnseignement");

             UniteEnseignement resultatFind = UniteEnseignementDAO.find(resultat.id);
             Assert.AreEqual("TEST_UniteEnseignement", resultatFind.libelle);
             Assert.AreNotEqual(0, resultatFind.periode.id);
             Assert.AreNotEqual(0, resultatFind.id);
             Assert.AreNotEqual(0, resultatFind.periode.annee.id);
             Assert.AreNotEqual(0, resultatFind.periode.annee.diplome.id);
         }

         public void TestCreationUniteEnseignement()
         {
             // test la création d'une UniteEnseignement et la recherche grace à son libelle
             UniteEnseignement resultat = creerUniteEnseignement("TEST_UniteEnseignement");

             Assert.AreNotEqual("", resultat.libelle);
             Assert.AreEqual("TEST_UniteEnseignement", resultat.libelle);
             Assert.IsTrue(resultat.id > 0);

         }

         public void TestUniteEnseignementLienAvecPeriode()
         {
             List<UniteEnseignement> resultats = UniteEnseignementDAO.findByLibelle("TEST_UniteEnseignement");
             foreach (UniteEnseignement resultat in resultats)
             {
                 Assert.AreEqual("TEST_UniteEnseignement", resultat.libelle);
                 Assert.AreNotEqual(0, resultat.id);
                 Assert.AreNotEqual(0, resultat.periode);
                 Assert.AreNotEqual(0, resultat.periode.annee);
                 Assert.AreNotEqual(0, resultat.periode.annee.diplome);
             }
         }

         public void TestFindByLibelleUniteEnseignement()
         {
             // test du fin by libelle
             List<UniteEnseignement> resultatFind = UniteEnseignementDAO.findByLibelle("TEST_UniteEnseignement");
             foreach (UniteEnseignement resultat in resultatFind)
             {
                 Assert.AreEqual("TEST_UniteEnseignement", resultat.libelle);
                 Assert.AreNotEqual(0, resultat.periode);
                 Assert.AreNotEqual(0, resultat.periode.annee);
                 Assert.AreNotEqual(0, resultat.periode.annee.diplome);
             }
         }

         public void TestFindByDiplomeUniteEnseignement()
         {
             // test du fin by libelle
             List<UniteEnseignement> resultatFind = UniteEnseignementDAO.findByDiplome(3);    
             Assert.IsTrue(resultatFind.Count > 0);
         }

         public void TestUpdateUniteEnseignement()
         {

             List<UniteEnseignement> uniteEnseignements = UniteEnseignementDAO.findByLibelle("TEST_UniteEnseignement%");
             foreach (UniteEnseignement resultat in uniteEnseignements)
             {
                 resultat.libelle = "TEST_UniteEnseignement_2";

                 UniteEnseignementDAO.update(resultat);

             }

             List<UniteEnseignement> resultatFind2 = UniteEnseignementDAO.findByLibelle("TEST_UniteEnseignement_2");

             Assert.IsTrue(resultatFind2.Count > 0);
             Assert.IsTrue(resultatFind2.Count == uniteEnseignements.Count);

         }

         public void TestDeleteUniteEnseignement()
         {
             // test du delete
             List<UniteEnseignement> resultatFind = UniteEnseignementDAO.findByLibelle("TEST%");

             foreach (UniteEnseignement resultat in resultatFind)
             {
                 supprimerUniteEnseignement(resultat);
             }
             List<UniteEnseignement> resultatFind2 = UniteEnseignementDAO.findByLibelle("TEST%");

             Assert.AreEqual(resultatFind2.Count, 0);
         }

         /** 
          * Methodes pour aider aux tests
          * **/
         public static UniteEnseignement creerUniteEnseignement(String libelle)
         {
             UniteEnseignement uniteEnseignement = new UniteEnseignement();
             uniteEnseignement.libelle = libelle;
             uniteEnseignement.periode = PeriodeTest.creerPeriode(libelle);
             UniteEnseignement resultat = UniteEnseignementDAO.create(uniteEnseignement);

             return resultat;
         }

         public static void supprimerUniteEnseignement(UniteEnseignement uniteEnseignement)
         {
             PeriodeTest.supprimerPeriode(uniteEnseignement.periode);
             UniteEnseignementDAO.delete(uniteEnseignement);
         }
     }
}
