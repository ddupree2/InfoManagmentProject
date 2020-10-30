using CS3230Project.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    /// <summary>
    ///     Represent the Data Access Layer for the visit table in the database
    /// </summary>
    public class VisitsDal
    {
        /// <summary>
        /// Retrieves the visits.
        /// </summary>
        /// <param name="patientID">The patient identifier.</param>
        /// <param name="appointmentDate">The appointment date.</param>
        /// <returns> an IList of visits</returns>
        public IList<Visit> RetrieveVisits(int patientID, DateTime appointmentDate)
        {
            var connection = DbConnection.GetConnection();
            const string patientIdQuery =
                "SELECT * FROM visit v JOIN patient p ON v.patientID = p.patientID where v.patientID = @patientID and appointmentdate = @appointmentDate";

            using (connection)
            {
                connection.Open();
                using (var cmd = new MySqlCommand(patientIdQuery, connection))
                {
                    cmd.Parameters.Add("@patientID", MySqlDbType.VarChar);
                    cmd.Parameters["@patientID"].Value = patientID.ToString();

                    cmd.Parameters.Add("@appointmentDate", MySqlDbType.DateTime);
                    cmd.Parameters["@appointmentDate"].Value = appointmentDate;

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
                        "SELECT testdate, results, appointmentdate, patientID, r.testCode, testName FROM testResults r JOIN test t ON r.testCode = t.testCode WHERE `appointmentdate` = @appointmentDate AND `patientID` = @patientId;";
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

                    var testResult = new TestResult(testDate, results, appointmentDate, patientId, testCode, testName);
                    testResults.Add(testResult);
                }
            }
        }
    }
}