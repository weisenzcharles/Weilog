using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weilog.Caching
{
    /// <summary>
    /// 系统缓存键值类，无法继承此类。
    /// </summary>
    public sealed class CacheKeys
    {

        #region Constructors...

        /// <summary>
        /// 初始化 <see cref="CacheKeys"/> 类的新实例。
        /// </summary>
        public CacheKeys()
        {

        }

        #endregion

        #region Properties...

        #region Menu...

        /// <summary>
        /// 用户缓存键。
        /// </summary>
        public const string USER_BY_ID_KEY = "WEILOG.USER.ID-{0}";
        /// <summary>
        /// 用户分页缓存键，{0}：分页索引，{1}：分页大小。
        /// </summary>
        public const string USER_PAGED_KEY = "WEILOG.USER.PAGED-{0}-{1}";
        /// <summary>
        /// 用户匹配缓存键。
        /// </summary>
        public const string USER_PATTERN_KEY = "WEILOG.USER.";

        #endregion

        #region Menu...

        /// <summary>
        /// 菜单缓存键。
        /// </summary>
        public const string MENU_BY_ID_KEY = "WEILOG.MENU.ID-{0}";

        /// <summary>
        /// 菜单分页缓存键，{0}：分页索引，{1}：分页大小。
        /// </summary>
        public const string MENU_PAGED_KEY = "WEILOG.MENU.PAGED-{0}-{1}";

        /// <summary>
        /// 菜单匹配缓存键。
        /// </summary>
        public const string MENU_PATTERN_KEY = "WEILOG.MENU.";

        #endregion

        #region UserRoles...

        /// <summary>
        /// 用户角色缓存键。
        /// </summary>
        public const string USERROLES_BY_ID_KEY = "WEILOG.USERROLES.ID-{0}";

        /// <summary>
        /// 用户角色分页缓存键，{0}：分页索引，{1}：分页大小。
        /// </summary>
        public const string USERROLES_PAGED_KEY = "WEILOG.USERROLES.PAGED-{0}-{1}";

        /// <summary>
        /// 用户角色匹配缓存键。
        /// </summary>
        public const string USERROLES_PATTERN_KEY = "WEILOG.USERROLES.";
        #endregion

        #region Role...

        /// <summary>
        /// 角色缓存键。
        /// </summary>
        public const string ROLE_BY_ID_KEY = "WEILOG.ROLE.ID-{0}";

        /// <summary>
        /// 角色分页缓存键，{0}：分页索引，{1}：分页大小。
        /// </summary>
        public const string ROLE_PAGED_KEY = "WEILOG.ROLE.PAGED-{0}-{1}";

        /// <summary>
        /// 角色匹配缓存键。
        /// </summary>
        public const string ROLE_PATTERN_KEY = "WEILOG.ROLE.";

        #endregion

        #region RoleMenu...

        /// <summary>
        /// 角色菜单缓存键。
        /// </summary>
        public const string ROLEMENU_BY_ID_KEY = "WEILOG.ROLEMENU.ID-{0}";

        /// <summary>
        /// 角色菜单分页缓存键，{0}：分页索引，{1}：分页大小。
        /// </summary>
        public const string ROLEMENU_PAGED_KEY = "WEILOG.ROLEMENU.PAGED-{0}-{1}";

        /// <summary>
        /// 角色菜单匹配缓存键。
        /// </summary>
        public const string ROLEMENU_PATTERN_KEY = "WEILOG.ROLEMENU.";

        #endregion

        #region Post...

        /// <summary>
        /// 文章缓存键。
        /// </summary>
        public const string POST_BY_ID_KEY = "WEILOG.POST.ID-{0}";

        /// <summary>
        /// 文章分页缓存键，{0}：分页索引，{1}：分页大小。
        /// </summary>
        public const string POST_PAGED_KEY = "WEILOG.POST.PAGED-{0}-{1}";

        /// <summary>
        /// 文章匹配缓存键。
        /// </summary>
        public const string POST_PATTERN_KEY = "WEILOG.POST.";

        #endregion

        #region Link...

        /// <summary>
        /// 链接缓存键。
        /// </summary>
        public const string LINK_BY_ID_KEY = "WEILOG.LINK.ID-{0}";

        /// <summary>
        /// 链接分页缓存键，{0}：分页索引，{1}：分页大小。
        /// </summary>
        public const string LINK_PAGED_KEY = "WEILOG.LINK.PAGED-{0}-{1}";

        /// <summary>
        /// 链接匹配缓存键。
        /// </summary>
        public const string LINK_PATTERN_KEY = "WEILOG.LINK.";

        #endregion

        #region Category...

        /// <summary>
        /// 分类缓存键。
        /// </summary>
        public const string CATEGORY_BY_ID_KEY = "WEILOG.CATEGORY.ID-{0}";

        /// <summary>
        /// 分类列表缓存键，{0}：分页索引，{1}：分页大小。
        /// </summary>
        public const string CATEGORY_PAGED_KEY = "WEILOG.CATEGORY.PAGED-{0}-{1}";

        /// <summary>
        /// 分类匹配缓存键。
        /// </summary>
        public const string CATEGORY_PATTERN_KEY = "WEILOG.CATEGORY.";

        #endregion

        /// <summary>
        /// 设置信息缓存键。
        /// </summary>
        public const string SETTINGS_KEY = "{0}.setting";

        /// <summary>
        /// 设置信息缓存规则键。
        /// </summary>
        public const string SETTINGS_PATTERN_KEY = "{0}.setting.";

        /// <summary>
        /// 导航菜单信息缓存字段。
        /// </summary>
        public const string NAVIGATION = "{0}.navigation";

        /// <summary>
        /// 文章分类信息缓存字段，{0}.缓存前缀，{1}.分类编号。
        /// </summary>
        public const string CATEGORY_INFO = "{0}.category.{1}";

        /// <summary>
        /// 文章分类信息列表缓存字段。
        /// </summary>
        public const string CATEGORY_LIST = "{0}.CATEGORY.LIST";

        /// <summary>
        /// 最新评论信息缓存字段，{0}.缓存前缀，{1}.记录数量。
        /// </summary>
        public const string LAST_COMMENT = "{0}.LAST.COMMENT.{1}";

        /// <summary>
        /// 热门标签信息缓存字段。
        /// </summary>
        public const string HOT_TAGS = "{0}.HOT.TAGS";

        /// <summary>
        /// 热门文章信息列表缓存字段，{0}.缓存前缀，{1}.记录数量。
        /// </summary>
        public const string HOT_POST = "{0}.HOT.POST.{1}";

        /// <summary>
        /// 随机文章信息列表缓存字段，{0}.缓存前缀，{1}.记录数量。
        /// </summary>
        public const string RANDOM_POST = "{0}.RANDOM.POST.{1}";

        /// <summary>
        /// 友情链接信息缓存字段。
        /// </summary>
        public const string FELLOW = "{0}.FELLOW";

        /// <summary>
        /// 独立页面信息缓存字段，{0}.缓存前缀，{1}.页面编号。
        /// </summary>
        public const string PAGE_INFO = "{0}.PAGE.INFO.{1}";

        /// <summary>
        /// 文章列表信息缓存字段，{0}.缓存前缀，{1}.页数。
        /// </summary>
        public const string INDEX_POST_LIST = "{0}.INDEX.POST.LIST.{1}";

        /// <summary>
        /// 评论列表信息缓存字段，{0}.缓存前缀，{1}.内容编号，{2}.页数。
        /// </summary>
        public const string COMMENTS_LIST = "{0}.COMMENTS.LIST.{0}.{1}";

        /// <summary>
        /// 文章页信息缓存字段，{0}.缓存前缀，{1}.文章编号。
        /// </summary>
        public const string POST_INFO = "{0}.POST.INFO.{1}";

        /// <summary>
        /// 语言缓存信息缓存字段，{0}.缓存前缀。
        /// </summary>
        public const string LANGUAGES = "{0}.LANGUAGES";

        /// <summary>
        /// Url重写缓存信息缓存字段，{0}.缓存前缀。
        /// </summary>
        public const string URLREWRITE = "{0}.URLREWRITE";

        #endregion

    }
}
