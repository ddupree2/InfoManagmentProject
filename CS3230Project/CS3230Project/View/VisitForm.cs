﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CS3230Project.Model;
using CS3230Project.ViewModel;
using MySql.Data.MySqlClient;

namespace CS3230Project.View
{
    /// <summary>
    ///     Represents a patient visitViewModel in the view
    /// </summary>
    /// <seealso cref="Form" />
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
            this.nurseComboBox.DataSource = this.retrieveNurseNames(nurses);
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
            this.addUpdateButton.Text = @"Add";

            this.testResultsGridView.DataSource = new DataTable();
        }

        private void fillVisitForm(Visit existingVisit)
        {
            

            this.diagnosisTextBox.Text = existingVisit.Diagnosis;
            this.diastolicTextBox.Text = existingVisit.DiastolicNum.ToString();
            this.systolicTextBox.Text = existingVisit.SystolicNum.ToString();
            this.bodyTempTextBox.Text = existingVisit.BodyTemp.ToString(CultureInfo.InvariantCulture);
            this.heartRateTextBox.Text = existingVisit.HeartRate.ToString();
            this.respirationRateTextBox.Text = existingVisit.RespirationRate.ToString();
            this.otherTextBox.Text = existingVisit.Other;
            this.addUpdateButton.Text = @"Update";

            var isFinalDiagnosis = this.isFinalDiagnosis();
            this.updateEnableProperties(!isFinalDiagnosis);
            this.addUpdateButton.Enabled = !isFinalDiagnosis;
            this.finalDiagnosisCheckBox.Checked = isFinalDiagnosis;

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
            this.finalDiagnosisCheckBox.Enabled = shouldEnable;
        }

        private IList<string> retrieveNurseNames(IEnumerable<Nurse> nurses)
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
            var isFinalDiagnosis = finalDiagnosis.EndsWith("final");
            return isFinalDiagnosis;
        }

        private void apppointmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.updateVisitForm();
        }

        private void finalDiagnosisCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var hasFinalDiagnosis = this.finalDiagnosisCheckBox.Checked;

            if (!hasFinalDiagnosis) return;

            var diagnosis = this.diagnosisTextBox.Text.ToLower();
            if (!diagnosis.EndsWith("final"))
            {
                this.diagnosisTextBox.Text += Environment.NewLine + @"Final";
            }

            this.updateEnableProperties(false);
        }

        private void addUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.toggleRequiredFieldsLabels(false);
                var visitExists = this.visitViewModel.VisitsExist(this.patient.PatientId,
                    (DateTime) this.appointmentComboBox.SelectedValue);

                var visit = this.parseVisit();

                if (visitExists)
                {
                    this.visitViewModel.UpdateVisit(visit);
                    showSuccessMessage("Update Success", "The visit info was successfully updated.");
                }
                else
                {
                    this.visitViewModel.InsertVisit(visit);
                    showSuccessMessage("Add Success", "The visit info was successfully added.");
                }
            }
            catch (MySqlException mex)
            {
                showErrorMessage(mex.Message);
            }
            catch (FormatException fe)
            {
                showErrorMessage("One or more of the required fields are missing.");
                this.toggleRequiredFieldsLabels(true);
            }
        }

        private void toggleRequiredFieldsLabels(bool isVisible)
        {
            this.requiredFieldsLabel.Visible = isVisible;
            this.bodyTempEmptyLabel.Visible = isVisible;
            this.systolicEmptyLabel.Visible = isVisible;
            this.diastolicEmptyLabel.Visible = isVisible;
            this.heartRateEmptyLabel.Visible = isVisible;
            this.respirationEmptyLabel.Visible = isVisible;
        }

        private Visit parseVisit()
        {
            var systolicNumber = int.Parse(this.systolicTextBox.Text);
            var diastolicNumber = int.Parse(this.diastolicTextBox.Text);
            var heartrate = int.Parse(this.heartRateTextBox.Text);
            var respirationRate = int.Parse(this.respirationRateTextBox.Text);
            var bodyTemp = double.Parse(this.bodyTempTextBox.Text);
            var other = this.otherTextBox.Text;

            var nurses = this.visitViewModel.Nurses;
            var selectedNurseIndex = this.nurseComboBox.SelectedIndex;

            var nurseId = nurses[selectedNurseIndex].NurseId;
            var appointmentDate = (DateTime) this.appointmentComboBox.SelectedValue;
            var patientID = this.patient.PatientId;
            var diagnosis = this.diagnosisTextBox.Text;

            var visit = new Visit()
            {
                SystolicNum = systolicNumber,
                Diagnosis = diagnosis,
                DiastolicNum = diastolicNumber,
                HeartRate = heartrate,
                RespirationRate = respirationRate,
                BodyTemp = bodyTemp,
                Other = other,
                NurseId = nurseId,
                AppointmentDate = appointmentDate,
                PatientId = patientID
            };

            return visit;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private static void showErrorMessage(string errorMessage)
        {
            const string noResultsTitle = "Add/Update Error";
            var noResultsMessage = "Error: " + errorMessage;
            const MessageBoxIcon messageType = MessageBoxIcon.Error;
            MessageBox.Show(noResultsMessage, noResultsTitle, MessageBoxButtons.OK, messageType);
        }

        private static void showSuccessMessage(string title, string message)
        {
            var successTitle = title;
            var successMessage = "Success: " + message;
            const MessageBoxIcon messageType = MessageBoxIcon.Information;
            MessageBox.Show(successMessage, successTitle, MessageBoxButtons.OK, messageType);
        }

        private void bodyTempTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            allowOnlyDecimalNumbers(sender, e);
        }

        private void allowOnlyDecimalNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char) Keys.Back)
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && this.bodyTempTextBox.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void systolicTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            allowOnlyDigits(e);
        }

        private void diastolicTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            allowOnlyDigits(e);
        }

        private void heartRateTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            allowOnlyDigits(e);
        }

        private void respirationRateTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            allowOnlyDigits(e);
        }
        private static void allowOnlyDigits(KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}