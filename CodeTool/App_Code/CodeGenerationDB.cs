using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Text;


namespace CodeTool.DataAccess
{
    public class CodeGenerationDB
    {
        private string _connectionString;
        //************************BEGIN**************************
        //Properties ConnectionString
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
        //************************BEGIN**************************
        //Get Table Name from DataBases SQL Server
        public static string GetInitialCatalog(string connectionString)
        {
            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString);          
            string initialCatalog = builder.InitialCatalog;
            return initialCatalog;
        }
        public static DataTable GetTableNames(string connectionString)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string sql = "select name from sys.tables order by name";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, cn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        //************************BEGIN**************************
        //Get Table Column Name from Table by Table Name SQL Server
        public DataTable GetTableItems(string tableName)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                string sql = "select COLUMN_NAME, DATA_TYPE,CHARACTER_MAXIMUM_LENGTH from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '" + tableName + "' ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, cn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }        
    }
}