using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myProject.Data.interfaces;
using myProject.Data.Models;
using myProject.DAL;

namespace myProject.Data.Repository
{
    public class CourseRepository : ICourse
    {
        private readonly UnitOfWork unitOfWork;

        public CourseRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Course> GetCourses() => unitOfWork.CourseRepository.Get();
        public void CreateCourse(Course course)
        {
            unitOfWork.CourseRepository.Insert(course);
            unitOfWork.Save();
        }

        public void DeleteCourse(int id)
        {
            var sum = from s in unitOfWork.GroupRepository.Get().ToList() where s.COURSE_ID == id select s;

            if (!sum.Any())
                unitOfWork.CourseRepository.Delete(id);
            else
            {
                throw new ArgumentException("It is impossible to delete a course if it contains groups");
            }
            unitOfWork.Save();
        }

        public void EditCourse(Course course)
        {
            unitOfWork.CourseRepository.Update(course);
            unitOfWork.Save();
        }
    }
}
