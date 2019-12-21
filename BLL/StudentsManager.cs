using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public class StudentsManager
    {
        public List<students> GetStudentsByClass(string ClassName)
        {
            return new StudentService().GetStudentsByClass(ClassName);
        }
        public students GetStudentsById(string studentId)
        {
            return new StudentService().GetStudentsById(studentId);
        }
        public List<students> GetStudents()
        {
            return new StudentService().GetStudents();
        }
    }
}
