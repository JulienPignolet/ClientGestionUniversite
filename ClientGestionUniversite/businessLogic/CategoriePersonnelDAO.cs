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
        private static MySqlConnection _connection = ConnectionMySql.getInstance();

        /// <summary>
        /// Retourne l'ensemble des categories
        /// </summary>
        /// <returns>categoriePersonnel</returns>
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

        /// <summary>
        /// Remplissage d'une categorie
        /// </summary>
        /// <param name="reader">resultat requete</param>
        /// <returns>categorie</returns>
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
