using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weilog.Core.Domain.Repositories;
using Weilog.Core.Domain.Uow;
using Weilog.Entities;
using Weilog.Services;

namespace Weilog.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IUserService _userService;
        private readonly IRepositoryAsync<User> _repository;
        public UserController(IUnitOfWorkAsync unitOfWork, IUserService userService, IRepositoryAsync<User> userRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = userRepository;
            _userService = userService;
        }


        // GET: User
        public ActionResult Index()
        {
            IList<User> users = new List<User>();
            users = _userService.GetUsers();
            List<User> users2 = new List<User>();
            users2 = _repository.Queryable(false).ToList();
            ViewData["users"] = users;
            ViewData["users2"] = users2;
            return View();
        }

        /// <summary>
        /// 使用 UnitOfWork 的添加数据。
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            User user = new User();
            user.Name = "user" + DateTime.Now.Millisecond;
            user.Password = "password" + DateTime.Now.Millisecond;
            _userService.Add(user);
            _unitOfWork.SaveChanges();
            return View();
        }

        /// <summary>
        /// 使用 UnitOfWork 的更新数据。
        /// </summary>
        /// <returns></returns>
        public ActionResult Update()
        {
            User user = new User();
            user.Id = 1;
            user.Name = "user" + DateTime.Now.Millisecond;
            user.Password = "password" + DateTime.Now.Millisecond;
            var userRepository = _unitOfWork.RepositoryAsync<User>();
            userRepository.Update(user);
            _unitOfWork.SaveChanges();
            return View();
        }

    }
}