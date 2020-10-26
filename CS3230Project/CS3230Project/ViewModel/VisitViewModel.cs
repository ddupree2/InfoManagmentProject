using System.Data;
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

        private readonly Visit visit;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="VisitViewModel" /> class.
        /// </summary>
        /// <param name="visit">The visit.</param>
        public VisitViewModel(Visit visit)
        {
            this.visit = visit;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Retrieves the test results.
        /// </summary>
        /// <returns> data-table containing the test results</returns>
        public DataTable RetrieveTestResults()
        {
            var testResultsTable = new DataTable();
            addColumns(testResultsTable);

            var testResults = this.visit.TestResults;
            foreach (var testResult in testResults)
            {
                addRowData(testResultsTable, testResult);
            }

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

        #endregion
    }
}