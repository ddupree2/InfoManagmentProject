using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3230Project.Model;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    /// <summary>
    ///     Represents the Data Access Layer for the appointment table in the database
    /// </summary>
    public class AppointmentDal
    {
        public bool registerAppointment(Appointment appointment)
        {
            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    var insertQuery =
                        "INSERT INTO `appointment` (`appointmentdate`, `reason`, `doctorID`, `patientID`) VALUES (@appointmentdate, @reason, @doctorID, @patientID);";
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {

                        cmd.Parameters.Add("@appointmentdate", MySqlDbType.DateTime);
                        cmd.Parameters["@appointmentdate"].Value = appointment.AppointmentDate;

                        cmd.Parameters.Add("@reason", MySqlDbType.VarChar);
                        cmd.Parameters["@reason"].Value = appointment.Reason;

                        cmd.Parameters.Add("@doctorID", MySqlDbType.VarChar);
                        cmd.Parameters["@doctorID"].Value = appointment.DoctorId;

                        cmd.Parameters.Add("@patientID", MySqlDbType.VarChar);
                        cmd.Parameters["@patientID"].Value = appointment.PatientId;

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
    }
}
