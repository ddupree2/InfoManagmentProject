using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using CS3230Project.Model;
using CS3230Project.View;
using CS3230Project.ViewModel;

namespace CS3230Project
{
    public partial class DashBoardForm : Form
    {
        #region Data members

        private readonly DashboardViewModel dashboardViewModel;

        private IList<Patient> patients;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DashBoardForm" /> class.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        public DashBoardForm(string employeeId)
        {
            InitializeComponent();
            dashboardViewModel = new DashboardViewModel();

            setupDashBoard(employeeId);
        }

        #endregion

        #region Methods

        private void setupDashBoard(string employeeId)
        {
            var title = dashboardViewModel.RetrieveTitle(employeeId);
            var firstName = dashboardViewModel.RetrieveFirstName(employeeId);

            setupGreetingsText(employeeId, title, firstName);
            patients = dashboardViewModel.RetrievePatients();

            if (title != "Administrator") return;

            adminButton.Enabled = true;
            adminButton.Visible = true;
        }

        private void setupGreetingsText(string employeeId, string title, string firstName)
        {
            var greetingsText = $"{greetingsLabel.Text} {title} {firstName}";
            greetingsLabel.Text = greetingsText;
        }

        private void loadPatientsIntoView()
        {
            mainInfoDisplay.Items.Clear();
            foreach (var patient in patients) mainInfoDisplay.Items.Add(patient.Fname + " " + patient.Lname);
        }

        private void registerPatientButton_Click(object sender, EventArgs e)
        {
            var registrationForm = new RegistrationForm();
            registrationForm.Show();
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            hideNonLoginForms();
        }

        private static void hideNonLoginForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                var notDashBoardForm = form.GetType() != typeof(DashBoardForm);
                var notLoginForm = form.GetType() != typeof(LoginForm);

                if (notLoginForm && notDashBoardForm) form.Hide();
            }
        }

        private void DashBoardForm_Activated(object sender, EventArgs e)
        {
            patients = dashboardViewModel.RetrievePatients();
            loadPatientsIntoView();
        }

        private void editPatientButton_Click(object sender, EventArgs e)
        {
            var patientNotSelected = mainInfoDisplay.SelectedIndex < 0;

            if (patientNotSelected)
            {
                MessageBox.Show(@"please select a patient.");
                return;
            }

            var selectPatientIndex = mainInfoDisplay.SelectedIndex;
            var patient = patients[selectPatientIndex];
            var address = dashboardViewModel.RetrieveAddress(patient);
            var registrationForm = new RegistrationForm(patient, address);
            registrationForm.Show();
        }

        private void patientLookUpButton_Click(object sender, EventArgs e)
        {
            var patientLookupForm = new PatientLookupForm();
            patientLookupForm.Show();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            hideNonLoginForms();
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            var adminQueryForm = new AdminQueryForm();
            adminQueryForm.Show();
        }

        private void appointmentBtn_Click(object sender, EventArgs e)
        {
            var selectedPatientIndex = mainInfoDisplay.SelectedIndex;
            if (patientNotSelected(selectedPatientIndex)) return;

            var patient = patients[selectedPatientIndex];
            var appointmentForm = new AppointmentForm(patient);
            appointmentForm.Show();
        }

        private void recordVisitButton_Click(object sender, EventArgs e)
        {
            var selectedPatientIndex = mainInfoDisplay.SelectedIndex;
            if (patientNotSelected(selectedPatientIndex) || patientHasNoAppointments(selectedPatientIndex)) return;

            var patient = patients[selectedPatientIndex];
            var visitForm = new VisitForm(patient);
            visitForm.Show();
        }

        private static bool patientNotSelected(int selectedPatientIndex)
        {
            var patientNotSelected = selectedPatientIndex < 0;
            if (patientNotSelected) MessageBox.Show(@"please select a patient.");

            return patientNotSelected;
        }

        private bool patientHasNoAppointments(int selectedPatientIndex)
        {
            var patient = patients[selectedPatientIndex];
            var hasAppointments = dashboardViewModel.HasAppointments(patient);
            Debug.WriteLine($"Has Appointments: {hasAppointments}");
            if (!hasAppointments) MessageBox.Show(@"Patient must have a scheduled appointment before a visit.");

            return !hasAppointments;
        }

        #endregion
    }
}