using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WN.DataItem;
using WN.ServiceProxy;
using System.Data;
using WN.Common;

namespace WN.WebApp.uc
{
    public partial class ucImageSlider : System.Web.UI.UserControl
    {
        public static DataTable dataBanner = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BannerItem bannerItem = new BannerItem();
                bannerItem.img_Id = Constants.RETRIEVE_ALL;
                bannerItem.img_Crud = Constants.WS_QUERY;

                IBannerProxy proxy = new BannerProxy();
                dataBanner = (DataTable)proxy.BannerCRUD(bannerItem);
            }
        }
    }
}