namespace CS3230Project.Model
{
    /// <summary>
    /// </summary>
    public class Address
    {
        #region Data members

        /// <summary>
        ///     The address identifier
        /// </summary>
        public int addressId;

        /// <summary>
        ///     The address1
        /// </summary>
        public string Address1;

        /// <summary>
        ///     The address2
        /// </summary>
        public string Address2;

        /// <summary>
        ///     The city
        /// </summary>
        public string City;

        /// <summary>
        ///     The state
        /// </summary>
        public string State;

        /// <summary>
        ///     The zip
        /// </summary>
        public int Zip;

        /// <summary>
        ///     The contact number
        /// </summary>
        public string ContactNum;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Address" /> class.
        /// </summary>
        /// <param name="address1">The address1.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="contactnum">The contactnum.</param>
        /// <param name="address2">The address2.</param>
        public Address(string address1, string city, string state, int zip, string contactnum, string address2 = null)
        {
            this.Address1 = address1;
            this.Address2 = address2;
            this.City = city;
            this.ContactNum = contactnum;
            this.Zip = zip;
            this.State = state;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Address" /> class.
        /// </summary>
        public Address()
        {
        }

        #endregion
    }
}