using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Inserts the address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <exception cref="ArgumentException">
        /// </exception>
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

                        cmd.ExecuteNonQuery();
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

        public void DeleteAddressIfNoReferencesLeft(Address address)
        {
            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    var deleteQuery = "DELETE FROM address WHERE addressID NOT IN (SELECT addressID FROM patient) and addressID NOT IN(SELECT addressID FROM employee)"; 
                    using (var cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                        
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
        /// Updates the patient address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public bool UpdatePatientAddress(Address address)
        {
            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    var insertQuery =
                        "UPDATE`address` SET `addr1`= @addr1, `addr2` = @addr2, `city`= @city, `state`= @state,  `zip`= @zip,  `contactNum` = @contactNum WHERE `addressID` = @addressId;";
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

                        cmd.Parameters.Add("@addressId", MySqlDbType.Int32);
                        cmd.Parameters["@addressId"].Value = address.addressId;

                        cmd.ExecuteNonQuery();

                        return true;
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
        /// Retrieves the address.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public Address RetrieveAddress(Patient patient)
        {
            var addressId = patient.AddressID;
            var address = new Address();

            try
            {
                var conn = DbConnection.GetConnection();
                using (conn)
                {
                    conn.Open();
                    var selectQuery = "select * from address where addressID = @addressId";
                    using (var cmd = new MySqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.Add("@addressId", MySqlDbType.VarChar);
                        cmd.Parameters["@addressId"].Value = addressId;

                        using (var reader = cmd.ExecuteReader())
                        {
                            var addressIdOrdinal = reader.GetOrdinal("addressId");
                            var addr1Ordinal = reader.GetOrdinal("addr1");
                            var addr2Ordinal = reader.GetOrdinal("addr2");
                            var cityOrdinal = reader.GetOrdinal("city");
                            var stateOrdinal = reader.GetOrdinal("state");
                            var zipOrdinal = reader.GetOrdinal("zip");
                            var contactNumOrdinal = reader.GetOrdinal("contactNum");

                            while (reader.Read())
                            {

                                address.addressId = reader[addressIdOrdinal] == DBNull.Value ? 0 : reader.GetInt32(addressIdOrdinal);
                                address.Address1 = reader[addr1Ordinal] == DBNull.Value ? "null" : reader.GetString(addr1Ordinal);
                                address.Address2 = reader[addr2Ordinal] == DBNull.Value ? "null" : reader.GetString(addr2Ordinal);
                                address.City = reader[cityOrdinal] == DBNull.Value ? "null" : reader.GetString(cityOrdinal);
                                address.State = reader[stateOrdinal] == DBNull.Value ? "null" : reader.GetString(stateOrdinal);
                                address.Zip = reader[zipOrdinal] == DBNull.Value ? 0 : reader.GetInt32(zipOrdinal);
                                address.ContactNum = reader[contactNumOrdinal] == DBNull.Value ? "null" : reader.GetString(contactNumOrdinal);

                            }
                        }

                        return address;

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

        #endregion
    }
}