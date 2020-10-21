using CS3230Project.DAL;

namespace CS3230Project.ViewModel
{
    /// <summary>
    ///     Represents the viewmodel that binds the Admin Data Access Layer to the Admin query form
    /// </summary>
    public class AdminQueryViewModel
    {
        #region Data members

        private readonly AdminDal adminDal;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdminQueryViewModel" /> class.
        /// </summary>
        public AdminQueryViewModel()
        {
            this.adminDal = new AdminDal();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Retrieves the query results.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public string RetrieveQueryResults(string query)
        {
            return this.adminDal.RetrieveQueryResults(query);
        }

        #endregion
    }
}