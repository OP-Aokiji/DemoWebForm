using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WN.DataItem;
using WN.ServiceProxy;
using WN.WebApp.cm;
using WN.Common;

namespace WN.WebApp.adminCp.uc
{
    public partial class ucHomePage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin-login-status"] != null)
            {
                if (Session["admin-login-status"].Equals("success"))
                {
                    if (!IsPostBack)
                        LoadProduct("");
                }
                else Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
            }
            else Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
        }
        private void LoadProduct(string pro_Name)
        {
            try
            {
                ProductItem productItem = new ProductItem();
                productItem.pro_Ws = Constants.WS_AC_RETRIEVE_PRODUCT_HOME_PAGE;
                productItem.pro_Name = pro_Name;
                IProductProxy proxy = new ProductProxy();
                repeaterProduct.DataSource = proxy.ProductCRUD(productItem);
                repeaterProduct.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), this);
            }
        }

        protected void repeaterProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals(Constants.DELETE_ITEM))
            {
                try
                {
                    ProductItem productItem = new ProductItem();
                    productItem.pro_Id = e.CommandArgument.ToString();
                    productItem.pro_Ws = Constants.WS_REMOVE_PRODUCT_FROM_HOME_PAGE;

                    IProductProxy proxy = new ProductProxy();
                    string result = (string)proxy.ProductCRUD(productItem);
                    if (result.Equals(Constants.WR_SUCCESS))
                    {
                        LoadProduct("");
                        MessageBox.Show("Sản phẩm đã được gỡ khỏi trang chủ !!!" , this);
                    }
                    else
                        MessageBox.Show("Lỗi xẩy ra trong quá trình gỡ bỏ sản phẩm khỏi trang chủ !!!", this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), this);
                }
            }
        }
        protected void buttonSearch_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(textboxProName.Text.Trim())) return;
            ProductItem productItem = new ProductItem();
            productItem.pro_Name = textboxProName.Text.Trim();
            productItem.pro_Ws = Constants.WS_AC_RETRIEVE_PRODUCT_HOME_PAGE;

            IProductProxy proxy = new ProductProxy();
            repeaterProduct.DataSource = proxy.ProductCRUD(productItem);
            repeaterProduct.DataBind();
        }
    }
}