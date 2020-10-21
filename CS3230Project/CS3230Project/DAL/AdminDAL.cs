using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    /// <summary>
    ///     Represents the Admin Data Access Layer to the database
    /// </summary>
    public class AdminDal
    {
        #region Methods

        /// <summary>
        ///     Retrieves the query results for the give query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public string RetrieveQueryResults(string query)
        {
            var connection = DbConnection.GetConnection();

            using (connection)
            {
                connection.Open();
                return fetchQueryResults(query, connection);
            }
        }

        private static string fetchQueryResults(string query, MySqlConnection connection)
        {
            using (var cmd = new MySqlCommand(query, connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    return readInResults(reader);
                }
            }
        }

        private static string readInResults(IDataReader reader)
        {
            var values = new StringBuilder();
            while (reader.Read())
            {
                var columns = reader.FieldCount;
                for (var i = 0; i < columns; i++)
                {
                    var currValue = reader[i] == DBNull.Value ? null : reader.GetString(i);
                    values.Append(currValue);
                }

                values.Append(Environment.NewLine);
            }

            return values.ToString();
        }

        #endregion
    }
}