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
    public partial class ProductByCategoryLevel1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoryLevel1Item categoryLevel1Item = new CategoryLevel1Item();
                categoryLevel1Item.cat_L1_Id = RouteData.Values["cat_L1_Id"].ToString();
                categoryLevel1Item.cat_L1_Ws = Constants.WS_RETRIEVE_PRODUCT_RETRIEVE_BY_CAT_L1;

                ICategoryLevel1Proxy proxy = new CategoryLevel1Proxy();
                listViewProduct.DataSource = proxy.CategoryLevel1CRUD(categoryLevel1Item);
                listViewProduct.DataBind();
            }
        }
    }
}