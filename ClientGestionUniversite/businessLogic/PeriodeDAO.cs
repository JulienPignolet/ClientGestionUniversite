using ClientGestionUniversite.modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.businessLogic
{
    public static class PeriodeDAO
    {
        public static Periode populatePeriode(MySqlDataReader reader)
        {
            Periode resultat = new Periode();
            resultat.id = Convert.ToInt64(reader["periodeID"]);
            resultat.libelle = (String)reader["periodeLibelle"];
            return resultat;
        }
    }
}
