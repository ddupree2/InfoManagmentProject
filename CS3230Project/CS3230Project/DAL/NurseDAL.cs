using System;
using System.Collections.Generic;
using CS3230Project.Model;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    /// <summary>
    ///     Represents the nurse Data Access Layer
    /// </summary>
    public class NurseDal
    {
        #region Methods

        /// <summary>
        ///     Retrieves the nurses.
        /// </summary>
        /// <returns> an IList of nurses</returns>
        public IList<Nurse> RetrieveNurses()
        {
            IList<Nurse> nurses = new List<Nurse>();

            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();

                const string selectQuery =
                    "SELECT e.eID, e.fname, e.lname, e.addressID, e.dob, n.nurseID FROM employee e, nurse n WHERE e.eID = n.eID";

                using (var cmd = new MySqlCommand(selectQuery, conn))
                {
                    readInNurses(cmd, nurses);
                }

                return nurses;
            }
        }

        private static void readInNurses(MySqlCommand cmd, ICollection<Nurse> nurses)
        {
            using (var reader = cmd.ExecuteReader())
            {
                var eIdOrdinal = reader.GetOrdinal("eID");
                var fnameOrdinal = reader.GetOrdinal("fname");
                var lnameOrdinal = reader.GetOrdinal("lname");
                var addressIdOrdinal = reader.GetOrdinal("addressID");
                var dobOrdinal = reader.GetOrdinal("dob");
                var nurseIdOrdinal = reader.GetOrdinal("nurseID");

                while (reader.Read())
                {
                    var nurse = new Nurse {
                        NurseId = reader[nurseIdOrdinal] == DBNull.Value
                            ? "null"
                            : reader.GetString(nurseIdOrdinal),
                        EId = reader[eIdOrdinal] == DBNull.Value
                            ? "null"
                            : reader.GetString(eIdOrdinal),
                        Fname = reader[fnameOrdinal] == DBNull.Value
                            ? "null"
                            : reader.GetString(fnameOrdinal),
                        Lname = reader[lnameOrdinal] == DBNull.Value
                            ? "null"
                            : reader.GetString(lnameOrdinal),
                        AddressId = reader[addressIdOrdinal] == DBNull.Value
                            ? default
                            : reader.GetInt32(addressIdOrdinal),
                        Dob = reader[dobOrdinal] == DBNull.Value
                            ? default
                            : reader.GetDateTime(dobOrdinal)
                    };

                    nurses.Add(nurse);
                }
            }
        }

        #endregion
    }
}