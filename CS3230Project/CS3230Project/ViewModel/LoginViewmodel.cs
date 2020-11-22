using System.Diagnostics;
using CS3230Project.DAL;
using MySql.Data.MySqlClient;

namespace CS3230Project.ViewModel
{
    /// <summary>
    ///     creates a new instance of the login view model class
    /// </summary>
    public class LoginViewModel
    {
        #region Properties

        /// <summary>
        ///     Gets or sets a value indicating whether [connection issue].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [connection issue]; otherwise, <c>false</c>.
        /// </value>
        public bool ConnectionIssue { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Validates the employee's login info.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="password">The password.</param>
        /// <returns>true iff the given credentials exist in the database.</returns>
        public bool ValidateEmployeeLogin(string employeeId, string password)
        {
            var loginDal = new LoginDal();
            var isValidLogin = false;
            try
            {
                isValidLogin = loginDal.Authenticate(employeeId, password);
            }
            catch (MySqlException mex)
            {
                Debug.WriteLine(mex.Message);
                this.ConnectionIssue = true;
            }

            return isValidLogin;
        }

        #endregion
    }
}