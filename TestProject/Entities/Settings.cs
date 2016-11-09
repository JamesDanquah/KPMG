using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject.Business;
using TestProject.Data;

namespace TestProject.Entities
{
    public class Settings
    {
        public Services Services { get; set; }
        public Data Data { get; set; }
        public string ConnectionString { get; set; }
    }

    public class Services
    {
        public Business Business { get; set; }
        public Data Data { get; set; }
    }

    public class Business
    {
        public ITransactionService TransactionService { get; set; }
    }

    public class Data
    {
        public ITransactionRepository TransactionRepository { get; set; }
    }
}