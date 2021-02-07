using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myProject.Data.Models;

namespace myProject.Data.interfaces
{
    public interface IGroup
    {
        void CreateGroup(Group group);
        IEnumerable<Group> GetGroups();
        void EditGroup(Group group);
        void DeleteGroup(int id);
    }
}
