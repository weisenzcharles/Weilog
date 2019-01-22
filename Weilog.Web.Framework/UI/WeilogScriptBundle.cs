using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace Weilog.Web.Framework.UI
{
    /// <summary>
    /// Weilog Script Bundle.
    /// </summary>
    public class WeilogScriptBundle : ScriptBundle
    {
        readonly JavaScriptObfuscator _jso = new JavaScriptObfuscator();

        /// <summary>
        /// 初始化 <see cref="WeilogScriptBundle"/> 类的新实例。
        /// </summary>
        /// <param name="virtrualPath"></param>
        public WeilogScriptBundle(string virtrualPath)
            : base(virtrualPath)
        {
            Transforms.Add(_jso);
        }
    }
}