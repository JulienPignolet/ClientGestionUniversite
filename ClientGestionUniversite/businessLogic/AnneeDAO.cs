using ClientGestionUniversite.modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.businessLogic
{
    public static class AnneeDAO
    {
        public static Annee find(long id)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            Annee resultat = new Annee();

            try
            {
                sql = "SELECT annee.id AS anneeId, annee.libelle AS anneeLibelle, "
                + "diplome.libelle AS diplomeLibelle, diplome.id AS diplomeId "
                + "FROM annee JOIN diplome ON annee.diplome_id = diplome.id "
                + "WHERE annee.id = @id";
                // sql = "SELECT * FROM annee WHERE id = @id";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", id);

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultat = populateAnnee(reader);
                    Diplome d = DiplomeDAO.populateDiplome(reader);
                    resultat.diplome = d;
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

        public static List<Annee> findAll()
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<Annee> resultats = new List<Annee>();

            try
            {
                sql = "SELECT annee.id as anneeId, annee.libelle as anneeLibelle, diplome.libelle as diplomeLibelle, diplome.id as diplomeId " +
                     "FROM annee JOIN diplome where annee.diplome_id = diplome.id";
                _cmd.CommandText = sql;

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Annee temp = populateAnnee(reader);
                    Diplome d = DiplomeDAO.populateDiplome(reader);
                    temp.diplome = d;

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

        public static List<Annee> findByLibelle(String libelle)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<Annee> annees = new List<Annee>();

            try
            {
                sql = "SELECT annee.id AS anneeId, annee.libelle AS anneeLibelle, "
                + "diplome.libelle AS diplomeLibelle, diplome.id AS diplomeId "
                + "FROM annee "
                + "JOIN diplome ON annee.diplome_id = diplome.id "
                + "AND annee.libelle LIKE @libelle";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@libelle", libelle);

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Annee temp = populateAnnee(reader);
                    Diplome d = DiplomeDAO.populateDiplome(reader);
                    temp.diplome = d;

                    annees.Add(temp);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e);
            }
            _cmd.Dispose();

            return annees;
        }

        public static Annee create(Annee obj)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "INSERT INTO annee (id, libelle, diplome_id) VALUES (@id,@libelle,@diplome) ";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", obj.id);
                _cmd.Parameters.AddWithValue("@libelle", obj.libelle);
                _cmd.Parameters.AddWithValue("@diplome", obj.diplome.id);

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

        public static Annee update(Annee obj)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "UPDATE annee set libelle = @libelle, diplome_id = @diplome_id WHERE id = @id";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", obj.id);
                _cmd.Parameters.AddWithValue("@libelle", obj.libelle);
                _cmd.Parameters.AddWithValue("@diplome_id", obj.diplome.id);

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

        public static void delete(Annee obj)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "DELETE FROM annee WHERE id = @id";
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

        public static Annee populateAnnee(MySqlDataReader reader)
        {
            Annee resultat = new Annee();
            if (reader.IsDBNull(reader.GetOrdinal("anneeId")) || reader.IsDBNull(reader.GetOrdinal("anneeLibelle")))
            {
                return null;
            }
            resultat.id = Convert.ToInt64(reader["anneeId"]);
            resultat.libelle = (String)reader["anneeLibelle"];
            return resultat;
        }
    }
}
