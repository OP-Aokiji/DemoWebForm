using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WN.DataItem;
using WN.ServiceProxy;
using System.Collections;
using WN.Common;
using WN.WebApp.cm;

namespace WN.WebApp.adminCp.uc
{
    public partial class ucBanner : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin-login-status"] != null)
            {
                if (Session["admin-login-status"].Equals("success"))
                {
                    if (!IsPostBack)
                        LoadBanner(Constants.RETRIEVE_ALL);
                }
                else
                    Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
            }
            else
                Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
        }

        private void LoadBanner(string imgId)
        {
            try
            {
                BannerItem bannerItem = new BannerItem();
                bannerItem.img_Id = imgId;
                bannerItem.img_Crud = Constants.WS_QUERY;

                IBannerProxy proxy = new BannerProxy();
                repeaterBanner.DataSource = proxy.BannerCRUD(bannerItem);
                repeaterBanner.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), this);
            }
        }

        protected void repeaterBanner_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals(Constants.DELETE_ITEM))
            {
                try
                {
                    //string confirmValue = Request.Form["confirm_value"];
                    //if (confirmValue != null && confirmValue.Equals("Yes"))
                    //{
                        BannerItem bannerItem = new BannerItem();
                        bannerItem.img_Id = e.CommandArgument.ToString();
                        bannerItem.img_Crud = Constants.WS_DELETE;
                        
                        IBannerProxy proxy = new BannerProxy();
                        string result = (string)proxy.BannerCRUD(bannerItem);
                        if (result.Equals(Constants.WR_SUCCESS))
                        {
                            LoadBanner(Constants.RETRIEVE_ALL);
                            MessageBox.Show(MessageBox.DELETE_SUCCESS, this);
                        }
                        else
                            MessageBox.Show(MessageBox.DELETE_FAILD, this);
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), this);
                }
            }
            else if (e.CommandName.Equals(Constants.UPDATE_ITEM))
            {
                Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucBannerCU&img_Id=" + e.CommandArgument.ToString() + "&crud=U");
            }
        }
    }
}