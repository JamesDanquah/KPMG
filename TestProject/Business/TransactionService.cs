using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using TestProject.Business.Startup;
using TestProject.Entities;

namespace TestProject.Business
{
    public interface ITransactionService
    {
        void CsvUpload(string csv_File);
    }
    public class TransactionService : ITransactionService
    {
        private Settings settings;

        public TransactionService(Settings settings)
        {
            this.settings = settings;
        }
        public void CsvUpload(string csv_File)
        {
            try
            {
                var dataTable = new DataTable();
                dataTable.Columns.AddRange(new DataColumn[4]
                {
                new DataColumn("Account", typeof(string)), new DataColumn("Description", typeof(string)),
                new DataColumn("CurrencyCode", typeof(string)),  new DataColumn("Amount", typeof(decimal))
                });

                string csv_Data = File.ReadAllText(csv_File);
                foreach (var row in csv_Data.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        dataTable.Rows.Add();
                        int i = 0;
                        foreach (var cell in row.Split(','))
                        {
                            switch (i)
                            {
                                case 0:
                                    dataTable.Rows[dataTable.Rows.Count - 1][i] = cell;
                                    break;
                                case 1:
                                    dataTable.Rows[dataTable.Rows.Count - 1][i] = cell;
                                    break;
                                case 2:
                                    dataTable.Rows[dataTable.Rows.Count - 1][i] = IsCurrencyValid(Regex.Replace(cell,"\\\"","").Trim()) ? cell : null; 
                                    break;
                                case 3:
                                    dataTable.Rows[dataTable.Rows.Count - 1][i] = IsNumber(cell.Replace("\\", "").Trim()) ? cell : "0"; 
                                    break;
                            }
                            i++;
                        }
                    }
                }
                settings.Services.Data.TransactionRepository.CsvUpload(dataTable);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private bool IsCurrencyValid(string currencyCode)
        {
            IEnumerable<string> currencySymbols = CultureInfo.GetCultures(CultureTypes.SpecificCultures) 
                .Select(x => (new RegionInfo(x.LCID)).ISOCurrencySymbol.ToLower())
                .Distinct()
                .OrderBy(x => x.ToLower());
            if (currencySymbols.Contains(currencyCode.ToLower()))
                return true;
            else
                return false;
        }
        private bool IsNumber(string num)
        {
            decimal n;
            bool isNumeric = decimal.TryParse(num, out n);

            return isNumeric;
        }
    }
}