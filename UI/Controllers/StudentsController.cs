using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using System.Web.Script.Serialization;

namespace WebApplication1.Controllers
{
    [Authorize]
    [LogExce]
    public class StudentsController : Controller
    {
        // GET: 
        public ActionResult stuList()
        {
            return View();
        }
        [HttpPost]
        public ActionResult stuList(string className)
        {
            List<students> list = new StudentsManager().GetStudentsByClass(className);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var Jlist = js.Serialize(list);
            return Json(Jlist,JsonRequestBehavior.AllowGet);
        }
        public ActionResult studentsList()
        {
                List<students> students = new StudentsManager().GetStudents();
                ViewBag.mess = students;
                return View();
        }
        public ActionResult studentDetail(string ID)
        {
                string studentId = ID;
                students students = new StudentsManager().GetStudentsById(studentId);
                ViewBag.title = students;
                return View();
        } 
    }
}