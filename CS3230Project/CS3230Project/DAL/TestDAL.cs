using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3230Project.Model;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    class TestDAL
    {
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
    }
}

