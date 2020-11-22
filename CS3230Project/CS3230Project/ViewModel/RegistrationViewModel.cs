using System;
using CS3230Project.DAL;
using CS3230Project.Model;

namespace CS3230Project.ViewModel
{
    /// <summary>
    ///     creates a new instance of the registration view model class
    /// </summary>
    public class RegistrationViewModel
    {
        #region Methods

        /// <summary>
        ///     Registers the patient.
        /// </summary>
        /// <param name="ssn">The SSN.</param>
        /// <param name="fname">The fname.</param>
        /// <param name="lname">The lname.</param>
        /// <param name="sex">The sex.</param>
        /// <param name="address">The address.</param>
        public bool RegisterPatient(string ssn, string fname, string lname, string sex, Address address, DateTime dob)
        {
            var addressDal = new AddressDal();
            var patientDal = new PatientDal();
            var patientExists = this.CheckForPatient(ssn);

            if (patientExists)
            {
                return false;
            }

            var addressId = addressDal.RetrieveAddressId(address);

            var patient = new Patient(ssn, fname, lname, addressId, sex, dob);

            return patientDal.InsertPatient(patient);
        }

        /// <summary>
        ///     Registers the address.
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

        /// <summary>
        ///     Checks for patient.
        /// </summary>
        /// <param name="patientID">The patient identifier.</param>
        /// <returns>true iff the given patientID exists in the database</returns>
        public bool CheckForPatient(string patientID)
        {
            var patientExists = false;
            var patientDal = new PatientDal();
            try
            {
                patientExists = patientDal.FindPatient(patientID);
            }
            catch
            {
                //preventing non-existent patientID from crashing the program
            }

            return patientExists;
        }

        /// <summary>
        ///     Updates the patient.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="address">The address.</param>
        /// <returns>true if the update was successful and false otherwise.</returns>
        public bool UpdatePatient(Patient patient, Address address)
        {
            bool updateSuccessful;
            var addressDal = new AddressDal();
            var patientDal = new PatientDal();

            var addressUpdateSuccess = addressDal.UpdatePatientAddress(address);
            var patientUpdateSuccess = patientDal.UpdatePatientInfo(patient);

            if (addressUpdateSuccess && patientUpdateSuccess)
            {
                updateSuccessful = true;
            }
            else
            {
                updateSuccessful = false;
            }

            return updateSuccessful;
        }

        /// <summary>
        ///     Deletes the patient.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="address">The address.</param>
        /// <returns>true if the delete was successful and false otherwise</returns>
        public bool DeletePatient(Patient patient, Address address)
        {
            var patientDal = new PatientDal();
            var addressDal = new AddressDal();

            var deleteSuccessful = patientDal.DeletePatientInfo(patient);

            addressDal.DeleteAddressIfNoReferencesLeft(address);

            return deleteSuccessful;
        }

        #endregion
    }
}