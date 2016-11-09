using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TestProject.Data;
using TestProject.Entities;
using Xunit.Extensions;

namespace TestProject.Test.Unit.Business
{
    public class CsvUploadSpec: BddSpecification
    {
        //set up the test
        protected Mock<ITransactionRepository> MockTransactionRepository = new Mock<ITransactionRepository>();
        protected string Actual;
        protected string Errors;
        protected string _DataTable;
        protected TestProject.Business.TransactionService TransactionService;
        protected override void EstablishSupportingContext()
        {
            _DataTable = "CH1 1AB"+","+"25"+","+"USD"+","+"16.00";
            Settings settings = new Settings
            {
                Services = new Entities.Services
                {                   
                    Data = new Entities.Data
                    {
                        TransactionRepository = MockTransactionRepository.Object
                    }
                }
            };
            TransactionService = new TestProject.Business.TransactionService(settings);
        }
        protected override void EstablishContext()
        {
            MockTransactionRepository.Setup(x => x.CsvUpload(It.IsAny<DataTable>()));
        }
        public override void Observe()
        {
            TransactionService.CsvUpload(_DataTable);
        }
    }
    //Test various scenarios here
    public class Test1 : CsvUploadSpec
    {
        [Observation]
        public void ShouldReturnSucessIsTrue()
        {
            Actual.ShouldNotBeNull();
        }
    }
}