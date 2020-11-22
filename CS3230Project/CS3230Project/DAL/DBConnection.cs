using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    /// <summary>
    ///     Represent a custom database connection
    /// </summary>
    public class DbConnection
    {
        #region Data members

        private static readonly string ConnString = "server=160.10.25.16; port=3306; uid=cs3230f20b;" +
                                                    "pwd=nMdOBbByiVbdVXKP;database=cs3230f20b;";

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the connection.
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(ConnString);

            return conn;
        }

        #endregion
    }
}