using System;
using System.Drawing;
using System.Windows.Forms;
using CS3230Project.Model;
using CS3230Project.ViewModel;
using MySql.Data.MySqlClient;

namespace CS3230Project.View
{
    /// <summary>
    ///     Visual representation of a patient registration form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class RegistrationForm : Form
    {
        #region Data members

        private const int ValidZipCodeLength = 5;
        private const int ValidSsnLength = 9;
        private const int ValidContactNumberLength = 10;

        private readonly RegistrationViewModel registrationViewmodel;

        private readonly Patient patient = new Patient();

        private readonly Address address = new Address();

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RegistrationForm" /> class.
        /// </summary>
        public RegistrationForm()
        {
            this.InitializeComponent();
            this.registrationViewmodel = new RegistrationViewModel();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RegistrationForm" /> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="address">The address.</param>
        public RegistrationForm(Patient patient, Address address)
        {
            this.InitializeComponent();
            this.showUpdateButtons();
            this.patient = patient;
            this.address = address;
            this.filledForm();
            this.registrationViewmodel = new RegistrationViewModel();
        }

        #endregion

        #region Methods

        private void showUpdateButtons()
        {
            this.RegisterButton.Visible = false;
            this.RegisterButton.Enabled = false;
            this.updateButton.Visible = true;
            this.updateButton.Enabled = true;
            this.deleteButton.Visible = true;
            this.deleteButton.Enabled = true;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (!this.areAllFieldsValid())
            {
                showFailedValidationMessage();
                this.updateLabels();
                return;
            }

            var address = this.registerAddress();

            var firstName = this.firstNameTextBox.Text;
            var lastName = this.lastNameTextBox.Text;
            var ssn = this.ssnTextBox.Text;
            var sex = this.sexComboBox.Text;
            var dob = DateTime.Parse(this.datePicker.Value.ToShortDateString());

            var successfulRegistration = false;
            try
            {
                successfulRegistration =
                    this.registrationViewmodel.RegisterPatient(ssn, firstName, lastName, sex, address, dob);
            }
            catch (MySqlException)
            {
                showFailedRegistrationMessage();
            }

            if (successfulRegistration)
            {
                showSuccessfulRegistrationMessage();
            }

            this.emptyForm();
        }

        private void emptyForm()
        {
            this.firstNameTextBox.Text = string.Empty;
            this.lastNameTextBox.Text = string.Empty;
            this.ssnTextBox.Text = string.Empty;
            this.stateComboBox.Text = string.Empty;
            this.sexComboBox.Text = string.Empty;
            this.cityTextBox.Text = string.Empty;
            this.Addr1TextBox.Text = string.Empty;
            this.Addr2TextBox.Text = string.Empty;
            this.contactNumberTextBox.Text = string.Empty;
            this.zipCodeTextBox.Text = string.Empty;
            this.datePicker.Value = DateTime.Now;
        }

        private void filledForm()
        {
            this.firstNameTextBox.Text = this.patient.Fname;
            this.lastNameTextBox.Text = this.patient.Lname;
            this.ssnTextBox.Text = this.patient.Ssn;
            this.stateComboBox.Text = this.address.State;
            this.sexComboBox.Text = this.patient.Sex;
            this.cityTextBox.Text = this.address.City;
            this.Addr1TextBox.Text = this.address.Address1;
            this.datePicker.Value = this.patient.DateOfBirth;

            if (this.address.Address2.Equals("null"))
            {
                this.Addr2TextBox.Text = string.Empty;
            }
            else
            {
                this.Addr2TextBox.Text = this.address.Address2;
            }

            this.contactNumberTextBox.Text = this.address.ContactNum;
            this.zipCodeTextBox.Text = this.address.Zip.ToString();
        }

        private Address registerAddress()
        {
            var address1 = this.Addr1TextBox.Text;
            var address2 = this.Addr2TextBox.Text;
            var city = this.cityTextBox.Text;
            var state = this.stateComboBox.Text;
            var zip = int.Parse(this.zipCodeTextBox.Text);
            var contactNumber = this.contactNumberTextBox.Text;

            if (address2.Equals(string.Empty))
            {
                address2 = null;
            }

            return this.registrationViewmodel.RegisterAddress(address1, city, state, zip, contactNumber, address2);
        }

        private bool areAllFieldsValid()
        {
            var sex = this.sexComboBox.Text;
            var firstName = this.firstNameTextBox.Text;
            var lastName = this.lastNameTextBox.Text;
            var address1 = this.Addr1TextBox.Text;
            var city = this.cityTextBox.Text;
            var zipCode = this.zipCodeTextBox.Text;
            var state = this.stateComboBox.Text;
            var ssn = this.ssnTextBox.Text;
            var contactNumber = this.contactNumberTextBox.Text;

            var checker = noEmptyFields(sex, firstName, lastName, address1, city, state, ssn, zipCode, contactNumber);
            checker = checker && validNumericFields(zipCode, ssn, contactNumber);

            return checker;
        }

        private static bool validNumericFields(string zipCode, string ssn, string contactNumber)
        {
            var validNumericFields = zipCode.Length == ValidZipCodeLength;
            validNumericFields = validNumericFields && ssn.Length == ValidSsnLength;
            validNumericFields = validNumericFields && contactNumber.Length == ValidContactNumberLength;

            return validNumericFields;
        }

        private static bool noEmptyFields(string sex, string firstName, string lastName, string address1, string city,
            string state, string ssn, string zipCode, string contactNumber)
        {
            var noEmptyFields = sex != string.Empty;
            noEmptyFields = noEmptyFields && firstName != string.Empty;
            noEmptyFields = noEmptyFields && lastName != string.Empty;
            noEmptyFields = noEmptyFields && address1 != string.Empty;
            noEmptyFields = noEmptyFields && city != string.Empty;
            noEmptyFields = noEmptyFields && state != string.Empty;
            noEmptyFields = noEmptyFields && ssn != string.Empty;
            noEmptyFields = noEmptyFields && zipCode != string.Empty;
            noEmptyFields = noEmptyFields && contactNumber != string.Empty;

            return noEmptyFields;
        }

        private static void showFailedValidationMessage()
        {
            const string issueTitle = "Validation Failed";
            var connectionIssue = "One or more fields are incorrect.";
            connectionIssue += Environment.NewLine + "Make sure all required fields are filled with valid formatting.";
            const MessageBoxIcon issueType = MessageBoxIcon.Error;
            MessageBox.Show(connectionIssue, issueTitle, MessageBoxButtons.OK, issueType);
        }

        private static void showSuccessfulRegistrationMessage(string updateOrAdd = "added")
        {
            const string issueTitle = "Successful Registration";
            var connectionIssue = "The patient was successfully " + updateOrAdd + ".";
            const MessageBoxIcon issueType = MessageBoxIcon.Information;
            MessageBox.Show(connectionIssue, issueTitle, MessageBoxButtons.OK, issueType);
        }

        private static void showFailedRegistrationMessage()
        {
            const string issueTitle = "Failed Registration";
            var connectionIssue = "The patient was not added." + Environment.NewLine;
            connectionIssue += "Please make sure all fields are valid data.";
            const MessageBoxIcon issueType = MessageBoxIcon.Error;
            MessageBox.Show(connectionIssue, issueTitle, MessageBoxButtons.OK, issueType);
        }

        private void updateLabels()
        {
            this.firstNameLabel.ForeColor = Color.Red;
            this.lastNameLabel.ForeColor = Color.Red;
            this.ssnLabel.ForeColor = Color.Red;
            this.addr1Label.ForeColor = Color.Red;
            this.cityLabel.ForeColor = Color.Red;
            this.contactNumberLabel.ForeColor = Color.Red;
            this.stateLabel.ForeColor = Color.Red;
            this.zipCodeLabel.ForeColor = Color.Red;
            this.sexLabel.ForeColor = Color.Red;
            this.requiredFieldLbl.Visible = true;
        }

        private void ssnTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char) Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void zipCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char) Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void contactNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char) Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void firstNameTextBox_Enter(object sender, EventArgs e)
        {
            var firstName = this.firstNameTextBox.Text;
            this.fNameWarnLabel.Visible = firstName == string.Empty;
        }

        private void lastNameTextBox_Leave(object sender, EventArgs e)
        {
            var lastName = this.lastNameTextBox.Text;
            this.lNameWarnLabel.Visible = lastName == string.Empty;
        }

        private void sexComboBox_Leave(object sender, EventArgs e)
        {
            var sex = this.sexComboBox.Text;
            this.sexWarnLabel.Visible = sex == string.Empty;
        }

        private void stateComboBox_Leave(object sender, EventArgs e)
        {
            var state = this.sexComboBox.Text;
            this.stateWarnLabel.Visible = state == string.Empty;
        }

        private void contactNumberTextBox_Leave(object sender, EventArgs e)
        {
            var contactNum = this.contactNumberTextBox.Text;
            this.contactNumWarnLabel.Visible = contactNum == string.Empty;
        }

        private void ssnTextBox_Leave(object sender, EventArgs e)
        {
            var ssn = this.ssnTextBox.Text;
            this.ssnWarnLabel.Visible = ssn == string.Empty;
        }

        private void addr1TextBox_Leave(object sender, EventArgs e)
        {
            var address1 = this.Addr1TextBox.Text;
            this.addr1WarnLabel.Visible = address1 == string.Empty;
        }

        private void cityTextBox_Leave(object sender, EventArgs e)
        {
            var city = this.cityTextBox.Text;
            this.cityWarnLabel.Visible = city == string.Empty;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (!this.areAllFieldsValid())
            {
                showFailedValidationMessage();
                this.updateLabels();
                return;
            }

            this.updatePatientAddressInfo();
            this.updatePatientInfo();

            var successfulRegistration = false;
            try
            {
                successfulRegistration =
                    this.registrationViewmodel.UpdatePatient(this.patient, this.address);
            }
            catch (MySqlException)
            {
                showFailedRegistrationMessage();
            }

            const string update = "updated";
            if (successfulRegistration)
            {
                showSuccessfulRegistrationMessage(update);
            }
        }

        private void updatePatientInfo()
        {
            this.patient.Lname = this.lastNameTextBox.Text;
            this.patient.Fname = this.firstNameTextBox.Text;
            this.patient.Ssn = this.ssnTextBox.Text;
            this.patient.Sex = this.sexComboBox.Text;
            this.patient.DateOfBirth = DateTime.Parse(this.datePicker.Value.ToShortDateString());
        }

        private void updatePatientAddressInfo()
        {
            this.address.Address1 = this.Addr1TextBox.Text;
            if (this.Addr2TextBox.Text.Equals(string.Empty))
            {
                this.address.Address2 = null;
            }
            else
            {
                this.address.Address2 = this.Addr2TextBox.Text;
            }

            this.address.City = this.cityTextBox.Text;
            this.address.State = this.stateComboBox.Text;
            this.address.Zip = int.Parse(this.zipCodeTextBox.Text);
            this.address.ContactNum = this.contactNumberTextBox.Text;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var message = "Are you sure you want to delete this patient?\nThis can't be undone";
            var caption = "WARNING!";
            var buttons = MessageBoxButtons.YesNo;

            var deletionResult = MessageBox.Show(message, caption, buttons);

            if (deletionResult != DialogResult.Yes)
            {
                return;
            }

            message = this.patient.Fname + " " + this.patient.Lname + " was deleted";
            caption = "Deleted";
            buttons = MessageBoxButtons.OK;

            MessageBox.Show(message, caption, buttons);
            this.registrationViewmodel.DeletePatient(this.patient, this.address);
            Close();
        }

        #endregion
    }
}