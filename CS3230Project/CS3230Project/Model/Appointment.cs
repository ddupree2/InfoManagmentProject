﻿using System;

namespace CS3230Project.Model
{
    /// <summary>
    ///     Represents an appointment of a patient
    /// </summary>
    public class Appointment
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the reason for the appointment.
        /// </summary>
        /// <value>
        ///     The reason.
        /// </value>
        public string Reason { get; set; }

        /// <summary>
        ///     Gets or sets the patient identifier.
        /// </summary>
        /// <value>
        ///     The patient identifier.
        /// </value>
        public string PatientId { get; set; }

        /// <summary>
        ///     Gets or sets the doctor identifier.
        /// </summary>
        /// <value>
        ///     The doctor identifier.
        /// </value>
        public string DoctorId { get; set; }

        /// <summary>
        ///     Gets or sets the appointment date.
        /// </summary>
        /// <value>
        ///     The appointment date.
        /// </value>
        public DateTime AppointmentDate { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Appointment" /> class.
        /// </summary>
        /// <param name="reason">The reason.</param>
        /// <param name="patientId">The patient identifier.</param>
        /// <param name="doctorId">The doctor identifier.</param>
        /// <param name="appointmentDate">The appointment date.</param>
        /// <exception cref="ArgumentNullException">reason</exception>
        public Appointment(string reason, string patientId, string doctorId, DateTime appointmentDate)
        {
            this.Reason = reason ?? throw new ArgumentNullException(nameof(reason));
            this.PatientId = patientId;
            this.DoctorId = doctorId;
            this.AppointmentDate = appointmentDate;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Appointment" /> class.
        /// </summary>
        public Appointment()
        {
        }

        #endregion
    }
}