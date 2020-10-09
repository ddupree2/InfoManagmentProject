using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3230Project.Model;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    class PatientDAL
    {
        public void InsertPatient(Patient patient)
        {
            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    var insertQuery = "INSERT INTO `patient` (`patientID`, `lname`, `fname`, `addressID`) VALUES (@ssn, @lname, @fname, @addressID);";
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add("@ssn", MySqlDbType.VarChar);
                        cmd.Parameters["@ssn"].Value = patient.Ssn;

                        cmd.Parameters.Add("@lname", MySqlDbType.VarChar);
                        cmd.Parameters["@lname"].Value = patient.Lname;

                        cmd.Parameters.Add("@fname", MySqlDbType.VarChar);
                        cmd.Parameters["@fname"].Value = patient.Fname;

                        cmd.Parameters.Add("@addressID", MySqlDbType.Int32);
                        cmd.Parameters["@addressID"].Value = patient.AddressID;
                        using (cmd.ExecuteReader())
                        {
                        }
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
    }
}
