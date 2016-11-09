using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Entities
{
    public class Transact
    {
        public string Account { get; set; }
        public string Description { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }
    }
}