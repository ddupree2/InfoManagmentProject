using CS3230Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3230Project.DAL;

namespace CS3230Project.ViewModel
{
    /// <summary>
    ///     Represents the viewmodel binding the AppointmentDAL to the appointment form
    /// </summary>
    public class AppointmentViewModel
    {
        public IList<Doctor> getDoctors()
        {
            var doctorDal = new DoctorDAL();
            var employeeDal = new EmployeeDal();
            
            var employees = employeeDal.RetrieveEmployees();
            var doctors = doctorDal.RetrieveDoctors(employees);

            return doctors;
        }

        public bool registerAppointment(Appointment appointment)
        {
            var appointmentDal = new AppointmentDal();

            var success = appointmentDal.registerAppointment(appointment);

            return success;
        }
    }
}
