using ClientGestionUniversite.modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.businessLogic
{
    public static class AnneeDAO
    {
        public static Annee populateAnnee(MySqlDataReader reader)
        {
            Annee resultat = new Annee();
            resultat.id = Convert.ToInt64(reader["anneeId"]);
            resultat.libelle = (String)reader["anneeLibelle"];
            return resultat;
        }
    }
}
