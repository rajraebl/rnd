using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxMVC.Helper
{
    public static class Class1
    {
        public static MvcHtmlString MyTextBox(this HtmlHelper helper, string name, string placeholder)
        {
            TagBuilder tb = new TagBuilder("input");
            tb.MergeAttribute("type" , "text");
            tb.MergeAttribute("placeholder", "i came from custome htmlhelper");
            return MvcHtmlString.Create(tb.ToString());
        }
    }
}