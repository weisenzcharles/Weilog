using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace Weilog.Web.Framework.UI
{
    public class JavaScriptObfuscator : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            var p = new ECMAScriptPacker(ECMAScriptPacker.PackerEncoding.Normal, true, false);
            response.Content = p.Pack(response.Content);
        }
    }
}
