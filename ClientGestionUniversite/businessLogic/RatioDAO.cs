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
        public static MySqlConnection _connection = ConnectionMySql.getInstance();

        public static Ratio find(long id)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            Ratio resultat = new Ratio();

            try
            {
                sql = "SELECT ratio.id AS ratioId, "
                 + "type_cours.id AS typeCoursID, type_cours.libelle AS typeCoursLibelle "
                 + "categorie_personnel.id AS categID, categorie_personnel.libelle AS categLibelle, categorie_personnel.volume_horaire as categVolume "
                 + "FROM ratio "
                 + "JOIN categorie_personnel ON ratio.categorie_id = categorie_personnel.id "
                 + "JOIN type_cours ON ratio.type_id = type_cours.id";

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
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<Ratio> resultats = new List<Ratio>();

            try
            {
                sql = "SELECT ratio.id AS ratioId, "
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

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "INSERT INTO ratio (id, type_id, categorie_id) VALUES (@id ,@typeId, @categorieId) ";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", obj.id);
                _cmd.Parameters.AddWithValue("@typeId", obj.typeCours.id);
                _cmd.Parameters.AddWithValue("@categorieId", obj.categoriePersonnel.id);

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

        public static void delete(Ratio obj)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "DELETE FROM ratio WHERE id = @id";
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

        public static Ratio populateRatio(MySqlDataReader reader)
        {
            Ratio resultat = new Ratio();

            resultat.id = Convert.ToInt64(reader["ratioId"]);

            return resultat;
        }
    }
}
