using ClientGestionUniversite.modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.businessLogic
{
    public static class UniteEnseignementDAO
    {
        private static MySqlConnection _connection = ConnectionMySql.getInstance();

        public static List<UniteEnseignement> findAll()
        {
            MySqlCommand _cmd = new MySqlCommand();
            _cmd.Connection = _connection;
            String sql = "";
            MySqlDataReader reader = null;
            List<UniteEnseignement> resultats = new List<UniteEnseignement>();
            try
            {
                sql = "SELECT unite_enseignement.id as uniteEnsID, unite_enseignement.libelle as uniteEnsLibelle, "
                    + "periode.id AS periodeID, periode.libelle AS periodeLibelle, "
                    + "annee.id AS anneeId, annee.libelle AS anneeLibelle, "
                    + "diplome.id AS diplomeID, diplome.libelle AS diplomeLibelle "
                    + "FROM unite_enseignement "
                    + "JOIN periode ON unite_enseignement.periode_id = periode.id "
                    + "JOIN annee ON periode.annee_id = annee.id "
                    + "JOIN diplome ON annee.diplome_id = diplome.id ";
                _cmd.CommandText = sql;
                reader = _cmd.ExecuteReader();
                while (reader.Read())
                {
                    UniteEnseignement tempUnite = populateUniteEnseignement(reader);
                    Diplome tempDiplome = DiplomeDAO.populateDiplome(reader);
                    Annee tempAnnee = AnneeDAO.populateAnnee(reader);
                    tempAnnee.diplome = tempDiplome;
                    Periode tempPeriode = PeriodeDAO.populatePeriode(reader);
                    tempPeriode.annee = tempAnnee;
                    tempUnite.periode = tempPeriode;
                    resultats.Add(tempUnite);
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

        public static UniteEnseignement populateUniteEnseignement(MySqlDataReader reader)
        {
            UniteEnseignement resultat = new UniteEnseignement();
            resultat.id = Convert.ToInt64(reader["uniteEnsID"]);
            resultat.libelle = (String)reader["uniteEnsLibelle"];
            return resultat;
        }
    }
}
