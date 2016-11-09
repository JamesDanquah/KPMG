using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using TestProject.Business.Startup;
using TestProject.Models.Transaction;

namespace TestProject.Controllers
{
    public class TransactionController : BaseController
    {
        // GET: Transaction
        public ActionResult Index()
        {
            var model = new TransactionViewModel();
            return View(model);
        }

        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            //do nothing and return to page if no file submitted
            if (file == null)
            {
                return RedirectToAction("Index", "Transaction");
            }

            string fileName = Path.GetFileName(file.FileName);
            string dirPath = Server.MapPath(@"~/UploadFiles");
            string fullPath = Path.Combine(dirPath, fileName);

            bool grant = GrantFullAccess(dirPath);
            //save file
            file.SaveAs(fullPath);

            InitializeService.Settings.Services.Business.TransactionService.CsvUpload(fullPath);

            return RedirectToAction("TransactionLog", "Transaction");
        }

        public ActionResult TransactionLog()
        {
            var model = new TransactionViewModel
            {
                Transactions = InitializeService.Settings.Services.Business.TransactionService.TransactionGetAll()
            };
            return View(model);
        }

        public ActionResult TransactionDetail(string id)
        {
            var model = new TransactionDetailViewModel();
            if (id != "-1")
            {
                var transaction = InitializeService.Settings.Services.Business.TransactionService.TransactionGetById(id);
                model.Account = transaction.Account;
                model.Description = transaction.Description;
                model.CurrencyCode = transaction.CurrencyCode;
                model.Amount = transaction.Amount;
            }

            return View("~/Views/Transaction/TransactionDetail.cshtml", model);
        }

        public ActionResult TransactionDetailUpdate(TransactionDetailViewModel detail, string delete, string account)
        {

            if (!string.IsNullOrEmpty(delete))
            {
                if (ModelState.IsValid)
                {
                    InitializeService.Settings.Services.Business.TransactionService.TransactionDelete(account);
                    return RedirectToAction("TransactionLog");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    InitializeService.Settings.Services.Business.TransactionService.UpdateTransaction(new Entities.Transact
                    {
                        Account = detail.Account,
                        Description = detail.Description,
                        CurrencyCode = detail.CurrencyCode,
                        Amount = detail.Amount
                    });
                    return RedirectToAction("TransactionLog");
                }
            }          

            return RedirectToAction("TransactionLog");
        }

        private bool GrantFullAccess(string path)
        {
            DirectoryInfo dInfo = new DirectoryInfo(path);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
            return true;
        }
    }
}