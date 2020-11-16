using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using CS3230Project.Model;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    internal class TestDAL
    {
        #region Methods

        public bool UpdateTestResults(TestResult testResults)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string updateQuery =
                    "UPDATE `testResults` SET  `testdate`= @testDate, `results`= @results, `AbnormalStatus`= @abnormalStatus WHERE `patientID` = @patientID AND `appointmentdate` = @AppointmentDate AND `testCode` = @testCode;";

                using (var cmd = new MySqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("@testDate", MySqlDbType.Date);
                    cmd.Parameters["@testDate"].Value = testResults.TestDate;

                    cmd.Parameters.Add("@results", MySqlDbType.VarChar);
                    cmd.Parameters["@results"].Value = testResults.Results;

                    cmd.Parameters.Add("@abnormalStatus", MySqlDbType.Int16);
                    cmd.Parameters["@abnormalStatus"].Value = testResults.AbnormalStatus;

                    cmd.Parameters.Add("@patientID", MySqlDbType.VarChar);
                    cmd.Parameters["@patientID"].Value = testResults.PatientId;

                    cmd.Parameters.Add("@AppointmentDate", MySqlDbType.DateTime);
                    cmd.Parameters["@AppointmentDate"].Value = testResults.AppointmentDate;

                    cmd.Parameters.Add("@testCode", MySqlDbType.Int64);
                    cmd.Parameters["@testCode"].Value = testResults.TestCode;

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
        }

        /// <summary>
        ///     Retrieves the available tests a patient can take.
        /// </summary>
        /// <returns>All available tests a patient can take</returns>
        public IDictionary<int, string> RetrieveAvailableTests(int patientId, DateTime appointmentDate)
        {
            IDictionary<int, string> availableTests = new Dictionary<int, string>();

            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string availableTestsQuery =
                    "test_retrieveAvailableTests";

                using (var cmd = new MySqlCommand(availableTestsQuery, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@patientID", MySqlDbType.Int32);
                    cmd.Parameters["@patientID"].Value = patientId;
                    cmd.Parameters["@patientID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@appointmentDate", MySqlDbType.DateTime);
                    cmd.Parameters["@appointmentDate"].Value = appointmentDate;
                    cmd.Parameters["@appointmentDate"].Direction = ParameterDirection.Input;

                    using (var reader = cmd.ExecuteReader())
                    {
                        var testCodeOrdinal = reader.GetOrdinal("testCode");
                        var testNameOrdinal = reader.GetOrdinal("testName");

                        while (reader.Read())
                        {
                            try
                            {
                                var testCode = reader[testCodeOrdinal] == DBNull.Value
                                    ? 0
                                    : reader.GetInt32(testCodeOrdinal);
                                var testName = reader[testNameOrdinal] == DBNull.Value
                                    ? null
                                    : reader.GetString(testNameOrdinal);

                                availableTests.Add(testCode, testName);
                            }
                            catch (ArgumentException ae)
                            {
                                Debug.WriteLine(ae.Message);
                                Debug.WriteLine(ae.StackTrace);
                            }
                        }
                    }
                }
            }

            return availableTests;
        }

        /// <summary>
        ///     Orders the tests.
        /// </summary>
        /// <param name="testsToOrder">The tests to order.</param>
        public bool OrderTests(IList<int> testsToOrder, int patientId, DateTime appointmentDate)
        {
            var allTestsOrdered = true;
            foreach (var testCode in testsToOrder)
            {
                try
                {
                    insertEmptyTestResult(testCode, patientId, appointmentDate);
                }
                catch (MySqlException e)
                {
                    allTestsOrdered = false;
                    Debug.WriteLine(e.Message);
                    Debug.WriteLine($"test code:{testCode} PatientID:{patientId} ApptDate:{appointmentDate}");
                }
            }

            return allTestsOrdered;
        }

        private static void insertEmptyTestResult(int testCode, int patientId, DateTime appointmentDate)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string insertTestQuery =
                    "INSERT INTO `testResults` (`appointmentdate`, `patientID`, `testCode`) VALUES (@appointmentDate, @patientID, @testCode);";

                using (var cmd = new MySqlCommand(insertTestQuery, conn))
                {
                    cmd.Parameters.Add("@appointmentDate", MySqlDbType.DateTime);
                    cmd.Parameters["@appointmentDate"].Value = appointmentDate;

                    cmd.Parameters.Add("@patientID", MySqlDbType.VarChar);
                    cmd.Parameters["@patientID"].Value = patientId;

                    cmd.Parameters.Add("@testCode", MySqlDbType.Int32);
                    cmd.Parameters["@testCode"].Value = testCode;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion
    }
}