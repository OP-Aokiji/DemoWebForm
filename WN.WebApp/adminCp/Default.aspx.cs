using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WN.WebApp.cm;
using WN.Common;
namespace WN.WebApp.adminCp
{
    public partial class Default : System.Web.UI.Page
    {
        private void LoadUserControl(PlaceHolder placeHolder, string usercontrolName)
        {
            try
            {
                placeHolder.Controls.Add(LoadControl(String.Format(Constants.USER_CONTROL_DIR, usercontrolName)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), this);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           try
            {
                string[] arrUserControl = new string[] { 
                                                         "ucLogin",  
                                                         "ucCategoryLevel1","ucCategoryLevel1CU",
                                                         "ucCategoryLevel2","ucCategoryLevel2CU",
                                                         "ucBanner","ucBannerCU", 
                                                         "ucChangePassword",
                                                         "ucUserAcount","ucUserAcountCU",
                                                         "ucShopInfo",
                                                         "ucProduct","ucProductCU",
                                                         "ucTagSEO","ucTagSEOCU",
                                                         "ucHomePage"
                                                      };
                string usercontrolName = Request["ctr"];
                if (string.IsNullOrEmpty(usercontrolName))
                    usercontrolName = "ucLogin";
                if (arrUserControl.Contains(usercontrolName))
                    LoadUserControl(placeHolderMain, usercontrolName);
                else 
                    Response.Redirect("404.aspx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), this);
            }
           
        }
    }
}