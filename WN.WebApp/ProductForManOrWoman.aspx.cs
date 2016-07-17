using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WN.DataItem;
using WN.ServiceProxy;
using WN.Common;

namespace WN.WebApp
{
    public partial class ProductForManOrWoman : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ProductItem productItem = new ProductItem();
                productItem.pro_Gender = RouteData.Values["pro_Gender"].ToString().ToUpper();
                productItem.pro_Ws = Constants.WS_RETRIEVE_PRODUCT_BY_GENDER;

                IProductProxy proxy = new ProductProxy();
                listViewProduct.DataSource = proxy.ProductCRUD(productItem);
                listViewProduct.DataBind();
            }
        }
    }
}