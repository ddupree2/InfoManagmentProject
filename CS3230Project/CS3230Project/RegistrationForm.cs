using System;
using System.Drawing;
using System.Windows.Forms;
using CS3230Project.Model;
using CS3230Project.ViewModel;
using MySql.Data.MySqlClient;

namespace CS3230Project
{
    public partial class RegistrationForm : Form
    {
        #region Data members

        private readonly RegistrationViewModel _registrationViewmodel;

        private readonly Patient patient = new Patient();

        private readonly Address address = new Address();

        #endregion

        #region Constructors

        public RegistrationForm()
        {
            InitializeComponent();
            _registrationViewmodel = new RegistrationViewModel();
        }

        public RegistrationForm(Patient patient, Address address)
        {
            this.InitializeComponent();
            this.showUpdateButtons();
            this.patient = patient;
            this.address = address;
            this.filledForm();
            this._registrationViewmodel = new RegistrationViewModel();
        }

        private void showUpdateButtons()
        {
            this.RegisterButton.Visible = false;
            this.RegisterButton.Enabled = false;
            this.updateButton.Visible = true;
            this.updateButton.Enabled = true;
            this.deleteButton.Visible = true;
            this.deleteButton.Enabled = true;
        }

        #endregion

        #region Methods

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (!AreAllFieldsValid())
            {
                ShowFailedValidationMessage();
                UpdateLabels();
                return;
            }

            var address = registerAddress();

            var firstName = firstNameTextBox.Text;
            var lastName = lastNameTextBox.Text;
            var ssn = ssnTextBox.Text;
            var sex = sexComboBox.Text;
            var dob = DateTime.Parse(this.datePicker.Value.ToShortDateString());

            var successfulRegistration = false;
            try
            {
                successfulRegistration =
                    _registrationViewmodel.RegisterPatient(ssn, firstName, lastName, sex, address, dob);
            }
            catch (MySqlException)
            {
                ShowFailedRegistrationMessage();
            }

            if (successfulRegistration) ShowSuccessfulRegistrationMessage();

            EmptyForm();
        }

        private void EmptyForm()
        {
            firstNameTextBox.Text = string.Empty;
            lastNameTextBox.Text = string.Empty;
            ssnTextBox.Text = string.Empty;
            stateComboBox.Text = string.Empty;
            sexComboBox.Text = string.Empty;
            cityTextBox.Text = string.Empty;
            Addr1TextBox.Text = string.Empty;
            Addr2TextBox.Text = string.Empty;
            contactNumberTextBox.Text = string.Empty;
            zipCodeTextBox.Text = string.Empty;
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
            var address1 = Addr1TextBox.Text;
            var address2 = Addr2TextBox.Text;
            var city = cityTextBox.Text;
            var state = stateComboBox.Text;
            var zip = int.Parse(zipCodeTextBox.Text);
            var contactNumber = contactNumberTextBox.Text;

            if (address2.Equals(string.Empty)) address2 = null;

            return _registrationViewmodel.RegisterAddress(address1, city, state, zip, contactNumber, address2);
        }

        private bool AreAllFieldsValid()
        {
            var sex = sexComboBox.Text;
            var firstName = firstNameTextBox.Text;
            var lastName = lastNameTextBox.Text;
            var address1 = Addr1TextBox.Text;
            var city = cityTextBox.Text;
            var zipCode = zipCodeTextBox.Text;
            var state = stateComboBox.Text;
            var ssn = ssnTextBox.Text;
            var contactNumber = contactNumberTextBox.Text;

            var checker = NoEmptyFields(sex, firstName, lastName, address1, city, state, ssn, zipCode, contactNumber);
            checker = checker && ValidNumericFields(zipCode, ssn, contactNumber);

            return checker;
        }

        private static bool ValidNumericFields(string zipCode, string ssn, string contactNumber)
        {
            var validNumericFields = zipCode.Length >= 5;
            validNumericFields = validNumericFields && ssn.Length > 8;
            validNumericFields = validNumericFields && contactNumber.Length > 9;

            return validNumericFields;
        }

        private static bool NoEmptyFields(string sex, string firstName, string lastName, string address1, string city,
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

        private static void ShowFailedValidationMessage()
        {
            const string issueTitle = "Validation Failed";
            var connectionIssue = "One or more fields are incorrect.";
            connectionIssue += Environment.NewLine + "Make sure all required fields are filled with valid formatting.";
            const MessageBoxIcon issueType = MessageBoxIcon.Error;
            MessageBox.Show(connectionIssue, issueTitle, MessageBoxButtons.OK, issueType);
        }

        private static void ShowSuccessfulRegistrationMessage(string updateOrAdd = "added")
        {
            const string issueTitle = "Successful Registration";
            var connectionIssue = "The patient was successfully " + updateOrAdd + ".";
            const MessageBoxIcon issueType = MessageBoxIcon.Information;
            MessageBox.Show(connectionIssue, issueTitle, MessageBoxButtons.OK, issueType);
        }

        private static void ShowFailedRegistrationMessage()
        {
            const string issueTitle = "Failed Registration";
            var connectionIssue = "The patient was not added." + Environment.NewLine;
            connectionIssue += "Please make sure all fields are valid data.";
            const MessageBoxIcon issueType = MessageBoxIcon.Error;
            MessageBox.Show(connectionIssue, issueTitle, MessageBoxButtons.OK, issueType);
        }

        private void UpdateLabels()
        {
            firstNameLabel.ForeColor = Color.Red;
            lastNameLabel.ForeColor = Color.Red;
            ssnLabel.ForeColor = Color.Red;
            addr1Label.ForeColor = Color.Red;
            cityLabel.ForeColor = Color.Red;
            contactNumberLabel.ForeColor = Color.Red;
            stateLabel.ForeColor = Color.Red;
            zipCodeLabel.ForeColor = Color.Red;
            sexLabel.ForeColor = Color.Red;
            requiredFieldLbl.Visible = true;
        }

        private void ssnTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char) Keys.Back)) e.Handled = true;
        }

        private void zipCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char) Keys.Back)) e.Handled = true;
        }

        private void contactNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char) Keys.Back)) e.Handled = true;
        }

        private void firstNameTextBox_Enter(object sender, EventArgs e)
        {
            var firstName = firstNameTextBox.Text;
            fNameWarnLabel.Visible = firstName == string.Empty;
        }

        private void lastNameTextBox_Leave(object sender, EventArgs e)
        {
            var lastName = lastNameTextBox.Text;
            lNameWarnLabel.Visible = lastName == string.Empty;
        }

        private void sexComboBox_Leave(object sender, EventArgs e)
        {
            var sex = sexComboBox.Text;
            sexWarnLabel.Visible = sex == string.Empty;
        }

        private void stateComboBox_Leave(object sender, EventArgs e)
        {
            var state = sexComboBox.Text;
            stateWarnLabel.Visible = state == string.Empty;
        }

        private void contactNumberTextBox_Leave(object sender, EventArgs e)
        {
            var contactNum = contactNumberTextBox.Text;
            contactNumWarnLabel.Visible = contactNum == string.Empty;
        }

        private void ssnTextBox_Leave(object sender, EventArgs e)
        {
            var ssn = ssnTextBox.Text;
            ssnWarnLabel.Visible = ssn == string.Empty;
        }

        private void addr1TextBox_Leave(object sender, EventArgs e)
        {
            var address1 = Addr1TextBox.Text;
            addr1WarnLabel.Visible = address1 == string.Empty;
        }

        private void cityTextBox_Leave(object sender, EventArgs e)
        {
            var city = cityTextBox.Text;
            cityWarnLabel.Visible = city == string.Empty;
        }

        #endregion

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (!AreAllFieldsValid())
            {
                ShowFailedValidationMessage();
                UpdateLabels();
                return;
            }

            this.updatePatientAddressInfo();
            this.updatePatientInfo();


            var successfulRegistration = false;
            try
            {
                successfulRegistration =
                    this._registrationViewmodel.UpdatePatient(this.patient, this.address);

            }
            catch (MySqlException)
            {
                ShowFailedRegistrationMessage();
            }

            const string update = "updated";
            if (successfulRegistration) ShowSuccessfulRegistrationMessage(update);

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

            var result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                message = this.patient.Fname + " " + this.patient.Lname + " was deleted";
                caption = "Deleted";
                buttons = MessageBoxButtons.OK;
                
                MessageBox.Show(message, caption, buttons);
                this._registrationViewmodel.DeletePatient(this.patient, this.address);
                this.Close();
            }

        }
    }
}