using System;
using System.Windows.Forms;
using CS3230Project.ViewModel;

namespace CS3230Project
{
    public partial class LoginForm : Form
    {
        #region Data members

        private readonly LoginViewmodel loginViewmodel;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="LoginForm" /> class.
        /// </summary>
        public LoginForm()
        {
            this.InitializeComponent();
            this.loginViewmodel = new LoginViewmodel();
        }

        #endregion

        #region Methods

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var employeeId = this.employeeIDTextBox.Text;
            var password = this.passwordTextBox.Text;

            var isValidLogin = this.loginViewmodel.ValidateEmployeeLogin(employeeId, password);

            if (!isValidLogin)
            {
                return;
            }

            var registrationForm = new RegistrationForm();
            Hide();
            registrationForm.Closed += (obj, args) => this.Close();
            registrationForm.Show();
        }

        #endregion
    }
}