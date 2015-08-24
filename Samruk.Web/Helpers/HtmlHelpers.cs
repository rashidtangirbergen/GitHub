using System;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using DevExpress.Web.Internal;
using DevExpress.Web.Mvc.UI;

namespace Samruk.Web.Helpers {
    public static class HtmlHelpers {
        public static MvcHtmlString GetScriptsEx(this ExtensionsFactory factory, params Script[] scriptItems) {
            try {
                return factory.GetScripts(scriptItems);
            }
            finally {
                MvcUtils.RenderScriptsCalled = false;
            }
        }

        public static IHtmlString RenderScripts(this HtmlHelper htmlHelper) {
            foreach (var key in htmlHelper.ViewContext.HttpContext.Items.Keys) {
                if (key.ToString().StartsWith("_script_")) {
                    var template = htmlHelper.ViewContext.HttpContext.Items[key] as Func<object, HelperResult>;
                    if (template != null) {
                        htmlHelper.ViewContext.Writer.Write(template(null));
                    }
                }
            }
            return MvcHtmlString.Empty;
        }
        public static MvcHtmlString Script(this HtmlHelper htmlHelper, Func<object, HelperResult> template) {
            if (htmlHelper.ViewContext.RequestContext.HttpContext.Request.IsAjaxRequest()) {
                if (template != null) {
                    htmlHelper.ViewContext.Writer.Write(template(null));
                }
            }
            else {
                htmlHelper.ViewContext.HttpContext.Items["_script_" + Guid.NewGuid()] = template;
            }
            return MvcHtmlString.Empty;
        }

     
    }
}