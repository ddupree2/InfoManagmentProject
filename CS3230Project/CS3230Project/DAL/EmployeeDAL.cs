using System;
using System.Collections.Generic;
using System.Diagnostics;
using CS3230Project.Model;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    /// <summary>
    ///     Represents the Data Access Layer of the employee table
    /// </summary>
    public class EmployeeDal
    {
        #region Methods

        /// <summary>
        ///     Retrieves the title.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns>the title of the employee</returns>
        public string RetrieveTitle(string employeeId)
        {
            return retrieveTitle(employeeId);
        }

        /// <summary>
        ///     Retrieves the first name.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns>The first name of the employee</returns>
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

        /// <summary>
        ///     Retrieves the employees.
        /// </summary>
        /// <returns>A list of all employees</returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public IList<Employee> RetrieveEmployees()
        {
            IList<Employee> employees = new List<Employee>();

            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    const string insertQuery = "SELECT eID, fname, lname, addressID, dob FROM employee";
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            var lnameOrdinal = reader.GetOrdinal("lname");
                            var fnameOrdinal = reader.GetOrdinal("fname");
                            var addressIdOrdinal = reader.GetOrdinal("addressID");
                            var dobOrdinal = reader.GetOrdinal("dob");
                            var eIdOrdinal = reader.GetOrdinal("eID");

                            while (reader.Read())
                            {
                                var employee = new Employee {
                                    Lname = reader[lnameOrdinal] == DBNull.Value
                                        ? "null"
                                        : reader.GetString(lnameOrdinal),
                                    Fname = reader[fnameOrdinal] == DBNull.Value
                                        ? "null"
                                        : reader.GetString(fnameOrdinal),
                                    EId = reader[eIdOrdinal] == DBNull.Value
                                        ? "null"
                                        : reader.GetString(eIdOrdinal),
                                    AddressId = reader[addressIdOrdinal] == DBNull.Value
                                        ? 0
                                        : reader.GetInt32(addressIdOrdinal),
                                    Dob = reader[dobOrdinal] == DBNull.Value
                                        ? DateTime.Now
                                        : reader.GetDateTime(dobOrdinal)
                                };

                                employees.Add(employee);
                            }
                        }

                        return employees;
                    }
                }
            }
            catch (MySqlException mex)
            {
                throw new ArgumentException(mex.Message);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        #endregion
    }
}