using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WN.WebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add("404", new Route("404", new PageRouteHandler("~/404.aspx")));
            RouteTable.Routes.Add("lien-he", new Route("lien-he", new PageRouteHandler("~/ContactUs.aspx")));
            RouteTable.Routes.Add("trang-chu", new Route("trang-chu", new PageRouteHandler("~/Default.aspx")));
            RouteTable.Routes.Add("danh-muc-cap-1", new Route("danh-muc/{cat_L1_Name}/{cat_L1_Id}", new PageRouteHandler("~/ProductByCategoryLevel1.aspx")));
            RouteTable.Routes.Add("danh-muc-cap-2", new Route("danh-muc/{cat_L1_Name}/{cat_L2_Name}/{cat_L2_Id}", new PageRouteHandler("~/ProductByCategoryLevel2.aspx")));
            RouteTable.Routes.Add("san-pham-chi-tiet", new Route("san-pham/{cat_L1_Name}/{cat_L2_Name}/{pro_Name}/{pro_Id}", new PageRouteHandler("~/ProductDetail.aspx")));
            RouteTable.Routes.Add("tim-kiem", new Route("san-pham/tim-kiem/{pro_Name}", new PageRouteHandler("~/ProductSearchByName.aspx")));
            RouteTable.Routes.Add("thoi-trang", new Route("thoi-trang/{pro_Gender}", new PageRouteHandler("~/ProductForManOrWoman.aspx")));
        }
    }
}