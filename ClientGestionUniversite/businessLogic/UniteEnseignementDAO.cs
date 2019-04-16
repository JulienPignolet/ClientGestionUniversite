using ClientGestionUniversite.modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.businessLogic
{
    public static class UniteEnseignementDAO
    {
        public static MySqlConnection _connection = ConnectionMySql.getInstance();

        public static UniteEnseignement find(long id)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            UniteEnseignement resultat = new UniteEnseignement();

            try
            {
                sql = "SELECT unite_enseignement.id as uniteEnsID, unite_enseignement.libelle as uniteEnsLibelle, "
                    + "periode.id AS periodeID, periode.libelle AS periodeLibelle, "
                    + "annee.id AS anneeId, annee.libelle AS anneeLibelle, "
                    + "diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle "
                    + "FROM unite_enseignement "
                    + "JOIN periode ON unite_enseignement.periode_id = periode.id "
                    + "JOIN annee ON periode.annee_id = annee.id "
                    + "JOIN diplome ON annee.diplome_id = diplome.id "
                    + "WHERE unite_enseignement.id = @id";

                _cmd.CommandText = sql;
                _cmd.Parameters.AddWithValue("@id", id);
                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultat = populateUniteEnseignement(reader);

                    Diplome tempDiplome = DiplomeDAO.populateDiplome(reader);

                    Annee tempAnnee = AnneeDAO.populateAnnee(reader);
                    tempAnnee.diplome = tempDiplome;

                    Periode tempPeriode = PeriodeDAO.populatePeriode(reader);
                    tempPeriode.annee = tempAnnee;

                    resultat.periode = tempPeriode;

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

        public static List<UniteEnseignement> findAll()
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<UniteEnseignement> resultats = new List<UniteEnseignement>();

            try
            {
                sql = "SELECT unite_enseignement.id as uniteEnsID, unite_enseignement.libelle as uniteEnsLibelle, "
                    + "periode.id AS periodeID, periode.libelle AS periodeLibelle, "
                    + "annee.id AS anneeId, annee.libelle AS anneeLibelle, "
                    + "diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle "
                    + "FROM unite_enseignement "
                    + "JOIN periode ON unite_enseignement.periode_id = periode.id "
                    + "JOIN annee ON periode.annee_id = annee.id "
                    + "JOIN diplome ON annee.diplome_id = diplome.id ";

                _cmd.CommandText = sql;

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    UniteEnseignement tempUnite = populateUniteEnseignement(reader);

                    Diplome tempDiplome = DiplomeDAO.populateDiplome(reader);

                    Annee tempAnnee = AnneeDAO.populateAnnee(reader);
                    tempAnnee.diplome = tempDiplome;

                    Periode tempPeriode = PeriodeDAO.populatePeriode(reader);
                    tempPeriode.annee = tempAnnee;

                    tempUnite.periode = tempPeriode;

                    resultats.Add(tempUnite);
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

        public static List<UniteEnseignement> findByLibelle(String libelle)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<UniteEnseignement> resultats = new List<UniteEnseignement>();

            try
            {
                sql = "SELECT unite_enseignement.id as uniteEnsID, unite_enseignement.libelle as uniteEnsLibelle, "
                    + "periode.id AS periodeID, periode.libelle AS periodeLibelle, "
                    + "annee.id AS anneeId, annee.libelle AS anneeLibelle, "
                    + "diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle "
                    + "FROM unite_enseignement "
                    + "JOIN periode ON unite_enseignement.periode_id = periode.id "
                    + "JOIN annee ON periode.annee_id = annee.id "
                    + "JOIN diplome ON annee.diplome_id = diplome.id "
                    + "WHERE unite_enseignement.libelle LIKE @libelle";

                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@libelle", libelle);
                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    UniteEnseignement tempUnite = populateUniteEnseignement(reader);

                    Diplome tempDiplome = DiplomeDAO.populateDiplome(reader);

                    Annee tempAnnee = AnneeDAO.populateAnnee(reader);
                    tempAnnee.diplome = tempDiplome;

                    Periode tempPeriode = PeriodeDAO.populatePeriode(reader);
                    tempPeriode.annee = tempAnnee;

                    tempUnite.periode = tempPeriode;

                    resultats.Add(tempUnite);
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

        
        public static List<UniteEnseignement> findByDiplome(long id)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<UniteEnseignement> resultats = new List<UniteEnseignement>();

            try
            {
                sql = "SELECT unite_enseignement.id as uniteEnsID, unite_enseignement.libelle as uniteEnsLibelle, "
                    + "periode.id AS periodeID, periode.libelle AS periodeLibelle, "
                    + "annee.id AS anneeId, annee.libelle AS anneeLibelle, "
                    + "diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle "
                    + "FROM unite_enseignement "
                    + "JOIN periode ON unite_enseignement.periode_id = periode.id "
                    + "JOIN annee ON periode.annee_id = annee.id "
                    + "JOIN diplome ON annee.diplome_id = diplome.id "
                    + "WHERE diplome.id = @id";

                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", id);
                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    UniteEnseignement tempUnite = populateUniteEnseignement(reader);

                    Diplome tempDiplome = DiplomeDAO.populateDiplome(reader);

                    Annee tempAnnee = AnneeDAO.populateAnnee(reader);
                    tempAnnee.diplome = tempDiplome;

                    Periode tempPeriode = PeriodeDAO.populatePeriode(reader);
                    tempPeriode.annee = tempAnnee;

                    tempUnite.periode = tempPeriode;

                    resultats.Add(tempUnite);
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

        public static UniteEnseignement create(UniteEnseignement obj)
        {

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "INSERT INTO unite_enseignement (id, libelle, periode_id) VALUES (@id,@libelle,@periode) ";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", obj.id);
                _cmd.Parameters.AddWithValue("@libelle", obj.libelle);
                _cmd.Parameters.AddWithValue("@periode", obj.periode.id);

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

        public static UniteEnseignement update(UniteEnseignement obj)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "UPDATE unite_enseignement set libelle = @libelle WHERE id = @id";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", obj.id);
                _cmd.Parameters.AddWithValue("@libelle", obj.libelle);

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

        public static void delete(UniteEnseignement obj)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "DELETE FROM unite_enseignement WHERE id = @id";
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

        public static UniteEnseignement populateUniteEnseignement(MySqlDataReader reader)
        {
            UniteEnseignement resultat = new UniteEnseignement();
            resultat.id = Convert.ToInt64(reader["uniteEnsID"]);
            resultat.libelle = (String)reader["uniteEnsLibelle"];
            return resultat;
        }
    }
}
