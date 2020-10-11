using System;
using System.Windows.Forms;
using CS3230Project.ViewModel;

namespace CS3230Project
{
    public partial class LoginForm : Form
    {
        private LoginViewmodel loginViewmodel;
        public LoginForm()
        {
            this.InitializeComponent();
            this.loginViewmodel = new LoginViewmodel();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var employeeID = this.employeeIDTextBox.Text;
            var password = this.passwordTextBox.Text;

           var isValidLogin = this.loginViewmodel.ValidateEmployeeLogin(employeeID, password);

           if (!isValidLogin)
           {
               return;
           }

           var registrationForm = new RegistrationForm();
           this.Hide();
           registrationForm.Show();
        }
    }
}
