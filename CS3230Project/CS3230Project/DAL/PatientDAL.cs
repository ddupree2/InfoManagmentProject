using System;
using System.Collections.Generic;
using System.Diagnostics;
using CS3230Project.Model;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    /// <summary>
    ///     Represents the Data Access Layer for manipulating patient table in the database.
    /// </summary>
    public class PatientDal
    {
        #region Methods

        /// <summary>
        /// Inserts the patient.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public bool InsertPatient(Patient patient)
        {
            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    var insertQuery =
                        "INSERT INTO `patient` (`patientID`, `lname`, `fname`, `addressID`, `sex`, ssn, `dob`) VALUES (@patientID, @lname, @fname, @addressID, @sex, @ssn, @dob);";
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        var patientId = this.generatePatientId();

                        cmd.Parameters.Add("@patientID", MySqlDbType.VarChar);
                        cmd.Parameters["@patientID"].Value = patientId;

                        cmd.Parameters.Add("@ssn", MySqlDbType.VarChar);
                        cmd.Parameters["@ssn"].Value = patient.Ssn;

                        cmd.Parameters.Add("@lname", MySqlDbType.VarChar);
                        cmd.Parameters["@lname"].Value = patient.Lname;

                        cmd.Parameters.Add("@fname", MySqlDbType.VarChar);
                        cmd.Parameters["@fname"].Value = patient.Fname;

                        cmd.Parameters.Add("@addressID", MySqlDbType.Int32);
                        cmd.Parameters["@addressID"].Value = patient.AddressID;

                        cmd.Parameters.Add("@sex", MySqlDbType.VarChar);
                        cmd.Parameters["@sex"].Value = patient.Sex;

                        cmd.Parameters.Add("@dob", MySqlDbType.Date);
                        cmd.Parameters["@dob"].Value = patient.DateOfBirth;

                        cmd.ExecuteNonQuery();

                        return true;
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

        private int generatePatientId()
        {
            Random rnd = new Random();
            var patientId = 0;
            var idChecker = true;

            while (idChecker == true)
            {
                patientId = rnd.Next(1, 1000000000);
                var patients = this.RetrievePatients();

                idChecker = checkIfIdExists(patients, patientId);
            }

            return patientId;
        }

        private static bool checkIfIdExists(IList<Patient> patients, int patientID)
        {
            foreach (var patient in patients)
            {
                if (patient.PatientId == patientID)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Updates the patient information.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public bool UpdatePatientInfo(Patient patient)
        {
            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    var insertQuery =
                        "UPDATE `patient` SET  `lname`= @lname, `fname`= @fname, `sex`= @sex, `ssn`= @ssn, `dob` = @dob WHERE `patientID` = @patientId;";
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add("@patientID", MySqlDbType.VarChar);
                        cmd.Parameters["@patientID"].Value = patient.PatientId;

                        cmd.Parameters.Add("@ssn", MySqlDbType.VarChar);
                        cmd.Parameters["@ssn"].Value = patient.Ssn;

                        cmd.Parameters.Add("@lname", MySqlDbType.VarChar);
                        cmd.Parameters["@lname"].Value = patient.Lname;

                        cmd.Parameters.Add("@fname", MySqlDbType.VarChar);
                        cmd.Parameters["@fname"].Value = patient.Fname;

                        cmd.Parameters.Add("@sex", MySqlDbType.VarChar);
                        cmd.Parameters["@sex"].Value = patient.Sex;

                        cmd.Parameters.Add("@dob", MySqlDbType.Date);
                        cmd.Parameters["@dob"].Value = patient.DateOfBirth;

                        cmd.ExecuteNonQuery();

                        return true;
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

        /// <summary>
        /// Retrieves the patients.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        /// <returns>A list of all patients in the database.</returns>
        public IList<Patient> RetrievePatients()
        {
            IList<Patient> patients = new List<Patient>();

            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    var insertQuery =
                        "SELECT * FROM patient";
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {

                        using (var reader = cmd.ExecuteReader())
                        {
                            var lnameOrdinal = reader.GetOrdinal("lname");
                            var fnameOrdinal = reader.GetOrdinal("fname");
                            var sexOrdinal = reader.GetOrdinal("sex");
                            var patientIDOrdinal = reader.GetOrdinal("patientID");
                            var addressIDOrdinal = reader.GetOrdinal("addressID");
                            var ssnOrdinal = reader.GetOrdinal("ssn");
                            var dobOrdinal = reader.GetOrdinal("dob");

                            while (reader.Read())
                            {
                                var patient = new Patient();

                                 patient.Lname = reader[lnameOrdinal] == DBNull.Value ? "null" : reader.GetString(lnameOrdinal);
                                 patient.Sex = reader[sexOrdinal] == DBNull.Value ? "null" : reader.GetString(sexOrdinal);
                                 patient.Fname = reader[fnameOrdinal] == DBNull.Value ? "null" : reader.GetString(fnameOrdinal);
                                 patient.PatientId = reader[patientIDOrdinal] == DBNull.Value ? 0 : reader.GetInt32(patientIDOrdinal);
                                 patient.AddressID = reader[addressIDOrdinal] == DBNull.Value ? 0 : reader.GetInt32(addressIDOrdinal);
                                 patient.Ssn = reader[ssnOrdinal] == DBNull.Value ? "null" : reader.GetString(ssnOrdinal);
                                 patient.DateOfBirth = reader[dobOrdinal] == DBNull.Value ? DateTime.Now : reader.GetDateTime(dobOrdinal);

                                patients.Add(patient);

                            }

                        }

                        return patients;
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

        /// <summary>
        /// Finds the patient.
        /// </summary>
        /// <param name="patientId">The patient identifier.</param>
        /// <returns></returns>
        public bool FindPatient(string patientId)
        {

            var connection = DbConnection.GetConnection();
            const string query = "select patientID from patient where patientID = @patientID";

            using (connection)
            {
                connection.Open();
                return checkForPatient(patientId, query, connection);
            }
        }

        private static bool checkForPatient(string patientId, string query,
            MySqlConnection connection)
        {
            var foundPatientId = false;
            try
            {
                using (var cmd = new MySqlCommand(query, connection))
                {
                    Debug.WriteLine($"isPotentialPatient: {patientId != null && !patientId.Equals(string.Empty)}");

                    cmd.Parameters.Add("@patientID", MySqlDbType.VarChar);
                    cmd.Parameters["@patientID"].Value = patientId;

                    var currPatientId = cmd.ExecuteScalar();
                    Debug.WriteLine($"Found patientID: {currPatientId}");
                    foundPatientId = currPatientId != null;
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

            return foundPatientId;
        }

        public bool DeletePatientInfo(Patient patient)
        {
            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    var deleteQuery = "DELETE FROM `patient` WHERE `patientID` = @patientId;";
                    using (var cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.Add("@patientID", MySqlDbType.VarChar);
                        cmd.Parameters["@patientID"].Value = patient.PatientId;

                        cmd.ExecuteNonQuery();

                        return true;
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