using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myProject.Data.Models;

namespace myProject.Data.interfaces
{
    public interface ICourse
    {
        void CreateCourse(Course course);
        IEnumerable<Course> GetCourses();
        void EditCourse(Course course);
        void DeleteCourse(int id);
    }
}
