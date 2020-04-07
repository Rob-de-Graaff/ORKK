using System;
using System.Web.Mvc;

namespace OverdeRheinKraanKeuringen.ExtensionMethods
{
    public static class HtmlExtension
    {
        public static MvcHtmlString Image(this HtmlHelper html, byte[] image)
        {
            var img = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(image));
            return new MvcHtmlString("<img src='" + img + "' />");
        }
    }
}