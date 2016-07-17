using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WN.WebApp.cm
{
    public class WebTag
    {
        public static string OldPrice(string old_Price)
        {
            return (!string.IsNullOrEmpty(old_Price)) ? @"&nbsp;<div class=""my-price myold-price"">" + old_Price + "</div>" : "";
        }

    }
}