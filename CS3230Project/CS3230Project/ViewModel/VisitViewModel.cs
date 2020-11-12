using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CS3230Project.DAL;
using CS3230Project.Model;

namespace CS3230Project.ViewModel
{
    /// <summary>
    ///     Represents the binding between visit related logic and the view for visits
    /// </summary>
    public class VisitViewModel
    {

        #region Data members

        private const string TestDate = "Test Date";
        private const string Results = "Results";
        private const string AppointmentDate = "Appointment Date";
        private const string PatientId = "Patient ID";
        private const string TestCode = "Test Code";
        private const string TestName = "Test Name";

        private readonly VisitsDal visistDal;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the nurses.
        /// </summary>
        /// <value>
        ///     The nurses.
        /// </value>
        public IList<Nurse> Nurses { get; set; }

        /// <summary>
        ///     Gets or sets the appointments dates.
        /// </summary>
        /// <value>
        ///     The appointments dates.
        /// </value>
        public IList<DateTime> AppointmentsDates { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="VisitViewModel"/> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public VisitViewModel(Patient patient)
        {
            this.Nurses = retrieveNurses();
            this.AppointmentsDates = retrieveAppointmentDates(patient);
            this.visistDal = new VisitsDal();
        }

        #endregion

        #region Methods

        private static IList<Nurse> retrieveNurses()
        {
            var nurseDal = new NurseDal();
            var nurses = nurseDal.RetrieveNurses();
            return nurses;
        }

        /// <summary>
        ///     Retrieves the nurse.
        /// </summary>
        /// <param name="nurseId">The nurse identifier.</param>
        /// <returns></returns>
        public Nurse RetrieveNurse(string nurseId)
        {
            return this.Nurses.FirstOrDefault(nurse => nurse.NurseId.Equals(nurseId));
        }

        /// <summary>
        ///     Retrieves the test results.
        /// </summary>
        /// <returns> data-table containing the test results</returns>
        public DataTable RetrieveTestResults(Visit visit)
        {
            var testResultsTable = new DataTable();
            addColumns(testResultsTable);

            var testResults = visit.TestResults;
            foreach (var testResult in testResults) addRowData(testResultsTable, testResult);

            return testResultsTable;
        }

        private static void addColumns(DataTable testResults)
        {
            var testDateColumn = new DataColumn(TestDate);
            var testResultsColumn = new DataColumn(Results);
            var appointmentDateColumn = new DataColumn(AppointmentDate);
            var patientIdColumn = new DataColumn(PatientId);
            var testCodeColumn = new DataColumn(TestCode);
            var testNameColumn = new DataColumn(TestName);

            testResults.Columns.Add(testDateColumn);
            testResults.Columns.Add(testResultsColumn);
            testResults.Columns.Add(appointmentDateColumn);
            testResults.Columns.Add(patientIdColumn);
            testResults.Columns.Add(testCodeColumn);
            testResults.Columns.Add(testNameColumn);
        }

        private static void addRowData(DataTable testResultsTable, TestResult testResult)
        {
            var dataRow = testResultsTable.NewRow();
            dataRow[TestDate] = testResult.TestDate;
            dataRow[Results] = testResult.Results;
            dataRow[AppointmentDate] = testResult.AppointmentDate;
            dataRow[PatientId] = testResult.PatientId;
            dataRow[TestCode] = testResult.TestCode;
            dataRow[TestName] = testResult.TestName;
            testResultsTable.Rows.Add(dataRow);
        }

        /// <summary>
        ///     Retrieves the appointment dates.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <returns>the IList of appointment dates</returns>
        private static IList<DateTime> retrieveAppointmentDates(Patient patient)
        {
            var allAppointments = new AppointmentViewModel().RetrieveAppointments(patient);

            var appointmentDates = (from appointment in allAppointments
                where appointment.AppointmentDate.Date <= DateTime.Now
                select appointment.AppointmentDate).ToList();

            return appointmentDates;
        }

        /// <summary>
        ///     Retrieves the visits.
        /// </summary>
        /// <param name="patientID">The patient identifier.</param>
        /// <param name="appointmentDate">The appointment date.</param>
        /// <returns>the IList of visits</returns>
        public IList<Visit> RetrieveVisits(int patientID, DateTime appointmentDate)
        {
            var visitsDal = new VisitsDal();
            var visits = visitsDal.RetrieveVisits(patientID, appointmentDate);
            return visits;
        }

        /// <summary>
        ///     Checks if visits exist for the datetime and PatientId.
        /// </summary>
        /// <param name="patientId">The patient identifier.</param>
        /// <param name="appointmentDate">The appointment date.</param>
        /// <returns>true iff a visit exists for the given patient id and appointment date</returns>
        public bool VisitsExist(int patientId, DateTime appointmentDate)
        {
            return this.visistDal.VisitExists(patientId, appointmentDate);
        }

        /// <summary>
        ///     Inserts the visit.
        /// </summary>
        /// <param name="visit">The visit.</param>
        public void InsertVisit(Visit visit)
        {
            this.visistDal.InsertVisit(visit);
        }

        /// <summary>
        ///     Updates the visit.
        /// </summary>
        /// <param name="visit">The visit.</param>
        public void UpdateVisit(Visit visit)
        {
            this.visistDal.UpdateVist(visit);
        }

        #endregion
    }
}