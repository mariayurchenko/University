using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myProject.Data;
using myProject.Data.Models;

namespace myProject.DAL
{
    public class UnitOfWork : IDisposable
    {
        private AppDBContent context;
        private GenericRepository<Group> groupRepository;
        private GenericRepository<Course> courseRepository;
        private GenericRepository<Student> studentRepository;

        public UnitOfWork(AppDBContent context)
        {
            this.context = context;
        }

        public GenericRepository<Group> GroupRepository
        {
            get
            {

                if (this.groupRepository == null)
                {
                    this.groupRepository = new GenericRepository<Group>(context);
                }
                return groupRepository;
            }
        }

        public GenericRepository<Course> CourseRepository
        {
            get
            {

                if (this.courseRepository == null)
                {
                    this.courseRepository = new GenericRepository<Course>(context);
                }
                return courseRepository;
            }
        }
        public GenericRepository<Student> StudentRepository
        {
            get
            {

                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(context);
                }
                return studentRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
