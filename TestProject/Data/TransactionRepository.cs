using System.Data;
using System.Data.SqlClient;

namespace TestProject.Data
{
    public interface ITransactionRepository
    {
        void CsvUpload(DataTable dataTable);
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
                        sqlBulkCopy.DestinationTableName = "dbo.tblTransaction";
                        conn.Open();
                        sqlBulkCopy.WriteToServer(dataTable);
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
    }
}