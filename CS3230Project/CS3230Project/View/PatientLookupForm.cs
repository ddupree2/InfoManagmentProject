using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using CS3230Project.Model;
using CS3230Project.ViewModel;
using MySql.Data.MySqlClient;

namespace CS3230Project.View
{
    /// <summary>
    ///     Visual representation of a patient lookup form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class PatientLookupForm : Form
    {
        #region Data members

        private readonly PatientLookupViewModel patientLookupViewModel;
        private IList<Patient> patients;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PatientLookupForm" /> class.
        /// </summary>
        public PatientLookupForm()
        {
            this.InitializeComponent();
            this.patientLookupViewModel = new PatientLookupViewModel();
            this.patientGridView.MultiSelect = false;
        }

        #endregion

        #region Methods

        private void patientSearchButton_Click(object sender, EventArgs e)
        {
            var firstName = this.firstNameTextBox.Text != string.Empty ? this.firstNameTextBox.Text : null;
            var lastName = this.lastNameTextBox.Text != string.Empty ? this.lastNameTextBox.Text : null;
            var dob = this.dobDateTimePicker.Value;

            var enableDobSearch = this.enableDOBCeckBox.Checked;
            dob = enableDobSearch ? dob : default;

            this.patients = this.retrievePatients(firstName, lastName, dob);

            var haveResults = this.patients.Any();
            Debug.WriteLine($"Patients exist? {haveResults} # Patients: {this.patients.Count}");
            if (haveResults)
            {
                var patientTable = this.patientLookupViewModel.RetrievePatientsTable(this.patients);
                this.patientGridView.DataSource = patientTable;
                this.patientGridView.AutoResizeColumns();
            }
            else
            {
                showNoResultsMessage($"{firstName} {lastName} {dob}", "patients");
            }

            this.resetForm();
        }

        private void resetForm()
        {
            this.firstNameTextBox.Text = string.Empty;
            this.lastNameTextBox.Text = string.Empty;
        }

        private IList<Patient> retrievePatients(string firstName, string lastName, DateTime dob)
        {
            try
            {
                return this.patientLookupViewModel.RetrievePatients(firstName, lastName, dob);
            }
            catch (MySqlException mex)
            {
                Debug.WriteLine(mex.Message + Environment.NewLine + mex.StackTrace);
                showNoResultsMessage($"{firstName} {lastName} {dob}", "patients");
            }

            return new List<Patient>();
        }

        private static void showNoResultsMessage(string name, string eventString)
        {
            const string noResultsTitle = "No Results";
            var noResultsMessage = $"There were no {eventString} found for {name}.";
            const MessageBoxIcon messageType = MessageBoxIcon.Information;
            MessageBox.Show(noResultsMessage, noResultsTitle, MessageBoxButtons.OK, messageType);
        }

        private void patientGridView_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.patientGridView.Rows.Count > 0)
            {
                this.viewAppointmentsButton.Enabled = true;
                this.viewVisitsButton.Enabled = true;
            }
            else
            {
                this.viewAppointmentsButton.Enabled = false;
                this.viewVisitsButton.Enabled = false;
            }
        }

        private void viewAppointmentsButton_Click(object sender, EventArgs e)
        {
            var patientIndex = this.patientGridView.CurrentCell.RowIndex;
            Debug.WriteLine($"appointments: patient index: {patientIndex}");
            var patient = this.patients[patientIndex];
            var appointmentForm = new AppointmentForm(patient);
            appointmentForm.Show();
        }

        private void viewVisits_Click(object sender, EventArgs e)
        {
            var patientIndex = this.patientGridView.CurrentCell.RowIndex;
            Debug.WriteLine($"visits: patient index: {patientIndex}");

            if (this.patientHasNoAppointments(patientIndex))
            {
                return;
            }

            var patient = this.patients[patientIndex];
            var visitForm = new VisitForm(patient);
            visitForm.Show();
        }

        private bool patientHasNoAppointments(int selectedPatientIndex)
        {
            var patient = this.patients[selectedPatientIndex];
            var hasAppointments = new DashboardViewModel().HasAppointments(patient);
            Debug.WriteLine($"Has Appointments: {hasAppointments}");
            if (!hasAppointments)
            {
                MessageBox.Show(
                    @"Patient must have an inprogress or past appointment before adding or viewing visit info.");
            }

            return !hasAppointments;
        }

        #endregion
    }
}