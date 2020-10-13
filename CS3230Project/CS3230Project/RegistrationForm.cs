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

        #endregion

        #region Constructors

        public RegistrationForm()
        {
            InitializeComponent();
            _registrationViewmodel = new RegistrationViewModel();
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

            var address = RegisterAddress();

            var firstName = firstNameTextBox.Text;
            var lastName = lastNameTextBox.Text;
            var ssn = ssnTextBox.Text;
            var sex = sexComboBox.Text;

            var successfulRegistration = false;
            try
            {
                successfulRegistration =
                    _registrationViewmodel.RegisterPatient(ssn, firstName, lastName, sex, address);
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
        }

        private Address RegisterAddress()
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

        private static void ShowSuccessfulRegistrationMessage()
        {
            const string issueTitle = "Successful Registration";
            const string connectionIssue = "The patient was successfully added.";
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
    }
}