using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CS3230Project.Model;
using CS3230Project.ViewModel;
using MySql.Data.MySqlClient;

namespace CS3230Project.View
{
    /// <summary>
    ///     Visual representation of an appointment form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class AppointmentForm : Form
    {
        #region Data members

        private readonly Appointment appointment;

        private readonly AppointmentViewModel appointmentViewModel = new AppointmentViewModel();

        private readonly Patient patient;

        private readonly IList<Doctor> doctors;

        private IList<Appointment> appointments;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AppointmentForm" /> class.
        /// </summary>
        /// <param name="appointment">The appointment.</param>
        public AppointmentForm(Appointment appointment)
        {
            this.InitializeComponent();
            this.appointment = appointment;
            this.setupForCurrentAppointment();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AppointmentForm" /> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public AppointmentForm(Patient patient)
        {
            this.InitializeComponent();

            this.patient = patient;
            this.doctors = this.appointmentViewModel.RetrieveDoctors();
            this.appointmentViewModel.RetrieveDoctorsAppointments(this.doctors);
            this.addDoctorsToComboBox();
            this.addPatientToPatientField();
            this.fillAppointmentInfo();
            this.nameLabel.Text = this.patient.Fname + " " + this.patient.Lname;
        }

        #endregion

        #region Methods

        private void fillAppointmentGrid()
        {
            this.appointmentDataGrid.Rows.Clear();
            this.appointmentDataGrid.Refresh();

            foreach (var appointment in this.appointments)
            {
                this.appointmentDataGrid.Rows.Add(appointment.AppointmentDate);
            }

            this.appointmentDataGrid.Rows.Add("New Appointment");
        }

        private IList<Appointment> getPatientAppointments()
        {
            var appointmentList = this.appointmentViewModel.RetrieveAppointments(this.patient);
            return appointmentList;
        }

        private void addPatientToPatientField()
        {
            var patient = this.patient.Fname + " " + this.patient.Lname;
            this.patientIDTextBox.Text = patient;
        }

        private void addDoctorsToComboBox()
        {
            foreach (var doctor in this.doctors)
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
            this.doctorIDComboBox.Text = this.appointment.DoctorId;
            this.patientIDTextBox.Text = this.appointment.PatientId;
            this.reasonTextBox.Text = this.appointment.Reason;
        }

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
            var time = this.timeComboBox.Text;

            var dateAndTimeString = appointmentDate.ToShortDateString() + " " + time;
            var dateAndTime = DateTime.Parse(dateAndTimeString);

            var appointment = new Appointment(reason, patientId, doctorId, dateAndTime);
            var appointmentViewModel = new AppointmentViewModel();

            var successfulRegistration = false;
            try
            {
                successfulRegistration = appointmentViewModel.RegisterAppointment(appointment);
                this.appointmentViewModel.RetrieveDoctorsAppointments(this.doctors);
            }
            catch (MySqlException)
            {
                this.showFailedRegistrationMessage();
            }

            var doctorName = this.doctors[doctorIdLocator].Employee.Fname + " " +
                             this.doctors[doctorIdLocator].Employee.Lname;
            var registered = this.patient.Fname + " " + this.patient.Lname + " is registered to see doctor " +
                             doctorName + "on : " + dateAndTime;
            if (successfulRegistration)
            {
                this.showSuccessfulRegisterMessage(registered);
                this.fillAppointmentInfo();
                this.turnLabelsBack();
                this.emptyForm();
            }
        }

        private void emptyForm()
        {
            this.timeComboBox.SelectedItem = null;
            this.reasonTextBox.Text = string.Empty;
            this.doctorIDComboBox.SelectedItem = null;
        }

        private void showSuccessfulRegisterMessage(string registered)
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

        private void turnLabelsBack()
        {
            this.appointmentLabel.Text = @"Appointment Date:";
            this.appointmentLabel.ForeColor = Color.Black;

            this.timeLabel.Text = @"Time: ";
            this.timeLabel.ForeColor = Color.Black;

            this.doctorLabel.Text = @" Doctor";
            this.doctorLabel.ForeColor = Color.Black;

            this.patientLabel.Text = @"Patient";
            this.patientLabel.ForeColor = Color.Black;

            this.reasonLabel.Text = @"Reason(s)";
            this.reasonLabel.ForeColor = Color.Black;

            this.warningLabel.Visible = false;
        }

        private bool checkIfFieldsAreNull()
        {
            var checker = this.doctorIDComboBox.Text == string.Empty ||
                          this.appointmentDateTimePicker.Text == string.Empty ||
                          this.reasonTextBox.Text == string.Empty || this.timeComboBox.Text == string.Empty;

            return checker;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            var emptyField = this.checkIfFieldsAreNull();
            if (emptyField)
            {
                this.turnLabelsRed();
                return;
            }

            var appointmentSelected = this.appointmentDataGrid.CurrentCell.RowIndex;
            if (appointmentSelected < 0)
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
                this.turnLabelsBack();
                MessageBox.Show(@"Appointment Updated");
                this.fillAppointmentInfo();
                this.appointmentDataGrid.ClearSelection();
                this.appointmentViewModel.RetrieveDoctorsAppointments(this.doctors);
                this.emptyForm();
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
            var newAppointmentCell = this.appointmentDataGrid.RowCount - 1;
            var cell = this.appointmentDataGrid.CurrentCell.RowIndex;
            if (cell >= newAppointmentCell)
            {
                this.addNewAppointmentButton.Visible = true;
                this.updateButton.Visible = false;

                this.reasonTextBox.Text = string.Empty;
                this.doctorIDComboBox.Text = string.Empty;

                this.timeComboBox.Enabled = true;
                this.appointmentDateTimePicker.Enabled = true;

                this.reasonTextBox.Enabled = true;
                this.doctorIDComboBox.Enabled = true;
                this.appointmentDateTimePicker.Enabled = true;
                this.timeComboBox.Enabled = true;
                this.appointmentTimePassedLabel.Visible = false;
            }
            else
            {
                this.addNewAppointmentButton.Visible = false;
                this.reasonTextBox.Text = this.appointments[cell].Reason;

                var doctorId = this.appointments[cell].DoctorId;
                var doctorName = this.findDoctor(doctorId);

                this.doctorIDComboBox.Text = doctorName;
                this.appointmentDateTimePicker.Text = this.appointments[cell].AppointmentDate.ToShortDateString();
                this.timeComboBox.Text = this.appointments[cell].AppointmentDate.ToShortTimeString();
                this.checkIfAppointmentHasPassed(this.appointments[cell].AppointmentDate);

                this.timeComboBox.Enabled = false;
                this.appointmentDateTimePicker.Enabled = false;
            }
        }

        private void checkIfAppointmentHasPassed(DateTime time)
        {
            if (DateTime.Now > time)
            {
                this.appointmentTimePassedLabel.Visible = true;
                this.updateButton.Visible = false;
                this.reasonTextBox.Enabled = false;
                this.doctorIDComboBox.Enabled = false;
            }
            else
            {
                this.appointmentTimePassedLabel.Visible = false;
                this.updateButton.Visible = true;
                this.reasonTextBox.Enabled = true;
                this.doctorIDComboBox.Enabled = true;
            }
        }

        private string findDoctor(string doctorID)
        {
            var doctorName = string.Empty;

            foreach (var doctor in this.doctors)
            {
                if (doctor.IsDoctor(doctorID))
                {
                    doctorName = doctor.Employee.Fname + " " + doctor.Employee.Lname;
                    break;
                }
            }

            return doctorName;
        }

        private void doctorIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.doctorIDComboBox.SelectedIndex >= 0)
            {
                this.updateTimeComboBox();
            }
        }

        private void updateTimeComboBox()
        {
            this.timeComboBox.Items.Clear();
            this.timeComboBox.Text = string.Empty;
            var selectedDate = this.appointmentDateTimePicker.Value.Date;

            var timeSlots = new Times(this.doctors[this.doctorIDComboBox.SelectedIndex], selectedDate);

            foreach (var time in timeSlots.times)
            {
                this.timeComboBox.Items.Add(time);
            }

            if (this.timeComboBox.Items.Count > 0)
            {
                this.timeComboBox.Enabled = true;
            }
            else
            {
                this.timeComboBox.Enabled = false;
            }
        }

        private void appointmentDateTimePicker_Leave(object sender, EventArgs e)
        {
            if (this.doctorIDComboBox.SelectedIndex >= 0)
            {
                this.updateTimeComboBox();
            }
        }

        #endregion
    }
}