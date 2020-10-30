using System;
using System.Collections.Generic;
using System.Data;
using CS3230Project.DAL;
using CS3230Project.Model;

namespace CS3230Project.ViewModel
{
    /// <summary>
    ///     Represents the viewmodel for binding the model to the patient lookup view
    /// </summary>
    public class PatientLookupViewModel
    {
        private const string PatientId = "Patient ID";
        private const string FirstName = "First Name";
        private const string LastName = "Last Name";
        private const string Ssn = "SSN";
        private const string Address1 = "Address 1";
        private const string Address2 = "Address 2";
        private const string City = "City";
        private const string State = "State";
        private const string ZipCode = "Zip Code";
        private const string ContactNumber = "Contact #";
        private const string Gender = "Gender";
        private const string DateOfBirth = "Date of Birth";

        #region Data members

        private readonly PatientDal patientDal;

        #endregion

        #region Constructors

        public PatientLookupViewModel()
        {
            patientDal = new PatientDal();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Retrieves the patients.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="dob">The dob.</param>
        /// <returns></returns>
        public IList<Patient> RetrievePatients(string firstName, string lastName, DateTime dob)
        {
            IList<Patient> visits = new List<Patient>();
            var missingName = firstName == null || lastName == null;
            var missingDob = dob == default;

            if (!missingName && !missingDob)
                visits = patientDal.RetrievePatients(firstName, lastName, dob);
            else if (missingName && !missingDob)
                visits = patientDal.RetrievePatients(dob);
            else if (!missingName) visits = patientDal.RetrievePatients(firstName, lastName);

            return visits;
        }

        public DataTable RetrievePatientsTable(IList<Patient> patients)
        {
            var patientTable = new DataTable();
            var addressDal = new AddressDal();

            addPatientColumns(patientTable);
            foreach (var patient in patients)
            {
                var patientAddress = addressDal.RetrieveAddress(patient);
                var patientDataRow = patientTable.NewRow();
                addPatientRow(patientDataRow, patient, patientAddress, patientTable);
            }

            return patientTable;
        }

        private static void addPatientColumns(DataTable patientTable)
        {
            patientTable.Columns.Add(new DataColumn(PatientId));
            patientTable.Columns.Add(new DataColumn(FirstName));
            patientTable.Columns.Add(new DataColumn(LastName));
            patientTable.Columns.Add(new DataColumn(Ssn));
            patientTable.Columns.Add(new DataColumn(Address1));
            patientTable.Columns.Add(new DataColumn(Address2));
            patientTable.Columns.Add(new DataColumn(City));
            patientTable.Columns.Add(new DataColumn(State));
            patientTable.Columns.Add(new DataColumn(ZipCode));
            patientTable.Columns.Add(new DataColumn(ContactNumber));
            patientTable.Columns.Add(new DataColumn(Gender));
            patientTable.Columns.Add(new DataColumn(DateOfBirth));
        }

        private static void addPatientRow(DataRow patientDataRow, Patient patient, Address patientAddress,
            DataTable patientTable)
        {
            patientDataRow[PatientId] = patient.PatientId;
            patientDataRow[FirstName] = patient.Fname;
            patientDataRow[LastName] = patient.Lname;
            patientDataRow[Ssn] = patient.Ssn;
            patientDataRow[Address1] = patientAddress.Address1;
            patientDataRow[Address2] = patientAddress.Address2;
            patientDataRow[City] = patientAddress.City;
            patientDataRow[State] = patientAddress.State;
            patientDataRow[ZipCode] = patientAddress.Zip;
            patientDataRow[ContactNumber] = patientAddress.ContactNum;
            patientDataRow[Gender] = patient.Sex;
            patientDataRow[DateOfBirth] = patient.DateOfBirth;

            patientTable.Rows.Add(patientDataRow);
        }

        #endregion
    }
}