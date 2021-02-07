using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.WebPages;
using myProject.Data;
using myProject.Data.Models;
using myProject.Data.Repository;
using myProject.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myProject.Controllers
{
    public class StudentController : Controller
    {
        private UnitOfWork unitOfWork;
        private GroupRepository _groupService;
        private StudentRepository _studentService;
        private CourseRepository _courseService;
        public StudentController(AppDBContent db)
        {
           unitOfWork = new UnitOfWork(db);
            _groupService = new GroupRepository(unitOfWork);
            _studentService = new StudentRepository(unitOfWork);
            _courseService = new CourseRepository(unitOfWork);
        }
        public IActionResult ListStudents(int? idG, int? idC)
        {
            ViewBag.Groups = _groupService.GetGroups().ToList();
            ViewBag.Courses = _courseService.GetCourses().ToList();
            List<Student> students = _studentService.GetStudents().ToList();
            if(idG!=null)
            {
                students = (from s in students where s.GROUP_ID==idG select s).ToList();
                ViewBag.idG = idG;
                ViewBag.idC = idC;
            }
            return View(students);
        }
        [HttpGet]
        public IActionResult CreateStudent(int? idG, int? idC)
        {
            ViewBag.idG = idG;
            ViewBag.idC = idC;
            SelectList groups = new SelectList(_groupService.GetGroups(), "GROUP_ID", "NAME");
            ViewBag.GROUP_ID =groups;
            Student student = new Student();
            if (idG != null)
            {
                ViewBag.idG = idG;
                student.GROUP_ID = ViewBag.idG;
            }
            return View(student);
        }
        [HttpPost]
        public ActionResult CreateStudent(Student student, int? idG, int? idC)
        {
            ViewBag.idG = idG;
            ViewBag.idC = idC;
            ViewBag.idC = idC;
            SelectList groups = new SelectList(_groupService.GetGroups(), "GROUP_ID", "NAME");
            ViewBag.GROUP_ID = groups;

            if (string.IsNullOrEmpty(student.FIRST_NAME))
            {
                ModelState.AddModelError(nameof(student.FIRST_NAME), "Enter the first name");
            }
            if (string.IsNullOrEmpty(student.LAST_NAME))
            {
                ModelState.AddModelError(nameof(student.LAST_NAME), "Enter the last name");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _studentService.CreateStudent(student);
                }
                catch
                {
                    return View(student);
                }
              
            }
            else
            {
                return View(student);
            }

            if (idG != null)
                return Redirect("/Student/ListStudents/?idG=" + idG + "&idC=" + idC);
            else
                return Redirect("/Student/ListStudents");
        }
        [HttpGet]
        public IActionResult EditStudent(int idS, int? idG, int? idC)
        {
            ViewBag.idG = idG;
            ViewBag.idC = idC;
            SelectList groups = new SelectList(_groupService.GetGroups(), "GROUP_ID", "NAME");
            ViewBag.GROUP_ID = groups;
            var student = unitOfWork.StudentRepository.GetByID(idS);
            return View(student);
        }
        [HttpPost]
        public ActionResult EditStudent(Student student, int? idG, int? idC)
        {
            ViewBag.idC = idC;
            ViewBag.idG = idG;
            SelectList groups = new SelectList(_groupService.GetGroups(), "GROUP_ID", "NAME");
            ViewBag.GROUP_ID = groups;

            if (string.IsNullOrEmpty(student.FIRST_NAME))
            {
                ModelState.AddModelError(nameof(student.FIRST_NAME), "Enter the first name");
            }
            if (string.IsNullOrEmpty(student.LAST_NAME))
            {
                ModelState.AddModelError(nameof(student.LAST_NAME), "Enter the last name");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _studentService.EditStudent(student);
                }
                catch
                {
                    return View(student);
                }
            }
            else
            {
                return View(student);
            }

            if (idG != null)
                return Redirect("/Student/ListStudents/?idG=" + idG + "&idC=" + idC);
            else
                return Redirect("/Student/ListStudents");
        }
        public ActionResult DeleteStudent(int idS, int? idG, int?idC)
        {
            try
            {
                _studentService.DeleteStudent(idS);
            }
            catch
            {

            }

            if (idG != null)
                return Redirect("/Student/ListStudents/?idG="+idG+"&idC="+idC);
            else
                return Redirect("/Student/ListStudents");
        }
    }
}   