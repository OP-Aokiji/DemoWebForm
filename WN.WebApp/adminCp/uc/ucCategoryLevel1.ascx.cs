using System;
using System.Collections.Generic;
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
    public partial class ucCategoryLevel1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin-login-status"] != null)
            {
                if (Session["admin-login-status"].Equals("success"))
                {
                    if (!IsPostBack)
                        LoadCategoryLevel1(Constants.RETRIEVE_ALL);
                }
                else Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
            }
            else Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
        }

        private void LoadCategoryLevel1(string cat_L1_Id)
        {
            try
            {
                CategoryLevel1Item categoryLevel1Item = new CategoryLevel1Item();
                categoryLevel1Item.cat_L1_Id = cat_L1_Id;
                categoryLevel1Item.cat_L1_Ws = Constants.WS_QUERY;

                ICategoryLevel1Proxy proxy = new CategoryLevel1Proxy();
                repeaterCategoryLevel1.DataSource = proxy.CategoryLevel1CRUD(categoryLevel1Item);
                repeaterCategoryLevel1.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), this);
            }
        }

        protected void repeaterCategoryLevel1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals(Constants.DELETE_ITEM))
            {
                try
                {
                    CategoryLevel1Item categoryLevel1Item = new CategoryLevel1Item();
                    categoryLevel1Item.cat_L1_Id = e.CommandArgument.ToString();
                    categoryLevel1Item.cat_L1_Ws = Constants.WS_DELETE;

                    ICategoryLevel1Proxy proxy = new CategoryLevel1Proxy();
                    string result = (string)proxy.CategoryLevel1CRUD(categoryLevel1Item);
                    if (result.Equals(Constants.WR_SUCCESS))
                    {
                        LoadCategoryLevel1(Constants.RETRIEVE_ALL);
                        MessageBox.Show(MessageBox.DELETE_SUCCESS, this);
                    }
                    else if (result.Equals(Constants.WR_CONSTRAINT_DATA))
                        MessageBox.Show("Dữ liệu đã có ràng buộc với danh mục cấp 2, không thể xóa danh mục này !!!", this);
                    else
                        MessageBox.Show(MessageBox.DELETE_FAILD, this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), this);
                }
            }
            else if (e.CommandName.Equals(Constants.UPDATE_ITEM))
            {
                Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucCategoryLevel1CU&cat_L1_Id=" + e.CommandArgument.ToString() + "&crud=U");
            }
        }
    }
}