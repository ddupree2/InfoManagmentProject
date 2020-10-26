using System.Globalization;
using System.Windows.Forms;
using CS3230Project.Model;
using CS3230Project.ViewModel;

namespace CS3230Project.View
{
    /// <summary>
    ///     Represents a patient visitViewModel in the view
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class VisitForm : Form
    {
        #region Data members

        private readonly VisitViewModel visitViewModel;
        private readonly Visit visit;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="VisitForm" /> class.
        /// </summary>
        /// <param name="visit">The visit.</param>
        public VisitForm(Visit visit)
        {
            this.InitializeComponent();
            this.visit = visit;
            this.visitViewModel = new VisitViewModel(visit);
            this.setupVistForm();
        }

        #endregion

        #region Methods

        private void setupVistForm()
        {
            this.AppointmentDateTimePicker.Value = this.visit.AppointmentDate;
            this.patientIDTextBox.Text = this.visit.PatientId.ToString();
            this.nurseIDTextBox.Text = this.visit.NurseId;
            this.diagnosisTextBox.Text = this.visit.Diagnosis;
            this.diastolicTextBox.Text = this.visit.DiastolicNum.ToString();
            this.systolicTextBox.Text = this.visit.SystolicNum.ToString();
            this.bodyTempTextBox.Text = this.visit.BodyTemp.ToString(CultureInfo.InvariantCulture);
            this.heartRateTextBox.Text = this.visit.HeartRate.ToString();
            this.respirationRateTextBox.Text = this.visit.RespirationRate.ToString();
            this.finalDiagnosisCheckBox.Checked = this.isFinalDiagnosis();
            this.otherTextBox.Text = this.visit.Other;

            this.populateTestResultsListView();
        }

        private void populateTestResultsListView()
        {
            var testResults = this.visitViewModel.RetrieveTestResults();
            this.testResultsGridView.DataSource = testResults;
            this.testResultsGridView.AutoResizeColumns();
        }

        private bool isFinalDiagnosis()
        {
            var finalDiagnosis = this.diagnosisTextBox.Text.ToLower();

            if (!finalDiagnosis.EndsWith("final"))
            {
                return false;
            }

            this.diagnosisTextBox.Enabled = false;
            return true;
        }

        #endregion
    }
}