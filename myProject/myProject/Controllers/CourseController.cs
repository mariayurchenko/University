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

namespace myProject.Controllers
{
    public class CourseController: Controller
    {
        private UnitOfWork unitOfWork;
        private CourseRepository _courseService;
        public CourseController(AppDBContent db)
        {
            unitOfWork = new UnitOfWork(db);
            _courseService = new CourseRepository(unitOfWork);
        }
        public ViewResult ListCourses()
        {
            try
            {
                var courses = _courseService.GetCourses();
                return View(courses.ToList());
            }
            catch (Exception e)
            {
                return View();
            }

        }
        [HttpGet]
        public IActionResult CreateCourse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCourse(Course course)
        {
            var exist = from c in _courseService.GetCourses().ToList() where c.NAME == course.NAME select c;

            if (string.IsNullOrEmpty(course.NAME))
            {
                ModelState.AddModelError(nameof(course.NAME), "Enter the name");
            }
            if (string.IsNullOrEmpty(course.DESCRIPTION))
            {
                ModelState.AddModelError(nameof(course.DESCRIPTION), "Enter the description");
            }
            if (exist.ToList().Count > 0)
            {
                ModelState.AddModelError(nameof(course.NAME), "This name already exists");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _courseService.CreateCourse(course);
                    return Redirect("/Course/ListCourses");
                }
                catch (Exception e)
                {
                    return View(course);
                }
            }

            return View(course);
        }
        [HttpGet]
        public IActionResult EditCourse(int id)
        {
            Course course = unitOfWork.CourseRepository.GetByID(id);
            return View(course);
        }
        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            var exist = from c in unitOfWork.CourseRepository.Get().ToList() where c.NAME == course.NAME select c;
            Course newCourse = unitOfWork.CourseRepository.GetByID(course.COURSE_ID);

            if (string.IsNullOrEmpty(course.NAME))
            {
                ModelState.AddModelError(nameof(course.NAME), "Enter the name");
            }
            if (string.IsNullOrEmpty(course.DESCRIPTION))
            {
                ModelState.AddModelError(nameof(course.DESCRIPTION), "Enter the description");
            }
            if (exist.ToList().Count > 0 && course.NAME!=newCourse.NAME)
            {
                ModelState.AddModelError(nameof(course.NAME), "This name already exists");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    newCourse.NAME = course.NAME;
                    newCourse.DESCRIPTION = course.DESCRIPTION;

                    _courseService.EditCourse(newCourse);
                    return Redirect("/Course/ListCourses");
                }
                catch (Exception e)
                {
                    return View(course);
                }
            }

            return View(course);
        }


        public ActionResult DeleteCourse(int id)
        {
            try
            {
                _courseService.DeleteCourse(id);
                return Redirect("/Course/ListCourses");

            }
            catch (Exception e)
            {
                return RedirectToAction("DeleteError", "Home", new { message = e.Message, path = "/Course/ListCourses" });
                
            }
        }

    }
}
