using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WN.DataItem;
using WN.ServiceProxy;
using WN.Common;
using System.Data;
using WN.WebApp.cm;

namespace WN.WebApp.adminCp.uc
{
    public partial class ucUserAcountCU : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin-login-status"] != null)
            {
                if (!Session["admin-login-status"].Equals("success"))
                    Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
                else
                {
                    if (Request.QueryString.AllKeys.Contains("user_Id") && Request.QueryString.AllKeys.Contains("crud"))
                    {
                        if (!string.IsNullOrEmpty(Request["user_Id"].ToString()) && !string.IsNullOrEmpty(Request["crud"].ToString()))
                        {
                            try
                            {
                                UserAcountItem userAcountItem = new UserAcountItem();
                                userAcountItem.user_Id = Request["user_Id"].ToString();
                                userAcountItem.user_Ws = Constants.WS_QUERY;

                                IUserAcountProxy proxy = new UserAcountProxy();
                                DataTable dataResult = (DataTable)proxy.UserAcountCRUD(userAcountItem);
                                if (dataResult.Rows.Count > 0)
                                {
                                    textboxFullName.Text = dataResult.Rows[0]["USER_FULLNAME"].ToString();
                                    textboxUserName.Text = dataResult.Rows[0]["USER_NAME"].ToString();
                                    //textboxUserEmail.Text = dataResult.Rows[0]["USER_EMAIL"].ToString();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString(), this);
                            }
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
                UserAcountItem userAcountItem = new UserAcountItem();
                userAcountItem.user_fullname = textboxFullName.Text;
                //userAcountItem.user_Email = textboxUserEmail.Text;

                if (!Request.QueryString.AllKeys.Contains("user_Id") || !Request.QueryString.AllKeys.Contains("crud"))
                {
                    if (textboxPassword.Text.Equals(textboxConfirmPassword.Text))
                    {
                        userAcountItem.user_Name = textboxUserName.Text;
                        userAcountItem.user_Password = Security.Encrypt(textboxPassword.Text);
                        userAcountItem.user_Ws = Constants.WS_INSERT;
                    }
                    else
                    {
                        MessageBox.Show("Hai mật khẩu phải giống nhau !!!", this);
                        return;
                    }
                }
                else
                {
                    userAcountItem.user_Id = Request["user_Id"].ToString();
                    userAcountItem.user_Ws = Constants.WS_UPDATE;
                }

                IUserAcountProxy proxy = new UserAcountProxy();
                string result = (string)proxy.UserAcountCRUD(userAcountItem);
                if (result.Equals(Constants.WR_SUCCESS))
                {
                    if (!Request.QueryString.AllKeys.Contains("user_Id") || !Request.QueryString.AllKeys.Contains("crud"))
                    {
                        userAcountItem.user_fullname = string.Empty;
                        userAcountItem.user_Name = string.Empty;
                        userAcountItem.user_Password = string.Empty;
                        //userAcountItem.user_Email = string.Empty;
                    }
                    MessageBox.Show(MessageBox.SAVE_SUCCESS, this);
                }
                else
                    MessageBox.Show(MessageBox.SAVE_FAILD, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),   this);
            }
        }
    }
}