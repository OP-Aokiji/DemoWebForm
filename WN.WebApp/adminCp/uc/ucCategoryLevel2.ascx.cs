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
    public partial class ucCategoryLevel2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin-login-status"] != null)
            {
                if (Session["admin-login-status"].Equals("success"))
                {
                    if (!IsPostBack)
                    {
                        LoadCategoryLevel1(Constants.RETRIEVE_ALL);
                        LoadCategoryLevel2(Constants.RETRIEVE_ALL);
                    }
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
                comboboxCategoryL1.DataSource = (DataTable)proxy.CategoryLevel1CRUD(categoryLevel1Item);
                comboboxCategoryL1.DataValueField = "CAT_L1_ID";
                comboboxCategoryL1.DataTextField = "CAT_L1_NAME";
                comboboxCategoryL1.DataBind();
                CommonUtility.AddFirstRowDropDownList(comboboxCategoryL1, "--Select--", "000");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), this);
            }
        }

        private void LoadCategoryLevel2(string cat_L2_Id)
        {
            try
            {
                CategoryLevel2Item categoryLevel2Item = new CategoryLevel2Item();
                categoryLevel2Item.cat_L2_Id = cat_L2_Id;
                categoryLevel2Item.cat_L2_Ws = Constants.WS_QUERY;

                ICategoryLevel2Proxy proxy = new CategoryLevel2Proxy();
                repeaterCategoryLevel2.DataSource = proxy.CategoryLevel2CRUD(categoryLevel2Item);
                repeaterCategoryLevel2.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), this);
            }
        }

        private void LoadCategoryLevel2ByCatL1(string cat_L1_Id)
        {
            try
            {
                CategoryLevel2Item categoryLevel2Item = new CategoryLevel2Item();
                categoryLevel2Item.cat_L1_Id = cat_L1_Id;
                categoryLevel2Item.cat_L2_Ws = Constants.WS_RETRIEVE_CATEGORY_LEVEL2_BY_CAT_L1;

                ICategoryLevel2Proxy proxy = new CategoryLevel2Proxy();
                repeaterCategoryLevel2.DataSource = proxy.CategoryLevel2CRUD(categoryLevel2Item);
                repeaterCategoryLevel2.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), this);
            }
        }


        protected void repeaterCategoryLevel2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals(Constants.DELETE_ITEM))
            {
                try
                {
                    CategoryLevel2Item categoryLevel2Item = new CategoryLevel2Item();
                    categoryLevel2Item.cat_L2_Id = e.CommandArgument.ToString();
                    categoryLevel2Item.cat_L2_Ws = Constants.WS_DELETE;

                    ICategoryLevel2Proxy proxy = new CategoryLevel2Proxy();
                    string result = (string)proxy.CategoryLevel2CRUD(categoryLevel2Item);
                    if (result.Equals(Constants.WR_SUCCESS))
                    {
                        LoadCategoryLevel2(Constants.RETRIEVE_ALL);
                        MessageBox.Show(MessageBox.DELETE_SUCCESS, this);
                    }
                    else if (result.Equals(Constants.WR_CONSTRAINT_DATA))
                        MessageBox.Show("Dữ liệu đã có ràng buộc với sản phẩm, không thể xóa danh mục này !!!", this);
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
                Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucCategoryLevel2CU&cat_L2_Id=" + e.CommandArgument.ToString() + "&crud=U");
            }
        }

        protected void comboboxCategoryL1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cat_L1_Id = string.Empty;
            if (comboboxCategoryL1.SelectedIndex < 1)
                cat_L1_Id = Constants.RETRIEVE_ALL;
            else
                cat_L1_Id = comboboxCategoryL1.SelectedValue.ToString();

            LoadCategoryLevel2ByCatL1(cat_L1_Id);
        }
    }
}