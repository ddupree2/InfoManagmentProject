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
        public bool RegisterAppointment(Appointment appointment)
        {
            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    const string insertQuery = "INSERT INTO `appointment` (`appointmentdate`, `reason`, `doctorID`, `patientID`) VALUES (@appointmentdate, @reason, @doctorID, @patientID);";
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

        public bool DeleteAppointment(Appointment appointmentToUpdate)
        {
            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    var deleteQuery =
                        "DELETE FROM `appointment` WHERE patientID = @patientID and appointmentdate = @appointmentdate;" ;
                    using (var cmd = new MySqlCommand(deleteQuery, conn))
                    {

                        cmd.Parameters.Add("@patientID", MySqlDbType.VarChar);
                        cmd.Parameters["@patientID"].Value = appointmentToUpdate.PatientId;

                        cmd.Parameters.Add("@appointmentdate", MySqlDbType.DateTime);
                        cmd.Parameters["@appointmentdate"].Value = appointmentToUpdate.AppointmentDate;

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
        /// Determines whether the specified patient has appointment.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <returns>
        ///   <c>true</c> if the specified patient has appointment; otherwise, <c>false</c>.
        /// </returns>
        public bool HasAppointment(Patient patient)
        { 
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();

                const string visitExistsQuery =
                    "SELECT patientID FROM appointment WHERE patientID = @patientID;";
                using (var cmd = new MySqlCommand(visitExistsQuery, conn))
                {
                    cmd.Parameters.Add("@patientID", MySqlDbType.VarChar);
                    cmd.Parameters["@patientID"].Value = patient.PatientId.ToString();

                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.Read();
                    }
                }
            }
        }

        public IList<Appointment> RetrieveAppointments(Patient patient)
        {
            var appointments = new List<Appointment>();
            
            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    const string selectQuery = "SELECT appointmentdate, reason, doctorID FROM appointment WHERE patientID = @patientID";
                    using (var cmd = new MySqlCommand(selectQuery, conn))
                    {

                        cmd.Parameters.Add("@patientID", MySqlDbType.VarChar);
                        cmd.Parameters["@patientID"].Value = patient.PatientId;

                        using (var reader = cmd.ExecuteReader())
                        {
                            var reasonOrdinal = reader.GetOrdinal("reason");
                            var appointmentDateOrdinal = reader.GetOrdinal("appointmentdate");
                            var doctorIdOrdinal = reader.GetOrdinal("doctorID");


                            while (reader.Read())
                            {
                                var appointment = new Appointment()
                                {
                                    Reason = reader[reasonOrdinal] == DBNull.Value ? "null" : reader.GetString(reasonOrdinal),
                                    AppointmentDate = reader[appointmentDateOrdinal] == DBNull.Value ? DateTime.Now : reader.GetDateTime(appointmentDateOrdinal),
                                    DoctorId  = reader[doctorIdOrdinal] == DBNull.Value ? "null" : reader.GetString(doctorIdOrdinal),
                                    PatientId = patient.PatientId.ToString()
                                };

                                appointments.Add(appointment);
                            }
                        }

                        return appointments;
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

        public void RetrieveDoctorAppointments(IList<Doctor> doctors)
        {
            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();

                    foreach (var doctor in doctors)
                    {


                        const string selectQuery = "SELECT appointmentdate FROM appointment WHERE doctorID = @doctorID";
                        
                        using (var cmd = new MySqlCommand(selectQuery, conn))
                        {

                            cmd.Parameters.Add("@doctorID", MySqlDbType.VarChar);
                            cmd.Parameters["@doctorID"].Value = doctor.DoctorId;

                            using (var reader = cmd.ExecuteReader())
                            {
                                var appointmentDateOrdinal = reader.GetOrdinal("appointmentdate");

                                while (reader.Read())
                                {

                                    var dateTime = reader[appointmentDateOrdinal] == DBNull.Value ? DateTime.Now : reader.GetDateTime(appointmentDateOrdinal);
                                    
                                    doctor.Appointments.Add(dateTime);
                                }
                            }
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
