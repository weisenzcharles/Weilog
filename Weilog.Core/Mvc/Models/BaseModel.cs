using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Weilog.Core.Mvc.Models
{
    /// <summary>
    /// 定义应用程序的基础对象模型。
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// 初始化 <see cref="BaseModel"/> 类的新实例。
        /// </summary>
        public BaseModel()
        {
            this.CustomProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// 绑定指定的控制器到模型对象。
        /// </summary>
        /// <param name="controllerContext">指定的控制器对象。</param>
        /// <param name="bindingContext">指定的模型绑定内容。</param>
        public virtual void BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
        }

        /// <summary>
        /// 使用这个属性来存储任何自定义值的模型。
        /// </summary>
        public Dictionary<string, object> CustomProperties { get; set; }

        ///// <summary>
        ///// 获取或设置应用程序的语言。
        ///// </summary>
        //public Dictionary<string, string> Languages { get; set; }

        ///// <summary>
        ///// 获取或设置应用程序的设置。
        ///// </summary>
        //public Dictionary<string, object> Settings { get; set; }

    }
}
