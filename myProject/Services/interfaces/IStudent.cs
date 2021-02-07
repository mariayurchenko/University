using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myProject.Data.Models;

namespace myProject.Data.interfaces
{
    public interface IStudent
    {
        void CreateStudent(Student student);
        IEnumerable<Student> GetStudents();
        void EditStudent(Student student);
        void DeleteStudent(int id);
    }
}
