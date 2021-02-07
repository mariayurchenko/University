using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.interfaces;
using myProject.Data.Models;

namespace Infrastructure.Repository
{
    public class GroupsRepository: IGroups
    {
        private readonly AppDBContent appDBContent;

        public GroupsRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Group> AllGroups => appDBContent.Group;

        public Course GetCourse(int courseId) => appDBContent.Course.FirstOrDefault(p => p.COURSE_ID == courseId);
    
    }
}
