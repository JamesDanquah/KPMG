using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject.Entities;

namespace TestProject.Models.Transaction
{
    public class TransactionViewModel:BaseModel
    {
        public List<Transact> Transactions { get; set; }
    }
}