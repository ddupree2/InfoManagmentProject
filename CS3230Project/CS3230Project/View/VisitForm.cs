using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        private readonly DateTimePicker gridDate = new DateTimePicker();
        private DateTime testTime;
        private TextBox resultsTextBox = new TextBox {Multiline = true};

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="VisitForm" /> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public VisitForm(Patient patient)
        {
            this.InitializeComponent();
            this.visitViewModel = new VisitViewModel(patient);
            this.patient = patient;
            this.setupVistForm();
            this.setUpGridColumns();
        }

        #endregion

        #region Methods

        private void setUpGridColumns()
        {
            var numberOfColumns = this.testResultsGridView.Columns.Count;

            var columnCounter = 2;
            while (columnCounter < numberOfColumns)
            {
                this.testResultsGridView.Columns[columnCounter].ReadOnly = true;
                columnCounter++;
            }
        }

        private void setupVistForm()
        {
            this.appointmentComboBox.DataSource = this.visitViewModel.AppointmentsDates;
            this.appointmentComboBox.SelectedIndex = 0;

            var nurses = this.visitViewModel.Nurses;
            this.nurseComboBox.DataSource = this.retrieveNurseNames(nurses);
            this.nurseComboBox.SelectedIndex = 0;
            this.patientIDTextBox.Text = this.patient.PatientId.ToString();
            this.updateVisitForm();
        }

        private void updateVisitForm()
        {
            this.visits = this.visitViewModel.RetrieveVisits(this.patient.PatientId,
                (DateTime) this.appointmentComboBox.SelectedValue);

            var existingVisit = this.visits.FirstOrDefault();
            if (existingVisit != null)
            {
                this.fillVisitForm(existingVisit);
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
            this.weightTextBox.Text = string.Empty;
            this.addUpdateButton.Text = @"Add";

            this.testResultsGridView.DataSource = new DataTable();
        }

        private void fillVisitForm(Visit existingVisit)
        {
            this.checkIfFinalDiagnosisIsPresent(existingVisit);

            this.diagnosisTextBox.Text = existingVisit.Diagnosis;
            this.diastolicTextBox.Text = existingVisit.DiastolicNum.ToString();
            this.systolicTextBox.Text = existingVisit.SystolicNum.ToString();
            this.bodyTempTextBox.Text = existingVisit.BodyTemp.ToString(CultureInfo.InvariantCulture);
            this.weightTextBox.Text = existingVisit.Weight.ToString(CultureInfo.InvariantCulture);
            this.heartRateTextBox.Text = existingVisit.HeartRate.ToString();
            this.respirationRateTextBox.Text = existingVisit.RespirationRate.ToString();
            this.otherTextBox.Text = existingVisit.Other;
            this.addUpdateButton.Text = @"Update";

            var nurse = this.visitViewModel.RetrieveNurse(existingVisit.NurseId);
            var nurseName = $"{nurse.Fname} {nurse.Lname}";
            this.nurseComboBox.SelectedItem = nurseName;
        }

        private void checkIfFinalDiagnosisIsPresent(Visit existingVisit)
        {
            if (existingVisit.FinalDiagnosis)
            {
                this.updateEnableProperties(false);
                this.finalDiagnosisCheckBox.Checked = true;
            }
            else
            {
                this.updateEnableProperties(true);
                this.finalDiagnosisCheckBox.Checked = false;
            }
        }

        private void updateEnableProperties(bool shouldEnable)
        {
            this.diagnosisTextBox.Enabled = shouldEnable;
            this.diastolicTextBox.Enabled = shouldEnable;
            this.systolicTextBox.Enabled = shouldEnable;
            this.bodyTempTextBox.Enabled = shouldEnable;
            this.weightTextBox.Enabled = shouldEnable;
            this.heartRateTextBox.Enabled = shouldEnable;
            this.respirationRateTextBox.Enabled = shouldEnable;
            this.finalDiagnosisCheckBox.Enabled = shouldEnable;
            this.otherTextBox.Enabled = shouldEnable;
            this.nurseComboBox.Enabled = shouldEnable;
            this.finalDiagnosisCheckBox.Enabled = shouldEnable;
            this.testResultsGridView.Enabled = shouldEnable;
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

        private void apppointmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.updateVisitForm();
            }
            catch
            {
                // catching the error caused by updating the visit form
                // when no visits exists for the selected data.
            }
        }

        private void addUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.toggleRequiredFieldsLabels(false);

                var patientId = this.patient.PatientId;
                var appointmentDate = (DateTime) this.appointmentComboBox.SelectedValue;
                var visitExists = this.visitViewModel.VisitsExist(patientId, appointmentDate);

                var visit = this.parseVisit();
                var allTestResults = this.CreateUpdatedTestResults(visit);

                var finalDiagnosisResult = this.promptForFinalDiagnosis();
                if (finalDiagnosisResult == DialogResult.No)
                {
                    return;
                }

                if (visitExists)
                {
                    this.visitViewModel.UpdateVisit(visit);
                    this.visitViewModel.UpdateTests(allTestResults);
                    showSuccessMessage("Update Success", "The visit info was successfully updated.");
                }
                else
                {
                    this.visitViewModel.InsertVisit(visit);
                    showSuccessMessage("Add Success", "The visit info was successfully added.");
                }

                this.updateVisitForm();
            }
            catch (MySqlException mex)
            {
                showErrorMessage(mex.Message);
            }
            catch (FormatException)
            {
                showErrorMessage("One or more of the required fields are missing.");
                this.toggleRequiredFieldsLabels(true);
            }
        }

        private List<TestResult> CreateUpdatedTestResults(Visit visit)
        {
            var allTestResults = new List<TestResult>();

            var counter = 0;
            foreach (DataGridViewRow row in this.testResultsGridView.Rows)
            {
                if (counter < this.testResultsGridView.Rows.Count - 1)
                {
                    var date = DateTime.Parse(row.Cells[0].Value.ToString()).Date;
                    var testResults = row.Cells[1].Value.ToString();
                    var statusIndicator = row.Cells[5].Value.ToString().Equals("True");
                    var appointmentDate = DateTime.Parse(row.Cells[2].Value.ToString());
                    var testCode = int.Parse(row.Cells[3].Value.ToString());
                    var testName = row.Cells[4].Value.ToString();
                    var test = new TestResult(date, testResults, appointmentDate, visit.PatientId, testCode, testName,
                        statusIndicator);
                    allTestResults.Add(test);
                }

                counter++;
            }

            return allTestResults;
        }

        private DialogResult promptForFinalDiagnosis()
        {
            var result = DialogResult.OK;
            if (this.finalDiagnosisCheckBox.CheckState == CheckState.Checked)
            {
                const string message =
                    "Are you sure that you would like submit a final diagnosis. You will not be able to change any information for this visit afterwords.";
                const string caption = "Caution";
                result = MessageBox.Show(message, caption,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            }

            return result;
        }

        private void toggleRequiredFieldsLabels(bool isVisible)
        {
            this.requiredFieldsLabel.Visible = isVisible;
            this.bodyTempEmptyLabel.Visible = isVisible;
            this.systolicEmptyLabel.Visible = isVisible;
            this.diastolicEmptyLabel.Visible = isVisible;
            this.heartRateEmptyLabel.Visible = isVisible;
            this.respirationEmptyLabel.Visible = isVisible;
            this.weightEmptyLabel.Visible = isVisible;
        }

        private Visit parseVisit()
        {
            var systolicNumber = int.Parse(this.systolicTextBox.Text);
            var diastolicNumber = int.Parse(this.diastolicTextBox.Text);
            var heartrate = int.Parse(this.heartRateTextBox.Text);
            var respirationRate = int.Parse(this.respirationRateTextBox.Text);
            var bodyTemp = double.Parse(this.bodyTempTextBox.Text);
            var weight = double.Parse(this.weightTextBox.Text);
            var other = this.otherTextBox.Text;

            var nurses = this.visitViewModel.Nurses;
            var selectedNurseIndex = this.nurseComboBox.SelectedIndex;
            var nurseId = nurses[selectedNurseIndex].NurseId;

            var appointmentDate = (DateTime) this.appointmentComboBox.SelectedValue;
            var patientID = this.patient.PatientId;
            var diagnosis = this.diagnosisTextBox.Text;
            var finalDiagnosis = false || this.finalDiagnosisCheckBox.CheckState == CheckState.Checked;

            var visit = new Visit {
                SystolicNum = systolicNumber,
                Diagnosis = diagnosis,
                DiastolicNum = diastolicNumber,
                HeartRate = heartrate,
                RespirationRate = respirationRate,
                BodyTemp = bodyTemp,
                Weight = weight,
                Other = other,
                NurseId = nurseId,
                AppointmentDate = appointmentDate,
                PatientId = patientID,
                FinalDiagnosis = finalDiagnosis
            };

            return visit;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Hide();
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
            this.allowOnlyDecimalNumbers(sender, e);
        }

        private void allowOnlyDecimalNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' &&
                e.KeyChar != (char) Keys.Back)
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
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char) Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void orderTestsButton_Click(object sender, EventArgs e)
        {
            var patientId = this.patient.PatientId;
            var appointmentDate = (DateTime) this.appointmentComboBox.SelectedValue;
            var visitExists = this.visitViewModel.VisitsExist(patientId, appointmentDate);
            var nurses = this.visitViewModel.Nurses;
            var selectedNurseIndex = this.nurseComboBox.SelectedIndex;
            var nurseId = nurses[selectedNurseIndex].NurseId;

            if (!visitExists)
            {
                var visit = new Visit {AppointmentDate = appointmentDate, PatientId = patientId, NurseId = nurseId};
                this.visitViewModel.InsertVisit(visit);
            }

            try
            {
                var orderTestsViewModel = new OrderTestViewModel(appointmentDate, this.patient);
                var orderTestsForm = new OrderTestsForm(orderTestsViewModel);
                orderTestsForm.Show();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private void testResultsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnIndex = e.ColumnIndex;
            var rowIndex = e.RowIndex;
            var lastRowIndex = this.testResultsGridView.RowCount - 1;

            if (columnIndex == 0 && rowIndex >= 0 && rowIndex != lastRowIndex)
            {
                Debug.WriteLine($"Row Count:{this.testResultsGridView.RowCount} index: {e.RowIndex}");
                this.testTime = DateTime.Parse(this.testResultsGridView.CurrentCell.Value.ToString());
                this.testResultsGridView.Controls.Add(this.gridDate);

                this.gridDate.Format = DateTimePickerFormat.Short;

                var oRectangle = this.testResultsGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                this.gridDate.Size = new Size(oRectangle.Width, oRectangle.Height);
                this.gridDate.Location = new Point(oRectangle.X, oRectangle.Y);
                this.gridDate.TextChanged += this.dateTimePicker_OnTextChange;
                this.gridDate.Visible = true;
            }

            if (columnIndex == 5)
            {
                if (this.testResultsGridView.CurrentCell.Value.Equals("False"))
                {
                    this.testResultsGridView.CurrentCell.Value = "True";
                }
                else if (this.testResultsGridView.CurrentCell.Value.Equals("True"))
                {
                    this.testResultsGridView.CurrentCell.Value = "";
                }
                else
                {
                    this.testResultsGridView.CurrentCell.Value = "False";
                }
            }
        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            var dateToCompare = this.gridDate.Value;
            var selectedAppointmentDate = DateTime.Parse(this.appointmentComboBox.Text);

            var dateComparison = DateTime.Compare(selectedAppointmentDate, dateToCompare);

            if (dateComparison > 0)
            {
                MessageBox.Show(@"Please select a date on or after the selected appointment date.");
                this.gridDate.Value = this.testTime;
            }
            else
            {
                this.testResultsGridView.CurrentCell.Value = dateToCompare.ToShortDateString();
                this.gridDate.Hide();
            }
        }

        #endregion
    }
}