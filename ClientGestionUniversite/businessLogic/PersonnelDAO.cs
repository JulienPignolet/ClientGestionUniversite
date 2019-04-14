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
            resultats.Add(new Personnel("Bosco", "Gaetan", new CategoriePersonnel("git master", 200)));
            resultats.Add(new Personnel("Fath", "Yoan", new CategoriePersonnel("chauve master", 200)));
            resultats.Add(new Personnel("Scheffler", "Arnaud", new CategoriePersonnel("la mere a bosco", 200)));
            return resultats;
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

        /// <summary>
        /// Retourne le détail sur une personne
        /// </summary>
        /// <param name="id">id de la personne</param>
        /// <param name="personnelViewModel">données à mettre à jours</param>
        public static void get(string id, PersonnelViewModel personnelViewModel)
        {
            // TODO Données à remplir via requête
            personnelViewModel.nomPrenom = "Julien";
            personnelViewModel.titre = "Professeur";
            personnelViewModel.heureEff = "200";
        }
    }
}
