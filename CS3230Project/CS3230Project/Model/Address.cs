namespace CS3230Project.Model
{
    public class Address
    {
        #region Data members

        public string Address1;

        public string Address2;

        public string City;

        public string State;

        public int Zip;

        public string ContactNum;

        #endregion

        #region Constructors

        public Address(string address1, string city, string state, int zip, string contactnum, string address2 = null)
        {
            this.Address1 = address1;
            this.Address2 = address2;
            this.City = city;
            this.ContactNum = contactnum;
            this.Zip = zip;
            this.State = state;
        }

        #endregion
    }
}