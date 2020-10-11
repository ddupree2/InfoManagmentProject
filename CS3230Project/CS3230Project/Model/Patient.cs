namespace CS3230Project.Model
{
    public class Patient
    {
        #region Data members

        public string Ssn;

        public string Fname;

        public string Lname;

        public int AddressID;

        public string Sex;

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
        public Patient(string ssn, string fname, string lname, int addressID, string sex)
        {
            this.Ssn = ssn;
            this.Fname = fname;
            this.Lname = lname;
            this.AddressID = addressID;
            this.Sex = sex;
        }

        #endregion
    }
}