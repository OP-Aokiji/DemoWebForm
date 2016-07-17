using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WN.DataItem;
using WN.ServiceProxy;
using System.Data;
using WN.Common;
using WN.WebApp.cm;

namespace WN.WebApp.adminCp.uc
{
    public partial class ucChangePassword : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin-login-status"] != null)
            {
                if (!Session["admin-login-status"].Equals("success"))
                    Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
            }
            else Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
        }

        protected void buttonChangePassword_Click(object sender, EventArgs e)
        {
            if (textboxNewPassword.Text.Equals(textboxConfirmPassword.Text))
            {
                UserAcountItem userAcountItem = new UserAcountItem();
                userAcountItem.user_Name = textboxUsername.Text;
                userAcountItem.user_Password = Security.Encrypt(textboxOldPassword.Text);

                IUserAcountProxy proxy = new UserAcountProxy();
                DataTable dataResult = (DataTable)(proxy.UserAcountChangePassword(userAcountItem, Security.Encrypt(textboxNewPassword.Text)));

                if (dataResult == null || dataResult.Rows.Count <= 0)
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác !!!", this);
                }
                else if (dataResult.Rows[0]["ERR_CODE"].ToString().Equals(Constants.WR_SUCCESS))
                    MessageBox.Show("Mật khẩu đã được thay đổi !!!", this);
                else MessageBox.Show("Lỗi xẩy ra trong quá trình đổi mật khẩu !!!", this);
            }
            else MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không giống nhau !!!",this);
        }
    }
}