using System;
using System.Drawing;
using System.Windows.Forms;
using CS3230Project.Model;
using CS3230Project.ViewModel;

namespace CS3230Project
{
    public partial class RegistrationForm : Form
    {
        #region Data members

        private readonly RegistrationViewModel registrationViewmodel;

        #endregion

        #region Constructors

        public RegistrationForm()
        {
            this.InitializeComponent();
            this.registrationViewmodel = new RegistrationViewModel();
        }

        #endregion

        #region Methods

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (!this.allFieldsAreValid())
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

            var successfulRegistration =
                this.registrationViewmodel.RegisterPatient(ssn, firstName, lastName, sex, address);

            if (successfulRegistration)
            {
                showSuccessfulRegistrationMessage();
            }
            else
            {
                showFailedRegistrationMessage();
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

        private bool allFieldsAreValid()
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
            var validNumericFields = zipCode.Length >= 5;
            validNumericFields = validNumericFields && ssn.Length > 8;
            validNumericFields = validNumericFields && contactNumber.Length > 9;

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

        private static void showSuccessfulRegistrationMessage()
        {
            const string issueTitle = "Successful Registration";
            var connectionIssue = "The patient was successfully added.";
            const MessageBoxIcon issueType = MessageBoxIcon.Information;
            MessageBox.Show(connectionIssue, issueTitle, MessageBoxButtons.OK, issueType);
        }

        private static void showFailedRegistrationMessage()
        {
            const string issueTitle = "Failed Registration";
            var connectionIssue = "The patient was not added.";
            const MessageBoxIcon issueType = MessageBoxIcon.Error;
            MessageBox.Show(connectionIssue, issueTitle, MessageBoxButtons.OK, issueType);
        }

        private void updateLabels()
        {
            this.sexLabel.Text = "*Gender";
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
            if (firstName == string.Empty)
            {
                this.fNameWarnLabel.Visible = true;
            }
            else
            {
                this.fNameWarnLabel.Visible = false;
            }
        }

        private void lastNameTextBox_Leave(object sender, EventArgs e)
        {
            var lastName = this.lastNameTextBox.Text;
            if (lastName == string.Empty)
            {
                this.lNameWarnLabel.Visible = true;
            }
            else
            {
                this.lNameWarnLabel.Visible = false;
            }
        }

        private void sexComboBox_Leave(object sender, EventArgs e)
        {
            var sex = this.sexComboBox.Text;
            if (sex == string.Empty)
            {
                this.sexWarnLabel.Visible = true;
            }
            else
            {
                this.sexWarnLabel.Visible = false;
            }
        }

        private void stateComboBox_Leave(object sender, EventArgs e)
        {
            var state = this.sexComboBox.Text;
            if (state == string.Empty)
            {
                this.stateWarnLabel.Visible = true;
            }
            else
            {
                this.stateWarnLabel.Visible = false;
            }
        }

        private void contactNumberTextBox_Leave(object sender, EventArgs e)
        {
            var contactNum = this.contactNumberTextBox.Text;
            if (contactNum == string.Empty)
            {
                this.contactNumWarnLabel.Visible = true;
            }
            else
            {
                this.contactNumWarnLabel.Visible = false;
            }
        }

        private void ssnTextBox_Leave(object sender, EventArgs e)
        {
            var ssn = this.ssnTextBox.Text;
            if (ssn == string.Empty)
            {
                this.ssnWarnLabel.Visible = true;
            }
            else
            {
                this.ssnWarnLabel.Visible = false;
            }
        }

        private void addr1TextBox_Leave(object sender, EventArgs e)
        {
            var address1 = this.Addr1TextBox.Text;
            if (address1 == string.Empty)
            {
                this.addr1WarnLabel.Visible = true;
            }
            else
            {
                this.addr1WarnLabel.Visible = false;
            }
        }

        private void cityTextBox_Leave(object sender, EventArgs e)
        {
            var city = this.cityTextBox.Text;
            if (city == string.Empty)
            {
                this.cityWarnLabel.Visible = true;
            }
            else
            {
                this.cityWarnLabel.Visible = false;
            }
        }

        #endregion
    }
}