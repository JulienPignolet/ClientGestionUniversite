using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.businessLogic
{
    public class ConnectionMySql
    {
        public const String server = "mysql1.yulpa.io";
        public const String userId = "535_U370143";
        public const String database = "535_partages51";
        public const String password = "nybzub-tunhy0-Cyqjat";

        private static MySqlConnection _connection;

        public static MySqlConnection getInstance()
        {
            String connectionString = "server=" + server + ";user id=" + userId + ";password=" + password + ";database=" + database;

            if (_connection == null
                || _connection.State == System.Data.ConnectionState.Broken
                || _connection.State == System.Data.ConnectionState.Closed
                || !_connection.Ping()
                )
            {

                if (_connection != null)
                {
                    if (_connection.State != System.Data.ConnectionState.Broken
                && _connection.State != System.Data.ConnectionState.Closed)
                    {
                        _connection.Close();
                    }

                    _connection.Dispose();
                }

                try
                {
                    _connection = new MySqlConnection(connectionString);
                    _connection.Open();
                }
                catch (NullReferenceException e)
                {
                    Debug.WriteLine("Error MySQL: ", e.ToString());
                    throw e;
                }
            }

            return _connection;

        }
        /**
         * comment utiliser le connecteur : 
         * MySqlConnection connection = ConnectionMySql.getInstance();
            MySqlCommand _cmd = new MySqlCommand();
   
            _cmd.Connection = connection;
         * ... 
         * **/
    }
}
