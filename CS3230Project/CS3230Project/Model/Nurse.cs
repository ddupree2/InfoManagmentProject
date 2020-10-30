namespace CS3230Project.Model
{
    /// <summary>
    ///     Represents a nurse
    /// </summary>
    public class Nurse : Employee
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the nurse identifier.
        /// </summary>
        /// <value>
        ///     The nurse identifier.
        /// </value>
        public string NurseId { get; set; }

        #endregion
    }
}