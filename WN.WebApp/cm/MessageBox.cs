using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;

namespace WN.WebApp.cm
{
    public static class MessageBox
    {
        public const string SAVE_SUCCESS = "Lưu dữ liệu thành công !!!";
        public const string SAVE_FAILD = "Xẩy ra lỗi trong quá trình lưu dữ liệu !!!";

        public const string DELETE_SUCCESS = "Xóa dữ liệu thành công !!!";
        public const string DELETE_FAILD = "Xẩy ra lỗi trong quá trình xóa dữ liệu !!!";

        public static void Show(string msg, Control ctr)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert('");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
            sb.Append("');");
            ScriptManager.RegisterStartupScript(ctr.Page, ctr.GetType(), "SHOWALERT", sb.ToString(), true);
        }
    }
}