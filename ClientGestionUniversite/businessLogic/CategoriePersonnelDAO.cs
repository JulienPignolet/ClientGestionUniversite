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
