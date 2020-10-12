﻿using System;
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
                const string query = "select eID from login where eID = @eID and password = @password";

                using (connection)
                {
                    connection.Open();
                    return checkCredentials(employeeId, password, query, connection);
                }
        }

        private static bool checkCredentials(string employeeId, string password, string query,
            MySqlConnection connection)
        {
            var foundEmployeeId = false;
            try
            {
                using (var cmd = new MySqlCommand(query, connection))
                {
                    Debug.WriteLine($"eID: {employeeId}, isPotentialPassword: {password != null && !password.Equals(string.Empty)}");
                    cmd.Parameters.Add("@eID", MySqlDbType.VarChar);
                    cmd.Parameters["@eID"].Value = employeeId;
                    cmd.Parameters.AddWithValue("@password", password);
                    var currEmployeeId = cmd.ExecuteScalar();
                    Debug.WriteLine($"Found eID: {currEmployeeId}");
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