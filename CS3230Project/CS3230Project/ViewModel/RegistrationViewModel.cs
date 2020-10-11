using CS3230Project.DAL;
using CS3230Project.Model;

namespace CS3230Project.ViewModel
{
    public class RegistrationViewModel
    {
        #region Methods

        /// <summary>
        ///      Registers the patient.
        /// </summary>
        /// <param name="ssn">The SSN.</param>
        /// <param name="fname">The fname.</param>
        /// <param name="lname">The lname.</param>
        /// <param name="address">The address.</param>
        public void RegisterPatient(string ssn, string fname, string lname, Address address)
        {
            var addressDal = new AddressDal();
            var patientDal = new PatientDAL();

            var addressId = addressDal.RetrieveAddressId(address);

            var patient = new Patient(ssn, fname, lname, addressId);

            patientDal.InsertPatient(patient);
        }

        /// <summary>
        /// Registers the address.
        /// </summary>
        /// <param name="addr1">The addr1.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="contactNum">The contact number.</param>
        /// <param name="addr2">The addr2.</param>
        /// <returns>an address object with the given fields</returns>
        public Address RegisterAddress(string addr1, string city, string state, int zip, string contactNum,
            string addr2 = null)
        {
            var addressDal = new AddressDal();
            var address = new Address(addr1, city, state, zip, contactNum, addr2);

            try
            {
                addressDal.InsertAddress(address);
            }
            catch
            {
                //preventing existing address from crashing the program
            }

            return address;
        }

        #endregion
    }
}