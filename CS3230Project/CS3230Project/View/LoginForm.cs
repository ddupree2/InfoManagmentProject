using System;
using System.Windows.Forms;
using CS3230Project.ViewModel;

namespace CS3230Project
{
    public partial class LoginForm : Form
    {
        #region Data members

        private readonly LoginViewModel loginViewmodel;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="LoginForm" /> class.
        /// </summary>
        public LoginForm()
        {
            this.InitializeComponent();
            this.loginViewmodel = new LoginViewModel();
        }

        #endregion

        #region Methods

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var employeeId = this.employeeIDTextBox.Text;
            var password = this.passwordTextBox.Text;

            var isValidLogin = this.loginViewmodel.ValidateEmployeeLogin(employeeId, password);

            this.invalidCredentialsLabel.Visible = false;

            if (isValidLogin)
            {
                var dashBoardForm = new DashBoardForm(employeeId);
                Hide();
                dashBoardForm.ShowDialog();
                this.Show();
                this.resetLoginForm();
            }
            else if (this.loginViewmodel.ConnectionIssue)
            {
                this.showConnIssueMessage();
            }
            else
            {
                this.invalidCredentialsLabel.Visible = true;
            }
        }

        private void resetLoginForm()
        {
            this.invalidCredentialsLabel.Visible = false;
            this.employeeIDTextBox.Text = string.Empty;
            this.passwordTextBox.Text = string.Empty;
        }

        private void showConnIssueMessage()
        {
            const string issueTitle = "Bad Connection";
            var connectionIssue =
                $"Unable to connect to database.{Environment.NewLine}Make sure you currently have access to the network the database is on.";
            const MessageBoxIcon issueType = MessageBoxIcon.Error;
            MessageBox.Show(connectionIssue, issueTitle, MessageBoxButtons.OK, issueType);
            this.loginViewmodel.ConnectionIssue = false;
        }

        #endregion
    }
}