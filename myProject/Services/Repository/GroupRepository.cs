using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myProject.Data.interfaces;
using myProject.Data.Models;
using myProject.DAL;

namespace myProject.Data.Repository
{
    public class GroupRepository: IGroup
    {
        private readonly UnitOfWork unitOfWork;

        public GroupRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Group> GetGroups() => unitOfWork.GroupRepository.Get();
        public void CreateGroup(Group group)
        {
            unitOfWork.GroupRepository.Insert(@group);
            unitOfWork.Save();
        }

        public void DeleteGroup(int id)
        {
            var sum = from s in unitOfWork.StudentRepository.Get().ToList() where s.GROUP_ID == id select s;

            if (!sum.Any())
                unitOfWork.GroupRepository.Delete(id);
            else
            {
                throw new ArgumentException("It is impossible to delete a group if it contains students");
            }
            unitOfWork.Save();
        }

        public void EditGroup(Group group)
        {
            unitOfWork.GroupRepository.Update(@group);
            unitOfWork.Save();
        }
    }
}
