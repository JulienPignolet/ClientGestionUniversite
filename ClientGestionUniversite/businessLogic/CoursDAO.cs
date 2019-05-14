using ClientGestionUniversite.modele;
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
        public static Cours find(long id)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

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
                    "LEFT JOIN type_cours on cours.type_id = type_cours.id " +
                    "LEFT JOIN element_constitutif on cours.ec_id = element_constitutif.id " +
                    "LEFT JOIN personnel on cours.personnel_id = personnel.id " +
                    "LEFT JOIN categorie_personnel ON personnel.categorie_id = categorie_personnel.id " +
                    "LEFT JOIN unite_enseignement on element_constitutif.ue_id = unite_enseignement.id " +
                    "LEFT JOIN periode ON unite_enseignement.periode_id = periode.id " +
                    "LEFT JOIN annee ON periode.annee_id = annee.id " +
                    "LEFT JOIN diplome ON annee.diplome_id = diplome.id " +
                    "WHERE cours.id = @id";

                _cmd.CommandText = sql;
                _cmd.Parameters.AddWithValue("@id", id);
                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Diplome tempDiplome = DiplomeDAO.populateDiplome(reader);

                    Annee tempAnnee = AnneeDAO.populateAnnee(reader);
                    if (tempDiplome != null) tempAnnee.diplome = tempDiplome;

                    Periode tempPeriode = PeriodeDAO.populatePeriode(reader);
                    if (tempPeriode != null) tempPeriode.annee = tempAnnee;

                    UniteEnseignement tempUnite = UniteEnseignementDAO.populateUniteEnseignement(reader);
                    if (tempUnite != null) tempUnite.periode = tempPeriode;

                    ElementConstitutif tempElemConstitutif = ElementConstitutifDAO.populateElementConstitutif(reader);
                    if (tempElemConstitutif != null) tempElemConstitutif.uniteEnseignement = tempUnite;

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
                    if (tempPersonnel != null) tempPersonnel.categoriePersonnel = tempCategPersonnel;
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
            MySqlConnection _connection = ConnectionMySql.getInstance();

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
                    "LEFT JOIN type_cours on cours.type_id = type_cours.id " +
                    "LEFT JOIN element_constitutif on cours.ec_id = element_constitutif.id " +
                    "LEFT JOIN personnel on cours.personnel_id = personnel.id " +
                    "LEFT JOIN categorie_personnel ON personnel.categorie_id = categorie_personnel.id " +
                    "LEFT JOIN unite_enseignement on element_constitutif.ue_id = unite_enseignement.id " +
                    "LEFT JOIN periode ON unite_enseignement.periode_id = periode.id " +
                    "LEFT JOIN annee ON periode.annee_id = annee.id " +
                    "LEFT JOIN diplome ON annee.diplome_id = diplome.id ";

                _cmd.CommandText = sql;

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cours resultat = populateCours(reader);

                    Diplome tempDiplome = DiplomeDAO.populateDiplome(reader);

                    Annee tempAnnee = AnneeDAO.populateAnnee(reader);
                    if (tempDiplome != null) tempAnnee.diplome = tempDiplome;

                    Periode tempPeriode = PeriodeDAO.populatePeriode(reader);
                    if (tempPeriode != null) tempPeriode.annee = tempAnnee;

                    UniteEnseignement tempUnite = UniteEnseignementDAO.populateUniteEnseignement(reader);
                    if (tempUnite != null) tempUnite.periode = tempPeriode;

                    ElementConstitutif tempElemConstitutif = ElementConstitutifDAO.populateElementConstitutif(reader);
                    if (tempElemConstitutif != null) tempElemConstitutif.uniteEnseignement = tempUnite;

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
                    if (tempPersonnel != null) tempPersonnel.categoriePersonnel = tempCategPersonnel;
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
            MySqlConnection _connection = ConnectionMySql.getInstance();

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
                    "LEFT JOIN type_cours on cours.type_id = type_cours.id " +
                    "LEFT JOIN element_constitutif on cours.ec_id = element_constitutif.id " +
                    "LEFT JOIN personnel on cours.personnel_id = personnel.id " +
                    "LEFT JOIN categorie_personnel ON personnel.categorie_id = categorie_personnel.id " +
                    "LEFT JOIN unite_enseignement on element_constitutif.ue_id = unite_enseignement.id " +
                    "LEFT JOIN periode ON unite_enseignement.periode_id = periode.id " +
                    "LEFT JOIN annee ON periode.annee_id = annee.id " +
                    "LEFT JOIN diplome ON annee.diplome_id = diplome.id " +
                    "WHERE cours.groupe = @groupe";

                _cmd.CommandText = sql;
                _cmd.Parameters.AddWithValue("@groupe", groupe);
                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cours resultat = populateCours(reader);

                    Diplome tempDiplome = DiplomeDAO.populateDiplome(reader);

                    Annee tempAnnee = AnneeDAO.populateAnnee(reader);
                    if(tempDiplome != null) tempAnnee.diplome = tempDiplome;

                    Periode tempPeriode = PeriodeDAO.populatePeriode(reader);
                    if (tempPeriode != null) tempPeriode.annee = tempAnnee;

                    UniteEnseignement tempUnite = UniteEnseignementDAO.populateUniteEnseignement(reader);
                    if (tempUnite != null) tempUnite.periode = tempPeriode;

                    ElementConstitutif tempElemConstitutif = ElementConstitutifDAO.populateElementConstitutif(reader);
                    if (tempElemConstitutif != null) tempElemConstitutif.uniteEnseignement = tempUnite;

                    // champ du cours
                    resultat = populateCours(reader);
                    // ajout element constitutif
                    if (tempElemConstitutif != null) resultat.elementConstitutif = tempElemConstitutif;
                    // ajout type de cours
                    TypeCours tempTypeCours = TypeCoursDAO.populateTypeCours(reader);
                    if (tempTypeCours != null) resultat.typeCours = tempTypeCours;
                    // ajout intervenant et sa categorie
                    CategoriePersonnel tempCategPersonnel = CategoriePersonnelDAO.populateCategoriePersonnel(reader);
                    Personnel tempPersonnel = PersonnelDAO.populatePersonnel(reader);
                    if (tempPersonnel != null) tempPersonnel.categoriePersonnel = tempCategPersonnel;
                    if (tempPersonnel != null) resultat.intervenant = tempPersonnel;

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
            MySqlConnection _connection = ConnectionMySql.getInstance();

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
                    "LEFT JOIN type_cours on cours.type_id = type_cours.id " +
                    "LEFT JOIN element_constitutif on cours.ec_id = element_constitutif.id " +
                    "LEFT JOIN personnel on cours.personnel_id = personnel.id " +
                    "LEFT JOIN categorie_personnel ON personnel.categorie_id = categorie_personnel.id " +
                    "LEFT JOIN unite_enseignement on element_constitutif.ue_id = unite_enseignement.id " +
                    "LEFT JOIN periode ON unite_enseignement.periode_id = periode.id " +
                    "LEFT JOIN annee ON periode.annee_id = annee.id " +
                    "LEFT JOIN diplome ON annee.diplome_id = diplome.id " +
                    "WHERE element_constitutif.id = @id";

                _cmd.CommandText = sql;
                _cmd.Parameters.AddWithValue("@id", id);
                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cours resultat = populateCours(reader);

                    Diplome tempDiplome = DiplomeDAO.populateDiplome(reader);

                    Annee tempAnnee = AnneeDAO.populateAnnee(reader);
                    if (tempDiplome != null) tempAnnee.diplome = tempDiplome;

                    Periode tempPeriode = PeriodeDAO.populatePeriode(reader);
                    if (tempPeriode != null) tempPeriode.annee = tempAnnee;

                    UniteEnseignement tempUnite = UniteEnseignementDAO.populateUniteEnseignement(reader);
                    if (tempUnite != null) tempUnite.periode = tempPeriode;

                    ElementConstitutif tempElemConstitutif = ElementConstitutifDAO.populateElementConstitutif(reader);
                    if (tempElemConstitutif != null) tempElemConstitutif.uniteEnseignement = tempUnite;

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
                    if (tempPersonnel != null) tempPersonnel.categoriePersonnel = tempCategPersonnel;
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
            MySqlConnection _connection = ConnectionMySql.getInstance();

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
                    "LEFT JOIN type_cours on cours.type_id = type_cours.id " +
                    "LEFT JOIN element_constitutif on cours.ec_id = element_constitutif.id " +
                    "LEFT JOIN personnel on cours.personnel_id = personnel.id " +
                    "LEFT JOIN categorie_personnel ON personnel.categorie_id = categorie_personnel.id " +
                    "LEFT JOIN unite_enseignement on element_constitutif.ue_id = unite_enseignement.id " +
                    "LEFT JOIN periode ON unite_enseignement.periode_id = periode.id " +
                    "LEFT JOIN annee ON periode.annee_id = annee.id " +
                    "LEFT JOIN diplome ON annee.diplome_id = diplome.id " +
                    "WHERE personnel.id = @id";

                _cmd.CommandText = sql;
                _cmd.Parameters.AddWithValue("@id", id);
                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cours resultat = populateCours(reader);

                    Diplome tempDiplome = DiplomeDAO.populateDiplome(reader);

                    Annee tempAnnee = AnneeDAO.populateAnnee(reader);
                    if (tempDiplome != null) tempAnnee.diplome = tempDiplome;

                    Periode tempPeriode = PeriodeDAO.populatePeriode(reader);
                    if (tempPeriode != null) tempPeriode.annee = tempAnnee;

                    UniteEnseignement tempUnite = UniteEnseignementDAO.populateUniteEnseignement(reader);
                    if (tempUnite != null) tempUnite.periode = tempPeriode;

                    ElementConstitutif tempElemConstitutif = ElementConstitutifDAO.populateElementConstitutif(reader);
                    if (tempElemConstitutif != null) tempElemConstitutif.uniteEnseignement = tempUnite;

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
                    if (tempPersonnel != null) tempPersonnel.categoriePersonnel = tempCategPersonnel;
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
            MySqlConnection _connection = ConnectionMySql.getInstance();

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
                if (obj.intervenant != null) {
                    _cmd.Parameters.AddWithValue("@personnel_id", obj.intervenant.id);
                }
                else
                {
                    _cmd.Parameters.AddWithValue("@personnel_id", DBNull.Value);
                }
               
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

        public static void updateIntervenant(long? idPersonnel, long idCours)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "UPDATE cours set personnel_id = @personnel_id WHERE id = @idCours";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@idCours", idCours);
                _cmd.Parameters.AddWithValue("@personnel_id", idPersonnel);
                _cmd.ExecuteNonQuery();


            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e);
            }

            _cmd.Dispose();

        }

        public static int getVolumeCoursByPersonnel(long idPersonnel)
        {
            int res = 0;

            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "select sum(volume) from cours where personnel_id = @idPersonnel";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@idPersonnel", idPersonnel);
                _cmd.ExecuteNonQuery();


            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e);
            }

            _cmd.Dispose();

            return res;
        }
        public static void update(Cours Cours)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "UPDATE cours set ec_id = @ecId, volume = @volume, type_id = @idTypeCours, groupe = @groupe WHERE id = @idCours";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@idCours", Cours.id);
                _cmd.Parameters.AddWithValue("@ecId", Cours.elementConstitutif.id);
                _cmd.Parameters.AddWithValue("@volume", Cours.volumeHoraire);
                _cmd.Parameters.AddWithValue("@idTypeCours", Cours.typeCours.id);
                _cmd.Parameters.AddWithValue("@groupe", Cours.numeroGroupe);
                _cmd.ExecuteNonQuery();


            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e);
            }

            _cmd.Dispose();

        }
   

        public static void delete(Cours obj)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

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
            if (!reader.IsDBNull(reader.GetOrdinal("coursGroupe")))
            {
                resultat.numeroGroupe = (String)reader["coursGroupe"];
            }
            return resultat;
        }
    }
}
