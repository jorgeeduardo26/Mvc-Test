using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Bootstrap.Components
{
    public static class HtmlExtensions
    {
        #region Button
        public static MvcHtmlString SubmitButton(this HtmlHelper htmlHelper, string buttonText, object htmlAttributes = null)
        {
            return SubmitButton(htmlHelper, buttonText, null, false, null, htmlAttributes);
        }

        public static MvcHtmlString SubmitButton(this HtmlHelper htmlHelper, string buttonText, string id, object htmlAttributes = null)
        {
            return SubmitButton(htmlHelper, buttonText, id, false, null, htmlAttributes);

        }
        public static MvcHtmlString SubmitButton(this HtmlHelper htmlHelper, string buttonText, string id, bool isDisabled, object htmlAttributes = null)
        {
            return SubmitButton(htmlHelper, buttonText, id, isDisabled, null, htmlAttributes);
        }
        public static MvcHtmlString SubmitButton(this HtmlHelper htmlHelper, string buttonText, string id, bool isDisabled, string btnClass, object htmlAttributes = null)
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

        #endregion

        #region Checkbox
        public static MvcHtmlString CheckBoxBootstrapFor<TModel, TValue>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            string id,
            string text,
            bool isChecked,
            bool isAutoFocus,
            bool useInline = false,
            object htmlAttributes = null
            )
        {
            StringBuilder sb = new StringBuilder(512);
            string htmlChecked = string.Empty;
            string htmlAutoFocus = string.Empty;
            if (isChecked)
            {
                htmlChecked = "checked = 'checked'";
            }
            if (isAutoFocus)
            {
                htmlAutoFocus = "autofocus = 'autofocus'";
            }
            if (useInline)
            {
                sb.Append("<label class ='checkbox-inline'> ");
            }
            else
            {
                sb.Append("<div class='checkbox'> ");
                sb.Append("  <label> ");
            }
            sb.AppendFormat("     <input id = '{0}' name = '{1}' type = 'checkbox' value = 'true' {1} {2} /><input name = '{0}' type = 'hidden' value = 'false' {3} /> ",
               id, htmlChecked, htmlAutoFocus, GetHtmlAttributes(htmlAttributes));
            sb.AppendFormat("     {0}", text);
            if (useInline)
            {
                sb.Append("</label> ");
            }
            else
            {
                sb.Append("   </label> ");
                sb.Append("</div> ");

            }
            return MvcHtmlString.Create(sb.ToString());
        }

        #endregion

    }
}