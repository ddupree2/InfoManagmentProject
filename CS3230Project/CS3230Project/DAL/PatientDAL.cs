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
                var patients = this.RetrievePatients();

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
        ///     Retrieves the patients.
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
                    const string insertQuery = "SELECT * FROM patient";
                    using (var cmd = new MySqlCommand(insertQuery, conn))
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

        /// <summary>
        ///     Retrieves the appointments.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        public IList<Appointment> RetrieveAppointments(string firstName, string lastName)
        {
            var connection = DbConnection.GetConnection();
            const string patientIdQuery =
                "SELECT * FROM appointment a JOIN patient p ON a.patientID = p.patientID where fname = @fname and lname = @lname";

            using (connection)
            {
                connection.Open();
                using (var cmd = new MySqlCommand(patientIdQuery, connection))
                {
                    cmd.Parameters.Add("@lname", MySqlDbType.VarChar);
                    cmd.Parameters["@lname"].Value = lastName;

                    cmd.Parameters.Add("@fname", MySqlDbType.VarChar);
                    cmd.Parameters["@fname"].Value = firstName;

                    return retrieveAppointmentsList(cmd);
                }
            }
        }

        /// <summary>
        ///     Retrieves the appointments.
        /// </summary>
        /// <param name="dob">The dob.</param>
        /// <returns></returns>
        public IList<Appointment> RetrieveAppointments(DateTime dob)
        {
            var connection = DbConnection.GetConnection();
            const string patientIdQuery =
                "SELECT * FROM appointment a JOIN patient p ON a.patientID = p.patientID where dob = @dob";

            using (connection)
            {
                connection.Open();
                using (var cmd = new MySqlCommand(patientIdQuery, connection))
                {
                    cmd.Parameters.Add("@dob", MySqlDbType.Date);
                    cmd.Parameters["@dob"].Value = dob;

                    return retrieveAppointmentsList(cmd);
                }
            }
        }

        /// <summary>
        ///     Retrieves the appointments.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="dob">The dob.</param>
        /// <returns></returns>
        public IList<Appointment> RetrieveAppointments(string firstName, string lastName, DateTime dob)
        {
            var connection = DbConnection.GetConnection();
            const string patientIdQuery =
                "SELECT * FROM appointment a JOIN patient p ON a.patientID = p.patientID where fname = @fname and lname = @lname and dob = @dob";

            using (connection)
            {
                connection.Open();
                using (var cmd = new MySqlCommand(patientIdQuery, connection))
                {
                    cmd.Parameters.Add("@lname", MySqlDbType.VarChar);
                    cmd.Parameters["@lname"].Value = lastName;

                    cmd.Parameters.Add("@fname", MySqlDbType.VarChar);
                    cmd.Parameters["@fname"].Value = firstName;

                    cmd.Parameters.Add("@dob", MySqlDbType.Date);
                    cmd.Parameters["@dob"].Value = dob;

                    return retrieveAppointmentsList(cmd);
                }
            }
        }

        private static IList<Appointment> retrieveAppointmentsList(MySqlCommand cmd)
        {
            IList<Appointment> appointments = new List<Appointment>();

            using (var reader = cmd.ExecuteReader())
            {
                var appointmentDateOrdinal = reader.GetOrdinal("appointmentdate");
                var reasonOrdinal = reader.GetOrdinal("reason");
                var doctorIdOrdinal = reader.GetOrdinal("doctorID");
                var patientIdOrdinal = reader.GetOrdinal("patientID");

                while (reader.Read())
                {
                    var appointmentDate = reader[appointmentDateOrdinal] == DBNull.Value
                        ? DateTime.Now
                        : reader.GetDateTime(appointmentDateOrdinal);
                    var reason = reader[reasonOrdinal] == DBNull.Value
                        ? "null"
                        : reader.GetString(reasonOrdinal);
                    var doctorId = reader[doctorIdOrdinal] == DBNull.Value
                        ? default
                        : reader.GetString(doctorIdOrdinal);
                    var patientId = reader[patientIdOrdinal] == DBNull.Value
                        ? "null"
                        : reader.GetString(patientIdOrdinal);

                    var appointment = new Appointment(reason, patientId, doctorId, appointmentDate);

                    appointments.Add(appointment);
                }
            }

            return appointments;
        }

        public IList<Visit> RetrieveVisits(string firstName, string lastName)
        {
            var connection = DbConnection.GetConnection();
            const string patientIdQuery =
                "SELECT * FROM visit v JOIN patient p ON v.patientID = p.patientID where fname = @fname and lname = @lname";

            using (connection)
            {
                connection.Open();
                using (var cmd = new MySqlCommand(patientIdQuery, connection))
                {
                    cmd.Parameters.Add("@lname", MySqlDbType.VarChar);
                    cmd.Parameters["@lname"].Value = lastName;

                    cmd.Parameters.Add("@fname", MySqlDbType.VarChar);
                    cmd.Parameters["@fname"].Value = firstName;

                    return retrieveVisitList(cmd);
                }
            }
        }

        /// <summary>
        ///     Retrieves the appointments.
        /// </summary>
        /// <param name="dob">The dob.</param>
        /// <returns></returns>
        public IList<Visit> RetrieveVisits(DateTime dob)
        {
            var connection = DbConnection.GetConnection();
            const string patientIdQuery =
                "SELECT * FROM visit v JOIN patient p ON v.patientID = p.patientID where dob = @dob";

            using (connection)
            {
                connection.Open();
                using (var cmd = new MySqlCommand(patientIdQuery, connection))
                {
                    cmd.Parameters.Add("@dob", MySqlDbType.Date);
                    cmd.Parameters["@dob"].Value = dob;

                    return retrieveVisitList(cmd);
                }
            }
        }

        /// <summary>
        ///     Retrieves the appointments.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="dob">The dob.</param>
        /// <returns></returns>
        public IList<Visit> RetrieveVisits(string firstName, string lastName, DateTime dob)
        {
            var connection = DbConnection.GetConnection();
            const string patientIdQuery =
                "SELECT * FROM visit v JOIN patient p ON v.patientID = p.patientID where fname = @fname and lname = @lname and dob = @dob";

            using (connection)
            {
                connection.Open();
                using (var cmd = new MySqlCommand(patientIdQuery, connection))
                {
                    cmd.Parameters.Add("@lname", MySqlDbType.VarChar);
                    cmd.Parameters["@lname"].Value = lastName;

                    cmd.Parameters.Add("@fname", MySqlDbType.VarChar);
                    cmd.Parameters["@fname"].Value = firstName;

                    cmd.Parameters.Add("@dob", MySqlDbType.Date);
                    cmd.Parameters["@dob"].Value = dob;

                    return retrieveVisitList(cmd);
                }
            }
        }

        private static IList<Visit> retrieveVisitList(MySqlCommand cmd)
        {
            IList<Visit> visits = new List<Visit>();

            using (var reader = cmd.ExecuteReader())
            {
                var systolicNumberOrdinal = reader.GetOrdinal("systolicNum");
                var diastolicNumberOrdinal = reader.GetOrdinal("diastolicNum");
                var heartRateOrdinal = reader.GetOrdinal("heartrate");
                var respirationRateOrdinal = reader.GetOrdinal("respirationrate");
                var bodyTempOrdinal = reader.GetOrdinal("bodytemp");
                var otherOrdinal = reader.GetOrdinal("other");
                var nurseIdOrdinal = reader.GetOrdinal("nurseID");
                var appointmentDateOrdinal = reader.GetOrdinal("appointmentdate");
                var patientIdOrdinal = reader.GetOrdinal("patientID");
                var diagnosisOrdinal = reader.GetOrdinal("diagnosis");

                while (reader.Read())
                {
                    var systolicNum = reader[systolicNumberOrdinal] == DBNull.Value
                        ? 0
                        : reader.GetInt32(systolicNumberOrdinal);
                    var diastolicNum = reader[diastolicNumberOrdinal] == DBNull.Value
                        ? 0
                        : reader.GetInt32(diastolicNumberOrdinal);
                    var heartRate = reader[heartRateOrdinal] == DBNull.Value
                        ? 0
                        : reader.GetInt32(heartRateOrdinal);
                    var respirationRate = reader[respirationRateOrdinal] == DBNull.Value
                        ? 0
                        : reader.GetInt32(respirationRateOrdinal);
                    var bodyTemp = reader[bodyTempOrdinal] == DBNull.Value
                        ? 0
                        : reader.GetDouble(bodyTempOrdinal);
                    var other = reader[otherOrdinal] == DBNull.Value
                        ? "null"
                        : reader.GetString(otherOrdinal);
                    var nurseId = reader[nurseIdOrdinal] == DBNull.Value
                        ? default
                        : reader.GetString(nurseIdOrdinal);
                    var appointmentDate = reader[appointmentDateOrdinal] == DBNull.Value
                        ? DateTime.Now
                        : reader.GetDateTime(appointmentDateOrdinal);
                    var patientId = reader[patientIdOrdinal] == DBNull.Value
                        ? 0
                        : reader.GetInt32(patientIdOrdinal);
                    var diagnosis = reader[diagnosisOrdinal] == DBNull.Value
                        ? "null"
                        : reader.GetString(diagnosisOrdinal);

                    var visit = new Visit(systolicNum, diastolicNum, heartRate, respirationRate, bodyTemp, other,
                        nurseId, patientId, appointmentDate, diagnosis);

                    var testResults = retrieveTestResults(patientId, appointmentDate);
                    visit.TestResults = testResults;
                    visits.Add(visit);
                }
            }

            return visits;
        }

        private static IList<TestResult> retrieveTestResults(int patientId, DateTime appointmentDate)
        {
            IList<TestResult> testResults = new List<TestResult>();

            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    const string deleteQuery =
                        "SELECT * FROM `testResults` WHERE `patientID` = @patientId AND 'appointmentdate' = @appointmentDate;";
                    using (var cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.Add("@patientID", MySqlDbType.VarChar);
                        cmd.Parameters["@patientID"].Value = patientId.ToString();

                        cmd.Parameters.Add("@appointmentDate", MySqlDbType.DateTime);
                        cmd.Parameters["@appointmentDate"].Value = appointmentDate;

                        readInTestResults(cmd, testResults);
                    }
                }
            }
            catch (MySqlException mex)
            {
                Debug.WriteLine(mex.Message + Environment.NewLine + mex.StackTrace);
            }

            return testResults;
        }

        private static void readInTestResults(MySqlCommand cmd, IList<TestResult> testResults)
        {
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var testDateOrdinal = reader.GetOrdinal("testdate");
                    var resultsOrdinal = reader.GetOrdinal("results");
                    var appointmentDateOrdinal = reader.GetOrdinal("appointmentdate");
                    var patientIdOrdinal = reader.GetOrdinal("patientID");
                    var testCodeOrdinal = reader.GetOrdinal("testCode");

                    var testDate = reader[testDateOrdinal] == DBNull.Value
                        ? DateTime.Now
                        : reader.GetDateTime(testDateOrdinal);
                    var results = reader[resultsOrdinal] == DBNull.Value
                        ? default
                        : reader.GetString(resultsOrdinal);
                    var appointmentDate = reader[appointmentDateOrdinal] == DBNull.Value
                        ? DateTime.Now
                        : reader.GetDateTime(appointmentDateOrdinal);
                    var patientId = reader[patientIdOrdinal] == DBNull.Value
                        ? 0
                        : reader.GetInt32(patientIdOrdinal);
                    var testCode = reader[testCodeOrdinal] == DBNull.Value
                        ? 0
                        : reader.GetInt32(testCodeOrdinal);

                    var testResult = new TestResult(testDate,results,appointmentDate,patientId,testCode);
                    testResults.Add(testResult);
                }
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
                    const string deleteQuery = "DELETE FROM `patient` WHERE `patientID` = @patientId;";
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