using System;
using ClientGestionUniversite.modele;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.businessLogic
{
    public static class TypeCoursDAO
    {
        public static MySqlConnection _connection = ConnectionMySql.getInstance();

        public static TypeCours find(long id)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            TypeCours resultat = new TypeCours();

            try
            {
                sql = "SELECT type_cours.id AS typeCoursID, type_cours.libelle AS typeCoursLibelle "
                + "FROM type_cours "
                + "WHERE id = @id";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", id);

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultat = populateTypeCours(reader);
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

        public static List<TypeCours> findAll()
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<TypeCours> resultats = new List<TypeCours>();

            try
            {
                sql = "SELECT type_cours.id AS typeCoursID, type_cours.libelle AS typeCoursLibelle "
                + "FROM type_cours ";
                _cmd.CommandText = sql;

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    TypeCours temp = populateTypeCours(reader);
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

        public static List<TypeCours> findByLibelle(String libelle)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;
            List<TypeCours> resultats = new List<TypeCours>();

            try
            {
                sql = "SELECT type_cours.id AS typeCoursID, type_cours.libelle AS typeCoursLibelle "
                + "FROM type_cours "
                + "WHERE libelle LIKE @libelle";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@libelle", libelle);

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    TypeCours resultat = populateTypeCours(reader);
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

        public static TypeCours create(TypeCours obj)
        {

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "INSERT INTO type_cours (id, libelle) VALUES (@id,@libelle) ";
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

        public static TypeCours update(TypeCours obj)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "UPDATE type_cours set libelle = @libelle WHERE id = @id";
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

        public static void delete(TypeCours obj)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "DELETE FROM type_cours WHERE id = @id";
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

        public static TypeCours populateTypeCours(MySqlDataReader reader)
        {
            TypeCours resultat = new TypeCours();

            resultat.id = Convert.ToInt64(reader["typeCoursID"]);
            resultat.libelle = (String)reader["typeCoursLibelle"];

            return resultat;
        }
    }
}
