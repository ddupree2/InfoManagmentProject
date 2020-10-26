using System.Collections.Generic;
using CS3230Project.DAL;
using CS3230Project.Model;

namespace CS3230Project.ViewModel
{
    /// <summary>
    ///     Represents the viewmodel binding the AppointmentDAL to the appointment form
    /// </summary>
    public class AppointmentViewModel
    {
        #region Methods

        /// <summary>
        ///     Retrieves the doctors.
        /// </summary>
        /// <returns>the list of doctors</returns>
        public IList<Doctor> RetrieveDoctors()
        {
            var doctorDal = new DoctorDAL();
            var employeeDal = new EmployeeDal();

            var employees = employeeDal.RetrieveEmployees();
            var doctors = doctorDal.RetrieveDoctors(employees);

            return doctors;
        }

        /// <summary>
        ///     Registers the appointment.
        /// </summary>
        /// <param name="appointment">The appointment.</param>
        /// <returns>true iff the appointment is successfully registered</returns>
        public bool RegisterAppointment(Appointment appointment)
        {
            var appointmentDal = new AppointmentDal();

            var success = appointmentDal.RegisterAppointment(appointment);

            return success;
        }

        /// <summary>
        ///     Gets the appointments.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <returns> the list of appointments the patient has</returns>
        public IList<Appointment> RetrieveAppointments(Patient patient)
        {
            var appointmentDal = new AppointmentDal();

            var appointments = appointmentDal.RetrieveAppointments(patient);

            return appointments;
        }

        /// <summary>
        ///     Updates the appointment.
        /// </summary>
        /// <param name="appointmentToUpdate">The appointment to update.</param>
        /// <returns>true iff the appointment to update is successfully updated</returns>
        public bool UpdateAppointment(Appointment appointmentToUpdate)
        {
            var appointmentDal = new AppointmentDal();

            var success = appointmentDal.UpdateAppointment(appointmentToUpdate);

            return success;
        }

        #endregion
    }
}