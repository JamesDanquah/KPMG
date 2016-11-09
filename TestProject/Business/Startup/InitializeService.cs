using TestProject.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TestProject.Data;

namespace TestProject.Business.Startup
{
    internal class InitializeService
    {
        internal static Settings Settings;
        private static Settings _settings;
        internal static void Initialize()
        {
            if (Settings != null)
                return;

            _settings = new Settings();

            GetDatabaseSettings();
            //GetLookupSettings();
            GetServiceSettings();

            Settings = _settings;
        }

        private static void GetDatabaseSettings()
        {
            _settings.ConnectionString = ConfigurationManager.ConnectionStrings["TestDb"].ConnectionString;
        }

        private static void GetServiceSettings()
        {
            _settings.Services = new Entities.Services();

            //data
            _settings.Services.Data = new Entities.Data();
            _settings.Services.Data.TransactionRepository = new TransactionRepository(_settings.ConnectionString);

            //business
            _settings.Services.Business = new Entities.Business();
            _settings.Services.Business.TransactionService = new TransactionService(_settings);

        }
    }
}