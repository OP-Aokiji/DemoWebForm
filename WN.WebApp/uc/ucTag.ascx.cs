using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WN.WebApp.cm;
using WN.DataItem;
using WN.Common;
using WN.ServiceProxy;
using System.Data;

namespace WN.WebApp.uc
{
    public partial class ucTag : System.Web.UI.UserControl
    {
        public static DataTable dataTag = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    TagSeoItem tagSeoItem = new TagSeoItem();
                    tagSeoItem.tag_Seo_Id = Constants.RETRIEVE_ALL;
                    tagSeoItem.tag_Seo_Ws = Constants.WS_QUERY;

                    ITagSeoProxy proxy = new TagSeoProxy();
                    dataTag = new DataTable();
                    dataTag = (DataTable)proxy.TagSeoCRUD(tagSeoItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), this);
                }
            }
        }
    }
}