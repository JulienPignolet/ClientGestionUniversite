using ClientGestionUniversite.modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.businessLogic
{
    public static class PeriodeDAO
    {
        public static MySqlConnection _connection = ConnectionMySql.getInstance();

        public static Periode find(long id)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            Periode resultat = new Periode();

            try
            {
                sql = "SELECT periode.id AS periodeID, periode.libelle AS periodeLibelle, "
                    + "annee.id AS anneeId, annee.libelle AS anneeLibelle, "
                    + "diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle "
                    + "FROM periode "
                    + "JOIN annee ON periode.annee_id = annee.id "
                    + "JOIN diplome ON annee.diplome_id = diplome.id "
                    + "WHERE periode.id = @id";

                _cmd.CommandText = sql;
                _cmd.Parameters.AddWithValue("@id", id);
                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultat = populatePeriode(reader);

                    Diplome tempDiplome = DiplomeDAO.populateDiplome(reader);

                    Annee tempAnnee = AnneeDAO.populateAnnee(reader);
                    tempAnnee.diplome = tempDiplome;

                    resultat.annee = tempAnnee;

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

        public static List<Periode> findAll()
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<Periode> resultats = new List<Periode>();

            try
            {
                sql = "SELECT periode.id as periodeID, periode.libelle as periodeLibelle, "
                    + "annee.id as anneeId, annee.libelle as anneeLibelle ,"
                    + "diplome.id as diplomeID, diplome.libelle as diplomeLibelle "
                    + "FROM periode "
                    + "join annee on periode.annee_id = annee.id "
                    + "join diplome on annee.diplome_id = diplome.id";

                _cmd.CommandText = sql;

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Periode temp = populatePeriode(reader);

                    Diplome tempDiplome = DiplomeDAO.populateDiplome(reader);

                    Annee tempAnnee = AnneeDAO.populateAnnee(reader);
                    tempAnnee.diplome = tempDiplome;

                    temp.annee = tempAnnee;

                    resultats.Add(temp);
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

        public static List<Periode> findByLibelle(String libelle)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<Periode> resultats = new List<Periode>();

            try
            {
                sql = "SELECT periode.id AS periodeID, periode.libelle AS periodeLibelle, "
                    + "annee.id AS anneeId, annee.libelle AS anneeLibelle ,"
                    + "diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle "
                    + "FROM periode "
                    + "JOIN annee ON periode.annee_id = annee.id "
                    + "JOIN diplome ON annee.diplome_id = diplome.id "
                    + "WHERE periode.libelle LIKE @libelle";

                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@libelle", libelle);
                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Periode temp = populatePeriode(reader);

                    Diplome tempDiplome = DiplomeDAO.populateDiplome(reader);

                    Annee tempAnnee = AnneeDAO.populateAnnee(reader);
                    tempAnnee.diplome = tempDiplome;

                    temp.annee = tempAnnee;

                    resultats.Add(temp);
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

        public static Periode create(Periode obj)
        {

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "INSERT INTO periode (id, libelle, annee_id) VALUES (@id,@libelle,@annee) ";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", obj.id);
                _cmd.Parameters.AddWithValue("@libelle", obj.libelle);
                _cmd.Parameters.AddWithValue("@annee", obj.annee.id);

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

        public static Periode update(Periode obj)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "UPDATE periode set libelle = @libelle WHERE id = @id";
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

        public static void delete(Periode obj)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "DELETE FROM periode WHERE id = @id";
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

        public static Periode populatePeriode(MySqlDataReader reader)
        {
            Periode resultat = new Periode();
            resultat.id = Convert.ToInt64(reader["periodeID"]);
            resultat.libelle = (String)reader["periodeLibelle"];
            return resultat;
        }
    }
}
