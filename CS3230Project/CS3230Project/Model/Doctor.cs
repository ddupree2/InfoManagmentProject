using System;
using System.Collections.Generic;

namespace CS3230Project.Model
{
    /// <summary>
    ///     creates a new instance of the doctor class
    /// </summary>
    public class Doctor
    {
        #region Data members

        /// <summary>
        ///     The doctor identifier
        /// </summary>
        public string DoctorId;

        /// <summary>
        ///     The employee
        /// </summary>
        public Employee Employee;

        /// <summary>
        ///     The appointments
        /// </summary>
        public IList<DateTime> Appointments = new List<DateTime>();

        #endregion

        #region Constructors

        #endregion

        #region Methods

        /// <summary>
        ///     Determines whether the specified doctor identifier is doctor.
        /// </summary>
        /// <param name="doctorID">The doctor identifier.</param>
        /// <returns>
        ///     <c>true</c> if the specified doctor identifier is doctor; otherwise, <c>false</c>.
        /// </returns>
        public bool IsDoctor(string doctorID)
        {
            var checker = false || this.DoctorId.Equals(doctorID);

            return checker;
        }

        #endregion
    }
}