using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weilog.Core.Domain.Repositories;
using Weilog.Core.Domain.Uow;
using Weilog.Entities;
using Weilog.Services;
using Weilog.Web.Framework.Controllers;

namespace Weilog.Web.Areas.Admin.Controllers
{
    public class MenuController : BaseAdminController
    {
        #region Fields...

        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IMenuService _menuService;
        private readonly IRepositoryAsync<Menu> _repository;

        #endregion

        #region Constructor...

        /// <summary>
        /// 初始化 <see cref="MenuController"/> 类的新实例。
        /// </summary>
        public MenuController(IUnitOfWorkAsync unitOfWork, IMenuService menuService, IRepositoryAsync<Menu> menuRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = menuRepository;
            _menuService = menuService;
        }

        #endregion

        /// <summary>
        /// 侧边栏菜单。
        /// </summary>
        /// <returns>视图响应结果。</returns>
        public ActionResult SidebarMenu()
        {
            //_menuService.GetMenu
            return View();
        }

        // GET: Admin/Menu
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Menu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Menu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Menu/Create
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

        // GET: Admin/Menu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Menu/Edit/5
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

        // GET: Admin/Menu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Menu/Delete/5
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