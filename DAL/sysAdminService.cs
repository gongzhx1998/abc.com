using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using System.Data.SqlClient;
using DAL.Helper;

namespace DAL
{
    public class sysAdminService
    {
        /// <summary>
        ///根据账号和密码登录
        /// </summary>
        /// <param name="objAdmin"></param>
        /// <returns></returns>
        public sysAdmin AdminLogin(sysAdmin objAdmin)
        {
            string sql = "select AdminName from Admins where LoginId={0} and LoginPwd='{1}'";
            sql = string.Format(sql,objAdmin.LoginId,objAdmin.LoginPwd);
            try
            {
                SqlDataReader objReader = SQLHelper.GetReader(sql);
                if (objReader.Read())
                {
                    objAdmin.AdminName = objReader["AdminName"].ToString();
                    objReader.Close();
                }
                else
                {
                    objAdmin = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("数据库连接失败"+e.Message);
            }
            return objAdmin;
        }
        public Boolean  Register(sysAdmin objAdmin)
        {
            string sql = "INSERT INTO Admins(LoginId,AdminName,LoginPwd) VALUES({0},'{1}','{2}')";
            sql=String.Format(sql,objAdmin.LoginId,objAdmin.AdminName,objAdmin.LoginPwd);
            try
            {
                var sQLins =SQLHelper.Update(sql);
                if (sQLins != null)
                {
                    return true;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            return false;
        }
    }
}
