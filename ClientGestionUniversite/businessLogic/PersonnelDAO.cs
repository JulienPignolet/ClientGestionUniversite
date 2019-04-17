using ClientGestionUniversite.modele;
using ClientGestionUniversite.viewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGestionUniversite.businessLogic
{
    public static class PersonnelDAO
    {
        public static MySqlConnection _connection = ConnectionMySql.getInstance();

        public static Personnel find(long id)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            Personnel resultat = new Personnel();

            try
            {
                sql = "SELECT personnel.id AS personnelId, personnel.nom AS personnelNom, personnel.prenom AS personnelPrenom, "
                + "categorie_personnel.id AS categID, categorie_personnel.libelle AS categLibelle, categorie_personnel.volume_horaire as categVolume "
                + "FROM personnel "
                + "JOIN categorie_personnel ON personnel.categorie_id = categorie_personnel.id "
                + "WHERE personnel.id = @id";

                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", id);

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultat = populatePersonnel(reader);
                    CategoriePersonnel d = CategoriePersonnelDAO.populateCategoriePersonnel(reader);
                    resultat.categoriePersonnel = d;

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

        public static List<Personnel> findAll()
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<Personnel> resultats = new List<Personnel>();

            try
            {
                sql = "SELECT personnel.id AS personnelId, personnel.nom AS personnelNom, personnel.prenom AS personnelPrenom, "
                + "categorie_personnel.id AS categID, categorie_personnel.libelle AS categLibelle, categorie_personnel.volume_horaire as categVolume "
                + "FROM personnel "
                + "JOIN categorie_personnel ON personnel.categorie_id = categorie_personnel.id ";
                _cmd.CommandText = sql;

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Personnel temp = populatePersonnel(reader);
                    CategoriePersonnel d = CategoriePersonnelDAO.populateCategoriePersonnel(reader);
                    temp.categoriePersonnel = d;

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

        public static List<Personnel> findByNom(String nom)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<Personnel> resultats = new List<Personnel>();

            try
            {
                sql = "SELECT personnel.id AS personnelId, personnel.nom AS personnelNom, personnel.prenom AS personnelPrenom, "
                + "categorie_personnel.id AS categID, categorie_personnel.libelle AS categLibelle, categorie_personnel.volume_horaire as categVolume "
                + "FROM personnel "
                + "JOIN categorie_personnel ON personnel.categorie_id = categorie_personnel.id "
                + "WHERE personnel.nom LIKE @nom";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@nom", nom);

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Personnel temp = populatePersonnel(reader);
                    CategoriePersonnel d = CategoriePersonnelDAO.populateCategoriePersonnel(reader);
                    temp.categoriePersonnel = d;

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

        public static List<Personnel> findByPrenom(String prenom)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";
            MySqlDataReader reader = null;

            List<Personnel> resultats = new List<Personnel>();

            try
            {
                sql = "SELECT personnel.id AS personnelId, personnel.nom AS personnelNom, personnel.prenom AS personnelPrenom, "
                + "categorie_personnel.id AS categID, categorie_personnel.libelle AS categLibelle, categorie_personnel.volume_horaire as categVolume "
                + "FROM personnel "
                + "JOIN categorie_personnel ON personnel.categorie_id = categorie_personnel.id "
                + "WHERE personnel.prenom LIKE @prenom";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@prenom", prenom);

                reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Personnel temp = populatePersonnel(reader);
                    CategoriePersonnel d = CategoriePersonnelDAO.populateCategoriePersonnel(reader);
                    temp.categoriePersonnel = d;

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

        public static Personnel create(Personnel obj)
        {

            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "INSERT INTO personnel (id, prenom, nom , categorie_id) VALUES (@id ,@prenom ,@nom, @categorieId) ";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", obj.id);
                _cmd.Parameters.AddWithValue("@prenom", obj.prenom);
                _cmd.Parameters.AddWithValue("@nom", obj.nom);
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

        public static Personnel update(Personnel obj)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "UPDATE personnel set nom = @nom, prenom = @prenom, categorie_id = @categId WHERE id = @id";
                _cmd.CommandText = sql;

                _cmd.Parameters.AddWithValue("@id", obj.id);
                _cmd.Parameters.AddWithValue("@nom", obj.nom);
                _cmd.Parameters.AddWithValue("@prenom", obj.prenom);
                _cmd.Parameters.AddWithValue("@categId", obj.categoriePersonnel.id);

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

        public static void delete(Personnel obj)
        {
            MySqlCommand _cmd = new MySqlCommand();

            _cmd.Connection = _connection;

            String sql = "";

            try
            {
                sql = "DELETE FROM personnel WHERE id = @id";
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

        public static Personnel populatePersonnel(MySqlDataReader reader)
        {
            Personnel resultat = new Personnel();

            resultat.id = Convert.ToInt64(reader["personnelId"]);
            resultat.nom = (String)reader["personnelNom"];
            resultat.prenom = (String)reader["personnelPrenom"];

            return resultat;
        }
    }
}
