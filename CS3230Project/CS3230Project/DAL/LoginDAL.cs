using System;
using System.Data;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    /// <summary>
    ///     Represents the Data Access Layer for logging into the database.
    /// </summary>
    public class LoginDal
    {
        #region Methods

        /// <summary>
        ///     Authenticates the specified employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="password">The password.</param>
        /// <returns>true iff the employeeId and password are in the login table of the database</returns>
        public bool Authenticate(string employeeId, string password)
        {
            var connection = DbConnection.GetConnection();
            const string command = "login_verifyLogin";

            using (connection)
            {
                connection.Open();
                return checkCredentials(employeeId, password, command, connection);
            }
        }

        private static bool checkCredentials(string employeeId, string password, string command,
            MySqlConnection connection)
        {
            var foundEmployeeId = false;
            try
            {
                using (var cmd = new MySqlCommand(command, connection))
                {
                    Debug.WriteLine(
                        $"id: {employeeId}, isPotentialPassword: {password != null && !password.Equals(string.Empty)}");
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", MySqlDbType.VarChar);
                    cmd.Parameters["@id"].Value = employeeId;
                    cmd.Parameters["@id"].Direction = ParameterDirection.Input;
                    
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.Parameters["@pass"].Direction = ParameterDirection.Input;

                    var currEmployeeId = cmd.ExecuteScalar();
                    Debug.WriteLine($"Found id: {currEmployeeId}");
                    foundEmployeeId = currEmployeeId != null;
                }
            }
            catch (MySqlException mex)
            {
                Debug.WriteLine(mex.Message);
            }
            catch (ArgumentException e)
            {
                Debug.WriteLine(e.Message);
            }

            return foundEmployeeId;
        }

        #endregion
    }
}