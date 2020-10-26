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
    public partial class PatientLookupForm : Form
    {
        #region Data members

        private readonly PatientLookupViewModel patientLookupViewModel;
        private IList<Appointment> appointments;
        private IList<Visit> visits;

        #endregion

        #region Constructors

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

            this.appointments = this.retrieveAppointments(firstName, lastName, dob);
            this.visits = this.retrieveVisits(firstName, lastName, dob);

            var haveResults = this.visits.Any() || this.appointments.Any();

            if (haveResults)
            {

            }
            else
            {
                showNoResultsMessage($"{firstName} {lastName} {dob}", "appointments or visits");
            }
        }

        private IList<Visit> retrieveVisits(string firstName, string lastName, DateTime dob)
        {
            try
            {
                return this.patientLookupViewModel.RetrieveVisits(firstName, lastName, dob);
            }
            catch (MySqlException mex)
            {
                Debug.WriteLine(mex.Message + Environment.NewLine + mex.StackTrace);
                showNoResultsMessage($"{firstName} {lastName} {dob}", "visits");
            }

            return new List<Visit>();
        }

        private IList<Appointment> retrieveAppointments(string firstName, string lastName, DateTime dob)
        {
            try
            {
                return this.patientLookupViewModel.RetrieveAppointments(firstName, lastName, dob);
            }
            catch (MySqlException mex)
            {
                Debug.WriteLine(mex.Message + Environment.NewLine + mex.StackTrace);
                showNoResultsMessage($"{firstName} {lastName} {dob}", "appointments");
            }

            return new List<Appointment>();
        }

        private static void showNoResultsMessage(string name, string eventString)
        {
            const string noResultsTitle = "No Results";
            var noResultsMessage = $"There were no {eventString} found for {name}.";
            const MessageBoxIcon messageType = MessageBoxIcon.Information;
            MessageBox.Show(noResultsMessage, noResultsTitle, MessageBoxButtons.OK, messageType);
        }

        #endregion

        private void patientGridView_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.patientGridView.Rows.Count > 1)
            {
                this.viewAppointmentsButton.Enabled = true;
                this.viewAppointmentsButton.Enabled = true;
            }
            else
            {
                this.viewAppointmentsButton.Enabled = false;
                this.viewAppointmentsButton.Enabled = false;
            }
        }

        private void viewAppointmentsButton_Click(object sender, EventArgs e)
        {
            var patientIndex = this.patientGridView.CurrentCell.RowIndex;
        }
    }
}