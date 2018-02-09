using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bootstrap.Components
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString SubmitButton(this HtmlHelper htmlHelper, string buttonText, object htmlAttributes = null)
        {
            return SubmitButton(htmlHelper, buttonText, null, false, null,htmlAttributes);
        }

        public static MvcHtmlString SubmitButton(this HtmlHelper htmlHelper, string buttonText, string id, object htmlAttributes = null)
        {
            return SubmitButton(htmlHelper, buttonText, id, false,null,htmlAttributes);
                
        }
        public static MvcHtmlString SubmitButton(this HtmlHelper htmlHelper, string buttonText, string id,bool isDisabled , object htmlAttributes = null)
        {
            return SubmitButton(htmlHelper, buttonText, id,isDisabled, null,htmlAttributes);
        }
        public static MvcHtmlString SubmitButton(this HtmlHelper htmlHelper, string buttonText, string id, bool isDisabled,string btnClass ,object htmlAttributes = null)
        {
            string html = string.Empty;
            string disable = string.Empty;

            if (string.IsNullOrEmpty(id))
            {
                id = buttonText;
            }
            if (string.IsNullOrEmpty(btnClass))
            {
                btnClass = "btn-primary";
            }
            id = id.Replace(" ", "").Replace("-", "_");
            html = "<input type = 'submit' class = 'btn {3} {1}' title = '{0}' value = {0} id = '{2}' {4} />";

            if (isDisabled)
            {
                disable = " disabled";
            }
            html = string.Format(html, buttonText, disable, id, btnClass, GetHtmlAttributes(htmlAttributes));
            html = html.Replace("'", "\"");

            return new MvcHtmlString(html);
        }

        private static object GetHtmlAttributes(object htmlAttributes)
        {
            string ret = string.Empty;

            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                foreach (var item in attributes)
                {
                    ret += " " + item.Key + "=" + "'" + item.Value + "'";
                }
            }
            return ret;
        }
    }
}