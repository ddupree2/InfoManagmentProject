﻿using System;
using System.Collections.Generic;
using System.Linq;
using CS3230Project.DAL;
using CS3230Project.Model;

namespace CS3230Project.ViewModel
{
    /// <summary>
    ///     the dashboard view model
    /// </summary>
    public class DashboardViewModel
    {
        #region Methods

        /// <summary>
        ///     Retrieves the name and title.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns>the title and name of the given employeeId</returns>
        public string RetrieveTitle(string employeeId)
        {
            var employeeDal = new EmployeeDal();
            return employeeDal.RetrieveTitle(employeeId);
        }

        /// <summary>
        ///     Retrieves the name.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public string RetrieveFirstName(string employeeId)
        {
            var employeeDal = new EmployeeDal();
            return employeeDal.RetrieveFirstName(employeeId);
        }

        /// <summary>
        ///     Retrieves the patients.
        /// </summary>
        /// <returns></returns>
        public IList<Patient> RetrievePatients()
        {
            var patientDAL = new PatientDal();
            var patients = patientDAL.RetrieveAllPatients();

            return patients;
        }

        /// <summary>
        ///     Gets the address.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <returns></returns>
        public Address RetrieveAddress(Patient patient)
        {
            var addressDal = new AddressDal();
            var address = addressDal.RetrieveAddress(patient);

            return address;
        }

        /// <summary>
        ///     Determines whether the specified patient has appointments.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <returns>
        ///     <c>true</c> if the specified patient has appointments; otherwise, <c>false</c>.
        /// </returns>
        public bool HasAppointments(Patient patient)
        {
            var appointmentDal = new AppointmentDal();
            var appointments = appointmentDal.RetrieveAppointments(patient);

            return appointments.Any(appointment => appointment.AppointmentDate <= DateTime.Now);
        }

        #endregion
    }
}