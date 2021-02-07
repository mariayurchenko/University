using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.WebPages;
using myProject.Data;
using myProject.Data.Models;
using myProject.DAL;
using Microsoft.AspNetCore.Mvc;

namespace myProject.Controllers
{
    public class HomeController: Controller
    {
        private UnitOfWork unitOfWork;
        public HomeController(AppDBContent db)
        { 
            unitOfWork = new UnitOfWork(db);
        }
        public ViewResult Index()
        {
            var courses = unitOfWork.CourseRepository.Get();
            return View(courses.ToList());
        }
        public ActionResult DeleteError(string message, string path)
        {
            ViewBag.Message = message;
            ViewBag.Path = path;
            return View();
        }
    }
}
