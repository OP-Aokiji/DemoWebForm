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
    public partial class ucCategoryLevel1CU : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin-login-status"] != null)
            {
                if (!Session["admin-login-status"].Equals("success"))
                    Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
                else
                {
                    if (Request.QueryString.AllKeys.Contains("cat_L1_Id") && Request.QueryString.AllKeys.Contains("crud"))
                    {
                        if (!string.IsNullOrEmpty(Request["cat_L1_Id"].ToString()) && !string.IsNullOrEmpty(Request["crud"].ToString()))
                        {
                            CategoryLevel1Item categoryLevel1Item = new CategoryLevel1Item();
                            categoryLevel1Item.cat_L1_Id = Request["cat_L1_Id"].ToString();
                            categoryLevel1Item.cat_L1_Ws = Constants.WS_QUERY;

                            ICategoryLevel1Proxy proxy = new CategoryLevel1Proxy();
                            DataTable dataResult = new DataTable();
                            dataResult = (DataTable)proxy.CategoryLevel1CRUD(categoryLevel1Item);
                            textboxCatL1Name.Text = dataResult.Rows[0]["CAT_L1_NAME"].ToString();
                            textboxCatL1Description.Text = dataResult.Rows[0]["CAT_L1_DESCRIPTION"].ToString();
                        }
                    }
                }
            }
            else Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
        }

        protected void buttonSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                CategoryLevel1Item categoryLevel1Item = new CategoryLevel1Item();
                categoryLevel1Item.cat_L1_Name = textboxCatL1Name.Text.ToUpper();
                categoryLevel1Item.cat_L1_Description = textboxCatL1Description.Text;

                if (!Request.QueryString.AllKeys.Contains("cat_L1_Id") || !Request.QueryString.AllKeys.Contains("crud"))
                    categoryLevel1Item.cat_L1_Ws = Constants.WS_INSERT;
                else //Update Case
                {
                    categoryLevel1Item.cat_L1_Id = Request["cat_L1_Id"].ToString();
                    categoryLevel1Item.cat_L1_Ws = Constants.WS_UPDATE;
                }

                ICategoryLevel1Proxy proxy = new CategoryLevel1Proxy();
                string result = (string)proxy.CategoryLevel1CRUD(categoryLevel1Item);
                if (result.Equals(Constants.WR_SUCCESS))
                {
                    if (!Request.QueryString.AllKeys.Contains("cat_L1_Id") || !Request.QueryString.AllKeys.Contains("crud"))
                    {
                        textboxCatL1Name.Text = string.Empty;
                        textboxCatL1Description.Text = string.Empty;
                    }
                    MessageBox.Show(MessageBox.SAVE_SUCCESS, this);
                }
                else if (result.Equals(Constants.WR_EXIST_DATA))
                    MessageBox.Show("Tên danh mục cấp 1 đã tồn tại, vui lòng nhập tên khác !!!", this);
                else
                    MessageBox.Show(MessageBox.SAVE_FAILD, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), this);
            }
        }
    }
}