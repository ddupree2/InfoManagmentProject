using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS3230Project.Model;
using CS3230Project.ViewModel;

namespace CS3230Project
{
    public partial class DashBoardForm : Form
    {
        private readonly DashboardViewModel dashboardViewModel;

        private IList<Patient> patients = new List<Patient>();

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
        }

        private void DashBoardForm_Activated(object sender, EventArgs e)
        {
            this.patients = this.dashboardViewModel.RetrievePatients();
            this.loadPatientsIntoView();
        }
    }
}
