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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductItem productItem = new ProductItem();
                productItem.pro_Id = Constants.RETRIEVE_ALL;
                productItem.pro_Ws = Constants.WS_QUERY;

                IProductProxy proxy = new ProductProxy();
                listViewProduct.DataSource = proxy.ProductCRUD(productItem);
                listViewProduct.DataBind();
            }
        }
    }
}