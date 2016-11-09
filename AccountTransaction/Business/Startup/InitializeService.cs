using AccountTransaction.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AccountTransaction.Business.Startup
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
            //GetServiceSettings();

            Settings = _settings;
        }

        private static void GetDatabaseSettings()
        {
            _settings.ConnectionString = ConfigurationManager.ConnectionStrings["TestDb"].ConnectionString;
        }
    }
}