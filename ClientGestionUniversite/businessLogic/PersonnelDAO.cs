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
        private static MySqlConnection _connection = ConnectionMySql.getInstance();

        /// <summary>
        /// Retourne l'ensemble du personnel
        /// </summary>
        public static List<Personnel> getAll()
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

        /// <summary>
        /// Création d'un personnel
        /// </summary>
        /// <param name="obj">personnel</param>
        public static void create(Personnel obj)
        {
            MySqlCommand _cmd = new MySqlCommand();
            _cmd.Connection = _connection;
            String sql = "";
            try
            {
                sql = "INSERT INTO personnel (id, prenom, nom , categorie_id) VALUES (@id ,@prenom ,@nom, @categorieId) ";
                _cmd.CommandText = sql;
                _cmd.Parameters.AddWithValue("@id", obj.id);
                _cmd.Parameters.AddWithValue("@prenom", obj.Prenom);
                _cmd.Parameters.AddWithValue("@nom", obj.Nom);
                _cmd.Parameters.AddWithValue("@categorieId", obj.categoriePersonnel.id);
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
        /// Suppression d'un personnel
        /// </summary>
        /// <param name="obj">personnel</param>
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

        /// <summary>
        /// Mise à jour d'un personnel
        /// </summary>
        /// <param name="obj">personnel</param>
        public static void update(Personnel obj)
        {
            MySqlCommand _cmd = new MySqlCommand();
            _cmd.Connection = _connection;
            String sql = "";
            try
            {
                sql = "UPDATE personnel set nom = @nom WHERE id = @id";
                _cmd.CommandText = sql;
                _cmd.Parameters.AddWithValue("@id", obj.id);
                _cmd.Parameters.AddWithValue("@nom", obj.Nom);
                _cmd.Parameters.AddWithValue("@prenom", obj.Prenom);
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
        /// Remplissage d'un personne
        /// </summary>
        /// <param name="reader">res d'une requête</param>
        /// <returns>une personne</returns>
        public static Personnel populatePersonnel(MySqlDataReader reader)
        {
            Personnel resultat = new Personnel();
            resultat.id = Convert.ToInt64(reader["personnelId"]);
            resultat.Nom = (String)reader["personnelNom"];
            resultat.Prenom = (String)reader["personnelPrenom"];
            return resultat;
        }
    }
}
