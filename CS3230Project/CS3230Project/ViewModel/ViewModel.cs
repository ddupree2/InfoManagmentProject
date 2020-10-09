using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3230Project.DAL;
using CS3230Project.Model;

namespace CS3230Project.ViewModel
{
    class ViewModel
    {
        public void RegisterPatient(string ssn, string fname, string lname, Address address)
        {
            var addressDal = new AddressDAL();
            var patientDal = new PatientDAL();
            
            var addressId = addressDal.RetrieveAddressId(address);
            
            var patient = new Patient(ssn, fname, lname, addressId);

            patientDal.InsertPatient(patient);

        }

        public Address RegisterAddress(string addr1, string city, string state, int zip, string contactNum,string addr2 = null)
        {
            var addressDal = new AddressDAL();
            Address address = new Address(addr1, city, state, zip, contactNum, addr2);

            addressDal.InsertAddress(address);

            return address;
        }

    }
}
