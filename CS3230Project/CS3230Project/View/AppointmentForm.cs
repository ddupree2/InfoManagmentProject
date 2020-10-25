using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CS3230Project.Model;
using CS3230Project.ViewModel;
using MySql.Data.MySqlClient;

namespace CS3230Project
{
    public partial class AppointmentForm : Form
    {

        private Appointment appointment;

        private Patient patient;

        private IList<Doctor> doctors;
        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentForm"/> class.
        /// </summary>
        /// <param name="appointment">The appointment.</param>
        public AppointmentForm(Appointment appointment)
        {
            this.InitializeComponent();
            this.appointment = appointment;
            this.setupForCurrentAppointment();
        }

        public AppointmentForm(Patient patient)
        {
            this.InitializeComponent();
            var appointmentViewModel = new AppointmentViewModel();

            this.patient = patient;
            this.doctors = appointmentViewModel.getDoctors();
            this.addDoctorsToComboBox();
            this.addPatientToPatientField();
        }

        private void addPatientToPatientField()
        {
            var patient = this.patient.Fname + " " + this.patient.Lname;
            this.patientIDTextBox.Text = patient;
        }

        private void addDoctorsToComboBox()
        {
            
            foreach (var doctor in doctors)
            {
                var doctorName = doctor.Employee.Fname + " " + doctor.Employee.Lname;

                this.doctorIDComboBox.Items.Add(doctorName);
            }
        }

        private void setupForCurrentAppointment()
        {
            this.loadInAppointmentInfo();

            if (this.appointment.AppointmentDate >= DateTime.Now)
            {
                return;
            }

            this.saveButton.Enabled = false;
            this.saveButton.Visible = false;
            this.cancelButton.Text = @"Done";
            this.reasonTextBox.Enabled = false;
            this.appointmentDateTimePicker.Enabled = false;
            this.doctorIDComboBox.Enabled = false;
            this.patientIDTextBox.Enabled = false;
        }

        private void loadInAppointmentInfo()
        {
            this.appointmentDateTimePicker.Value = this.appointment.AppointmentDate;
            this.doctorIDComboBox.Text = this.appointment.DoctorId.ToString();
            this.patientIDTextBox.Text = this.appointment.PatientId.ToString();
            this.reasonTextBox.Text = this.appointment.Reason;
        }

        #endregion

        #region Methods

        private void saveButton_Click(object sender, EventArgs e)
        {
            var emptyField = this.checkIfFieldsAreNull();
            if (emptyField)
            {
                this.turnLabelsRed();
                return;
            }

            var reason = this.reasonTextBox.Text;
            var doctorIdLocator = this.doctorIDComboBox.SelectedIndex;
            var doctorId = this.doctors[doctorIdLocator].DoctorId;
            var patientId = this.patient.PatientId.ToString();
            var appointmentDate = this.appointmentDateTimePicker.Value;


            var appointment = new Appointment(reason, patientId, doctorId, appointmentDate);
            var appointmentViewModel = new AppointmentViewModel();

            var successfulRegistration = false;
            try
            {
                successfulRegistration = appointmentViewModel.registerAppointment(appointment);
            }
            catch (MySqlException)
            {
                showFailedRegistrationMessage();
            }

            var doctorName = this.doctors[doctorIdLocator].Employee.Fname + " " + this.doctors[doctorIdLocator].Employee.Lname;
            var registered = this.patient.Fname + " " + this.patient.Lname + " is registered to see doctor " +
                             doctorName + "on : " + appointmentDate;
            if (successfulRegistration)
            {
                showSuccessfulRegisterMessage(registered);
                this.Close();
            }
        }

        private  void showSuccessfulRegisterMessage(string registered)
        {
            const string issueTitle = "Successful Registration";
            const MessageBoxIcon issueType = MessageBoxIcon.Information;
            MessageBox.Show(registered, issueTitle, MessageBoxButtons.OK, issueType);
        }

        private void showFailedRegistrationMessage()
        {
            const string issueTitle = "Failed Registration";
            var connectionIssue = "The appointment was not registered." + Environment.NewLine;
            connectionIssue += "Please make sure all fields are valid data.";
            const MessageBoxIcon issueType = MessageBoxIcon.Error;
            MessageBox.Show(connectionIssue, issueTitle, MessageBoxButtons.OK, issueType);
        }

        private void turnLabelsRed()
        {
            var star = "*";
            
            this.appointmentLabel.Text = star + @"Appointment Date:";
            this.appointmentLabel.ForeColor = Color.Red;

            this.doctorLabel.Text = star + @" Doctor";
            this.doctorLabel.ForeColor = Color.Red;

            this.patientLabel.Text = star + @"Patient";
            this.patientLabel.ForeColor = Color.Red;

            this.reasonLabel.Text = star + @"Reason(s)";
            this.reasonLabel.ForeColor = Color.Red;

            this.warningLabel.Visible = true;
        }

        private bool checkIfFieldsAreNull()
        {
            var checker = this.doctorIDComboBox.Text == string.Empty || this.appointmentDateTimePicker.Text == string.Empty ||
                          this.reasonTextBox.Text == string.Empty;

            return checker;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion
    }
}