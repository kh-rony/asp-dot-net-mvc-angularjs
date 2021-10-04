using System.Collections.Generic;
using ASPDotNETMVCAngularJS.Models;

namespace ASPDotNETMVCAngularJS.DataAccessLayer.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        string AddStudent(Student student);
        string UpdateStudent(Student student);
        string DeleteStudent(int id);
    }
}