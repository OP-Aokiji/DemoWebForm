using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WN.DataItem;
using WN.Common;
using WN.ServiceProxy;
using System.Data;

namespace WN.WebApp.uc
{
    public partial class ucFooter : System.Web.UI.UserControl
    {
        public static DataTable dataResult = null;
        public static DataTable dataCategoryL1 = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShopInfoItem shopInfoItem = new ShopInfoItem();
                shopInfoItem.shop_Ws = Constants.WS_QUERY;

                IShopInfoProxy proxy = new ShopInfoProxy();
                dataResult = new DataTable();
                dataResult = (DataTable)proxy.ShopInfoCRUD(shopInfoItem);
                LoadCategoryL1();
            }
        }

        private void LoadCategoryL1()
        {
            CategoryLevel1Item categoryLevel1Item = new CategoryLevel1Item();
            categoryLevel1Item.cat_L1_Id = Constants.RETRIEVE_ALL;
            categoryLevel1Item.cat_L1_Ws = Constants.WS_QUERY;

            ICategoryLevel1Proxy proxyCategoryL1 = new CategoryLevel1Proxy();
            dataCategoryL1 = new DataTable();
            dataCategoryL1 = (DataTable)proxyCategoryL1.CategoryLevel1CRUD(categoryLevel1Item);
        }
    }
}