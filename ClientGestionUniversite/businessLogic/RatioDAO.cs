using System;
using ClientGestionUniversite.modele;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.businessLogic
{
    public static class RatioDAO
    {
        
        public static Ratio find(long id)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            Ratio resultat = new Ratio();

            try
            {
                sql = "SELECT ratio.ratio AS ratio, "
                 + "type_cours.id AS typeCoursID, type_cours.libelle AS typeCoursLibelle "
                 + "categorie_personnel.id AS categID, categorie_personnel.libelle AS categLibelle, categorie_personnel.volume_horaire as categVolume "
                 + "FROM ratio "
                 + "JOIN categorie_personnel ON ratio.categorie_id = categorie_personnel.id "
                 + "JOIN type_cours ON ratio.type_id = type_cours.id " +
                 "WHERE type_id = @typeId, categorie_id = @categorieId";

                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", id);

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultat = populateRatio(reader);
                    CategoriePersonnel d = CategoriePersonnelDAO.populateCategoriePersonnel(reader);
                    TypeCours t = TypeCoursDAO.populateTypeCours(reader);
                    resultat.categoriePersonnel = d;
                    resultat.typeCours = t;

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

        public static List<Ratio> findAll()
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<Ratio> resultats = new List<Ratio>();

            try
            {
                sql = "SELECT ratio.ratio AS ratio, "
                + "type_cours.id AS typeCoursID, type_cours.libelle AS typeCoursLibelle "
                + "categorie_personnel.id AS categID, categorie_personnel.libelle AS categLibelle, categorie_personnel.volume_horaire as categVolume "
                + "FROM ratio "
                + "JOIN categorie_personnel ON ratio.categorie_id = categorie_personnel.id "
                + "JOIN type_cours ON ratio.type_id = type_cours.id";
                _cmd.CommandText = sql;

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Ratio temp = populateRatio(reader);
                    CategoriePersonnel d = CategoriePersonnelDAO.populateCategoriePersonnel(reader);
                    TypeCours t = TypeCoursDAO.populateTypeCours(reader);
                    temp.categoriePersonnel = d;
                    temp.typeCours = t;

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

        public static Ratio create(Ratio obj)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "INSERT INTO ratio (ratio, type_id, categorie_id) VALUES (@ratio ,@typeId, @categorieId) ";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@ratio", obj.ratio);
                _cmd.Parameters.AddWithValue("@typeId", obj.typeCours.id);
                _cmd.Parameters.AddWithValue("@categorieId", obj.categoriePersonnel.id);

                _cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e);
            }

            _cmd.Dispose();

            return obj;

        }

        public static Ratio update(Ratio obj)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "UPDATE ratio set ratio = @ratio WHERE type_id = @typeId, categorie_id = @categorieId ";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@categorieId", obj.categoriePersonnel.id);
                _cmd.Parameters.AddWithValue("@typeId", obj.typeCours.id);
                _cmd.Parameters.AddWithValue("@ratio", obj.ratio);
                

                _cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e);
            }

            _cmd.Dispose();

            return obj;

        }

        public static void delete(Ratio obj)
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "DELETE FROM ratio WHERE type_id = @typeId, categorie_id = @categorieId";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@categorieId", obj.categoriePersonnel.id);
                _cmd.Parameters.AddWithValue("@typeId", obj.typeCours.id);

                _cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e);
            }
            _cmd.Dispose();
        }

        public static Ratio populateRatio(MySqlDataReader reader)
        {
            Ratio resultat = new Ratio();

            resultat.ratio = Convert.ToInt32(reader["ratio"]);

            return resultat;
        }
    }
}
