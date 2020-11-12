using System;
using System.Collections.Generic;
using System.Diagnostics;
using CS3230Project.Model;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    /// <summary>
    ///     Represent the Data Access Layer for the visit table in the database
    /// </summary>
    public class VisitsDal
    {
        /// <summary>
        ///     Retrieves the visits.
        /// </summary>
        /// <param name="patientID">The visit identifier.</param>
        /// <param name="appointmentDate">The appointment date.</param>
        /// <returns> an IList of visits</returns>
        public IList<Visit> RetrieveVisits(int patientID, DateTime appointmentDate)
        {
            var connection = DbConnection.GetConnection();
            const string patientIdQuery =
                "SELECT * FROM visit v JOIN visit p ON v.patientID = p.patientID where v.patientID = @patientID and v.appointmentdate = @AppointmentDate";

            using (connection)
            {
                connection.Open();
                using (var cmd = new MySqlCommand(patientIdQuery, connection))
                {
                    cmd.Parameters.Add("@patientID", MySqlDbType.VarChar);
                    cmd.Parameters["@patientID"].Value = patientID.ToString();

                    cmd.Parameters.Add("@AppointmentDate", MySqlDbType.DateTime);
                    cmd.Parameters["@AppointmentDate"].Value = appointmentDate;

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
                var finalDiagnosisOrdinal = reader.GetOrdinal("FinalDiagnosis");

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

                    var finalDiagnosis = reader[finalDiagnosisOrdinal] != DBNull.Value && reader.GetBoolean(finalDiagnosisOrdinal);

                    var visit = new Visit(systolicNum, diastolicNum, heartRate, respirationRate, bodyTemp, other,
                        nurseId, patientId, appointmentDate, diagnosis, finalDiagnosis);

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
                        "SELECT testdate, results, appointmentdate, patientID, r.testCode, testName, AbnormalStatus FROM testResults r JOIN test t ON r.testCode = t.testCode WHERE `appointmentdate` = @appointmentDate AND `patientID` = @patientId;";
                    using (var cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.Add("@patientID", MySqlDbType.VarChar);
                        cmd.Parameters["@patientID"].Value = patientId.ToString();

                        cmd.Parameters.Add("@AppointmentDate", MySqlDbType.DateTime);
                        cmd.Parameters["@AppointmentDate"].Value = appointmentDate;

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

        private static void readInTestResults(MySqlCommand cmd, ICollection<TestResult> testResults)
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
                    var testNameOrdinal = reader.GetOrdinal("testName");
                    var statusNameOrdinal = reader.GetOrdinal("AbnormalStatus");

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
                    var testName = reader[testNameOrdinal] == DBNull.Value
                        ? default
                        : reader.GetString(testNameOrdinal);

                    var status = reader[statusNameOrdinal] == DBNull.Value
                        ? default
                        : reader.GetBoolean(statusNameOrdinal);

                    var testResult = new TestResult(testDate, results, appointmentDate, patientId, testCode, testName, status);
                    testResults.Add(testResult);
                }
            }
        }

        /// <summary>
        ///     Checks if visits exists for the given visit id and appointment date.
        /// </summary>
        /// <param name="patientId">The visit identifier.</param>
        /// <param name="appointmentDate">The appointment date.</param>
        /// <returns>true iff a visit exists for the given visit id and appointment date</returns>
        public bool VisitExists(int patientId, DateTime appointmentDate)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();

                const string visitExistsQuery =
                    "SELECT patientID, appointmentdate FROM visit WHERE appointmentdate = @AppointmentDate AND patientID = @patientID;";
                using (var cmd = new MySqlCommand(visitExistsQuery, conn))
                {
                    cmd.Parameters.Add("@patientID", MySqlDbType.VarChar);
                    cmd.Parameters["@patientID"].Value = patientId.ToString();

                    cmd.Parameters.Add("@AppointmentDate", MySqlDbType.DateTime);
                    cmd.Parameters["@AppointmentDate"].Value = appointmentDate;

                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.Read();
                    }
                }
            }
        }

        /// <summary>
        ///     Inserts the visit.
        /// </summary>
        /// <param name="visit">The visit.</param>
        /// <returns>true iff the visit is successfully inserted</returns>
        public bool InsertVisit(Visit visit)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string insertQuery =
                    "INSERT INTO `visit` (`systolicNum`, `diastolicNum`, `heartrate`, `respirationrate`, `bodytemp`, `other`, `nurseID`, `appointmentdate`, `patientID`,`diagnosis`, `FinalDiagnosis`) " +
                    "VALUES (@systolicNum, @diastolicNum, @heartrate, @respirationrate, @bodytemp, @other, @nurseID, @AppointmentDate, @patientID, @diagnosis, @finalDiagnosis);";
                using (var cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add("@systolicNum", MySqlDbType.Int32);
                    cmd.Parameters["@systolicNum"].Value = visit.SystolicNum;

                    cmd.Parameters.Add("@diastolicNum", MySqlDbType.Int32);
                    cmd.Parameters["@diastolicNum"].Value = visit.DiastolicNum;

                    cmd.Parameters.Add("@heartrate", MySqlDbType.Int32);
                    cmd.Parameters["@heartrate"].Value = visit.HeartRate;

                    cmd.Parameters.Add("@respirationrate", MySqlDbType.Int32);
                    cmd.Parameters["@respirationrate"].Value = visit.RespirationRate;

                    cmd.Parameters.Add("@bodytemp", MySqlDbType.Double);
                    cmd.Parameters["@bodytemp"].Value = visit.BodyTemp;

                    cmd.Parameters.Add("@other", MySqlDbType.VarChar);
                    cmd.Parameters["@other"].Value = visit.Other;

                    cmd.Parameters.Add("@nurseID", MySqlDbType.VarChar);
                    cmd.Parameters["@nurseID"].Value = visit.NurseId;

                    cmd.Parameters.Add("@AppointmentDate", MySqlDbType.DateTime);
                    cmd.Parameters["@AppointmentDate"].Value = visit.AppointmentDate;

                    cmd.Parameters.Add("@patientID", MySqlDbType.VarChar);
                    cmd.Parameters["@patientID"].Value = visit.PatientId;

                    cmd.Parameters.Add("@diagnosis", MySqlDbType.VarChar);
                    cmd.Parameters["@diagnosis"].Value = visit.Diagnosis;

                    cmd.Parameters.Add("@finalDiagnosis", MySqlDbType.Int32);
                    cmd.Parameters["@finalDiagnosis"].Value = visit.FinalDiagnosis;

                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }

        /// <summary>
        ///     Updates the visit information.
        /// </summary>
        /// <param name="visit">The visit.</param>
        /// <returns>true iff the visit was updated</returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public bool UpdateVist(Visit visit)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string insertQuery =
                    "UPDATE `visit` SET  `systolicNum`= @systolicNum, `diastolicNum`= @diastolicNum, `heartrate`= @heartrate, `respirationrate`= @respirationrate, " +
                    "`bodytemp` = @bodytemp, `other` = @other, `nurseID` = @nurseID, `diagnosis` = @diagnosis, `FinalDiagnosis` = @finalDiagnosis WHERE `patientID` = @patientID AND `appointmentdate` = @AppointmentDate;";
                
                using (var cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add("@systolicNum", MySqlDbType.Int32);
                    cmd.Parameters["@systolicNum"].Value = visit.SystolicNum;

                    cmd.Parameters.Add("@diastolicNum", MySqlDbType.Int32);
                    cmd.Parameters["@diastolicNum"].Value = visit.DiastolicNum;

                    cmd.Parameters.Add("@heartrate", MySqlDbType.Int32);
                    cmd.Parameters["@heartrate"].Value = visit.HeartRate;

                    cmd.Parameters.Add("@respirationrate", MySqlDbType.Int32);
                    cmd.Parameters["@respirationrate"].Value = visit.RespirationRate;

                    cmd.Parameters.Add("@bodytemp", MySqlDbType.Double);
                    cmd.Parameters["@bodytemp"].Value = visit.BodyTemp;

                    cmd.Parameters.Add("@other", MySqlDbType.VarChar);
                    cmd.Parameters["@other"].Value = visit.Other;

                    cmd.Parameters.Add("@nurseID", MySqlDbType.VarChar);
                    cmd.Parameters["@nurseID"].Value = visit.NurseId;

                    cmd.Parameters.Add("@AppointmentDate", MySqlDbType.DateTime);
                    cmd.Parameters["@AppointmentDate"].Value = visit.AppointmentDate;

                    cmd.Parameters.Add("@patientID", MySqlDbType.VarChar);
                    cmd.Parameters["@patientID"].Value = visit.PatientId;

                    cmd.Parameters.Add("@diagnosis", MySqlDbType.VarChar);
                    cmd.Parameters["@diagnosis"].Value = visit.Diagnosis;

                    cmd.Parameters.Add("@finalDiagnosis", MySqlDbType.Int32);
                    cmd.Parameters["@finalDiagnosis"].Value = visit.FinalDiagnosis;

                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
    }
}