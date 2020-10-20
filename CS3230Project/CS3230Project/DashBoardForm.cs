using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CS3230Project.Model;
using CS3230Project.ViewModel;

namespace CS3230Project
{
    public partial class DashBoardForm : Form
    {
        private readonly DashboardViewModel dashboardViewModel;

        private IList<Patient> patients;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashBoardForm"/> class.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        public DashBoardForm(string employeeId)
        {
            this.InitializeComponent();
            this.dashboardViewModel = new DashboardViewModel();
            var greetingsText = this.greetingsLabel.Text;
            this.greetingsLabel.Text = greetingsText + this.dashboardViewModel.RetrieveTitleAndName(employeeId);
            this.patients = this.dashboardViewModel.RetrievePatients();
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
            this.DialogResult = DialogResult.OK;
            hideRegistrationForms();
        }

        private static void hideRegistrationForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(RegistrationForm))
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
            var address = this.dashboardViewModel.getAddress(patient);
            var registrationForm = new RegistrationForm(patient, address);
            registrationForm.Show();

        }
    }
}
