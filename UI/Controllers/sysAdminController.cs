using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Models;
using BLL;
using System.Web.Security;
using System.Web;

namespace WebApplication1.Controllers
{
    [LogExce]
    public class sysAdminController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("AdminLogin");
        }
        public ActionResult AdminLogin()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("studentsList", "Stuents");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(sysAdmin objAdmin)
        {
            var adminName = new sysAdminManager().AdminLogin(objAdmin);
            if (adminName != null)
            {
                FormsAuthentication.SetAuthCookie(adminName,false);
                HttpContext.Session["adminName"] = adminName;
                return Content("<script>alert('登陆成功！');" +
                "window.location.href='" + Url.Action("studentsList","Students") + "'</script>");
            }
            return Content("<script>alert('登录失败！检查用户名和密码！');" +
                "window.location.href='"+Url.Content("Index")+"'</script>");
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            HttpContext.Session["adminName"] = null;
            return Content("<script>alert('注销账号成功，即将返回登录页！');" +
                "window.location.href='" + Url.Action("Index") + "'</script>");
        }
        public ActionResult GetCurrentUser()
        {
            sysAdmin sysAdmin = (sysAdmin)Session["CurrentAdmin"];
            return PartialView("LoginedUser",sysAdmin);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(sysAdmin objAdmin)
        {
            var aaa = new sysAdminManager().Register(objAdmin);
            if (aaa)
            {
                return Content("<script>alert('添加成功!点击确定去登陆');" +
                    "window.location.href='"+Url.Action("AdminLogin","sysAdmin")+"'</script>");
            }
            return Content("<script>alert('添加失败');</script>");
        }
    }
}