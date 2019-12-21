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
    public class StudentService
    {
        /// <summary>
        /// 根据班级模糊查找
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public List<students> GetStudentsByClass(string className)
        {
            string sql = "select * from Students where ClassName like '%{0}%'";
            //sql += "inner join StudentClass on Students.ClassId=StudentsClass.ClassId";
            //sql += "where ClassName like'%{0}%'";
            sql=string.Format(sql,className);
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<students> students = new List<students>();
            while (objReader.Read())
            {
                students.Add(new students()
                {
                    StudentId=Convert.ToInt32(objReader["StudentId"]),
                    StudentName=objReader["StudentName"].ToString(),
                    Gender=objReader["Gender"].ToString(),
                    Birthday=Convert.ToDateTime(objReader["Birthday"]),
                    StudentAddress=Convert.ToString(objReader["StudentAddress"]),
                    ClassName=Convert.ToString(objReader["ClassName"])
                });
            }
            objReader.Close();
            return students;
        }
        //查看学生的详情信息
        public students GetStudentsById(string studentsId)
        {
            string sql = "select * from Students where StudentId="+ studentsId;
            //sql += "inner join StudentClass on Students.ClassId=StudentsClass.ClassId";
            //sql += "where StudentId=" + studentsId;
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            students objStudent = null;
            if (objReader.Read())
            {
                objStudent = new students()
                {
                    Age=Convert.ToInt32(objReader["Age"]),
                    Birthday=Convert.ToDateTime(objReader["Birthday"]),
                    StudentId=Convert.ToInt32(objReader["StudentId"]),
                    PhoneNumber=Convert.ToString(objReader["PhoneNumber"]),
                    //ClassId=Convert.ToInt32(objReader["ClassId"]),
                    StudentAddress=Convert.ToString(objReader["StudentAddress"]),
                    StudentName=objReader["StudentName"].ToString(),
                    Gender=objReader["Gender"].ToString()
                    //CardNo=objReader["CardNo"].ToString()
                };
            }
            objReader.Close();
            return objStudent;
        }
        public List<students> GetStudents()
        {
            string sql = "select * from Students";
            SqlDataReader objSql = SQLHelper.GetReader(sql);
            List<students> objList = new List<students>();
            while(objSql.Read())
            {
                objList.Add(new students()
                    {
                        Age = Convert.ToInt32(objSql["Age"]),
                        Birthday = Convert.ToDateTime(objSql["BirthDay"]),
                        Gender = objSql["Gender"].ToString(),
                        StudentAddress = objSql["StudentAddress"].ToString(),
                        StudentId = Convert.ToInt32(objSql["StudentId"]),
                        StudentName = objSql["StudentName"].ToString(),
                        PhoneNumber = objSql["PhoneNumber"].ToString()
                    });
            }
            objSql.Close();
            return objList;
        }
    }
}
