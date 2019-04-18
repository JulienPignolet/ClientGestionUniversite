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
    public class ElementConstitutifTest
    {

    [TestMethod]
        public void executeTestsElementConstitutif()
         {

             TestFind();
             TestCreationElementConstitutif();
             TestFindAll(); // DEBUG PURPOSE : add breakpoint in it
             TestElementConstitutifLienAvecUniteEnseignement();
             TestFindByLibelleElementConstitutif();
             TestFindByUniteEnseignementElementConstitutif();
             TestUpdateElementConstitutif();
             TestDeleteElementConstitutif();
         }

         public void TestFindAll()
         {
             // test du fin by libelle
             List<ElementConstitutif> resultatFind = ElementConstitutifDAO.findAll();
             foreach (ElementConstitutif resultat in resultatFind)
             {

                 Assert.AreNotEqual(0, resultat.id);
                 Assert.IsNotNull(resultat.uniteEnseignement.id);
                 Assert.AreNotEqual(0, resultat.uniteEnseignement.periode.id);
                 Assert.AreNotEqual(0, resultat.uniteEnseignement.periode.annee.id);
                 Assert.AreNotEqual(0, resultat.uniteEnseignement.periode.annee.diplome.id);
             }
         }

         public void TestFind()
         {
             // test du find simple
             ElementConstitutif resultat = creerElementConstitutif("TEST_ElementConstitutif");
             ElementConstitutif resultatFind = ElementConstitutifDAO.find(resultat.id);
             Assert.AreEqual("TEST_ElementConstitutif", resultatFind.libelle);
             Assert.AreNotEqual(0, resultatFind.id);
             Assert.AreNotEqual(0, resultatFind.uniteEnseignement.id);
             Assert.AreNotEqual(0, resultatFind.uniteEnseignement.periode.id);
             Assert.AreNotEqual(0, resultatFind.uniteEnseignement.periode.annee.id);
             Assert.AreNotEqual(0, resultatFind.uniteEnseignement.periode.annee.diplome.id);
         }

         public void TestCreationElementConstitutif()
         {
             // test la création d'une UniteEnseignement et la recherche grace à son libelle
             ElementConstitutif resultat = creerElementConstitutif("TEST_ElementConstitutif");

             Assert.AreNotEqual("", resultat.libelle);
             Assert.AreEqual("TEST_ElementConstitutif", resultat.libelle);
             Assert.IsTrue(resultat.id > 0);

         }

         public void TestElementConstitutifLienAvecUniteEnseignement()
         {
             List<ElementConstitutif> resultats = ElementConstitutifDAO.findByLibelle("TEST_ElementConstitutif");
             foreach (ElementConstitutif resultat in resultats)
             {
                 Assert.AreEqual("TEST_ElementConstitutif", resultat.libelle);
                 Assert.AreNotEqual(0, resultat.id);
                 Assert.AreNotEqual(0, resultat.uniteEnseignement.id);
                 Assert.AreNotEqual(0, resultat.uniteEnseignement.periode.id);
                 Assert.AreNotEqual(0, resultat.uniteEnseignement.periode.annee.id);
                 Assert.AreNotEqual(0, resultat.uniteEnseignement.periode.annee.diplome.id);
             }
         }

         public void TestFindByLibelleElementConstitutif()
         {
             // test du fin by libelle
             List<ElementConstitutif> resultatFind = ElementConstitutifDAO.findByLibelle("TEST_ElementConstitutif");
             foreach (ElementConstitutif resultat in resultatFind)
             {
                 Assert.AreEqual("TEST_ElementConstitutif", resultat.libelle);
                 Assert.AreNotEqual(0, resultat.id);
                 Assert.AreNotEqual(0, resultat.uniteEnseignement.id);
                 Assert.AreNotEqual(0, resultat.uniteEnseignement.periode.id);
                 Assert.AreNotEqual(0, resultat.uniteEnseignement.periode.annee.id);
                 Assert.AreNotEqual(0, resultat.uniteEnseignement.periode.annee.diplome.id);
             }
         }
         public void TestFindByUniteEnseignementElementConstitutif()
         {
             // test du fin by libelle
             List<ElementConstitutif> resultatFind = ElementConstitutifDAO.findByUniteEnseignement(87);
             Assert.IsTrue(resultatFind.Count > 0);
                 
         }
        
         public void TestUpdateElementConstitutif()
         {

             List<ElementConstitutif> resultats = ElementConstitutifDAO.findByLibelle("TEST_ElementConstitutif%");
             foreach (ElementConstitutif resultat in resultats)
             {
                 resultat.libelle = "TEST_ElementConstitutif_2";

                 ElementConstitutifDAO.update(resultat);

             }

             List<ElementConstitutif> resultatFind2 = ElementConstitutifDAO.findByLibelle("TEST_ElementConstitutif_2");

             Assert.IsTrue(resultatFind2.Count > 0);
             Assert.IsTrue(resultatFind2.Count == resultats.Count);

         }

         public void TestDeleteElementConstitutif()
         {
             // test du delete
             List<ElementConstitutif> resultatFind = ElementConstitutifDAO.findByLibelle("TEST%");

             foreach (ElementConstitutif resultat in resultatFind)
             {
                 supprimerElementConstitutif(resultat);
             }
             List<ElementConstitutif> resultatFind2 = ElementConstitutifDAO.findByLibelle("TEST%");

             Assert.AreEqual(resultatFind2.Count, 0);
         }

         /** 
          * Methodes pour aider aux tests
          * **/
         public static ElementConstitutif creerElementConstitutif(String libelle)
         {
             ElementConstitutif elementConstitutif = new ElementConstitutif();
             elementConstitutif.libelle = libelle;
             elementConstitutif.uniteEnseignement = UniteEnseignementTest.creerUniteEnseignement(libelle);
             ElementConstitutif resultat = ElementConstitutifDAO.create(elementConstitutif);

             return resultat;
         }

         public static void supprimerElementConstitutif(ElementConstitutif elementConstitutif)
         {
             UniteEnseignementTest.supprimerUniteEnseignement(elementConstitutif.uniteEnseignement);
             ElementConstitutifDAO.delete(elementConstitutif);         
         }
     }
}
