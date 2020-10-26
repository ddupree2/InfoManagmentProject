﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CS3230Project.Model;
using CS3230Project.ViewModel;
using MySql.Data.MySqlClient;

namespace CS3230Project
{
    public partial class AppointmentForm : Form
    {

        private Appointment appointment;

        private AppointmentViewModel appointmentViewModel = new AppointmentViewModel();

        private Patient patient;

        private IList<Doctor> doctors;

        private IList<Appointment> appointments;
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

            this.patient = patient;
            this.doctors = this.appointmentViewModel.getDoctors();
            this.addDoctorsToComboBox();
            this.addPatientToPatientField();
            this.fillAppointmentInfo();
            this.nameLabel.Text = this.patient.Fname + " " + this.patient.Lname;
        }

        private void fillAppointmentGrid()
        {

            this.appointmentDataGrid.Rows.Clear();
            this.appointmentDataGrid.Refresh();

            foreach (var appointment in this.appointments)
            {
                this.appointmentDataGrid.Rows.Add(appointment.AppointmentDate);
            }

        }

        private IList<Appointment> getPatientAppointments()
        {
            IList<Appointment> appointmentList = this.appointmentViewModel.GetAppointments(this.patient);
            return appointmentList;
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

            this.addNewAppointmentButton.Enabled = false;
            this.addNewAppointmentButton.Visible = false;
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
            this.appointmentDataGrid.ClearSelection();
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
            var appointmentDate = this.appointmentDateTimePicker.Value.Date;
            var time = this.timePicker.Value.TimeOfDay;

            var dateAndTimeString = appointmentDate.ToShortDateString() + " " + time.ToString();
            var dateAndTime = DateTime.Parse(dateAndTimeString);


            var appointment = new Appointment(reason, patientId, doctorId, dateAndTime);
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
                             doctorName + "on : " + dateAndTime;
            if (successfulRegistration)
            {
                showSuccessfulRegisterMessage(registered);
                this.fillAppointmentInfo();
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

            this.timeLabel.Text = star + @"Time: ";
            this.timeLabel.ForeColor = Color.Red;

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
                          this.reasonTextBox.Text == string.Empty || this.timePicker.Text == string.Empty;

            return checker;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion

        private void updateButton_Click(object sender, EventArgs e)
        {
             var appointmentSelected = this.appointmentDataGrid.SelectedRows.Count == 1;
             if (appointmentSelected == false)
             {
                MessageBox.Show(@"please select an appointment.");
                return;
             }

             var appointmentToUpdate = this.appointments[this.appointmentDataGrid.CurrentCell.RowIndex];
             appointmentToUpdate.Reason = this.reasonTextBox.Text;
             var doctorIdLocator = this.doctorIDComboBox.SelectedIndex;
             appointmentToUpdate.DoctorId = this.doctors[doctorIdLocator].DoctorId;

             var successfulUpdate = this.appointmentViewModel.UpdateAppointment(appointmentToUpdate);
             if (successfulUpdate)
             {
                 MessageBox.Show(@"Appointment Updated");
                 this.fillAppointmentInfo();
             }

        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            this.appointmentDataGrid.ClearSelection();
        }

        private void fillAppointmentInfo()
        {
            this.appointments = this.getPatientAppointments();
            this.fillAppointmentGrid();
        }

        private void appointmentDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = this.appointmentDataGrid.CurrentCell.RowIndex;

            this.reasonTextBox.Text = this.appointments[cell].Reason;
            var doctorID = this.appointments[cell].DoctorId;
            var doctorName = this.findDoctor(doctorID);
            this.doctorIDComboBox.Text = doctorName;
            this.appointmentDateTimePicker.Text = this.appointments[cell].AppointmentDate.ToShortDateString();
            this.timePicker.Text = this.appointments[cell].AppointmentDate.ToShortTimeString();
        }

        private string findDoctor(string doctorID)
        {
            var doctorName = string.Empty;

            foreach (var doctor in doctors)
            {
                if (doctor.IsDoctor(doctorID))
                {
                    doctorName = doctor.Employee.Fname + " " + doctor.Employee.Lname;
                    break;
                }
            }

            return doctorName;
        }
    }
}