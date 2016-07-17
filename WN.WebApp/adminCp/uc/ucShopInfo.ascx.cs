using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WN.DataItem;
using WN.ServiceProxy;
using System.Data;
using WN.WebApp.cm;
using WN.Common;

namespace WN.WebApp.adminCp.uc
{
    public partial class ucShopInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin-login-status"] != null)
            {
                if (Session["admin-login-status"].Equals("success"))
                {
                    if (!IsPostBack) LoadShopInfo();
                }
                else
                    Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
            }
            else
                Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
        }
        private void LoadShopInfo()
        {
            try
            {
                ShopInfoItem shopInfoItem = new ShopInfoItem();
                shopInfoItem.shop_Ws = Constants.WS_QUERY;

                IShopInfoProxy proxy = new ShopInfoProxy();
                DataTable datarResult = (DataTable)proxy.ShopInfoCRUD(shopInfoItem);
                if (datarResult.Rows.Count > 0)
                {
                    textboxShopName.Text = datarResult.Rows[0]["SHOP_NAME"].ToString();
                    textboxShopAddress.Text = datarResult.Rows[0]["SHOP_ADDRESS"].ToString();
                    textboxShopPhone.Text = datarResult.Rows[0]["SHOP_PHONE"].ToString();
                    textboxShopSkype.Text = datarResult.Rows[0]["SHOP_SKYPE"].ToString();
                    textboxShopEmail.Text = datarResult.Rows[0]["SHOP_EMAIL"].ToString();
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),this);
            }
        }

        protected void buttonSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textboxEmailPass.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu để tiếp tục lưu dữ liệu !", this);
                    return;
                }
                ShopInfoItem ShopInfoItem = new ShopInfoItem();
                ShopInfoItem.shop_Name = textboxShopName.Text;
                ShopInfoItem.shop_Email = textboxShopEmail.Text;
                ShopInfoItem.shop_Email_Password = Security.Encrypt(textboxEmailPass.Text);
                ShopInfoItem.shop_Phone = textboxShopPhone.Text;
                ShopInfoItem.shop_Address = textboxShopAddress.Text;
                ShopInfoItem.shop_Skype = textboxShopSkype.Text;
                ShopInfoItem.shop_Ws = Constants.WS_UPDATE;

                IShopInfoProxy proxy = new ShopInfoProxy();
                string result = (string)proxy.ShopInfoCRUD(ShopInfoItem);
                if (result.Equals(Constants.WR_SUCCESS))
                {
                    MessageBox.Show(MessageBox.SAVE_SUCCESS, this);
                }
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