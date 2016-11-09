using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TestProject.Entities;

namespace TestProject.Data
{
    public interface ITransactionRepository
    {
        void CsvUpload(DataTable dataTable);
        List<Transact> TransactionGetAll();
        Transact TransactionGetById(string id);
        void UpdateTransactions(Transact transaction);
        void TransactionDelete(string id);
    }
    public class TransactionRepository : ITransactionRepository
    {
        private readonly string connectionString;
        public TransactionRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void CsvUpload(DataTable dataTable)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var sqlBulkCopy = new SqlBulkCopy(conn))
                    {
                        sqlBulkCopy.DestinationTableName = "dbo.tblTransaction";//get the database table name
                        conn.Open();
                        sqlBulkCopy.WriteToServer(dataTable);// bulk insert the csv data into the table tblTranaction
                        conn.Close();
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            //return returnObject;
        }

        public List<Transact> TransactionGetAll()
        {
            var returnObject = new List<Transact>();
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("TransactionGetAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            returnObject.Add(new Transact
                            {
                                Account = (reader["Account"] != DBNull.Value) ? (string)reader["Account"] : "",
                                Description = (reader["Description"] != DBNull.Value) ? (string)reader["Description"] : "",
                                CurrencyCode = (reader["CurrencyCode"] != DBNull.Value) ? (string)reader["CurrencyCode"] : "",
                                Amount = (reader["Amount"] != DBNull.Value) ? (decimal)reader["Amount"] : 0m
                            });
                        }
                    }
                    reader.Close();
                }
            }
            return returnObject;
        }

        public Transact TransactionGetById(string id)
        {
            var transaction = new Transact();
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("dbo.TransactionGetById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = id;
                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            transaction = new Transact
                            {
                                Account = (string)reader["Account"],
                                Description = (reader["Description"] != DBNull.Value) ? (string)reader["Description"] : "",
                                CurrencyCode = (reader["CurrencyCode"] != DBNull.Value) ? (string)reader["CurrencyCode"] : "",
                                Amount = (reader["Amount"] != DBNull.Value) ? (decimal)reader["Amount"] : 0m,
                            };
                        }
                    }
                    reader.Close();
                }
            }
            return transaction;
        }

        public void UpdateTransactions(Transact transaction)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("TransactionUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar, -1).Value = transaction.Account;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar, -1).Value = transaction.Description ?? null ?? "";
                    cmd.Parameters.Add("@CurrencyCode", SqlDbType.NVarChar, 5).Value = transaction.CurrencyCode ?? null ?? "";
                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = transaction.Amount;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void TransactionDelete(string id)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (conn == null || conn.State == System.Data.ConnectionState.Closed || conn.State == System.Data.ConnectionState.Broken) conn.Open();
                    SqlCommand cmd = new SqlCommand("TransactionDelete", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", System.Data.SqlDbType.NVarChar).Value = id;

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                    conn.Close();
                }
            }
        }
    }
}