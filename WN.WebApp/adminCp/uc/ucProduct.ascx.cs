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
    public partial class ucProduct : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin-login-status"] != null)
            {
                if (Session["admin-login-status"].Equals("success"))
                {
                    if (!IsPostBack)
                        LoadProduct(Constants.RETRIEVE_ALL);
                }
                else Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
            }
            else Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
        }
        
        private void LoadProduct(string pro_Id)
        {
            try
            {
                ProductItem productItem = new ProductItem();
                productItem.pro_Id = pro_Id;
                productItem.pro_Ws = Constants.WS_QUERY;

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
                    productItem.pro_Ws = Constants.WS_DELETE;

                    IProductProxy proxy = new ProductProxy();
                    string result = (string)proxy.ProductCRUD(productItem);
                    if (result.Equals(Constants.WR_SUCCESS))
                    {
                        LoadProduct(Constants.RETRIEVE_ALL);
                        MessageBox.Show(MessageBox.DELETE_SUCCESS, this);
                    }
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
                Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucProductCU&pro_Id=" + e.CommandArgument.ToString() + "&crud=U");
            }
        }

        protected void buttonSearch_Click(object sender, EventArgs e)
        {
            ProductItem productItem = new ProductItem();
            productItem.pro_Name = textboxProName.Text.Trim();
            productItem.pro_Ws = Constants.WS_AC_SEARCH_PRODUCT;

            IProductProxy proxy = new ProductProxy();
            repeaterProduct.DataSource = proxy.ProductCRUD(productItem);
            repeaterProduct.DataBind();
        }

    }
}