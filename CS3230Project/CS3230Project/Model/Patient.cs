using System;

namespace CS3230Project.Model
{
    /// <summary>
    ///     creates a new instance of the patient class
    /// </summary>
    public class Patient
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the patient identifier.
        /// </summary>
        /// <value>
        ///     The patient identifier.
        /// </value>
        public int PatientId { get; set; }

        /// <summary>
        ///     Gets or sets the SSN.
        /// </summary>
        /// <value>
        ///     The SSN.
        /// </value>
        public string Ssn { get; set; }

        /// <summary>
        ///     Gets or sets the fname.
        /// </summary>
        /// <value>
        ///     The fname.
        /// </value>
        public string Fname { get; set; }

        /// <summary>
        ///     Gets or sets the lname.
        /// </summary>
        /// <value>
        ///     The lname.
        /// </value>
        public string Lname { get; set; }

        /// <summary>
        ///     Gets or sets the address identifier.
        /// </summary>
        /// <value>
        ///     The address identifier.
        /// </value>
        public int AddressId { get; set; }

        /// <summary>
        ///     Gets or sets the sex.
        /// </summary>
        /// <value>
        ///     The sex.
        /// </value>
        public string Sex { get; set; }

        /// <summary>
        ///     Gets or sets the date of birth.
        /// </summary>
        /// <value>
        ///     The date of birth.
        /// </value>
        public DateTime DateOfBirth { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Patient" /> class.
        /// </summary>
        /// <param name="ssn">The SSN.</param>
        /// <param name="fname">The fname.</param>
        /// <param name="lname">The lname.</param>
        /// <param name="addressId">The address identifier.</param>
        /// <param name="sex">The sex.</param>
        /// <param name="dob">The dob.</param>
        public Patient(string ssn, string fname, string lname, int addressId, string sex, DateTime dob)
        {
            this.Ssn = ssn;
            this.Fname = fname;
            this.Lname = lname;
            this.AddressId = addressId;
            this.Sex = sex;
            this.DateOfBirth = dob;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Patient" /> class.
        /// </summary>
        public Patient()
        {
        }

        #endregion
    }
}