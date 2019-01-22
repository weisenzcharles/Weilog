using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Weilog.Entities;

namespace Weilog.Web.Framework.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    //[NopHttpsRequirement(SslRequirement.Yes)]
    //[AdminValidateIpAddress]
    [AdminAuthorize]
    //[AdminAntiForgery]
    //[AdminVendorValidation]
    public abstract partial class BaseAdminController : Controller
    {
        #region Fields...

        //private readonly IUnitOfWorkAsync _unitOfWork;
        //private readonly IUserService _userService;
        //private readonly IRepositoryAsync<User> _repository;

        #endregion

        #region Constructor...

        ///// <summary>
        ///// 初始化 <see cref="AdminController"/> 类的新实例。
        ///// </summary>
        //public AdminController(IUnitOfWorkAsync unitOfWork, IUserService userService, IRepositoryAsync<User> userRepository)
        //{
        //    _unitOfWork = unitOfWork;
        //    _repository = userRepository;
        //    _userService = userService;
        //}

        #endregion

        /// <summary>
        /// 当前登录用户。
        /// </summary>
        protected User CurrentUser { get; private set; }

        /// <summary>
        /// 是否登录。
        /// </summary>
        protected bool Logined { get; set; }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            //用户信息处理
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity as FormsIdentity;
                CurrentUser = new User
                {
                    Id = Convert.ToInt32(user.Ticket.UserData),
                    Username = User.Identity.Name
                };
            }

            Logined = CurrentUser != null && CurrentUser.Id > 0;

            //ViewRecord(requestContext);
        }

        /// <summary>
        /// 获取用户菜单。
        /// </summary>
        /// <param name="parentId"></param>
        protected virtual void GetUserMenus(int parentId)
        {
            //获取我的角色
            var userId = CurrentUser.Id;
            //var menus = UserService.GetMenus(userId);

            //ViewBag.MyButtons = myMenus.Where(item => item.ParentId == parentId && item.Type == MenuType.按钮)
            //    .OrderBy(item => item.Order)
            //.ToList();
        }
    }
}
