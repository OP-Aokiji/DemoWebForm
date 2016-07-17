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
    public partial class ProductDetail : System.Web.UI.Page
    {
        public static DataTable dataProInfo = null;
        public static DataTable dataProImg = null;
        public static DataTable dataAlsoPurchased = null;
        public static DataTable dataRelatedProduct = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductItem productItem = new ProductItem();
                productItem.pro_Id = RouteData.Values["pro_Id"].ToString();
                productItem.pro_Ws = Constants.WS_RETRIEVE_PRODUCT_DETAIL;

                IProductProxy proxy = new ProductProxy();
                DataSet dsProDetail  = (DataSet)proxy.ProductCRUD(productItem);

                dataProInfo = new DataTable();
                dataProImg = new DataTable();
                dataAlsoPurchased = new DataTable();
                dataRelatedProduct = new DataTable();

                dataProInfo = dsProDetail.Tables[0];
                dataProImg = dsProDetail.Tables[1];
                dataAlsoPurchased = dsProDetail.Tables[2];
                dataRelatedProduct = dsProDetail.Tables[3];
            }
        }
    }
}