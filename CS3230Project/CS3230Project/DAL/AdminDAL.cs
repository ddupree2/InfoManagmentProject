using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    /// <summary>
    ///     Represents the Admin Data Access Layer to the database
    /// </summary>
    public class AdminDal
    {
        #region Methods

        public DataTable RetrieveVisitsBetween(DateTime startDateTime, DateTime endDateTime)
        {
            var startDate = startDateTime.ToString("yyyy-MM-dd") + " 00:00:00";
            var endDate = endDateTime.ToString("yyyy-MM-dd") + " 23:59:59";
            const string visitsBetweenQuery =
                "SELECT * FROM visit WHERE appointmentdate BETWEEN @startDate AND @endDate";
            var connection = DbConnection.GetConnection();

            using (connection)
            {
                connection.Open();
                using (var cmd = new MySqlCommand(visitsBetweenQuery, connection))
                {
                    cmd.Parameters.Add("@startDate", MySqlDbType.DateTime);
                    cmd.Parameters["@startDate"].Value = DateTime.Parse(startDate);

                    cmd.Parameters.Add("@endDate", MySqlDbType.DateTime);
                    cmd.Parameters["@endDate"].Value = DateTime.Parse(endDate);
                    using (var reader = cmd.ExecuteReader())
                    {
                        return readInResults(reader);
                    }
                }
            }
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
                return fetchQueryResults(query, connection);
            }
        }

        private static DataTable fetchQueryResults(string query, MySqlConnection connection)
        {
            using (var cmd = new MySqlCommand(query, connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    return readInResults(reader);
                }
            }
        }

        private static DataTable readInResults(IDataReader reader)
        {
            var columns = reader.FieldCount;
            var columnsNamesAppended = false;
            var table = new DataTable();

            while (reader.Read())
            {
                appendColumnNames(reader, columnsNamesAppended, columns, table);
                columnsNamesAppended = true;

                var fields = new string[columns];
                for (var i = 0; i < columns; i++)
                {
                    var currValue = reader[i] == DBNull.Value ? null : reader.GetString(i);
                    fields[i] = currValue;
                }

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

        private static void appendColumnNames(IDataRecord record, bool columnsNamesAppended, int columns,
            DataTable dataTable)
        {
            if (columnsNamesAppended)
            {
                return;
            }

            var columnNames = new string[columns];
            for (var i = 0; i < columns; i++)
            {
                var columnName = record[i] == DBNull.Value ? null : record.GetName(i);
                columnNames[i] = columnName;
            }

            foreach (var columnName in columnNames)
            {
                var currDataColumn = new DataColumn(columnName);
                dataTable.Columns.Add(currDataColumn);
            }
        }

        #endregion
    }
}