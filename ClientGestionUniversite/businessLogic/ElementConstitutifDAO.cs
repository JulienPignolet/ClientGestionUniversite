using System;
using ClientGestionUniversite.modele;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.businessLogic
{
    public static class ElementConstitutifDAO
    {
        public static MySqlConnection _connection = ConnectionMySql.getInstance();

        public static ElementConstitutif find(long id)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            ElementConstitutif resultat = new ElementConstitutif();

            try
            {
                sql = "SELECT element_constitutif.id as elemConstID, element_constitutif.libelle as elemConstLibelle, "
                    + "unite_enseignement.id as uniteEnsID, unite_enseignement.libelle as uniteEnsLibelle, "
                    + "periode.id AS periodeID, periode.libelle AS periodeLibelle, "
                    + "annee.id AS anneeId, annee.libelle AS anneeLibelle, "
                    + "diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle "
                    + "FROM element_constitutif "
                    + "JOIN unite_enseignement on element_constitutif.ue_id = unite_enseignement.id "
                    + "JOIN periode ON unite_enseignement.periode_id = periode.id "
                    + "JOIN annee ON periode.annee_id = annee.id "
                    + "JOIN diplome ON annee.diplome_id = diplome.id "
                    + "WHERE element_constitutif.id = @id";

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

                    resultat = populateElementConstitutif(reader);
                    resultat.uniteEnseignement = tempUnite;

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

        public static List<ElementConstitutif> findAll()
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<ElementConstitutif> resultats = new List<ElementConstitutif>();

            try
            {
                sql = "SELECT element_constitutif.id as elemConstID, element_constitutif.libelle as elemConstLibelle, "
                    + "unite_enseignement.id as uniteEnsID, unite_enseignement.libelle as uniteEnsLibelle, "
                    + "periode.id AS periodeID, periode.libelle AS periodeLibelle, "
                    + "annee.id AS anneeId, annee.libelle AS anneeLibelle, "
                    + "diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle "
                    + "FROM element_constitutif "
                    + "JOIN unite_enseignement on element_constitutif.ue_id = unite_enseignement.id "
                    + "JOIN periode ON unite_enseignement.periode_id = periode.id "
                    + "JOIN annee ON periode.annee_id = annee.id "
                    + "JOIN diplome ON annee.diplome_id = diplome.id ";

                _cmd.CommandText = sql;

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

                    ElementConstitutif tempElementConstitutif = populateElementConstitutif(reader);
                    tempElementConstitutif.uniteEnseignement = tempUnite;

                    resultats.Add(tempElementConstitutif);
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

        public static List<ElementConstitutif> findByLibelle(String libelle)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<ElementConstitutif> resultats = new List<ElementConstitutif>();

            try
            {
                sql = "SELECT element_constitutif.id as elemConstID, element_constitutif.libelle as elemConstLibelle, "
                    + "unite_enseignement.id as uniteEnsID, unite_enseignement.libelle as uniteEnsLibelle, "
                    + "periode.id AS periodeID, periode.libelle AS periodeLibelle, "
                    + "annee.id AS anneeId, annee.libelle AS anneeLibelle, "
                    + "diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle "
                    + "FROM element_constitutif "
                    + "JOIN unite_enseignement on element_constitutif.ue_id = unite_enseignement.id "
                    + "JOIN periode ON unite_enseignement.periode_id = periode.id "
                    + "JOIN annee ON periode.annee_id = annee.id "
                    + "JOIN diplome ON annee.diplome_id = diplome.id "
                    + "WHERE element_constitutif.libelle LIKE @libelle";

                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@libelle", libelle);
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

                    ElementConstitutif tempElementConstitutif = populateElementConstitutif(reader);
                    tempElementConstitutif.uniteEnseignement = tempUnite;

                    resultats.Add(tempElementConstitutif);
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

        public static List<ElementConstitutif> findByUniteEnseignement(long id)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<ElementConstitutif> resultats = new List<ElementConstitutif>();

            try
            {
                sql = "SELECT element_constitutif.id as elemConstID, element_constitutif.libelle as elemConstLibelle, "
                    + "unite_enseignement.id as uniteEnsID, unite_enseignement.libelle as uniteEnsLibelle, "
                    + "periode.id AS periodeID, periode.libelle AS periodeLibelle, "
                    + "annee.id AS anneeId, annee.libelle AS anneeLibelle, "
                    + "diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle "
                    + "FROM element_constitutif "
                    + "JOIN unite_enseignement on element_constitutif.ue_id = unite_enseignement.id "
                    + "JOIN periode ON unite_enseignement.periode_id = periode.id "
                    + "JOIN annee ON periode.annee_id = annee.id "
                    + "JOIN diplome ON annee.diplome_id = diplome.id "
                    + "WHERE unite_enseignement.id = @id";

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

                    ElementConstitutif tempElementConstitutif = populateElementConstitutif(reader);
                    tempElementConstitutif.uniteEnseignement = tempUnite;

                    resultats.Add(tempElementConstitutif);
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

        public static ElementConstitutif create(ElementConstitutif obj)
        {

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "INSERT INTO element_constitutif (id, libelle, ue_id) VALUES (@id,@libelle,@UniteEnseignement) ";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", obj.id);
                _cmd.Parameters.AddWithValue("@libelle", obj.libelle);
                _cmd.Parameters.AddWithValue("@UniteEnseignement", obj.uniteEnseignement.id);

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

        public static ElementConstitutif update(ElementConstitutif obj)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "UPDATE element_constitutif set libelle = @libelle, ue_id = @ue_id WHERE id = @id";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", obj.id);
                _cmd.Parameters.AddWithValue("@libelle", obj.libelle);
                _cmd.Parameters.AddWithValue("@ue_id", obj.uniteEnseignement.id);

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

        public static void delete(ElementConstitutif obj)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "DELETE FROM element_constitutif WHERE id = @id";
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

        public static ElementConstitutif populateElementConstitutif(MySqlDataReader reader)
        {
            ElementConstitutif resultat = new ElementConstitutif();

            resultat.id = Convert.ToInt64(reader["elemConstID"]);
            resultat.libelle = (String)reader["elemConstLibelle"];

            return resultat;
        }
    }
}
