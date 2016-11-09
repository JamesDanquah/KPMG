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

            //update coursenotefile table here
            //client.UpdateCourseNoteFile(new CourseNoteFile
            //{
            //    FileUrl = fullPath,
            //    Name = fileName,
            //    CourseCode = fileData.CourseCode,
            //    CourseNoteWeek = fileData.CourseNoteWeek,
            //    IsEnabled = true
            //});

            return RedirectToAction("Index", "Transaction");
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