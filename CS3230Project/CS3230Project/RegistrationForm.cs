using System;
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
            var address = this.registerAddress();

            var firstName = this.firstNameTextBox.Text;
            var lastName = this.lastNameTextBox.Text;
            var ssn = this.ssnTextBox.Text;

            this.registrationViewmodel.RegisterPatient(ssn, firstName, lastName, address);
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

        #endregion
    }
}