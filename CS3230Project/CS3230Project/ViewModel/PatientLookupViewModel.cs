using System;
using System.Collections.Generic;
using CS3230Project.DAL;
using CS3230Project.Model;

namespace CS3230Project.ViewModel
{
    /// <summary>
    ///     Represents the viewmodel for binding the model to the patient lookup view
    /// </summary>
    public class PatientLookupViewModel
    {
        #region Data members

        private readonly PatientDal patientDal;

        #endregion

        #region Constructors

        public PatientLookupViewModel()
        {
            this.patientDal = new PatientDal();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Retrieves the appointments.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="dob">The dob.</param>
        /// <returns></returns>
        public IList<Appointment> RetrieveAppointments(string firstName, string lastName,
            DateTime dob)
        {
            IList<Appointment> appointments = new List<Appointment>();
            var missingName = firstName == null || lastName == null;
            var missingDob = dob == default;

            if (!missingName && !missingDob)
            {
                appointments = this.patientDal.RetrieveAppointments(firstName, lastName, dob);
            }
            else if (missingName && !missingDob)
            {
                appointments = this.patientDal.RetrieveAppointments(dob);
            }
            else if (!missingName)
            {
                appointments = this.patientDal.RetrieveAppointments(firstName, lastName);
            }

            return appointments;
        }

        /// <summary>
        ///     Retrieves the visits.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="dob">The dob.</param>
        /// <returns></returns>
        public IList<Visit> RetrieveVisits(string firstName, string lastName, DateTime dob)
        {
            IList<Visit> visits = new List<Visit>();
            var missingName = firstName == null || lastName == null;
            var missingDob = dob == default;

            if (!missingName && !missingDob)
            {
                visits = this.patientDal.RetrieveVisits(firstName, lastName, dob);
            }
            else if (missingName && !missingDob)
            {
                visits = this.patientDal.RetrieveVisits(dob);
            }
            else if (!missingName)
            {
                visits = this.patientDal.RetrieveVisits(firstName, lastName);
            }

            return visits;
        }

        #endregion
    }
}