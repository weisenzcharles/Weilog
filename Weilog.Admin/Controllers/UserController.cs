using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Weilog.Core.Domain.Repositories;
using Weilog.Core.Domain.Uow;
using Weilog.Entities;
using Weilog.Services;
using Weilog.Web.Framework.Models;
using Weilog.Core.Extensions;
namespace Weilog.Web.Areas.Admin.Controllers
{
    public class UsersController : AdminController
    {
        #region Fields...

        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IUserService _userService;
        private readonly IRepositoryAsync<User> _repository;

        #endregion

        #region Constructor...

        /// <summary>
        /// 初始化 <see cref="UsersController"/> 类的新实例。
        /// </summary>
        public UsersController(IUnitOfWorkAsync unitOfWork, IUserService userService, IRepositoryAsync<User> userRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = userRepository;
            _userService = userService;
        }

        #endregion

        // GET: Admin/User/Login
        [HttpGet, AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 用户登录。
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, AllowAnonymous]
        public ActionResult Login(UserModel userModel)
        {
            bool result = false;
            try
            {
                var user = _userService.GetUser(1);
                if (user == null)
                {
                }
                //res.msg = "无效的用户";
                else
                {
                    ////记录登录日志
                    //loginLogService.Add(new LoginLogDto
                    //{
                    //    UserId = user.Id,
                    //    LoginName = user.LoginName,
                    //    IP = WebHelper.GetClientIP(),
                    //    Mac = WebHelper.GetClientMACAddress()
                    //});
                    if (user.Password != userModel.Password.ToMD5())
                    {
                    }
                    //res.msg = "登录密码错误";
                    else if (user.Deleted)
                    { }
                    //res.msg = "用户已被删除";
                    //else if (user.Status == UserStatus.未激活)
                    //    res.msg = "账号未被激活";
                    //else if (user.Status == UserStatus.禁用)
                    //    res.msg = "账号被禁用";
                    else
                    {
                        //res.flag = true;
                        //res.msg = "登录成功";
                        //res.data = user;

                        //写入注册信息
                        DateTime expiration = true
                            ? DateTime.Now.AddDays(7)
                            : DateTime.Now.Add(FormsAuthentication.Timeout);
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2,
                            user.Username,
                            DateTime.Now,
                            expiration,
                            true,
                            user.Id.ToString(),
                            FormsAuthentication.FormsCookiePath);

                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                            FormsAuthentication.Encrypt(ticket))
                        {
                            HttpOnly = true,
                            Expires = expiration
                        };

#if !DEBUG
                cookie.Domain = FormsAuthentication.CookieDomain;
#endif

                        HttpContext.Response.Cookies.Add(cookie);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex);
                result = false;
                //res.msg = ex.Message;
                //Logger.Log(ex.Message, ex);
            }

            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Error", new Exception());
            return View();
        }

        /// <summary>
        /// 忘记密码。
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        /// <summary>
        /// 更改密码。
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult ChangePassword()
        {
            return View();
        }

        /// <summary>
        /// 注册用户。
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 注销登录。
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                var cookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie != null)
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Response.Cookies.Add(cookie);
                }
            }
            return RedirectToAction("Login");
        }

        // GET: Admin/User
        public ActionResult List()
        {
            return View();
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
