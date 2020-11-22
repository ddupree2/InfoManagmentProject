using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using CS3230Project.DAL;
using CS3230Project.ViewModel;
using MySql.Data.MySqlClient;

namespace CS3230Project.View
{
    /// <summary>
    ///     Visual representation of an admin query form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class AdminQueryForm : Form
    {
        #region Data members

        private readonly AdminQueryViewModel adminQueryViewModel;
        private bool viewVisits;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdminQueryForm" /> class.
        /// </summary>
        public AdminQueryForm()
        {
            this.InitializeComponent();
            this.adminQueryViewModel = new AdminQueryViewModel();
        }

        #endregion

        #region Methods

        private void queryButton_Click(object sender, EventArgs e)
        {
            var query = this.queryTextBox.Text;
            try
            {
                var results = this.adminQueryViewModel.RetrieveQueryResults(query);
                this.resultsGridView.DataSource = results;
                this.resultsGridView.AutoResizeColumns();
                this.viewVisits = false;
            }
            catch (MySqlException mex)
            {
                showErrorMessage(mex.Message);
                Debug.WriteLine(mex.StackTrace);
            }
            catch (InvalidOperationException ex)
            {
                showErrorMessage(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private void visitsButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable results;
                if (this.timeRangeCheckBox.Checked)
                {
                    results = this.adminQueryViewModel.RetrieveVisitsBetween(DateTime.MinValue, DateTime.MaxValue);
                }
                else
                {
                    var startDate = this.beforeDatePicker.Value;
                    var endDate = this.afterDateTimePicker.Value;
                    results = this.adminQueryViewModel.RetrieveVisitsBetween(startDate, endDate);
                }

                this.viewVisits = results.Rows.Count > 0;
                this.resultsGridView.DataSource = results;
                this.resultsGridView.AutoResizeColumns();
            }
            catch (MySqlException mex)
            {
                showErrorMessage(mex.Message);
                Debug.WriteLine(mex.StackTrace);
                this.viewVisits = false;
            }
            catch (InvalidOperationException ex)
            {
                showErrorMessage(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                this.viewVisits = false;
            }
        }

        private static void showErrorMessage(string errorMessage)
        {
            const string noResultsTitle = "Query Error";
            var noResultsMessage = "Error: " + errorMessage;
            const MessageBoxIcon messageType = MessageBoxIcon.Error;
            MessageBox.Show(noResultsMessage, noResultsTitle, MessageBoxButtons.OK, messageType);
        }

        #endregion

        private void resultsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var visitIndex = e.RowIndex;
            if (visitIndex > 0 && this.viewVisits)
            {
                var selectedRow = this.resultsGridView.Rows[visitIndex];
                var selectedDate = DateTime.Parse(selectedRow.Cells[0].Value.ToString());
                var selectedPatientId = int.Parse(selectedRow.Cells[1].Value.ToString());
                var visitTests = VisitsDal.retrieveTestResults(selectedPatientId, selectedDate);

                foreach (var test in visitTests)
                {
                    test.PatientId = selectedPatientId;
                }

                this.testResultsGridView.DataSource = visitTests;
                this.testResultsGridView.AutoResizeColumns();
            }
        }
    }
}