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
using WN.WebApp.cm;

namespace WN.WebApp.adminCp.uc
{
    public partial class ucTagSEOCU : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin-login-status"] != null)
            {
                if (!Session["admin-login-status"].Equals("success"))
                    Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
                else
                {
                    if (Request.QueryString.AllKeys.Contains("tag_Seo_Id") && Request.QueryString.AllKeys.Contains("crud"))
                    {
                        if (!string.IsNullOrEmpty(Request["tag_Seo_Id"].ToString()) && !string.IsNullOrEmpty(Request["crud"].ToString()))
                        {
                            TagSeoItem tagSeoItem = new TagSeoItem();
                            tagSeoItem.tag_Seo_Id = Request["tag_Seo_Id"].ToString();
                            tagSeoItem.tag_Seo_Ws = Constants.WS_QUERY;

                            ITagSeoProxy proxy = new TagSeoProxy();
                            DataTable dataResult = new DataTable();
                            dataResult = (DataTable)proxy.TagSeoCRUD(tagSeoItem);
                            textboxTagName.Text = dataResult.Rows[0]["TAG_NAME"].ToString();
                            textboxTagURL.Text = dataResult.Rows[0]["TAG_URL"].ToString();
                        }
                    }
                }
            }
            else Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
        }

        protected void buttonSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                TagSeoItem tagSeoItem = new TagSeoItem();
                tagSeoItem.tag_Seo_Name = textboxTagName.Text;
                tagSeoItem.tag_Seo_Url = textboxTagURL.Text;

                if (!Request.QueryString.AllKeys.Contains("tag_Seo_Id") || !Request.QueryString.AllKeys.Contains("crud"))
                    tagSeoItem.tag_Seo_Ws = Constants.WS_INSERT;
                else //Update Case
                {
                    tagSeoItem.tag_Seo_Id = Request["tag_Seo_Id"].ToString();
                    tagSeoItem.tag_Seo_Ws = Constants.WS_UPDATE;
                }

                ITagSeoProxy proxy = new TagSeoProxy();
                string result = (string)proxy.TagSeoCRUD(tagSeoItem);
                if (result.Equals(Constants.WR_SUCCESS))
                {
                    if (!Request.QueryString.AllKeys.Contains("tag_Seo_Id") || !Request.QueryString.AllKeys.Contains("crud"))
                    {
                        textboxTagName.Text = string.Empty;
                        textboxTagURL.Text = string.Empty;
                    }
                    MessageBox.Show(MessageBox.SAVE_SUCCESS, this);
                }
                else
                    MessageBox.Show(MessageBox.SAVE_FAILD, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), this);
            }
        }
    }
}