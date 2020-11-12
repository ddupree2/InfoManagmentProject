using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3230Project.Model;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    class TestResultsDAL
    {

        public bool updateTestResults(TestResult testResult)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string insertQuery =
                    "UPDATE `testResults` SET  `testDate`= @testDate, `testResults`= @testResults, `AbnormalStatus`= @abnormalStatus` WHERE `patientID` = @patientID AND `appointmentdate` = @appointmentDate;";

                using (var cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add("@testDate", MySqlDbType.Date);
                    cmd.Parameters["@testDate"].Value = testResult.TestDate.Date;

                    cmd.Parameters.Add("@testResults", MySqlDbType.VarChar);
                    cmd.Parameters["@testResults"].Value = testResult.Results;

                    cmd.Parameters.Add("@abnormalStatus", MySqlDbType.Int32);
                    cmd.Parameters["@abnormalStatus"].Value = testResult.AbnormalStatus;


                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
    }
}

