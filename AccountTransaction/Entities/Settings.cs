using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountTransaction.Entities
{
    public class Settings
    {
        public Services Services { get; set; }
        public string ConnectionString { get; set; }
    }

    public class Services
    {
        public Business Business { get; set; }
        public Data Data { get; set; }
    }

    public class Business
    {
        //public ICampusService CampusService { get; set; }
    }

    public class Data
    {
       // public ICampusRepository CampusRepository { get; set; }
    }
}