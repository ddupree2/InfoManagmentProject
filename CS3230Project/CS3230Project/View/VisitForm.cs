using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        private readonly Patient patient;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="VisitForm" /> class.
        /// </summary>
        /// <param name="visit">The visit.</param>
        public VisitForm(Patient patient)
        {
            this.InitializeComponent();
            this.visitViewModel = new VisitViewModel();
            this.patient = patient;
            this.setupVistForm();
        }

        #endregion

        #region Methods

        private void setupVistForm()
        {
            this.apppointmentComboBox.DataSource = this.visitViewModel.RetrieveAppointmentDates(this.patient);
            this.apppointmentComboBox.SelectedIndex = 0;

            var nurses = this.visitViewModel.RetrieveNurses();
            this.nurseComboBox.DataSource = this.getNurseNames(nurses);
            this.nurseComboBox.SelectedIndex = 0;

            var existingVisit = this.visitViewModel.RetrieveVisits(this.patient.PatientId, (DateTime) this.apppointmentComboBox.SelectedItem).FirstOrDefault();
            if (existingVisit != null)
            {
                fillVisitForm(existingVisit);
                this.populateTestResultsListView(existingVisit);

            }
            else
            {
                this.patientIDTextBox.Text = this.patient.PatientId.ToString();
            }

            this.nameTextBox.Text = $@"{this.patient.Fname} {this.patient.Lname}";
        }

        private void fillVisitForm(Visit existingVisit)
        {
            this.patientIDTextBox.Text = existingVisit.PatientId.ToString();
            this.diagnosisTextBox.Text = existingVisit.Diagnosis;
            this.diastolicTextBox.Text = existingVisit.DiastolicNum.ToString();
            this.systolicTextBox.Text = existingVisit.SystolicNum.ToString();
            this.bodyTempTextBox.Text = existingVisit.BodyTemp.ToString(CultureInfo.InvariantCulture);
            this.heartRateTextBox.Text = existingVisit.HeartRate.ToString();
            this.respirationRateTextBox.Text = existingVisit.RespirationRate.ToString();
            this.finalDiagnosisCheckBox.Checked = this.isFinalDiagnosis();
            this.otherTextBox.Text = existingVisit.Other;
        }

        private IList<string> getNurseNames(IList<Nurse> nurses)
        {
            var nurseNames = nurses.Select(nurse => $"{nurse.Fname} {nurse.Lname}").ToList();
            return nurseNames;
        }

        private void populateTestResultsListView(Visit existingVisit)
        {
            var testResults = this.visitViewModel.RetrieveTestResults(existingVisit);
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