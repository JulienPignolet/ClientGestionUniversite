﻿using ClientGestionUniversite.modele;
using ClientGestionUniversite.viewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.businessLogic
{
    public static class CoursDAO
    {
        private static MySqlConnection _connection = ConnectionMySql.getInstance();

        public static Cours find(long id)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            Cours resultat = new Cours();

            try
            {
                sql = "SELECT cours.id as coursID, cours.volume as coursVolume, cours.groupe as coursGroupe, cours.ec_id, " +
					"type_cours.id AS typeCoursID, type_cours.libelle AS typeCoursLibelle, "+
					"personnel.id AS personnelId, personnel.nom AS personnelNom, personnel.prenom AS personnelPrenom, "+
					"categorie_personnel.id AS categID, categorie_personnel.libelle AS categLibelle, categorie_personnel.volume_horaire as categVolume, "+
					"element_constitutif.id as elemConstID, element_constitutif.libelle as elemConstLibelle, "+
                    "unite_enseignement.id as uniteEnsID, unite_enseignement.libelle as uniteEnsLibelle, "+
                    "periode.id AS periodeID, periode.libelle AS periodeLibelle, "+
                    "annee.id AS anneeId, annee.libelle AS anneeLibelle, "+
                    "diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle "+ 
                    "FROM cours "+
					"JOIN type_cours on cours.type_id = type_cours.id "+
					"JOIN element_constitutif on cours.ec_id = element_constitutif.id "+
					"JOIN personnel on cours.personnel_id = personnel.id "+
					"JOIN categorie_personnel ON personnel.categorie_id = categorie_personnel.id "+
                    "JOIN unite_enseignement on element_constitutif.ue_id = unite_enseignement.id "+
                    "JOIN periode ON unite_enseignement.periode_id = periode.id "+
                    "JOIN annee ON periode.annee_id = annee.id "+
                    "JOIN diplome ON annee.diplome_id = diplome.id "+
                    "WHERE cours.id = @id";

                _cmd.CommandText = sql;
                _cmd.Parameters.AddWithValue("@id", id);
                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Diplome tempDiplome = DiplomeDAO.populateDiplome(reader);

                    Annee tempAnnee = AnneeDAO.populateAnnee(reader);
                    tempAnnee.diplome = tempDiplome;

                    Periode tempPeriode = PeriodeDAO.populatePeriode(reader);
                    tempPeriode.annee = tempAnnee;

                    UniteEnseignement tempUnite = UniteEnseignementDAO.populateUniteEnseignement(reader);
                    tempUnite.periode = tempPeriode;

                    ElementConstitutif tempElemConstitutif = ElementConstitutifDAO.populateElementConstitutif(reader);
                    tempElemConstitutif.uniteEnseignement = tempUnite;
                    
                    // champ du cours
                    resultat = populateCours(reader);
                    // ajout element constitutif
                    resultat.elementConstitutif = tempElemConstitutif;
                    // ajout type de cours
                    TypeCours tempTypeCours = TypeCoursDAO.populateTypeCours(reader);
                    resultat.typeCours = tempTypeCours;
                    // ajout intervenant et sa categorie
                    CategoriePersonnel tempCategPersonnel = CategoriePersonnelDAO.populateCategoriePersonnel(reader);
                    Personnel tempPersonnel = PersonnelDAO.populatePersonnel(reader);
                    tempPersonnel.categoriePersonnel = tempCategPersonnel;
                    resultat.intervenant = tempPersonnel;
             
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e);
            }
            _cmd.Dispose();

            return resultat;
        }

        public static List<Cours> findAllCours()
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<Cours> resultats = new List<Cours>();

            try
            {
                sql = "SELECT cours.id as coursID, cours.volume as coursVolume, cours.groupe as coursGroupe, cours.ec_id, " +
                    "type_cours.id AS typeCoursID, type_cours.libelle AS typeCoursLibelle, " +
                    "personnel.id AS personnelId, personnel.nom AS personnelNom, personnel.prenom AS personnelPrenom, " +
                    "categorie_personnel.id AS categID, categorie_personnel.libelle AS categLibelle, categorie_personnel.volume_horaire as categVolume, " +
                    "element_constitutif.id as elemConstID, element_constitutif.libelle as elemConstLibelle, " +
                    "unite_enseignement.id as uniteEnsID, unite_enseignement.libelle as uniteEnsLibelle, " +
                    "periode.id AS periodeID, periode.libelle AS periodeLibelle, " +
                    "annee.id AS anneeId, annee.libelle AS anneeLibelle, " +
                    "diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle " +
                    "FROM cours " +
                    "JOIN type_cours on cours.type_id = type_cours.id " +
                    "JOIN element_constitutif on cours.ec_id = element_constitutif.id " +
                    "JOIN personnel on cours.personnel_id = personnel.id " +
                    "JOIN categorie_personnel ON personnel.categorie_id = categorie_personnel.id " +
                    "JOIN unite_enseignement on element_constitutif.ue_id = unite_enseignement.id " +
                    "JOIN periode ON unite_enseignement.periode_id = periode.id " +
                    "JOIN annee ON periode.annee_id = annee.id " +
                    "JOIN diplome ON annee.diplome_id = diplome.id ";

                _cmd.CommandText = sql;

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cours resultat = populateCours(reader);

                    Diplome tempDiplome = DiplomeDAO.populateDiplome(reader);

                    Annee tempAnnee = AnneeDAO.populateAnnee(reader);
                    tempAnnee.diplome = tempDiplome;

                    Periode tempPeriode = PeriodeDAO.populatePeriode(reader);
                    tempPeriode.annee = tempAnnee;

                    UniteEnseignement tempUnite = UniteEnseignementDAO.populateUniteEnseignement(reader);
                    tempUnite.periode = tempPeriode;

                    ElementConstitutif tempElemConstitutif = ElementConstitutifDAO.populateElementConstitutif(reader);
                    tempElemConstitutif.uniteEnseignement = tempUnite;

                    // champ du cours
                    resultat = populateCours(reader);
                    // ajout element constitutif
                    resultat.elementConstitutif = tempElemConstitutif;
                    // ajout type de cours
                    TypeCours tempTypeCours = TypeCoursDAO.populateTypeCours(reader);
                    resultat.typeCours = tempTypeCours;
                    // ajout intervenant et sa categorie
                    CategoriePersonnel tempCategPersonnel = CategoriePersonnelDAO.populateCategoriePersonnel(reader);
                    Personnel tempPersonnel = PersonnelDAO.populatePersonnel(reader);
                    tempPersonnel.categoriePersonnel = tempCategPersonnel;
                    resultat.intervenant = tempPersonnel;

                    resultats.Add(resultat);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e);
            }
            _cmd.Dispose();

            return resultats;
        }

        public static List<Cours> findByGroupe(int groupe)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<Cours> resultats = new List<Cours>();

            try
            {
                sql = "SELECT cours.id as coursID, cours.volume as coursVolume, cours.groupe as coursGroupe, cours.ec_id, " +
                    "type_cours.id AS typeCoursID, type_cours.libelle AS typeCoursLibelle, " +
                    "personnel.id AS personnelId, personnel.nom AS personnelNom, personnel.prenom AS personnelPrenom, " +
                    "categorie_personnel.id AS categID, categorie_personnel.libelle AS categLibelle, categorie_personnel.volume_horaire as categVolume, " +
                    "element_constitutif.id as elemConstID, element_constitutif.libelle as elemConstLibelle, " +
                    "unite_enseignement.id as uniteEnsID, unite_enseignement.libelle as uniteEnsLibelle, " +
                    "periode.id AS periodeID, periode.libelle AS periodeLibelle, " +
                    "annee.id AS anneeId, annee.libelle AS anneeLibelle, " +
                    "diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle " +
                    "FROM cours " +
                    "JOIN type_cours on cours.type_id = type_cours.id " +
                    "JOIN element_constitutif on cours.ec_id = element_constitutif.id " +
                    "JOIN personnel on cours.personnel_id = personnel.id " +
                    "JOIN categorie_personnel ON personnel.categorie_id = categorie_personnel.id " +
                    "JOIN unite_enseignement on element_constitutif.ue_id = unite_enseignement.id " +
                    "JOIN periode ON unite_enseignement.periode_id = periode.id " +
                    "JOIN annee ON periode.annee_id = annee.id " +
                    "JOIN diplome ON annee.diplome_id = diplome.id "+
                    "WHERE cours.groupe = @groupe";

                _cmd.CommandText = sql;
                _cmd.Parameters.AddWithValue("@groupe", groupe);
                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cours resultat = populateCours(reader);

                    Diplome tempDiplome = DiplomeDAO.populateDiplome(reader);

                    Annee tempAnnee = AnneeDAO.populateAnnee(reader);
                    tempAnnee.diplome = tempDiplome;

                    Periode tempPeriode = PeriodeDAO.populatePeriode(reader);
                    tempPeriode.annee = tempAnnee;

                    UniteEnseignement tempUnite = UniteEnseignementDAO.populateUniteEnseignement(reader);
                    tempUnite.periode = tempPeriode;

                    ElementConstitutif tempElemConstitutif = ElementConstitutifDAO.populateElementConstitutif(reader);
                    tempElemConstitutif.uniteEnseignement = tempUnite;

                    // champ du cours
                    resultat = populateCours(reader);
                    // ajout element constitutif
                    resultat.elementConstitutif = tempElemConstitutif;
                    // ajout type de cours
                    TypeCours tempTypeCours = TypeCoursDAO.populateTypeCours(reader);
                    resultat.typeCours = tempTypeCours;
                    // ajout intervenant et sa categorie
                    CategoriePersonnel tempCategPersonnel = CategoriePersonnelDAO.populateCategoriePersonnel(reader);
                    Personnel tempPersonnel = PersonnelDAO.populatePersonnel(reader);
                    tempPersonnel.categoriePersonnel = tempCategPersonnel;
                    resultat.intervenant = tempPersonnel;

                    resultats.Add(resultat);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e);
            }
            _cmd.Dispose();

            return resultats;
        }

        public static List<Cours> findByElementConstitutif(long id)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<Cours> resultats = new List<Cours>();

            try
            {
                sql = "SELECT cours.id as coursID, cours.volume as coursVolume, cours.groupe as coursGroupe, cours.ec_id, " +
                    "type_cours.id AS typeCoursID, type_cours.libelle AS typeCoursLibelle, " +
                    "personnel.id AS personnelId, personnel.nom AS personnelNom, personnel.prenom AS personnelPrenom, " +
                    "categorie_personnel.id AS categID, categorie_personnel.libelle AS categLibelle, categorie_personnel.volume_horaire as categVolume, " +
                    "element_constitutif.id as elemConstID, element_constitutif.libelle as elemConstLibelle, " +
                    "unite_enseignement.id as uniteEnsID, unite_enseignement.libelle as uniteEnsLibelle, " +
                    "periode.id AS periodeID, periode.libelle AS periodeLibelle, " +
                    "annee.id AS anneeId, annee.libelle AS anneeLibelle, " +
                    "diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle " +
                    "FROM cours " +
                    "JOIN type_cours on cours.type_id = type_cours.id " +
                    "JOIN element_constitutif on cours.ec_id = element_constitutif.id " +
                    "JOIN personnel on cours.personnel_id = personnel.id " +
                    "JOIN categorie_personnel ON personnel.categorie_id = categorie_personnel.id " +
                    "JOIN unite_enseignement on element_constitutif.ue_id = unite_enseignement.id " +
                    "JOIN periode ON unite_enseignement.periode_id = periode.id " +
                    "JOIN annee ON periode.annee_id = annee.id " +
                    "JOIN diplome ON annee.diplome_id = diplome.id " +
                    "WHERE element_constitutif.id = @id";

                _cmd.CommandText = sql;
                _cmd.Parameters.AddWithValue("@id", id);
                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cours resultat = populateCours(reader);

                    Diplome tempDiplome = DiplomeDAO.populateDiplome(reader);

                    Annee tempAnnee = AnneeDAO.populateAnnee(reader);
                    tempAnnee.diplome = tempDiplome;

                    Periode tempPeriode = PeriodeDAO.populatePeriode(reader);
                    tempPeriode.annee = tempAnnee;

                    UniteEnseignement tempUnite = UniteEnseignementDAO.populateUniteEnseignement(reader);
                    tempUnite.periode = tempPeriode;

                    ElementConstitutif tempElemConstitutif = ElementConstitutifDAO.populateElementConstitutif(reader);
                    tempElemConstitutif.uniteEnseignement = tempUnite;

                    // champ du cours
                    resultat = populateCours(reader);
                    // ajout element constitutif
                    resultat.elementConstitutif = tempElemConstitutif;
                    // ajout type de cours
                    TypeCours tempTypeCours = TypeCoursDAO.populateTypeCours(reader);
                    resultat.typeCours = tempTypeCours;
                    // ajout intervenant et sa categorie
                    CategoriePersonnel tempCategPersonnel = CategoriePersonnelDAO.populateCategoriePersonnel(reader);
                    Personnel tempPersonnel = PersonnelDAO.populatePersonnel(reader);
                    tempPersonnel.categoriePersonnel = tempCategPersonnel;
                    resultat.intervenant = tempPersonnel;

                    resultats.Add(resultat);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e);
            }
            _cmd.Dispose();

            return resultats;
        }

        public static List<Cours> findByPersonnel(long id)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<Cours> resultats = new List<Cours>();

            try
            {
                sql = "SELECT cours.id as coursID, cours.volume as coursVolume, cours.groupe as coursGroupe, cours.ec_id, " +
                    "type_cours.id AS typeCoursID, type_cours.libelle AS typeCoursLibelle, " +
                    "personnel.id AS personnelId, personnel.nom AS personnelNom, personnel.prenom AS personnelPrenom, " +
                    "categorie_personnel.id AS categID, categorie_personnel.libelle AS categLibelle, categorie_personnel.volume_horaire as categVolume, " +
                    "element_constitutif.id as elemConstID, element_constitutif.libelle as elemConstLibelle, " +
                    "unite_enseignement.id as uniteEnsID, unite_enseignement.libelle as uniteEnsLibelle, " +
                    "periode.id AS periodeID, periode.libelle AS periodeLibelle, " +
                    "annee.id AS anneeId, annee.libelle AS anneeLibelle, " +
                    "diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle " +
                    "FROM cours " +
                    "JOIN type_cours on cours.type_id = type_cours.id " +
                    "JOIN element_constitutif on cours.ec_id = element_constitutif.id " +
                    "JOIN personnel on cours.personnel_id = personnel.id " +
                    "JOIN categorie_personnel ON personnel.categorie_id = categorie_personnel.id " +
                    "JOIN unite_enseignement on element_constitutif.ue_id = unite_enseignement.id " +
                    "JOIN periode ON unite_enseignement.periode_id = periode.id " +
                    "JOIN annee ON periode.annee_id = annee.id " +
                    "JOIN diplome ON annee.diplome_id = diplome.id " +
                    "WHERE personnel.id = @id";

                _cmd.CommandText = sql;
                _cmd.Parameters.AddWithValue("@id", id);
                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cours resultat = populateCours(reader);

                    Diplome tempDiplome = DiplomeDAO.populateDiplome(reader);

                    Annee tempAnnee = AnneeDAO.populateAnnee(reader);
                    tempAnnee.diplome = tempDiplome;

                    Periode tempPeriode = PeriodeDAO.populatePeriode(reader);
                    tempPeriode.annee = tempAnnee;

                    UniteEnseignement tempUnite = UniteEnseignementDAO.populateUniteEnseignement(reader);
                    tempUnite.periode = tempPeriode;

                    ElementConstitutif tempElemConstitutif = ElementConstitutifDAO.populateElementConstitutif(reader);
                    tempElemConstitutif.uniteEnseignement = tempUnite;

                    // champ du cours
                    resultat = populateCours(reader);
                    // ajout element constitutif
                    resultat.elementConstitutif = tempElemConstitutif;
                    // ajout type de cours
                    TypeCours tempTypeCours = TypeCoursDAO.populateTypeCours(reader);
                    resultat.typeCours = tempTypeCours;
                    // ajout intervenant et sa categorie
                    CategoriePersonnel tempCategPersonnel = CategoriePersonnelDAO.populateCategoriePersonnel(reader);
                    Personnel tempPersonnel = PersonnelDAO.populatePersonnel(reader);
                    tempPersonnel.categoriePersonnel = tempCategPersonnel;
                    resultat.intervenant = tempPersonnel;

                    resultats.Add(resultat);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e);
            }
            _cmd.Dispose();

            return resultats;
        }

        public static Cours create(Cours obj)
        {

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "INSERT INTO cours (id, ec_id, volume,type_id,personnel_id,groupe) "+
                "VALUES (@id,@ec_id,@volume,@type_id,@personnel_id,@groupe) ";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", obj.id);
                _cmd.Parameters.AddWithValue("@ec_id", obj.elementConstitutif.id);
                _cmd.Parameters.AddWithValue("@volume", obj.volumeHoraire);
                _cmd.Parameters.AddWithValue("@type_id", obj.typeCours.id);
                _cmd.Parameters.AddWithValue("@personnel_id", obj.intervenant.id);
                _cmd.Parameters.AddWithValue("@groupe", obj.numeroGroupe);

                _cmd.ExecuteNonQuery();

                obj.id = _cmd.LastInsertedId;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e);
            }

            _cmd.Dispose();

            return obj;

        }

        public static Cours update(Cours obj)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "UPDATE cours set volume = @volume, groupe = @groupe, ec_id = @ec_id, "+
                    "type_id = @type_id, personnel_id = @personnel_id WHERE id = @id";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", obj.id);
                _cmd.Parameters.AddWithValue("@ec_id", obj.elementConstitutif.id);
                _cmd.Parameters.AddWithValue("@volume", obj.volumeHoraire);
                _cmd.Parameters.AddWithValue("@type_id", obj.typeCours.id);
                _cmd.Parameters.AddWithValue("@personnel_id", obj.intervenant.id);
                _cmd.Parameters.AddWithValue("@groupe", obj.numeroGroupe);
                _cmd.ExecuteNonQuery();

                obj.id = _cmd.LastInsertedId;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e);
            }

            _cmd.Dispose();

            return obj;
        }

        public static void delete(Cours obj)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "DELETE FROM cours WHERE id = @id";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", obj.id);

                _cmd.ExecuteNonQuery();

                obj.id = _cmd.LastInsertedId;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e);
            }
            _cmd.Dispose();
        }

        public static Cours populateCours(MySqlDataReader reader)
        {
            Cours resultat = new Cours();

            resultat.id = Convert.ToInt64(reader["coursID"]);
            resultat.volumeHoraire = Convert.ToInt32(reader["coursVolume"]);
            resultat.numeroGroupe = Convert.ToInt32(reader["coursGroupe"]);

            return resultat;
        }
        
        public static List<CoursParPersonnelViewModel> findAll()
        {
            List<CoursParPersonnelViewModel> res = new List<CoursParPersonnelViewModel>();
            res.Add(new CoursParPersonnelViewModel("Mathématique", "CM", 10));
            res.Add(new CoursParPersonnelViewModel("Mathématique", "CM", 10));
            return res;
        }
    }
}
