using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3230Project.DAL;
using CS3230Project.Model;

namespace CS3230Project.ViewModel
{
    /// <summary>
    ///     the dashboard view model
    /// </summary>
    public class DashboardViewModel
    {

        /// <summary>
        /// Retrieves the name and title.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns>the title and name of the given employeeId</returns>
        public string RetrieveTitleAndName(string employeeId)
        {
            var employeeDal = new EmployeeDal();

            return employeeDal.RetrieveTitleAndName(employeeId);
        }

        /// <summary>
        /// Retrieves the patients.
        /// </summary>
        /// <returns></returns>
        public IList<Patient> RetrievePatients()
        {
            var patientDAL = new PatientDal();
            var patients = patientDAL.RetrievePatients();

            return patients;
        }

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <returns></returns>
        public Address getAddress(Patient patient)
        {
            var addressDAL = new AddressDal();
            var address = addressDAL.RetrieveAddress(patient);

            return address;
        }
    }
}
