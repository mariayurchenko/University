using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.WebPages;
using myProject.Data;
using myProject.Data.Models;
using myProject.Data.Repository;
using myProject.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace myProject.Controllers
{
    public class GroupController : Controller
    {
        private UnitOfWork unitOfWork;
        private GroupRepository _groupService;
        private CourseRepository _courseService;
        public GroupController(AppDBContent db)
        {
            unitOfWork = new UnitOfWork(db);
            _groupService = new GroupRepository(unitOfWork);
            _courseService = new CourseRepository(unitOfWork);
        }
        public IActionResult ListGroups(int? id)
        {
            ViewBag.Courses = _courseService.GetCourses().ToList();
            List<Group> groups = new List<Group>();
            try
            {
                groups = _groupService.GetGroups().ToList();
                if (id != null)
                {
                    groups = (from g in groups where g.COURSE_ID == id select g).ToList();
                    ViewBag.idC = id;
                }

            }
            catch (Exception e)
            {
                return View();
            }
            return View(groups);

        }
        [HttpGet]
        public IActionResult CreateGroup(int? id)
        {
            SelectList courses = new SelectList(_courseService.GetCourses(), "COURSE_ID", "NAME");
            ViewBag.COURSE_ID = courses;
            Group group = new Group();
            if (id != null)
            {
                ViewBag.idC = id;
                group.COURSE_ID = ViewBag.idC;
            }
            return View(group);
        }
        [HttpPost]
        public ActionResult CreateGroup(Group groupp, int? idC)
        {
            ViewBag.idC = idC;
            SelectList courses = new SelectList(_courseService.GetCourses(), "COURSE_ID", "NAME");
            ViewBag.COURSE_ID = courses;
            var exist = from g in _groupService.GetGroups().ToList() where g.NAME == groupp.NAME select g;

            if (string.IsNullOrEmpty(groupp.NAME))
            {
                ModelState.AddModelError(nameof(groupp.NAME), "Enter the name");
            }
            if(exist.ToList().Count>0)
            {
                ModelState.AddModelError(nameof(groupp.NAME), "This name already exists");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _groupService.CreateGroup(groupp);
                }
                catch (Exception e)
                {
                    return View(groupp);
                }
            }
            else
            {
                return View(groupp);
            }
           
            if (idC != null)
                return Redirect("/Group/ListGroups/" + idC);
            else
                return Redirect("/Group/ListGroups");
        }
        [HttpGet]
        public IActionResult EditGroup(int idG, int? idC)
        {
            ViewBag.idC = idC;
            SelectList courses = new SelectList(_courseService.GetCourses(), "COURSE_ID", "NAME");
            ViewBag.COURSE_ID = courses;
            var group = unitOfWork.GroupRepository.GetByID(idG);
            return View(group);
        }
        [HttpPost]
        public ActionResult EditGroup(Group groupp, int? idC)
        {
            ViewBag.idC = idC;
            SelectList courses = new SelectList(_courseService.GetCourses(), "COURSE_ID", "NAME");
            ViewBag.COURSE_ID = courses;
            var exist = from g in _groupService.GetGroups().ToList() where g.NAME == groupp.NAME select g;
            Group newGroup = unitOfWork.GroupRepository.GetByID(groupp.GROUP_ID);

            if (string.IsNullOrEmpty(groupp.NAME))
            {
                ModelState.AddModelError(nameof(groupp.NAME), "Enter the name");
            }
            if (exist.ToList().Count > 0 && groupp.NAME!=newGroup.NAME)
            {
                ModelState.AddModelError(nameof(groupp.NAME), "This name already exists");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    newGroup.NAME = groupp.NAME;
                    newGroup.COURSE_ID = groupp.COURSE_ID;
                    _groupService.EditGroup(newGroup);
                }
                catch (Exception e)
                {
                    return View(groupp);
                }
            }
            else return View(groupp);

            if (idC != null)
                return Redirect("/Group/ListGroups/" + idC);
            else
                return Redirect("/Group/ListGroups");
        }
        public ActionResult DeleteGroup(int idG, int? idC)
        {
            string list;
            if (idC != null)
                list = "/Group/ListGroups/" + idC;
            else
                list = "/Group/ListGroups";
            try
            {
                _groupService.DeleteGroup(idG);
                return Redirect(list);

            }
            catch (Exception e)
            {
                return RedirectToAction("DeleteError", "Home", new { message = e.Message, path = list });

            }
        }

    }
}
