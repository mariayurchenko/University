using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myProject.Data.interfaces;
using myProject.Data.Models;
using myProject.DAL;

namespace myProject.Data.Repository
{
    public class StudentRepository : IStudent
    {
        private readonly UnitOfWork unitOfWork;

        public StudentRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Student> GetStudents() => unitOfWork.StudentRepository.Get();
        public void CreateStudent(Student student)
        {
            unitOfWork.StudentRepository.Insert(student);
            unitOfWork.Save();
        }

        public void DeleteStudent(int id)
        {
            unitOfWork.StudentRepository.Delete(id);
            unitOfWork.Save();
        }

        public void EditStudent(Student student)
        {
            unitOfWork.StudentRepository.Update(student);
            unitOfWork.Save();
        }
    }
}
