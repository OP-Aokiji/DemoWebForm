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

namespace WN.WebApp
{
    public partial class ProductSearchByName : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductItem productItem = new ProductItem();
                productItem.pro_Ws = Constants.WS_SEARCH_PRODUCT;
                productItem.pro_Name = RouteData.Values["pro_Name"].ToString();
                IProductProxy proxy = new ProductProxy();
                listViewProduct.DataSource = (DataTable)proxy.ProductCRUD(productItem);
                listViewProduct.DataBind();
            }
        }
    }
}