using System;
using System.Collections.Generic;
using CS3230Project.Model;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    /// <summary>
    /// </summary>
    internal class DoctorDAL
    {
        #region Methods

        /// <summary>
        ///     Retrieves the doctors.
        /// </summary>
        /// <param name="employees">The employees.</param>
        /// <returns>List of doctors</returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public IList<Doctor> RetrieveDoctors(IList<Employee> employees)
        {
            IList<Doctor> doctors = new List<Doctor>();

            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    foreach (var person in employees)
                    {
                        const string selectQuery = "SELECT doctorID FROM doctor WHERE eID = @eID";
                        using (var cmd = new MySqlCommand(selectQuery, conn))
                        {
                            cmd.Parameters.Add("@eID", MySqlDbType.VarChar);
                            cmd.Parameters["@eID"].Value = person.EId;

                            using (var reader = cmd.ExecuteReader())
                            {
                                var doctorIdOrdinal = reader.GetOrdinal("doctorID");

                                while (reader.Read())
                                {
                                    var doctor = new Doctor {
                                        DoctorId = reader[doctorIdOrdinal] == DBNull.Value
                                            ? "null"
                                            : reader.GetString(doctorIdOrdinal),
                                        Employee = person
                                    };

                                    doctors.Add(doctor);
                                }
                            }
                        }
                    }

                    return doctors;
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