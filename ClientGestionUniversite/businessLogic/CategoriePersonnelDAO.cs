using ClientGestionUniversite.modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.businessLogic
{
    public static class CategoriePersonnelDAO
    {
        public static MySqlConnection _connection = ConnectionMySql.getInstance();

        public static CategoriePersonnel find(long id)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            CategoriePersonnel resultat = new CategoriePersonnel();

            try
            {
                sql = "SELECT categorie_personnel.id AS categID, categorie_personnel.libelle AS categLibelle, categorie_personnel.volume_horaire as categVolume "
                + "FROM categorie_personnel "
                + "WHERE id = @id";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", id);

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultat = populateCategoriePersonnel(reader);
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

        public static List<CategoriePersonnel> findAll()
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<CategoriePersonnel> resultats = new List<CategoriePersonnel>();

            try
            {
                sql = "SELECT categorie_personnel.id AS categID, categorie_personnel.libelle AS categLibelle, categorie_personnel.volume_horaire as categVolume "
                + "FROM categorie_personnel ";
                _cmd.CommandText = sql;

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    CategoriePersonnel temp = populateCategoriePersonnel(reader);
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

        public static List<CategoriePersonnel> findByLibelle(String libelle)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;
            List<CategoriePersonnel> resultats = new List<CategoriePersonnel>();

            try
            {
                sql = "SELECT categorie_personnel.id AS categID, categorie_personnel.libelle AS categLibelle, categorie_personnel.volume_horaire as categVolume "
                + "FROM categorie_personnel "
                + "WHERE libelle LIKE @libelle";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@libelle", libelle);

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    CategoriePersonnel resultat = populateCategoriePersonnel(reader);
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

        public static CategoriePersonnel create(CategoriePersonnel obj)
        {

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "INSERT INTO categorie_personnel (id, libelle, volume_horaire) VALUES (@id,@libelle, @volume) ";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", obj.id);
                _cmd.Parameters.AddWithValue("@libelle", obj.libelle);
                _cmd.Parameters.AddWithValue("@volume", obj.volumeHoraire);

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

        public static CategoriePersonnel update(CategoriePersonnel obj)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "UPDATE categorie_personnel set libelle = @libelle, volume_horaire = @volume WHERE id = @id";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", obj.id);
                _cmd.Parameters.AddWithValue("@libelle", obj.libelle);
                _cmd.Parameters.AddWithValue("@volume", obj.volumeHoraire);

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

        public static void delete(CategoriePersonnel obj)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "DELETE FROM categorie_personnel WHERE id = @id";
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

        public static CategoriePersonnel populateCategoriePersonnel(MySqlDataReader reader)
        {
            CategoriePersonnel resultat = new CategoriePersonnel();

            resultat.id = Convert.ToInt64(reader["categID"]);
            resultat.libelle = (String)reader["categLibelle"];
            resultat.volumeHoraire = Convert.ToInt32(reader["categVolume"]);

            return resultat;
        }
    }
}
