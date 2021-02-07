using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.interfaces;
using myProject.Data.Models;

namespace Infrastructure.Repository
{
    public class StudentsRepository : IStudents
    {
        private readonly AppDBContent appDBContent;

        public StudentsRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Student> AllStudents => appDBContent.Student;
        public Group GetGroup(int groupId) => appDBContent.Group.FirstOrDefault(p => p.GROUP_ID == groupId);

    }
}
