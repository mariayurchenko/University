using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myProject.Data.Models;

namespace Infrastructure.interfaces
{
    public interface IGroups
    {
        IEnumerable<Group> AllGroups { get; }
        Course GetCourse(int courseId);

    }
}
