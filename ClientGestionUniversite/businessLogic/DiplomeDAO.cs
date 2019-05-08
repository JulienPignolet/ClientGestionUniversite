using ClientGestionUniversite.modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.businessLogic
{
    public static class DiplomeDAO
    {
        public static Diplome find(long id)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            Diplome resultat = new Diplome();

            try
            {
                sql = "SELECT diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle "
                + "FROM diplome "
                + "WHERE id = @id";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", id);

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultat = populateDiplome(reader);
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

        /// <summary>
        /// Retourne l'ensemble des diplomes
        /// </summary>
        /// <returns>diplomes</returns>
        public static List<Diplome> findAll()
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();
            _cmd.Connection = _connection;
            String sql = "";
            MySqlDataReader reader = null;
            List<Diplome> resultats = new List<Diplome>();
            try
            {
                sql = "SELECT diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle "
                + "FROM diplome";
                _cmd.CommandText = sql;
                reader = _cmd.ExecuteReader();
                while (reader.Read())
                {
                    Diplome temp = populateDiplome(reader);
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

        public static List<Diplome> findByLibelle(String libelle)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;
            List<Diplome> resultats = new List<Diplome>();

            try
            {
                sql = "SELECT diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle "
                + "FROM diplome "
                + "WHERE libelle LIKE @libelle";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@libelle", libelle);

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Diplome resultat = populateDiplome(reader);
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

        public static List<Diplome> findBy(String attribute, String value)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;
            List<Diplome> dips = new List<Diplome>();

            try
            {
                sql = "SELECT * FROM diplome WHERE @attribute LIKE @value";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@attribute", attribute);
                _cmd.Parameters.AddWithValue("@value", value);

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Diplome resultat = new Diplome();
                    resultat.id = Convert.ToInt64(reader["id"]);
                    resultat.libelle = (String)reader["libelle"];
                    dips.Add(resultat);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e);
            }
            _cmd.Dispose();

            return dips;
        }

        public static Diplome create(Diplome obj)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "INSERT INTO diplome (id, libelle) VALUES (@id,@libelle) ";
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

        public static Diplome update(Diplome obj)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "UPDATE diplome set libelle = @libelle WHERE id = @id";
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

        public static void delete(Diplome obj)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "DELETE FROM diplome WHERE id = @id";
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

        /// <summary>
        /// Remplissage d'un diplome
        /// </summary>
        /// <param name="reader">resultat requete</param>
        /// <returns>diplome</returns>
        public static Diplome populateDiplome(MySqlDataReader reader)
        {
            Diplome resultat = new Diplome();
            
            if (reader.IsDBNull(reader.GetOrdinal("diplomeID")) || reader.IsDBNull(reader.GetOrdinal("diplomeLibelle")))
            {
                return null;
            }
            resultat.id = Convert.ToInt64(reader["diplomeID"]);
            resultat.libelle = (String)reader["diplomeLibelle"];
            
            return resultat;
        }
    }
}
