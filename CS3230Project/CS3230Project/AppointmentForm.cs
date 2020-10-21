using System;
using System.Windows.Forms;
using CS3230Project.Model;

namespace CS3230Project
{
    public partial class AppointmentForm : Form
    {

        private Appointment appointment;
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
            this.doctorIDTextBox.Enabled = false;
            this.patientIDTextBox.Enabled = false;
        }

        private void loadInAppointmentInfo()
        {
            this.appointmentDateTimePicker.Value = this.appointment.AppointmentDate;
            this.doctorIDTextBox.Text = this.appointment.DoctorId.ToString();
            this.patientIDTextBox.Text = this.appointment.PatientId.ToString();
            this.reasonTextBox.Text = this.appointment.Reason;
        }

        #endregion

        #region Methods

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion
    }
}