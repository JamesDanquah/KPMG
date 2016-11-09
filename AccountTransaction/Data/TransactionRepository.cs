using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountTransaction.Data
{
    public interface ITransactionRepository
    {
    }
    public class TransactionRepository : ITransactionRepository
    {
        private readonly string connectionString;
        public TransactionRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}