using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using CS3230Project.DAL;
using CS3230Project.Model;

namespace CS3230Project.ViewModel
{
    /// <summary>
    ///     Represents the viewmodel for binding the model to the patient lookup view
    /// </summary>
    public class PatientLookupViewModel
    {
        #region Data members

        private readonly PatientDal patientDal;

        #endregion

        #region Constructors

        public PatientLookupViewModel()
        {
            this.patientDal = new PatientDal();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Retrieves the appointments.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="dob">The dob.</param>
        /// <returns></returns>
        public IList<Appointment> RetrieveAppointments(string firstName, string lastName,
            DateTime dob)
        {
            IList<Appointment> appointments = new List<Appointment>();
            var missingName = firstName == null || lastName == null;
            var missingDob = dob == default;

            if (!missingName && !missingDob)
            {
                appointments = this.patientDal.RetrieveAppointments(firstName, lastName, dob);
            }
            else if (missingName && !missingDob)
            {
                appointments = this.patientDal.RetrieveAppointments(dob);
            }
            else if (!missingName)
            {
                appointments = this.patientDal.RetrieveAppointments(firstName, lastName);
            }

            return appointments;
        }

        /// <summary>
        ///     Retrieves the visits.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="dob">The dob.</param>
        /// <returns></returns>
        public IList<Visit> RetrieveVisits(string firstName, string lastName, DateTime dob)
        {
            IList<Visit> visits = new List<Visit>();
            var missingName = firstName == null || lastName == null;
            var missingDob = dob == default;

            if (!missingName && !missingDob)
            {
                visits = this.patientDal.RetrieveVisits(firstName, lastName, dob);
            }
            else if (missingName && !missingDob)
            {
                visits = this.patientDal.RetrieveVisits(dob);
            }
            else if (!missingName)
            {
                visits = this.patientDal.RetrieveVisits(firstName, lastName);
            }

            return visits;
        }

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
            {
                visits = this.patientDal.RetrievePatients(firstName, lastName, dob);
            }
            else if (missingName && !missingDob)
            {
                visits = this.patientDal.RetrievePatients(dob);
            }
            else if (!missingName)
            {
                visits = this.patientDal.RetrievePatients(firstName, lastName);
            }

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
            patientTable.Columns.Add(new DataColumn("Patient ID"));
            patientTable.Columns.Add(new DataColumn("First Name"));
            patientTable.Columns.Add(new DataColumn("Last Name"));
            patientTable.Columns.Add(new DataColumn("SSN"));
            patientTable.Columns.Add(new DataColumn("Address 1"));
            patientTable.Columns.Add(new DataColumn("Address 2"));
            patientTable.Columns.Add(new DataColumn("City"));
            patientTable.Columns.Add(new DataColumn("State"));
            patientTable.Columns.Add(new DataColumn("Zip Code"));
            patientTable.Columns.Add(new DataColumn("Contact #"));
            patientTable.Columns.Add(new DataColumn("Gender"));
            patientTable.Columns.Add(new DataColumn("Date of Birth"));
        }

        private static void addPatientRow(DataRow patientDataRow, Patient patient, Address patientAddress, DataTable patientTable)
        {
            patientDataRow["Patient ID"] = patient.PatientId;
            patientDataRow["First Name"] = patient.Fname;
            patientDataRow["Last Name"] = patient.Lname;
            patientDataRow["SSN"] = patient.Ssn;
            patientDataRow["Address 1"] = patientAddress.Address1;
            patientDataRow["Address 2"] = patientAddress.Address2;
            patientDataRow["City"] = patientAddress.City;
            patientDataRow["State"] = patientAddress.State;
            patientDataRow["Zip Code"] = patientAddress.Zip;
            patientDataRow["Contact #"] = patientAddress.ContactNum;
            patientDataRow["Gender"] = patient.Sex;
            patientDataRow["Date of Birth"] = patient.DateOfBirth;

            patientTable.Rows.Add(patientDataRow);
        }

        #endregion
    }
}