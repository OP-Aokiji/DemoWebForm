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
    public partial class ucTopMenu : System.Web.UI.UserControl
    {
        public static DataTable dataCategoryL1 = null;
        public static DataTable dataCategoryL2 = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CategoryLevel1Item categoryLevel1Item = new CategoryLevel1Item();
                categoryLevel1Item.cat_L1_Id = Constants.RETRIEVE_ALL;
                categoryLevel1Item.cat_L1_Ws = Constants.WS_QUERY;

                ICategoryLevel1Proxy proxyCategoryL1 = new CategoryLevel1Proxy();
                dataCategoryL1 = new DataTable();
                dataCategoryL1 = (DataTable)proxyCategoryL1.CategoryLevel1CRUD(categoryLevel1Item);


                CategoryLevel2Item categoryLevel2Item = new CategoryLevel2Item();
                categoryLevel2Item.cat_L2_Id = Constants.RETRIEVE_ALL;
                categoryLevel2Item.cat_L2_Ws = Constants.WS_QUERY;

                CategoryLevel2Proxy proxyCategoryL2 = new CategoryLevel2Proxy();
                dataCategoryL2 = new DataTable();
                dataCategoryL2 = (DataTable)proxyCategoryL2.CategoryLevel2CRUD(categoryLevel2Item);
            }
        }

        protected void buttonSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textboxProName.Text.Trim()))
                Response.Redirect("/san-pham/tim-kiem/" + textboxProName.Text.Trim());
        }
    }
}