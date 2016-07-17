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
using System.Net.Mail;
using WN.WebApp.cm;
using System.Net;

namespace WN.WebApp
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShopInfoItem shopInfoItem = new ShopInfoItem();
                shopInfoItem.shop_Ws = Constants.WS_QUERY;

                IShopInfoProxy proxy = new ShopInfoProxy();
                DataTable datarResult = (DataTable)proxy.ShopInfoCRUD(shopInfoItem);

                if (datarResult.Rows.Count > 0)
                {
                    labelShopName.Text = datarResult.Rows[0]["SHOP_NAME"].ToString();
                    labelShopAddress.Text = datarResult.Rows[0]["SHOP_ADDRESS"].ToString();
                    labelShopPhone.Text = datarResult.Rows[0]["SHOP_PHONE"].ToString();
                    labelShopSkype.Text = "Skype: " +  datarResult.Rows[0]["SHOP_SKYPE"].ToString();
                    labelShopEmail.Text = datarResult.Rows[0]["SHOP_EMAIL"].ToString();
                }
            }
        }
        private void SendEmail(EmailItem emailItem)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                MailMessage mailMessage = new MailMessage();
                smtpClient.Credentials = new NetworkCredential(emailItem.from_Email_Address, emailItem.from_Email_Password);
                smtpClient.Port = 587;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                mailMessage.From = new MailAddress(emailItem.from_Email_Address, emailItem.from_Display);
                mailMessage.To.Add(emailItem.to_Email_Address);
                mailMessage.Subject = emailItem.subject;
                mailMessage.Body = emailItem.body;
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                smtpClient.Send(mailMessage);
                MessageBox.Show("Tin nhắn của bạn đã được gửi đi.", this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), this);
            }

        }
        protected void buttonSendMsg_Click(object sender, EventArgs e)
        {
            try
            {
                //Get Email and Password to send Email.

                ShopInfoItem shopInfoItem = new ShopInfoItem();
                shopInfoItem.shop_Ws = Constants.WS_QUERY;
                IShopInfoProxy proxy = new ShopInfoProxy();
                DataTable dataCompanyInfo = new DataTable();
                dataCompanyInfo = (DataTable)proxy.ShopInfoCRUD(shopInfoItem);
                if (dataCompanyInfo.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dataCompanyInfo.Rows[0]["COM_EMAIL"].ToString()) && !string.IsNullOrEmpty(dataCompanyInfo.Rows[0]["COM_EMAIL_PASSWORD"].ToString()))
                    {
                        EmailItem emailItem = new EmailItem();
                        emailItem.from_Email_Address = dataCompanyInfo.Rows[0]["SHOP_EMAIL"].ToString();
                        emailItem.from_Email_Password = Security.Decrypt(dataCompanyInfo.Rows[0]["SHOP_EMAIL_PASSWORD"].ToString());
                        emailItem.from_Display = textboxContactName.Text;
                        emailItem.to_Email_Address = textboxContactEmail.Text.Trim();
                        emailItem.subject = textboxContactSubject.Text.Trim();
                        emailItem.body = textboxContactMessage.Text.Trim();
                        SendEmail(emailItem);
                        textboxContactName.Text = "";
                        textboxContactEmail.Text = "";
                        textboxContactSubject.Text = "";
                        textboxContactMessage.Text = "";
                    }
                    else
                        MessageBox.Show("Xẩy ra lỗi trong quá trình gửi tin nhắn.", this);
                }
                else MessageBox.Show("Xẩy ra lỗi trong quá trình gửi tin nhắn.", this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), this);
            }
        }

       
    }
}