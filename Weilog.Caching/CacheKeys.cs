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

        ///// <summary>
        ///// 初始化 <see cref="CacheKeys"/> 类的新实例。
        ///// </summary>
        //public CacheKeys()
        //{

        //}

        #endregion

        #region Properties...

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
        public static readonly string ROLE_PATTERN_KEY;
        public static readonly string CATEGORY_PATTERN_KEY;
        public static readonly string POST_PATTERN_KEY;
        public static string USER_PATTERN_KEY;
        public static string LINK_PATTERN_KEY;
        public static string USERROLES_PATTERN_KEY;

        public static string MENU_PATTERN_KEY { get; set; }
        public static string ROLEMENU_PATTERN_KEY { get; set; }

        #endregion

    }
}
