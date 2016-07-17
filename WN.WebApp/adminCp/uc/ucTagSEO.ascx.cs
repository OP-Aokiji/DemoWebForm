using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WN.Common;
using WN.DataItem;
using WN.ServiceProxy;
using WN.WebApp.cm;

namespace WN.WebApp.adminCp.uc
{
    public partial class ucTagSEO : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin-login-status"] != null)
            {
                if (Session["admin-login-status"].Equals("success"))
                {
                    if (!IsPostBack)
                        LoadTagSEO(Constants.RETRIEVE_ALL);
                }
                else Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
            }
            else Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
        }

        private void LoadTagSEO(string tag_Seo_Id)
        {
            try
            {
                TagSeoItem tagSeoItem = new TagSeoItem();
                tagSeoItem.tag_Seo_Id = tag_Seo_Id;
                tagSeoItem.tag_Seo_Ws = Constants.WS_QUERY;

                ITagSeoProxy proxy = new TagSeoProxy();
                repeaterTagSEO.DataSource = proxy.TagSeoCRUD(tagSeoItem);
                repeaterTagSEO.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),  this);
            }
        }

        protected void repeaterTagSEO_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals(Constants.DELETE_ITEM))
            {
                try
                {
                    TagSeoItem tagSeoItem = new TagSeoItem();
                    tagSeoItem.tag_Seo_Id = e.CommandArgument.ToString();
                    tagSeoItem.tag_Seo_Ws = Constants.WS_DELETE;

                    ITagSeoProxy proxy = new TagSeoProxy();
                    string result = (string)proxy.TagSeoCRUD(tagSeoItem);
                    if (result.Equals(Constants.WR_SUCCESS))
                    {
                        LoadTagSEO(Constants.RETRIEVE_ALL);
                        MessageBox.Show(MessageBox.DELETE_SUCCESS, this);
                    }
                    else
                        MessageBox.Show(MessageBox.DELETE_FAILD, this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(),  this);
                }
            }
            else if (e.CommandName.Equals(Constants.UPDATE_ITEM))
            {
                Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucTagSEOCU&tag_Seo_Id=" + e.CommandArgument.ToString() + "&crud=U");
            }
        }
    }
}