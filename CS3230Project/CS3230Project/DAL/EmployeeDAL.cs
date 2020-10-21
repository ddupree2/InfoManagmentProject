using System;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    /// <summary>
    ///     Represents the Data Access Layer of the employee table
    /// </summary>
    public class EmployeeDal
    {
        #region Methods

        public string RetrieveTitle(string employeeId)
        {
            return retrieveTitle(employeeId);
        }

        public string RetrieveFirstName(string employeeId)
        {
            string name;
            var connection = DbConnection.GetConnection();
            const string nameQuery = "select fname from employee where eID = @eID";

            using (connection)
            {
                connection.Open();
                name = retrieveFirstName(employeeId, nameQuery, connection);
            }

            return name;
        }

        private static string retrieveFirstName(string employeeId, string query,
            MySqlConnection connection)
        {
            var currEmployeeName = string.Empty;
            try
            {
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@eID", MySqlDbType.VarChar);
                    cmd.Parameters["@eID"].Value = employeeId;
                    currEmployeeName = cmd.ExecuteScalar().ToString();
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

            return currEmployeeName;
        }

        private static string retrieveTitle(string employeeId)
        {
            string title;
            if (isNurse(employeeId))
            {
                title = "Nurse";
            }
            else if (isDoctor(employeeId))
            {
                title = "Doctor";
            }
            else
            {
                title = "Administrator";
            }

            return title;
        }

        private static bool isDoctor(string employeeId)
        {
            var isDoctor = false;
            var connection = DbConnection.GetConnection();
            const string query = "select eID from doctor where eID = @eID";
            using (connection)
            {
                connection.Open();
                try
                {
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.Add("@eID", MySqlDbType.VarChar);
                        cmd.Parameters["@eID"].Value = employeeId;
                        isDoctor = cmd.ExecuteScalar() != null;
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
            }

            return isDoctor;
        }

        private static bool isNurse(string employeeId)
        {
            var isNurse = false;
            var connection = DbConnection.GetConnection();
            const string query = "select eID from nurse where eID = @eID";
            using (connection)
            {
                connection.Open();
                try
                {
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.Add("@eID", MySqlDbType.VarChar);
                        cmd.Parameters["@eID"].Value = employeeId;
                        isNurse = cmd.ExecuteScalar() != null;
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
            }

            return isNurse;
        }

        #endregion
    }
}