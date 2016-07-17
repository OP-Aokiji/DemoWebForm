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
    public partial class ucCategoryLevel2CU : System.Web.UI.UserControl
    {
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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategoryLevel1(Constants.RETRIEVE_ALL);

                if (Session["admin-login-status"] != null)
                {
                    if (!Session["admin-login-status"].Equals("success"))
                        Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
                    else
                    {
                        if (Request.QueryString.AllKeys.Contains("cat_L2_Id") && Request.QueryString.AllKeys.Contains("crud"))
                        {
                            if (!string.IsNullOrEmpty(Request["cat_L2_Id"].ToString()) && !string.IsNullOrEmpty(Request["crud"].ToString()))
                            {
                                CategoryLevel2Item categoryLevel2Item = new CategoryLevel2Item();
                                categoryLevel2Item.cat_L2_Id = Request["cat_L2_Id"].ToString();
                                categoryLevel2Item.cat_L2_Ws = Constants.WS_QUERY;

                                ICategoryLevel2Proxy proxy = new CategoryLevel2Proxy();
                                DataTable dataResult = new DataTable();
                                dataResult = (DataTable)proxy.CategoryLevel2CRUD(categoryLevel2Item);
                                comboboxCategoryL1.Items.FindByValue(dataResult.Rows[0]["CAT_L1_ID"].ToString()).Selected = true;
                                textboxCatL2Name.Text = dataResult.Rows[0]["CAT_L2_NAME"].ToString();
                                textboxCatL2Description.Text = dataResult.Rows[0]["CAT_L2_DESCRIPTION"].ToString();
                            }
                        }
                    }
                }
                else Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");

            }
        }

        protected void buttonSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboboxCategoryL1.SelectedIndex < 1)
                {
                    MessageBox.Show("Vui lòng chọn danh mục cấp 1 !!!", this);
                    return;
                }
                CategoryLevel2Item categoryLevel2Item = new CategoryLevel2Item();
                categoryLevel2Item.cat_L1_Id = comboboxCategoryL1.SelectedValue.ToString();
                categoryLevel2Item.cat_L2_Name = textboxCatL2Name.Text;
                categoryLevel2Item.cat_L2_Description = textboxCatL2Description.Text;

                if (!Request.QueryString.AllKeys.Contains("cat_L2_Id") || !Request.QueryString.AllKeys.Contains("crud"))
                    categoryLevel2Item.cat_L2_Ws = Constants.WS_INSERT;
                else //Update Case
                {
                    categoryLevel2Item.cat_L2_Id = Request["cat_L2_Id"].ToString();
                    categoryLevel2Item.cat_L2_Ws = Constants.WS_UPDATE;
                }

                ICategoryLevel2Proxy proxy = new CategoryLevel2Proxy();
                string result = (string)proxy.CategoryLevel2CRUD(categoryLevel2Item);
                if (result.Equals(Constants.WR_SUCCESS))
                {
                    if (!Request.QueryString.AllKeys.Contains("cat_L2_Id") || !Request.QueryString.AllKeys.Contains("crud"))
                    {
                        textboxCatL2Name.Text = string.Empty;
                        textboxCatL2Description.Text = string.Empty;
                    }
                    MessageBox.Show(MessageBox.SAVE_SUCCESS, this);
                }
                else if (result.Equals(Constants.WR_EXIST_DATA))
                    MessageBox.Show("Tên danh mục cấp 2 đã tồn tại, vui lòng nhập tên khác !!!", this);
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