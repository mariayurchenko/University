using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myProject.Data.Models;

namespace Infrastructure.interfaces
{
    public interface ICourses
    {
        IEnumerable<Course> AllCourses { get; }
    }
}
