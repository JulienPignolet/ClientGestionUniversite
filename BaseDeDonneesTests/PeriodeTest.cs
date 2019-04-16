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
    public class PeriodeTest
    {

        [TestMethod]
        public void executeTestsPeriode()
        {
            TestFindAll(); // DEBUG PURPOSE : add breakpoint in it
            TestFind();
            TestCreationPeriode();
            TestPeriodeLienAvecAnnee();
            TestFindByLibellePeriode();
            TestUpdatePeriode();
            TestDeletePeriode();
        }

        public void TestFindAll()
        {
            // test du fin by libelle
            List<Periode> resultatFind = PeriodeDAO.findAll();
            foreach (Periode periode in resultatFind)
            {
                Assert.AreNotEqual(0, periode.annee.id);
                Assert.AreNotEqual(0, periode.annee.diplome.id);
            }
        }

        public void TestFind()
        {
            // test du find simple
            Periode resultatFind = PeriodeDAO.find(1);
            Assert.AreEqual("S1", resultatFind.libelle);
            Assert.AreEqual(1, resultatFind.annee.id);
            Assert.AreNotEqual(0, resultatFind.annee.diplome.id);
        }
        public void TestCreationPeriode()
        {
            // test la création d'une annee et la recherche grace à son libelle
            Periode resultat = creerPeriode("TEST_PERIODE");

            Assert.AreNotEqual("", resultat.libelle);
            Assert.AreEqual("TEST_PERIODE", resultat.libelle);
            Assert.IsTrue(resultat.id > 0);

        }

        public void TestPeriodeLienAvecAnnee()
        {
            List<Periode> resultats = PeriodeDAO.findByLibelle("TEST_PERIODE");
            foreach (Periode periode in resultats)
            {
                Assert.AreEqual("TEST_PERIODE", periode.libelle);
                Assert.AreNotEqual(0, periode.annee);
                Assert.AreNotEqual(0, periode.annee.diplome);
            }
        }

        public void TestFindByLibellePeriode()
        {
            // test du fin by libelle
            List<Periode> resultatFind = PeriodeDAO.findByLibelle("TEST_PERIODE");
            foreach (Periode periode in resultatFind)
            {
                Assert.AreEqual("TEST_PERIODE", periode.libelle);
                Assert.AreNotEqual(0, periode.annee.id);
                Assert.AreNotEqual(0, periode.annee.diplome.id);
            }
        }

        public void TestUpdatePeriode()
        {

            List<Periode> periodes = PeriodeDAO.findByLibelle("TEST_PERIODE%");
            foreach (Periode periode in periodes)
            {
                periode.libelle = "TEST_PERIODE_2";

                PeriodeDAO.update(periode);

            }

            List<Periode> resultatFind2 = PeriodeDAO.findByLibelle("TEST_PERIODE_2");

            Assert.IsTrue(resultatFind2.Count > 0);
            Assert.IsTrue(resultatFind2.Count == periodes.Count);

        }

        public void TestDeletePeriode()
        {
            // test du delete
            List<Periode> resultatFind = PeriodeDAO.findByLibelle("TEST%");

            foreach (Periode periode in resultatFind)
            {
                supprimerPeriode(periode);
            }
            List<Periode> resultatFind2 = PeriodeDAO.findByLibelle("TEST%");

            Assert.AreEqual(resultatFind2.Count, 0);
        }

        /** 
         * Methodes pour aider aux tests
         * **/
        public static Periode creerPeriode(String libelle)
        {
            Periode periode = new Periode();
            periode.libelle = libelle;
            periode.annee = AnneeTest.creerAnnee(libelle);
            Periode resultat = PeriodeDAO.create(periode);

            return resultat;
        }

        public static void supprimerPeriode(Periode periode)
        {
                AnneeTest.supprimerAnnee(periode.annee);
                PeriodeDAO.delete(periode);
        }
    }
}
