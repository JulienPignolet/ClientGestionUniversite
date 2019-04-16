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
        public static MySqlConnection _connection = ConnectionMySql.getInstance();

        /// <summary>
        /// Retourne l'ensemble des diplomes
        /// </summary>
        /// <returns>diplomes</returns>
        public static List<Diplome> findAll()
        {
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

        /// <summary>
        /// Remplissage d'un diplome
        /// </summary>
        /// <param name="reader">resultat requete</param>
        /// <returns>diplome</returns>
        public static Diplome populateDiplome(MySqlDataReader reader)
        {
            Diplome resultat = new Diplome();
            resultat.id = Convert.ToInt64(reader["diplomeID"]);
            resultat.libelle = (String)reader["diplomeLibelle"];
            return resultat;
        }
    }
}
