using System;

namespace CS3230Project.Model
{
    /// <summary>
    ///     Represents a test result of a patient
    /// </summary>
    public class TestResult
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the test date.
        /// </summary>
        /// <value>
        ///     The test date.
        /// </value>
        public DateTime TestDate { get; set; }

        /// <summary>
        ///     Gets or sets the results.
        /// </summary>
        /// <value>
        ///     The results.
        /// </value>
        public string Results { get; set; }

        /// <summary>
        ///     Gets or sets the appointment date.
        /// </summary>
        /// <value>
        ///     The appointment date.
        /// </value>
        public DateTime AppointmentDate { get; set; }

        /// <summary>
        ///     Gets or sets the patient identifier.
        /// </summary>
        /// <value>
        ///     The patient identifier.
        /// </value>
        public int PatientId { get; set; }

        /// <summary>
        ///     Gets or sets the test code.
        /// </summary>
        /// <value>
        ///     The test code.
        /// </value>
        public int TestCode { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TestResult" /> class.
        /// </summary>
        /// <param name="testDate">The test date.</param>
        /// <param name="results">The results.</param>
        /// <param name="appointmentDate">The appointment date.</param>
        /// <param name="patientId">The patient identifier.</param>
        /// <param name="testCode">The test code.</param>
        /// <exception cref="ArgumentNullException">results</exception>
        public TestResult(DateTime testDate, string results, DateTime appointmentDate, int patientId, int testCode)
        {
            this.TestDate = testDate;
            this.Results = results ?? throw new ArgumentNullException(nameof(results));
            this.AppointmentDate = appointmentDate;
            this.PatientId = patientId;
            this.TestCode = testCode;
        }

        #endregion
    }
}