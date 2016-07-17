using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WN.DataItem;
using WN.Common;
using WN.ServiceProxy;

namespace WN.WebApp
{
    public partial class ProductByCategoryLevel2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductItem productItem = new ProductItem();
                productItem.cat_L2_Id = RouteData.Values["cat_L2_Id"].ToString();
                productItem.pro_Ws = Constants.WS_RETRIEVE_PRODUCT_RETRIEVE_BY_CAT_L2;

                IProductProxy proxy = new ProductProxy();
                listViewProduct.DataSource = proxy.ProductCRUD(productItem);
                listViewProduct.DataBind();
            }
        }
    }
}