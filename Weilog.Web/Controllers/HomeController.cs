using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weilog.Core.Domain.Repositories;
using Weilog.Entities;
using Weilog.Services;

namespace Weilog.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserService _userService;

        //public HomeController()
        //{

        //}

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            IList<User> users = new List<User>();
            users = _userService.GetUserList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}