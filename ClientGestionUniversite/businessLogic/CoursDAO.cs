using ClientGestionUniversite.modele;
using ClientGestionUniversite.viewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.businessLogic
{
    public static class CoursDAO
    {
        // TODO COURS DAO 
        // Liste des cours d'une EC (Type, Heure, Personnel)
        //Liste des cours d'un prof (Nom, Type, Heure)
        private static MySqlConnection _connection = ConnectionMySql.getInstance();

        public static List<CoursViewModel> findAll()
        {
            List<CoursViewModel> res = new List<CoursViewModel>();
            res.Add(new CoursViewModel("Mathématique", "CM", 10));
            res.Add(new CoursViewModel("Mathématique", "CM", 10));
            return res;
        }
    }
}
