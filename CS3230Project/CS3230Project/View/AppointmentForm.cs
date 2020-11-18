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
        private void deleteButton_Click(object sender, EventArgs e)
        {
            var appointment = appointments[appointmentDataGrid.CurrentCell.RowIndex];
            var success = appointmentViewModel.DeleteAppointment(appointment);

            if (success)
            {
                MessageBox.Show(@"Appointment Deleted");
                refreshAppointmentGrid();
            }
            else
            {
                MessageBox.Show(@"Appointment was unable to be deleted");
            }
        }

        private void refreshAppointmentGrid()
        {
            fillAppointmentInfo();
            turnLabelsBack();
            emptyForm();
        }

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
            InitializeComponent();
            this.appointment = appointment;
            setupForCurrentAppointment();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AppointmentForm" /> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public AppointmentForm(Patient patient)
        {
            InitializeComponent();

            this.patient = patient;
            appointments = new List<Appointment>();
            doctors = appointmentViewModel.RetrieveDoctors();
            appointmentViewModel.RetrieveDoctorsAppointments(doctors);
            addDoctorsToComboBox();
            addPatientToPatientField();
            fillAppointmentInfo();
            nameLabel.Text = this.patient.Fname + " " + this.patient.Lname;
        }

        #endregion

        #region Methods

        private void fillAppointmentGrid()
        {
            appointmentDataGrid.Rows.Clear();
            appointmentDataGrid.Refresh();

            foreach (var appointment in appointments) appointmentDataGrid.Rows.Add(appointment.AppointmentDate);

            appointmentDataGrid.Rows.Add("New Appointment");
        }

        private IList<Appointment> getPatientAppointments()
        {
            var appointmentList = appointmentViewModel.RetrieveAppointments(patient);
            return appointmentList;
        }

        private void addPatientToPatientField()
        {
            var patient = this.patient.Fname + " " + this.patient.Lname;
            patientIDTextBox.Text = patient;
        }

        private void addDoctorsToComboBox()
        {
            foreach (var doctor in doctors)
            {
                var doctorName = doctor.Employee.Fname + " " + doctor.Employee.Lname;

                doctorIDComboBox.Items.Add(doctorName);
            }
        }

        private void setupForCurrentAppointment()
        {
            loadInAppointmentInfo();

            if (appointment.AppointmentDate >= DateTime.Now) return;

            addNewAppointmentButton.Enabled = false;
            addNewAppointmentButton.Visible = false;
            cancelButton.Text = @"Done";
            reasonTextBox.Enabled = false;
            appointmentDateTimePicker.Enabled = false;
            doctorIDComboBox.Enabled = false;
            patientIDTextBox.Enabled = false;
        }

        private void loadInAppointmentInfo()
        {
            appointmentDateTimePicker.Value = appointment.AppointmentDate;
            doctorIDComboBox.Text = appointment.DoctorId;
            patientIDTextBox.Text = appointment.PatientId;
            reasonTextBox.Text = appointment.Reason;
        }

        private Appointment createNewAppointment()
        {
            var reason = reasonTextBox.Text;
            var doctorIdLocator = doctorIDComboBox.SelectedIndex;
            var doctorId = doctors[doctorIdLocator].DoctorId;
            var patientId = patient.PatientId.ToString();
            var appointmentDate = appointmentDateTimePicker.Value.Date;
            var time = timeComboBox.Text;

            var dateAndTimeString = appointmentDate.ToShortDateString() + " " + time;
            var dateAndTime = DateTime.Parse(dateAndTimeString);

            var appointment = new Appointment(reason, patientId, doctorId, dateAndTime);

            return appointment;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            appointmentDataGrid.ClearSelection();
            var emptyField = checkIfFieldsAreNull();
            if (emptyField)
            {
                turnLabelsRed();
                return;
            }

            var newAppointment = createNewAppointment();
            var appointmentViewModel = new AppointmentViewModel();

            var successfulRegistration = false;
            try
            {
                successfulRegistration = appointmentViewModel.RegisterAppointment(newAppointment);
                this.appointmentViewModel.RetrieveDoctorsAppointments(doctors);
            }
            catch (MySqlException)
            {
                showFailedRegistrationMessage();
            }

            var doctorName = doctors[doctorIDComboBox.SelectedIndex].Employee.Fname + " " +
                             doctors[doctorIDComboBox.SelectedIndex].Employee.Lname;
            var registered = patient.Fname + " " + patient.Lname + " is registered to see doctor " +
                             doctorName + "on : " + newAppointment.AppointmentDate;
            if (successfulRegistration)
            {
                showSuccessfulRegisterMessage(registered);
                fillAppointmentInfo();
                turnLabelsBack();
                emptyForm();
            }
        }

        private void emptyForm()
        {
            timeComboBox.SelectedItem = null;
            reasonTextBox.Text = string.Empty;
            doctorIDComboBox.SelectedItem = null;
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

            appointmentLabel.Text = star + @"Appointment Date:";
            appointmentLabel.ForeColor = Color.Red;

            timeLabel.Text = star + @"Time: ";
            timeLabel.ForeColor = Color.Red;

            doctorLabel.Text = star + @" Doctor";
            doctorLabel.ForeColor = Color.Red;

            patientLabel.Text = star + @"Patient";
            patientLabel.ForeColor = Color.Red;

            reasonLabel.Text = star + @"Reason(s)";
            reasonLabel.ForeColor = Color.Red;

            warningLabel.Visible = true;
        }

        private void turnLabelsBack()
        {
            appointmentLabel.Text = @"Appointment Date:";
            appointmentLabel.ForeColor = Color.Black;

            timeLabel.Text = @"Time: ";
            timeLabel.ForeColor = Color.Black;

            doctorLabel.Text = @" Doctor";
            doctorLabel.ForeColor = Color.Black;

            patientLabel.Text = @"Patient";
            patientLabel.ForeColor = Color.Black;

            reasonLabel.Text = @"Reason(s)";
            reasonLabel.ForeColor = Color.Black;

            warningLabel.Visible = false;
        }

        private bool checkIfFieldsAreNull()
        {
            var checker = doctorIDComboBox.Text == string.Empty ||
                          appointmentDateTimePicker.Text == string.Empty ||
                          reasonTextBox.Text == string.Empty || timeComboBox.Text == string.Empty;

            return checker;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            var emptyField = checkIfFieldsAreNull();
            if (emptyField)
            {
                turnLabelsRed();
                return;
            }

            var appointmentSelected = appointmentDataGrid.CurrentCell.RowIndex;
            if (appointmentSelected < 0)
            {
                MessageBox.Show(@"please select an appointment.");
                return;
            }

            var appointmentToRemove = appointments[appointmentDataGrid.CurrentCell.RowIndex];
            var appointmentToAdd = createNewAppointment();

            var successfulUpdate = appointmentViewModel.UpdateAppointment(appointmentToAdd, appointmentToRemove);
            if (successfulUpdate)
            {
                MessageBox.Show(@"Appointment Updated");
                refreshAppointmentGrid();
                appointmentDataGrid.ClearSelection();
                appointmentViewModel.RetrieveDoctorsAppointments(doctors);
            }
        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            appointmentDataGrid.ClearSelection();
        }

        private void fillAppointmentInfo()
        {
            appointments = getPatientAppointments();
            fillAppointmentGrid();
        }

        private void appointmentDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var newAppointmentCell = appointmentDataGrid.RowCount - 1;
            var cell = appointmentDataGrid.CurrentCell.RowIndex;
            if (cell >= newAppointmentCell)
            {
                deleteButton.Visible = false;
                addNewAppointmentButton.Visible = true;
                updateButton.Visible = false;

                reasonTextBox.Text = string.Empty;
                doctorIDComboBox.Text = string.Empty;

                timeComboBox.Enabled = true;
                appointmentDateTimePicker.Enabled = true;

                reasonTextBox.Enabled = true;
                doctorIDComboBox.Enabled = true;
                appointmentDateTimePicker.Enabled = true;
                timeComboBox.Enabled = true;
                appointmentTimePassedLabel.Visible = false;
            }
            else
            {
                addNewAppointmentButton.Visible = false;
                reasonTextBox.Text = appointments[cell].Reason;

                var doctorId = appointments[cell].DoctorId;
                var doctorName = findDoctor(doctorId);

                doctorIDComboBox.Text = doctorName;
                appointmentDateTimePicker.Text = appointments[cell].AppointmentDate.ToShortDateString();
                timeComboBox.Text = appointments[cell].AppointmentDate.ToShortTimeString();
                checkIfAppointmentHasPassed(appointments[cell].AppointmentDate);
            }
        }

        private void checkIfCanBeDeleted(DateTime date)
        {
            try
            {
                var visits = new VisitViewModel(this.patient);
                if (!visits.VisitsExist(this.patient.PatientId, date))
                {
                    this.deleteButton.Visible = true;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void checkIfAppointmentHasPassed(DateTime time)
        {
            if (DateTime.Now > time)
            {
                appointmentTimePassedLabel.Visible = true;
                updateButton.Visible = false;
                reasonTextBox.Enabled = false;
                doctorIDComboBox.Enabled = false;
                this.timeComboBox.Enabled = false;
                this.appointmentDateTimePicker.Enabled = false;
                this.deleteButton.Visible = false;
            }
            else
            {
                appointmentTimePassedLabel.Visible = false;
                updateButton.Visible = true;
                reasonTextBox.Enabled = true;
                doctorIDComboBox.Enabled = true;
                timeComboBox.Enabled = true;
                appointmentDateTimePicker.Enabled = true;
                this.checkIfCanBeDeleted(time);
            }
        }

        private string findDoctor(string doctorID)
        {
            var doctorName = string.Empty;

            foreach (var doctor in doctors)
                if (doctor.IsDoctor(doctorID))
                {
                    doctorName = doctor.Employee.Fname + " " + doctor.Employee.Lname;
                    break;
                }

            return doctorName;
        }

        private void doctorIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (doctorIDComboBox.SelectedIndex >= 0) updateTimeComboBox();
        }

        private void updateTimeComboBox()
        {
            timeComboBox.Items.Clear();
            timeComboBox.Text = string.Empty;
            var selectedDate = appointmentDateTimePicker.Value.Date;

            var timeSlots = new Times(doctors[doctorIDComboBox.SelectedIndex], selectedDate);

            foreach (var time in timeSlots.times) timeComboBox.Items.Add(time);

            if (timeComboBox.Items.Count > 0)
                timeComboBox.Enabled = true;
            else
                timeComboBox.Enabled = false;
        }

        private void appointmentDateTimePicker_Leave(object sender, EventArgs e)
        {
            if (doctorIDComboBox.SelectedIndex >= 0) updateTimeComboBox();
        }

        #endregion
    }
}