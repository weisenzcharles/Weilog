using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Nop.Web.Framework.UI
{
    /// <summary>
    /// 数据列表扩展类。
    /// </summary>
    public static class DataListExtensions
    {
        /// <summary>
        /// 数据列表。
        /// </summary>
        /// <typeparam name="T">数据对象类型。</typeparam>
        /// <param name="helper">支持在视图中呈现 HTML 控件。</param>
        /// <param name="items">数据对象集合。</param>
        /// <param name="columns"></param>
        /// <param name="template"></param>
        /// <returns></returns>
        public static IHtmlString DataList<T>(this HtmlHelper helper, IEnumerable<T> items, int columns,
            Func<T, HelperResult> template) 
            where T : class
        {
            if (items == null)
                return new HtmlString("");

            var builder = new StringBuilder();
            builder.Append("<table>");

            int cellIndex = 0;

            foreach (T item in items)
            {
                if (cellIndex == 0)
                    builder.Append("<tr>");

                builder.Append("<td");
                builder.Append(">");
                
                builder.Append(template(item).ToHtmlString());
                builder.Append("</td>");

                cellIndex++;

                if (cellIndex == columns)
                {
                    cellIndex = 0;
                    builder.Append("</tr>");
                }
            }

            if (cellIndex != 0)
            {
                for (; cellIndex < columns; cellIndex++)
                {
                    builder.Append("<td>&nbsp;</td>");
                }

                builder.Append("</tr>");
            }

            builder.Append("</table>");

            return new HtmlString(builder.ToString());
        }
    }
}
