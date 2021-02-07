using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.interfaces;
using myProject.Data.Models;

namespace Infrastructure.Repository
{
    public class CoursesRepository : ICourses
    {
        private readonly AppDBContent appDBContent;

        public CoursesRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Course> AllCourses => appDBContent.Course;
    }
}
