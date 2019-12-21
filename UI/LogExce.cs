using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace WebApplication1
{
    public class LogExce : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string path = filterContext.HttpContext.Server.MapPath("~/log.txt");
            using (StreamWriter sw = File.AppendText(path)) 
            {
                sw.WriteLine("时间:" + DateTime.Now);
                sw.WriteLine("控制器:" + filterContext.RouteData.Values["Controller"]);
                sw.WriteLine("动作方法:" + filterContext.RouteData.Values["Action"]);
                sw.WriteLine("错误信息" + filterContext.Exception.Message);
                sw.WriteLine("");
                sw.Flush();
                sw.Close();
            }
            
        }
    }
}