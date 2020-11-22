using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    /// <summary>
    ///     Represents the Admin Data Access Layer to the database
    /// </summary>
    public class AdminDal
    {
        #region Data members

        private const string Results = "Results";
        private const string AppointmentDate = "Appointment Date";
        private const string PatientId = "Patient ID";
        private const string TestCode = "Test Code";
        private const string Diagnosis = "Diagnosis";
        private const string AbnormalStatus = "Abnormal Status";
        private const string PatientName = "Patient Name";
        private const string NurseName = "Nurse Name";
        private const string DoctorName = "Doctor Name";

        private readonly List<int> skippedColumns = new List<int>();

        #endregion

        #region Methods

        /// <summary>
        ///     Retrieves the visits between.
        /// </summary>
        /// <param name="startDateTime">The start date time.</param>
        /// <param name="endDateTime">The end date time.</param>
        /// <returns> a data table with all required visit info between the given date range.</returns>
        public DataTable RetrieveVisitsBetween(DateTime startDateTime, DateTime endDateTime)
        {
            var startDate = startDateTime.ToString("yyyy-MM-dd") + " 00:00:00";
            var endDate = endDateTime.ToString("yyyy-MM-dd") + " 23:59:59";
            const string visitsBetweenQuery = "pullDatesBetween";

            var connection = DbConnection.GetConnection();

            using (connection)
            {
                connection.Open();
                using (var cmd = new MySqlCommand(visitsBetweenQuery, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@startDate", MySqlDbType.DateTime);
                    cmd.Parameters["@startDate"].Value = DateTime.Parse(startDate);
                    cmd.Parameters["@startDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@endDate", MySqlDbType.DateTime);
                    cmd.Parameters["@endDate"].Value = DateTime.Parse(endDate);
                    cmd.Parameters["@endDate"].Direction = ParameterDirection.Input;

                    using (var reader = cmd.ExecuteReader())
                    {
                        return this.readInQueryVisits(reader);
                    }
                }
            }
        }

        private DataTable readInQueryVisits(IDataReader reader)
        {
            var queryVisitsTable = new DataTable();
            this.appendQueryVisitsColumns(queryVisitsTable);
            this.readInVisits(queryVisitsTable, reader);

            return queryVisitsTable;
        }

        private void readInVisits(DataTable queryVisitsTable, IDataReader reader)
        {
            var appointmentDateOrdinal = reader.GetOrdinal("appointmentdate");
            var patientIdOrdinal = reader.GetOrdinal("patientID");
            var patientNameOrdinal = reader.GetOrdinal("patientName");
            var diagnosisOrdinal = reader.GetOrdinal("diagnosis");
            var nurseNameOrdinal = reader.GetOrdinal("nurseName");
            var doctorNameOrdinal = reader.GetOrdinal("doctorName");

            while (reader.Read())
            {
                var appointmentDate = reader[appointmentDateOrdinal] == DBNull.Value
                    ? DateTime.Now
                    : reader.GetDateTime(appointmentDateOrdinal);
                var patientId = reader[patientIdOrdinal] == DBNull.Value
                    ? 0
                    : reader.GetInt32(patientIdOrdinal);
                var patientName = reader[patientNameOrdinal] == DBNull.Value
                    ? default
                    : reader.GetString(patientNameOrdinal);
                var diagnosis = reader[diagnosisOrdinal] == DBNull.Value
                    ? default
                    : reader.GetString(diagnosisOrdinal);
                var nurseName = reader[nurseNameOrdinal] == DBNull.Value
                    ? default
                    : reader.GetString(nurseNameOrdinal);
                var doctorName = reader[doctorNameOrdinal] == DBNull.Value
                    ? default
                    : reader.GetString(doctorNameOrdinal);


                var dataRow = queryVisitsTable.NewRow();
                dataRow[AppointmentDate] = appointmentDate;
                dataRow[PatientId] = patientId;
                dataRow[PatientName] = patientName;
                dataRow[Diagnosis] = diagnosis;
                dataRow[NurseName] = nurseName;
                dataRow[DoctorName] = doctorName;
                queryVisitsTable.Rows.Add(dataRow);
            }
        }

        private void appendQueryVisitsColumns(DataTable queryVisitsTable)
        {
            var appointmentDateColumn = new DataColumn(AppointmentDate);
            var patientIdColumn = new DataColumn(PatientId);
            var patientNameColumn = new DataColumn(PatientName);
            var diagnosisColumn = new DataColumn(Diagnosis);
            var nurseNameColumn = new DataColumn(NurseName);
            var doctorNameColumn = new DataColumn(DoctorName);

            queryVisitsTable.Columns.Add(appointmentDateColumn);
            queryVisitsTable.Columns.Add(patientIdColumn);
            queryVisitsTable.Columns.Add(patientNameColumn);
            queryVisitsTable.Columns.Add(diagnosisColumn);
            queryVisitsTable.Columns.Add(nurseNameColumn);
            queryVisitsTable.Columns.Add(doctorNameColumn);
        }

        /// <summary>
        ///     Retrieves the query results for the give query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public DataTable RetrieveQueryResults(string query)
        {
            var connection = DbConnection.GetConnection();

            using (connection)
            {
                connection.Open();
                return this.fetchQueryResults(query, connection);
            }
        }

        private DataTable fetchQueryResults(string query, MySqlConnection connection)
        {
            using (var cmd = new MySqlCommand(query, connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    return this.readInResults(reader);
                }
            }
        }

        private DataTable readInResults(IDataReader reader)
        {
            var columns = reader.FieldCount;
            var columnsNamesAppended = false;
            var table = new DataTable();

            while (reader.Read())
            {
                this.appendColumnNames(reader, columnsNamesAppended, columns, table);
                columnsNamesAppended = true;

                var fields = new string[columns];
                for (var i = 0; i < columns; i++)
                {
                    if (this.skippedColumns.Contains(i))
                    {
                        continue;
                    }

                    var currValue = reader[i] == DBNull.Value ? default : reader.GetString(i);
                    fields[i] = currValue;
                }

                fields = removeEmptyColumns(fields);

                var colIndex = 0;
                var row = table.NewRow();
                foreach (var field in fields)
                {
                    row[table.Columns[colIndex]] = field;
                    colIndex++;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        private static string[] removeEmptyColumns(IEnumerable<string> fields)
        {
            var fieldsList = new List<string>();
            foreach (var field in fields)
            {
                if (!string.IsNullOrEmpty(field))
                {
                    fieldsList.Add(field);
                }
            }

            return fieldsList.ToArray();
        }

        private void appendColumnNames(IDataRecord record, bool columnsNamesAppended, int columns,
            DataTable dataTable)
        {
            if (columnsNamesAppended)
            {
                return;
            }

            for (var i = 0; i < columns; i++)
            {
                var columnName = record[i] == DBNull.Value ? default : record.GetName(i);
                try
                {
                    var currDataColumn = new DataColumn(columnName);
                    dataTable.Columns.Add(currDataColumn);
                }
                catch
                {
                    this.skippedColumns.Add(i);
                }
            }
        }

        #endregion
    }
}