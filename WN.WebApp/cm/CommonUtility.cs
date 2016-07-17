using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using WN.Common;
using System.Web.UI.HtmlControls;

namespace WN.WebApp.cm
{
    public static class CommonUtility
    {
        public static void AddFirstRowDropDownList(DropDownList dropDownListName, string text, string value)
        {
            dropDownListName.Items.Insert(0, new ListItem(text, value));
        }
        public static void LoadUserControl(PlaceHolder placeHolder, string userControlName, Page page)
        {
            try
            {
                placeHolder.Controls.Add(page.LoadControl(String.Format(Constants.USER_CONTROL_DIR, userControlName)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}