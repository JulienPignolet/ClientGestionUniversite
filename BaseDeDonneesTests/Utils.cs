using ClientGestionUniversite.businessLogic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDonneesTests.modele
{
    class Utils
    {

        public static void fermerConnexion()
        {
            MySqlConnection _connection = ConnectionMySql.getInstance();
            _connection.Close();
        }
    }
}
