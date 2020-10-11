using CS3230Project.DAL;

namespace CS3230Project.ViewModel
{
    public class LoginViewmodel
    {
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
            var isValidLogin = loginDal.Authenticate(employeeId, password);

            return isValidLogin;
        }

        #endregion
    }
}