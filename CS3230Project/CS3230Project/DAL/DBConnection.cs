using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3230Project.DAL
{
    class DbConnection
    {
        static readonly string Connstring = "server=160.10.25.16; port=3306; uid=cs3230f20b;" +
                                            "pwd=nMdOBbByiVbdVXKP;database=cs3230f20b;";

        public static MySqlConnection GetConnection()
        {

            MySqlConnection conn = new MySqlConnection(Connstring);

            return conn;

        }
    }
}
