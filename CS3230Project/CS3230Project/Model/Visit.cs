using System;
using System.Collections.Generic;

namespace CS3230Project.Model
{
    /// <summary>
    ///     Represents a patient visit in result of an appointment
    /// </summary>
    public class Visit
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the systolic number.
        /// </summary>
        /// <value>
        ///     The systolic number.
        /// </value>
        public int SystolicNum { get; set; }

        /// <summary>
        ///     Gets or sets the diastolic number.
        /// </summary>
        /// <value>
        ///     The diastolic number.
        /// </value>
        public int DiastolicNum { get; set; }

        /// <summary>
        ///     Gets or sets the heart rate.
        /// </summary>
        /// <value>
        ///     The heart rate.
        /// </value>
        public int HeartRate { get; set; }

        /// <summary>
        ///     Gets or sets the respiration rate.
        /// </summary>
        /// <value>
        ///     The respiration rate.
        /// </value>
        public int RespirationRate { get; set; }

        /// <summary>
        ///     Gets or sets the body temporary.
        /// </summary>
        /// <value>
        ///     The body temporary.
        /// </value>
        public double BodyTemp { get; set; }

        /// <summary>
        ///     Gets or sets the other.
        /// </summary>
        /// <value>
        ///     The other.
        /// </value>
        public string Other { get; set; }

        /// <summary>
        ///     Gets or sets the nurse identifier.
        /// </summary>
        /// <value>
        ///     The nurse identifier.
        /// </value>
        public string NurseId { get; set; }

        /// <summary>
        ///     Gets or sets the patient identifier.
        /// </summary>
        /// <value>
        ///     The patient identifier.
        /// </value>
        public int PatientId { get; set; }

        /// <summary>
        ///     Gets or sets the appointment date.
        /// </summary>
        /// <value>
        ///     The appointment date.
        /// </value>
        public DateTime AppointmentDate { get; set; }

        /// <summary>
        ///     Gets or sets the diagnosis.
        /// </summary>
        /// <value>
        ///     The diagnosis.
        /// </value>
        public string Diagnosis { get; set; }

        /// <summary>
        /// Gets or sets the test results.
        /// </summary>
        /// <value>
        /// The test results.
        /// </value>
        public IList<TestResult> TestResults { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether there is a final diagnosis.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [final diagnosis]; otherwise, <c>false</c>.
        /// </value>
        public bool FinalDiagnosis { get; set; }

        #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="Visit" /> class.
    /// </summary>
    /// <param name="systolicNum">The systolic number.</param>
    /// <param name="diastolicNum">The diastolic number.</param>
    /// <param name="heartRate">The heart rate.</param>
    /// <param name="respirationRate">The respiration rate.</param>
    /// <param name="bodyTemp">The body temporary.</param>
    /// <param name="other">The other.</param>
    /// <param name="nurseId">The nurse identifier.</param>
    /// <param name="patientId">The patient identifier.</param>
    /// <param name="appointmentDate">The appointment date.</param>
    /// <param name="diagnosis">The diagnosis.</param>
    /// <param name="finalDiagnosis"></param>
    /// <exception cref="ArgumentNullException">
    ///     other
    ///     or
    ///     diagnosis
    /// </exception>
    public Visit(int systolicNum, int diastolicNum, int heartRate, int respirationRate, double bodyTemp,
            string other, string nurseId, int patientId, DateTime appointmentDate, string diagnosis, bool finalDiagnosis)
        {
            this.SystolicNum = systolicNum;
            this.DiastolicNum = diastolicNum;
            this.HeartRate = heartRate;
            this.RespirationRate = respirationRate;
            this.BodyTemp = bodyTemp;
            this.Other = other ?? throw new ArgumentNullException(nameof(other));
            this.NurseId = nurseId;
            this.PatientId = patientId;
            this.AppointmentDate = appointmentDate;
            this.Diagnosis = diagnosis ?? throw new ArgumentNullException(nameof(diagnosis));
            this.TestResults = new List<TestResult>();
            this.FinalDiagnosis = finalDiagnosis;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Visit" /> class.
        /// </summary>
        public Visit()
        {
            this.SystolicNum = 0;
            this.DiastolicNum = 0;
            this.HeartRate = 0;
            this.RespirationRate = 0;
            this.BodyTemp = 0;
            this.Other = string.Empty;
            this.Diagnosis = string.Empty;
            this.FinalDiagnosis = false;
            this.TestResults = new List<TestResult>();
        }


        #endregion
    }
}