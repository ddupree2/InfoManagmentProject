using System;

namespace CS3230Project.Model
{
    public class Patient
    {
        #region Data members

        public int PatientId;
        
        public string Ssn;

        public string Fname;

        public string Lname;

        public int AddressId;

        public string Sex;

        public DateTime DateOfBirth;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Patient" /> class.
        /// </summary>
        /// <param name="ssn">The SSN.</param>
        /// <param name="fname">The fname.</param>
        /// <param name="lname">The lname.</param>
        /// <param name="addressID">The address identifier.</param>
        /// <param name="sex">The sex.</param>
        /// <param name="dob">The dob.</param>
        public Patient(string ssn, string fname, string lname, int addressID, string sex, DateTime dob)
        {
            this.Ssn = ssn;
            this.Fname = fname;
            this.Lname = lname;
            this.AddressId = addressID;
            this.Sex = sex;
            this.DateOfBirth = dob;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Patient"/> class.
        /// </summary>
        public Patient()
        {
        }


        #endregion
    }
}