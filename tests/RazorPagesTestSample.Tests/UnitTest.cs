using System;
using System.Linq;
using System.Threading.Tasks;
using myProject.Data;
using myProject.Data.Models;
using myProject.DAL;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace RazorPagesTestSample.Tests
{
    public class UnitTest
    {
        [Fact]
        public void DeleteStudent_NoStudentIsDeleted_WhenStudentIsNotFound()
        {
            using (var db = new AppDBContent(Utilities.TestDbContextOptions()))
            {
                SeedData.Initial(db);
                UnitOfWork unitOfWork = new UnitOfWork(db);
                var recId = 50;
                var expected = db.Student.AsNoTracking().ToList(); 
                try
                {
                    unitOfWork.StudentRepository.Delete(unitOfWork.StudentRepository.GetByID(recId));
                }
                catch
                {
                    // recId doesn't exist
                }
                unitOfWork.Save();
                
                var actual = unitOfWork.StudentRepository.Get().ToList();
                Assert.Equal(
                    expected.OrderBy(m => m.STUDENT_ID).Select(m => m.FIRST_NAME),
                    actual.OrderBy(m => m.STUDENT_ID).Select(m => m.FIRST_NAME));
            }
        }

        [Fact]
        public void DeleteStudent_NoStudentIsDeleted_WhenStudentIsFound()
        {
            using (var db = new AppDBContent(Utilities.TestDbContextOptions()))
            {
                SeedData.Initial(db);
                UnitOfWork unitOfWork = new UnitOfWork(db);
                db.SaveChanges();   
                var students = db.Student.AsNoTracking().ToList();
                var recId = 1;

                var expected = students.Where(student => student.STUDENT_ID != recId).ToList();

                unitOfWork.StudentRepository.Delete(unitOfWork.StudentRepository.GetByID(recId));
                unitOfWork.Save();

                var actual = unitOfWork.StudentRepository.Get().ToList();
                Assert.Equal(
                    expected.OrderBy(m => m.STUDENT_ID).Select(m => m.FIRST_NAME),
                    actual.OrderBy(m => m.STUDENT_ID).Select(m => m.FIRST_NAME));
            }
        }



    }
}
