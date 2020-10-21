using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3230Project.Model
{
    /// <summary>
    ///     Represents an appointment of a patient
    /// </summary>
    public class Appointment
    {
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
        public int PatientId { get; set; }

        /// <summary>
        ///     Gets or sets the doctor identifier.
        /// </summary>
        /// <value>
        ///     The doctor identifier.
        /// </value>
        public int DoctorId { get; set; }

        /// <summary>
        ///     Gets or sets the appointment date.
        /// </summary>
        /// <value>
        ///     The appointment date.
        /// </value>
        public DateTime AppointmentDate { get; set; }

        public Appointment(string reason, int patientId, int doctorId, DateTime appointmentDate)
        {
            this.Reason = reason ?? throw new ArgumentNullException(nameof(reason));
            this.PatientId = patientId;
            this.DoctorId = doctorId;
            this.AppointmentDate = appointmentDate;
        }
    }
}
