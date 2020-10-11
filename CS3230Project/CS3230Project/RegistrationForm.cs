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
            if (this.checkForEmptyField())
            {
                this.updateLabels();
                return;
            }

            var address = this.registerAddress();

            var firstName = this.firstNameTextBox.Text;
            var lastName = this.lastNameTextBox.Text;
            var ssn = this.ssnTextBox.Text;
            var sex = this.sexComboBox.Text;

            this.registrationViewmodel.RegisterPatient(ssn, firstName, lastName, sex, address);
        }

        private Address registerAddress()
        {
            var address1 = this.Addr1TextBox.Text;
            var address2 = this.Addr2TextBox.Text;
            var city = this.cityTextBox.Text;
            var state = this.stateTextBox.Text;
            var zip = int.Parse(this.zipCodeTextBox.Text);
            var contactNumber = this.contactNumberTextBox.Text;

            if (address2.Equals(string.Empty))
            {
                address2 = null;
            }

            return this.registrationViewmodel.RegisterAddress(address1, city, state, zip, contactNumber, address2);
        }

        private bool checkForEmptyField()
        {
            var checker = this.sexComboBox.Text == string.Empty;

            return checker;
        }

        private void updateLabels()
        {
            this.sexLbl.Text = "*Gender";
            this.sexLbl.ForeColor = Color.Red;
            this.requiredFieldLbl.Visible = true;
        }

        #endregion
    }
}