using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using CS3230Project.Model;
using CS3230Project.ViewModel;

namespace CS3230Project.View
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
            this.InitializeComponent();
            this.dashboardViewModel = new DashboardViewModel();

            this.setupDashBoard(employeeId);
        }

        #endregion

        #region Methods

        private void setupDashBoard(string employeeId)
        {
            var title = this.dashboardViewModel.RetrieveTitle(employeeId);
            var firstName = this.dashboardViewModel.RetrieveFirstName(employeeId);

            this.setupGreetingsText(employeeId, title, firstName);
            this.patients = this.dashboardViewModel.RetrievePatients();

            if (title != "Administrator")
            {
                return;
            }

            this.adminButton.Enabled = true;
            this.adminButton.Visible = true;
        }

        private void setupGreetingsText(string employeeId, string title, string firstName)
        {
            var greetingsText = $"{this.greetingsLabel.Text} {title} {firstName}";
            this.greetingsLabel.Text = greetingsText;
        }

        private void loadPatientsIntoView()
        {
            this.mainInfoDisplay.Items.Clear();
            foreach (var patient in this.patients)
            {
                this.mainInfoDisplay.Items.Add(patient.Fname + " " + patient.Lname);
            }
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

                if (notLoginForm && notDashBoardForm)
                {
                    form.Hide();
                }
            }
        }

        private void DashBoardForm_Activated(object sender, EventArgs e)
        {
            this.patients = this.dashboardViewModel.RetrievePatients();
            this.loadPatientsIntoView();
        }

        private void editPatientButton_Click(object sender, EventArgs e)
        {
            var patientNotSelected = this.mainInfoDisplay.SelectedIndex < 0;

            if (patientNotSelected)
            {
                MessageBox.Show(@"please select a patient.");
                return;
            }

            var selectPatientIndex = this.mainInfoDisplay.SelectedIndex;
            var patient = this.patients[selectPatientIndex];
            var address = this.dashboardViewModel.RetrieveAddress(patient);
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
            var selectedPatientIndex = this.mainInfoDisplay.SelectedIndex;
            if (patientNotSelected(selectedPatientIndex))
            {
                return;
            }

            var patient = this.patients[selectedPatientIndex];
            var appointmentForm = new AppointmentForm(patient);
            appointmentForm.Show();
        }

        private void recordVisitButton_Click(object sender, EventArgs e)
        {
            var selectedPatientIndex = this.mainInfoDisplay.SelectedIndex;
            if (patientNotSelected(selectedPatientIndex) || this.patientHasNoAppointments(selectedPatientIndex))
            {
                return;
            }

            var patient = this.patients[selectedPatientIndex];
            var visitForm = new VisitForm(patient);
            visitForm.Show();
        }

        private static bool patientNotSelected(int selectedPatientIndex)
        {
            var patientNotSelected = selectedPatientIndex < 0;
            if (patientNotSelected)
            {
                MessageBox.Show(@"please select a patient.");
            }

            return patientNotSelected;
        }

        private bool patientHasNoAppointments(int selectedPatientIndex)
        {
            var patient = this.patients[selectedPatientIndex];
            var hasAppointments = this.dashboardViewModel.HasAppointments(patient);
            Debug.WriteLine($"Has Appointments: {hasAppointments}");
            if (!hasAppointments)
            {
                MessageBox.Show(@"Patient must have an inprogress or past appointment  before adding or viewing visit info.");
            }

            return !hasAppointments;
        }

        #endregion
    }
}