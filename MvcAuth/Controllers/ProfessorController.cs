using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAuth.Models;

namespace MvcAuth.Controllers
{
    public class ProfessorController : Controller
    {
        // GET: Professor
        SmartModel1 Db = new SmartModel1();
        public ActionResult FileUpload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase files)
        {

            String FileExt = Path.GetExtension(files.FileName).ToUpper();

            if (FileExt == ".PDF")
            {
                Stream str = files.InputStream;
                BinaryReader Br = new BinaryReader(str);
                Byte[] FileDet = Br.ReadBytes((Int32)str.Length);

                Prof_Lecture_TBL Fd = new Prof_Lecture_TBL();
               
                Fd.Prof_Lecture_Name = files.FileName;
                Fd.Prof_Lecture = FileDet;
                Fd.Prof_ID = 1;
                Db.Prof_Lecture_TBL.Add(Fd);
                Db.SaveChanges();
                return RedirectToAction("FileUpload");
            }
            else
            {

                ViewBag.FileStatus = "Invalid file format.";
                return View();

            }
        }
        [HttpGet]
        public PartialViewResult FileDetails()
        {
            List<Prof_Lecture_TBL> DetList = Db.Prof_Lecture_TBL.ToList();

            return PartialView("FileDetails", DetList);
        }
        [HttpGet]
        public FileResult DownLoadFile(int id)
        {


            List<Prof_Lecture_TBL> ObjFiles = Db.Prof_Lecture_TBL.ToList();

            var FileById = (from FC in ObjFiles
                            where FC.Prof_Lecture_ID.Equals(id)
                            select new { FC.Prof_Lecture_Name, FC.Prof_Lecture }).ToList().FirstOrDefault();

            return File(FileById.Prof_Lecture, "application/pdf", FileById.Prof_Lecture_Name);

        }
    }
}