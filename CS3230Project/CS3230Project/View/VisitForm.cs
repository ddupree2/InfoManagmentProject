using System;
using System.Collections.Generic;
using System.Data;
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
        private IList<Visit> visits;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="VisitForm" /> class.
        /// </summary>
        /// <param name="visit">The visit.</param>
        public VisitForm(Patient patient)
        {
            this.InitializeComponent();
            this.visitViewModel = new VisitViewModel(patient);
            this.patient = patient;
            this.setupVistForm();
        }

        #endregion

        #region Methods

        private void setupVistForm()
        {
            this.appointmentComboBox.DataSource = this.visitViewModel.AppointmentsDates;
            this.appointmentComboBox.SelectedIndex = 0;

            var nurses = this.visitViewModel.Nurses;
            this.nurseComboBox.DataSource = this.getNurseNames(nurses);
            this.nurseComboBox.SelectedIndex = 0;
            this.patientIDTextBox.Text = this.patient.PatientId.ToString();
            updateVisitForm();
        }

        private void updateVisitForm()
        {
            this.visits = this.visitViewModel.RetrieveVisits(this.patient.PatientId,
                (DateTime) this.appointmentComboBox.SelectedValue);

            var existingVisit = this.visits.FirstOrDefault();
            if (existingVisit != null)
            {
                fillVisitForm(existingVisit);
                this.populateTestResultsListView(existingVisit);
            }
            else
            {
                this.emptyForm();
                this.updateEnableProperties(true);
            }

            this.nameTextBox.Text = $@"{this.patient.Fname} {this.patient.Lname}";
        }

        private void emptyForm()
        {
            this.diagnosisTextBox.Text = string.Empty;
            this.diastolicTextBox.Text = string.Empty;
            this.systolicTextBox.Text = string.Empty;
            this.bodyTempTextBox.Text = string.Empty;
            this.heartRateTextBox.Text = string.Empty;
            this.respirationRateTextBox.Text = string.Empty;
            this.finalDiagnosisCheckBox.Checked = false;
            this.otherTextBox.Text = string.Empty;

            this.testResultsGridView.DataSource = new DataTable();
        }

        private void fillVisitForm(Visit existingVisit)
        {
            var isFinalDiagnosis = this.isFinalDiagnosis();
            this.updateEnableProperties(isFinalDiagnosis);

            this.diagnosisTextBox.Text = existingVisit.Diagnosis;
            this.diastolicTextBox.Text = existingVisit.DiastolicNum.ToString();
            this.systolicTextBox.Text = existingVisit.SystolicNum.ToString();
            this.bodyTempTextBox.Text = existingVisit.BodyTemp.ToString(CultureInfo.InvariantCulture);
            this.heartRateTextBox.Text = existingVisit.HeartRate.ToString();
            this.respirationRateTextBox.Text = existingVisit.RespirationRate.ToString();
            this.finalDiagnosisCheckBox.Checked = isFinalDiagnosis;
            this.otherTextBox.Text = existingVisit.Other;

            var nurse = this.visitViewModel.RetrieveNurse(existingVisit.NurseId);
            var nurseName = $"{nurse.Fname} {nurse.Lname}";
            this.nurseComboBox.SelectedItem = nurseName;
        }

        private void updateEnableProperties(bool shouldEnable)
        {
            this.diagnosisTextBox.Enabled = shouldEnable;
            this.diastolicTextBox.Enabled = shouldEnable;
            this.systolicTextBox.Enabled = shouldEnable;
            this.bodyTempTextBox.Enabled = shouldEnable;
            this.heartRateTextBox.Enabled = shouldEnable;
            this.respirationRateTextBox.Enabled = shouldEnable;
            this.finalDiagnosisCheckBox.Enabled = shouldEnable;
            this.otherTextBox.Enabled = shouldEnable;
            this.nurseComboBox.Enabled = shouldEnable;
        }

        private IList<string> getNurseNames(IEnumerable<Nurse> nurses)
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
            var isFinalDiagnosis = !finalDiagnosis.EndsWith("final");
            this.finalDiagnosisCheckBox.Enabled = isFinalDiagnosis;
            return isFinalDiagnosis;
        }

        #endregion

        private void apppointmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.updateVisitForm();
        }

        private void finalDiagnosisCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var hasFinalDiagnosis = this.finalDiagnosisCheckBox.Checked;
            if (hasFinalDiagnosis)
            {
                this.diagnosisTextBox.Text += Environment.NewLine + @"Final";
                this.updateEnableProperties(false);
            }
        }
    }
}