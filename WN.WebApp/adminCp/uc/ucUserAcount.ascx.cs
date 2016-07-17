using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WN.DataItem;
using WN.ServiceProxy;
using WN.Common;
using WN.WebApp.cm;

namespace WN.WebApp.adminCp.uc
{
    public partial class ucUserAcount : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin-login-status"] != null)
            {
                if (Session["admin-login-status"].Equals("success"))
                {
                    if (!IsPostBack)
                        LoadUserAcount(Constants.RETRIEVE_ALL);
                }
                else Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
            }
            else Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
        }

        private void LoadUserAcount(string user_Id)
        {
            try
            {
                UserAcountItem userAcountItem = new UserAcountItem();
                userAcountItem.user_Id = user_Id;
                userAcountItem.user_Ws = Constants.WS_QUERY;

                IUserAcountProxy proxy = new UserAcountProxy();
                repeaterUserAcount.DataSource = proxy.UserAcountCRUD(userAcountItem);
                repeaterUserAcount.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),this);
            }
        }

        protected void repeaterUserAcount_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals(Constants.DELETE_ITEM))
            {
                try
                {
                    UserAcountItem userAcountItem = new UserAcountItem();
                    userAcountItem.user_Id = e.CommandArgument.ToString();
                    userAcountItem.user_Ws = Constants.WS_DELETE;

                    IUserAcountProxy proxy = new UserAcountProxy();
                    string result = (string)proxy.UserAcountCRUD(userAcountItem);
                    if (result.Equals(Constants.WR_SUCCESS))
                    {
                        LoadUserAcount(Constants.RETRIEVE_ALL);
                        MessageBox.Show(MessageBox.DELETE_SUCCESS, this);
                    }
                    else
                        MessageBox.Show(MessageBox.DELETE_FAILD, this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(),this);
                }
            }
            else if (e.CommandName.Equals(Constants.UPDATE_ITEM))
            {
                Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucUserAcountCU&user_Id=" + e.CommandArgument.ToString() + "&crud=U");
            }
        }
    }
}