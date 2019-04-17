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
        private static MySqlConnection _connection = ConnectionMySql.getInstance();

        public static List<CoursParPersonnelViewModel> findAll()
        {
            List<CoursParPersonnelViewModel> res = new List<CoursParPersonnelViewModel>();
            res.Add(new CoursParPersonnelViewModel("Mathématique", "CM", 10));
            res.Add(new CoursParPersonnelViewModel("Mathématique", "CM", 10));
            return res;
        }
    }
}
