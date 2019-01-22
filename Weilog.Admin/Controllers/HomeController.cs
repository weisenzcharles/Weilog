using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weilog.Entities;
using Weilog.Services;
using Weilog.Web.Framework.Controllers;

namespace Weilog.Admin.Controllers
{
    public class HomeController : BaseAdminController
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