﻿using System;
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
        ///     Inserts the patient.
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
                    const string insertQuery =
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
                        cmd.Parameters["@addressID"].Value = patient.AddressId;

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
            var rnd = new Random();
            var patientId = 0;
            var idChecker = true;

            while (idChecker)
            {
                patientId = rnd.Next(1, 1000000000);
                var patients = this.RetrieveAllPatients();

                idChecker = checkIfIdExists(patients, patientId);
            }

            return patientId;
        }

        private static bool checkIfIdExists(IEnumerable<Patient> patients, int patientId)
        {
            foreach (var patient in patients)
            {
                if (patient.PatientId == patientId)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Updates the patient information.
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
                    const string insertQuery =
                        "UPDATE `patient` SET  `lname`= @lname, `fname`= @fname, `sex`= @sex, `ssn`= @ssn, `dob` = @dob WHERE `patientID` = @PatientId;";
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
        ///     Retrieves the patients.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        /// <returns>A list of all patients in the database.</returns>
        public IList<Patient> RetrieveAllPatients()
        {
            IList<Patient> patients = new List<Patient>();

            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    const string insertQuery = "SELECT * FROM patient";
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        appendPatients(cmd, patients);

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
        ///     Retrieves the patients.
        /// </summary>
        /// <param name="dob">The dob.</param>
        /// <returns></returns>
        public IList<Patient> RetrievePatients(DateTime dob)
        {
            var patients = new List<Patient>();

            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string insertQuery =
                    "SELECT lname, fname, sex, patientID, addressID, ssn, dob FROM patient WHERE dob = @dob";
                using (var cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add("@dob", MySqlDbType.Date);
                    cmd.Parameters["@dob"].Value = dob;

                    appendPatients(cmd, patients);

                    return patients;
                }
            }
        }

        /// <summary>
        ///     Retrieves the patients.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        public IList<Patient> RetrievePatients(string firstName, string lastName)
        {
            var patients = new List<Patient>();

            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string selectQuery =
                    "SELECT lname, fname, sex, patientID, addressID, ssn, dob FROM patient WHERE fname = @fname and lname = @lname";
                using (var cmd = new MySqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.Add("@lname", MySqlDbType.VarChar);
                    cmd.Parameters["@lname"].Value = lastName;

                    cmd.Parameters.Add("@fname", MySqlDbType.VarChar);
                    cmd.Parameters["@fname"].Value = firstName;

                    appendPatients(cmd, patients);

                    return patients;
                }
            }
        }

        /// <summary>
        ///     Retrieves the patients.
        /// </summary>
        /// <param name="lastName">The last name.</param>
        /// <param name="dob">The dob.</param>
        /// <returns></returns>
        public IList<Patient> RetrievePatients(string lastName, DateTime dob)
        {
            var patients = new List<Patient>();

            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string insertQuery =
                    "SELECT lname, fname, sex, patientID, addressID, ssn, dob FROM patient WHERE lname = @lname and dob = @dob";
                using (var cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add("@lname", MySqlDbType.VarChar);
                    cmd.Parameters["@lname"].Value = lastName;

                    cmd.Parameters.Add("@dob", MySqlDbType.Date);
                    cmd.Parameters["@dob"].Value = dob;

                    appendPatients(cmd, patients);

                    return patients;
                }
            }
        }

        /// <summary>
        ///     Retrieves the patients.
        /// </summary>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        public IList<Patient> RetrievePatients(string lastName)
        {
            var patients = new List<Patient>();

            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string insertQuery =
                    "SELECT lname, fname, sex, patientID, addressID, ssn, dob FROM patient WHERE lname = @lname;";
                using (var cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add("@lname", MySqlDbType.VarChar);
                    cmd.Parameters["@lname"].Value = lastName;

                    appendPatients(cmd, patients);

                    return patients;
                }
            }
        }

        /// <summary>
        ///     Retrieves the patients.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="dob">The dob.</param>
        /// <returns></returns>
        public IList<Patient> RetrievePatients(string firstName, string lastName, DateTime dob)
        {
            var patients = new List<Patient>();

            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string insertQuery =
                    "SELECT lname, fname, sex, patientID, addressID, ssn, dob FROM patient WHERE fname = @fname and lname = @lname and dob = @dob";
                using (var cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add("@lname", MySqlDbType.VarChar);
                    cmd.Parameters["@lname"].Value = lastName;

                    cmd.Parameters.Add("@fname", MySqlDbType.VarChar);
                    cmd.Parameters["@fname"].Value = firstName;

                    cmd.Parameters.Add("@dob", MySqlDbType.Date);
                    cmd.Parameters["@dob"].Value = dob;

                    appendPatients(cmd, patients);

                    return patients;
                }
            }
        }

        private static void appendPatients(MySqlCommand cmd, ICollection<Patient> patients)
        {
            using (var reader = cmd.ExecuteReader())
            {
                var lnameOrdinal = reader.GetOrdinal("lname");
                var fnameOrdinal = reader.GetOrdinal("fname");
                var sexOrdinal = reader.GetOrdinal("sex");
                var patientIdOrdinal = reader.GetOrdinal("patientID");
                var addressIdOrdinal = reader.GetOrdinal("addressID");
                var ssnOrdinal = reader.GetOrdinal("ssn");
                var dobOrdinal = reader.GetOrdinal("dob");

                while (reader.Read())
                {
                    var patient = new Patient {
                        Lname = reader[lnameOrdinal] == DBNull.Value
                            ? "null"
                            : reader.GetString(lnameOrdinal),
                        Sex = reader[sexOrdinal] == DBNull.Value ? "null" : reader.GetString(sexOrdinal),
                        Fname = reader[fnameOrdinal] == DBNull.Value
                            ? "null"
                            : reader.GetString(fnameOrdinal),
                        PatientId = reader[patientIdOrdinal] == DBNull.Value
                            ? 0
                            : reader.GetInt32(patientIdOrdinal),
                        AddressId = reader[addressIdOrdinal] == DBNull.Value
                            ? 0
                            : reader.GetInt32(addressIdOrdinal),
                        Ssn = reader[ssnOrdinal] == DBNull.Value ? "null" : reader.GetString(ssnOrdinal),
                        DateOfBirth = reader[dobOrdinal] == DBNull.Value
                            ? DateTime.Now
                            : reader.GetDateTime(dobOrdinal)
                    };

                    patients.Add(patient);
                }
            }
        }

        /// <summary>
        ///     Finds the patient.
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

        /// <summary>
        ///     Deletes the patient information.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <returns>true if the delete was successful and false otherwise.</returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public bool DeletePatientInfo(Patient patient)
        {
            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    const string deleteQuery = "DELETE FROM `patient` WHERE `patientID` = @PatientId;";
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