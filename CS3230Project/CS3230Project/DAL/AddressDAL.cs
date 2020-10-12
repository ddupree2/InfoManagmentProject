﻿using System;
using CS3230Project.Model;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    /// <summary>
    ///     Represents the Data Access Layer for manipulating the address table in the database
    /// </summary>
    public class AddressDal
    {
        #region Methods

        public void InsertAddress(Address address)
        {
            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    var insertQuery =
                        "INSERT INTO `address` (`addr1`, `addr2`, `city`, `state`, `zip`, `contactNum`) VALUES (@addr1, @addr2, @city, @state, @zip, @contactNum);";
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add("@addr1", MySqlDbType.VarChar);
                        cmd.Parameters["@addr1"].Value = address.Address1;

                        cmd.Parameters.Add("@addr2", MySqlDbType.VarChar);
                        cmd.Parameters["@addr2"].Value = address.Address2;

                        cmd.Parameters.Add("@city", MySqlDbType.VarChar);
                        cmd.Parameters["@city"].Value = address.City;

                        cmd.Parameters.Add("@state", MySqlDbType.VarChar);
                        cmd.Parameters["@state"].Value = address.State;

                        cmd.Parameters.Add("@zip", MySqlDbType.Int32);
                        cmd.Parameters["@zip"].Value = address.Zip;

                        cmd.Parameters.Add("@contactNum", MySqlDbType.VarChar);
                        cmd.Parameters["@contactNum"].Value = address.ContactNum;

                        using (cmd.ExecuteReader())
                        {
                        }
                    }
                }
            }
            catch (MySqlException mex)
            {
                throw new ArgumentException(mex.Message);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        ///     Retrieves the address identifier.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public int RetrieveAddressId(Address address)
        {
            var addressId = 0;

            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    var selectQuery = "select addressID from address where addr1 = @addr1 and zip = @zip";
                    using (var cmd = new MySqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.Add("@addr1", MySqlDbType.VarChar);
                        cmd.Parameters["@addr1"].Value = address.Address1;

                        cmd.Parameters.Add("@zip", MySqlDbType.Int32);
                        cmd.Parameters["@zip"].Value = address.Zip;
                        using (var reader = cmd.ExecuteReader())
                        {
                            var addressIdOrdinal = reader.GetOrdinal("addressID");

                            while (reader.Read())
                            {
                                var id = reader[addressIdOrdinal] == DBNull.Value
                                    ? 0
                                    : reader.GetInt32(addressIdOrdinal);
                                addressId = id;
                            }
                        }
                    }
                }
            }
            catch (MySqlException mex)
            {
                throw new ArgumentException(mex.Message);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return addressId;
        }

        #endregion
    }
}