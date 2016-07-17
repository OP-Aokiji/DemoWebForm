using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WN.Common;
using WN.DataItem;
using WN.ServiceProxy;
using WN.WebApp.cm;

namespace WN.WebApp.adminCp.uc
{
    public partial class ucLogin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["admin-login-status"] = "error";
        }

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UserAcountItem userAcountItem = new UserAcountItem();
                userAcountItem.user_Name = textboxUsername.Text;
                userAcountItem.user_Password = Security.Encrypt(textboxPassword.Text);
                userAcountItem.user_Ws = Constants.WS_LOGIN;

                IUserAcountProxy proxy = new UserAcountProxy();
                DataTable dataResult = (DataTable)(proxy.UserAcountCRUD(userAcountItem));

                if (dataResult != null && dataResult.Rows.Count > 0 && dataResult.Rows[0]["ERR_CODE"].ToString().Equals(Constants.WR_SUCCESS))
                {
                    Session["admin-login-status"] = "success";
                    Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucBanner");
                }
                else
                {
                    Session["admin-login-status"] = "error";
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác  !!!", this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), this);
            }


        }
    }
}